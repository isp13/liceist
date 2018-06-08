using UnityEngine;
#if UNITY_EDITOR
using UnityEditor;
#endif
using System.Collections;

[ExecuteInEditMode]
public class PixelPerfectObject : MonoBehaviour {
	
	public PixelPerfectCamera pixelPerfectCamera;
	public PixelPerfectFitType fitType=PixelPerfectFitType.Retro;
	public int parallaxLayer=0;
	public int pixelScale=1;
	public bool runContinously=true;
	public bool useParentTransform=false;
	public bool displayGrid=false;
	
	Vector2 spriteOrigin;
	Vector2 fixedSpriteOrigin;
	Vector2 fixedSpriteCenter;
	Vector2 pixelCorrection;
	
	protected float pixelCompoundScale {
		get {
			if (pixelPerfectCamera!=null) {
				if (fitType==PixelPerfectFitType.Retro) {
					return pixelScale*pixelPerfectCamera.GetParallaxLayerScale(parallaxLayer);
				} else {
					return pixelPerfectCamera.GetParallaxLayerScale(parallaxLayer)/pixelPerfectCamera.cameraZoom;
				}
			} else {
				if (fitType==PixelPerfectFitType.Retro) {
					return pixelScale;
				} else {
					return 1f/PixelPerfect.mainCamera.cameraZoom;
				}
			}
		}
	}
	
	void OnEnable() {
		SetPixelPerfect();
	}
	
	protected void LateUpdate () {
		if (runContinously) {
			SetPixelPerfect();
		}
		#if UNITY_EDITOR
		if (!Application.isPlaying && UnityEditor.Selection.Contains(gameObject)) {
			SetPixelPerfect();
		}
		#endif
	}
	
	protected void SetPixelPerfect() {
		FindPixelPerfectCamera();
		SetPixelPerfectPosition();
		SetPixelPerfectScale();
	}
	
	void FindPixelPerfectCamera() {
		if (pixelPerfectCamera==null) {
			pixelPerfectCamera=FindObjectOfType<PixelPerfectCamera>();
		}
	}
	
	void SetPixelPerfectPosition() {
		if (useParentTransform) {
			transform.localPosition=Vector3.zero;
		}
	
		transform.position=new Vector3(transform.position.x, transform.position.y, GetPixelPerfectDepth());
		
		spriteOrigin=(Vector2)(transform.position)+GetPivotToOrigin();
		
		fixedSpriteOrigin=PixelPerfect.FitToGrid(spriteOrigin, PixelPerfect.worldPixelSize*pixelCompoundScale);
		
		fixedSpriteCenter=fixedSpriteOrigin-GetPivotToOrigin(); 
		pixelCorrection=fixedSpriteCenter-(Vector2)(transform.position);
		
		transform.position+=(Vector3)pixelCorrection;
	}
	
	float GetPixelPerfectDepth() {
		if (pixelPerfectCamera!=null && !pixelPerfectCamera.normalCamera.orthographic) {
			return pixelPerfectCamera.GetParallaxLayerDepth(parallaxLayer);
		} else {
			return transform.position.z;
		}
	}
	
	void SetPixelPerfectScale() {
		transform.localScale=new Vector3(Mathf.Sign(transform.localScale.x), Mathf.Sign(transform.localScale.y), 1)*GetTransformScaleFactor();
	}
	
	protected virtual float GetTransformScaleFactor() {
		float parallaxScale=(pixelPerfectCamera!=null)?pixelPerfectCamera.GetParallaxLayerScale(parallaxLayer):1;
		return PixelPerfect.pixelsPerUnit*PixelPerfect.worldPixelSize*pixelScale*parallaxScale;
	}
	
	protected virtual Vector2 GetPivotToCenter() {
		return Vector2.zero;
	}
	
	protected virtual Vector2 GetCenterToOrigin() {
		return Vector2.zero;
	}
	
	protected Vector2 GetPivotToOrigin() {
		return GetPivotToCenter()+GetCenterToOrigin();
	}
	
	#if UNITY_EDITOR
	void OnDrawGizmosSelected() {
		if (displayGrid) {
			if (pixelPerfectCamera!=null) {
				pixelPerfectCamera.DrawGridFromParallaxIndex(parallaxLayer, 1);
			}
			
			DrawPivotNode(transform.position, Color.yellow);
		}
	}
	
	void DrawPivotNode(Vector3 position, Color color) {
		Gizmos.color=color;
		float scale=PixelPerfect.worldPixelSize*pixelScale*4;
		Gizmos.DrawLine(position+Vector3.left *scale, position+Vector3.up   *scale);
		Gizmos.DrawLine(position+Vector3.up   *scale, position+Vector3.right*scale);
		Gizmos.DrawLine(position+Vector3.right*scale, position+Vector3.down *scale);
		Gizmos.DrawLine(position+Vector3.down *scale, position+Vector3.left *scale);
		Gizmos.DrawLine(position, position+Vector3.up   *scale);
		Gizmos.DrawLine(position, position+Vector3.right*scale);
		Gizmos.DrawLine(position, position+Vector3.down *scale);
		Gizmos.DrawLine(position, position+Vector3.left *scale);
	}
	#endif
}