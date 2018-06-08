using UnityEngine;
using System.Collections;
#if UNITY_EDITOR
using UnityEditor;
#endif

[RequireComponent(typeof(SpriteRenderer))]
public class PixelPerfectSprite : PixelPerfectObject {
	
	SpriteRenderer spriteRenderer {get { if (spriteRenderer_==null) {spriteRenderer_=GetComponent<SpriteRenderer>();} return spriteRenderer_;}}
	SpriteRenderer spriteRenderer_;
	
	Rect    spriteRect  {get {return (spriteRenderer.sprite!=null) ? spriteRenderer.sprite.rect  : new Rect(0,0,0,0);}}
	Vector2 spritePivot {get {return (spriteRenderer.sprite!=null) ? spriteRenderer.sprite.pivot : new Vector2(0,0);}}
	float spritePixelPerUnit { get { return (spriteRenderer.sprite!=null) ? spriteRenderer.sprite.pixelsPerUnit : PixelPerfect.pixelsPerUnit;}}
	
	new protected void LateUpdate() {
		base.LateUpdate();
	}
	
	override protected float GetTransformScaleFactor() {
		float parallaxScale;
		if (pixelPerfectCamera!=null && !pixelPerfectCamera.normalCamera.orthographic) {
			parallaxScale=pixelPerfectCamera.GetParallaxLayerScale(parallaxLayer);
		} else {
			parallaxScale=1;
		}
		return spritePixelPerUnit*PixelPerfect.worldPixelSize*pixelScale*parallaxScale;
	}
	
	override protected Vector2 GetPivotToCenter() {
		Vector2 normalizedPivot=new Vector2(spriteRect.width*0.5f-spritePivot.x, spriteRect.height*0.5f-spritePivot.y);
		return (new Vector2(normalizedPivot.x, normalizedPivot.y))*pixelScale*PixelPerfect.worldPixelSize;
	}
	
	override protected Vector2 GetCenterToOrigin() {
		return (new Vector2(-(float)spriteRect.width*0.5f, (float)spriteRect.height*0.5f))*pixelScale*PixelPerfect.worldPixelSize;
	}
}

#if UNITY_EDITOR
[CustomEditor(typeof(PixelPerfectSprite))]
public class PixelPerfectSpriteEditor : Editor {
	SerializedProperty pixelPerfectCamera;
	SerializedProperty pixelPerfectFitType;
	SerializedProperty parallaxLayer;
	SerializedProperty pixelScale;
	SerializedProperty runContinously;
	SerializedProperty useParentTransform;
	SerializedProperty displayGrid;
	
	override public void OnInspectorGUI() {
		FindSerializedProperties();
		DrawInspector();
	}
	
	void FindSerializedProperties() {
		pixelPerfectCamera	=serializedObject.FindProperty("pixelPerfectCamera");
		pixelPerfectFitType	=serializedObject.FindProperty("fitType");
		parallaxLayer		=serializedObject.FindProperty("parallaxLayer");
		pixelScale			=serializedObject.FindProperty("pixelScale");
		runContinously		=serializedObject.FindProperty("runContinously");
		useParentTransform	=serializedObject.FindProperty("useParentTransform");
		displayGrid			=serializedObject.FindProperty("displayGrid");
	}
	
	void DrawInspector() {
		EditorGUILayout.PropertyField(pixelPerfectFitType);
		EditorGUILayout.PropertyField(pixelScale);
		pixelScale.intValue=Mathf.Max(pixelScale.intValue, 0, pixelScale.intValue);
		DrawParallaxField();
		DrawButtons();
		
		serializedObject.ApplyModifiedProperties();
	}
	
	void DrawButtons() {
		EditorGUILayout.PrefixLabel("Options:");
		EditorGUILayout.BeginHorizontal();
		GUILayout.FlexibleSpace();
		runContinously.boolValue=GUILayout.Toggle(runContinously.boolValue, "Run Continously", GUI.skin.FindStyle("Button"), GUILayout.Height(24), GUILayout.Width(150));
		useParentTransform.boolValue=GUILayout.Toggle(useParentTransform.boolValue, "Use Parent Transform", GUI.skin.FindStyle("Button"), GUILayout.Height(24), GUILayout.Width(150));
		displayGrid.boolValue=GUILayout.Toggle(displayGrid.boolValue, "Show Grid", GUI.skin.FindStyle("Button"), GUILayout.Height(24), GUILayout.Width(150));
		GUILayout.FlexibleSpace();
		EditorGUILayout.EndHorizontal();
	}
	
	void DrawParallaxField() {
		PixelPerfectCamera targetCamera=((PixelPerfectCamera)pixelPerfectCamera.objectReferenceValue);
		if (targetCamera!=null && targetCamera.normalCamera!=null && !targetCamera.normalCamera.orthographic) {
			EditorGUILayout.BeginHorizontal();
			EditorGUILayout.PrefixLabel("Parallax Layer");
			parallaxLayer.intValue=EditorGUILayout.IntSlider(parallaxLayer.intValue, 0, targetCamera.parallaxLayerCount);
			EditorGUILayout.EndHorizontal();
		} else {
			EditorGUILayout.BeginHorizontal();
			EditorGUILayout.PrefixLabel("Parallax Layer");
			EditorGUILayout.LabelField("(Requires a camera set to 'Perspective')");
			EditorGUILayout.EndHorizontal();
		}
	}
}
#endif