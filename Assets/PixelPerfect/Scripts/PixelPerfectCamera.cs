using UnityEngine;
using System.Collections;
#if UNITY_EDITOR
using UnityEditor;
#endif

[ExecuteInEditMode]
[RequireComponent(typeof(Camera))]
public class PixelPerfectCamera : MonoBehaviour {
	public PixelPerfectFitType fitType=PixelPerfectFitType.Retro;
	public int targetPixelHeight=1080;
	public int parallaxLayerCount=10;
	public int cameraZoom=1;
	public bool pixelatedPostProcessing=true;
	public int heightError;
	public bool showGizmos=true;
	public Vector2 subpixelOffset=Vector2.zero;
	public PixelPerfectZoomMode pixelZoomMode=PixelPerfectZoomMode.ConstantZoom;
	
	Vector2 cameraOrigin, fixedCameraOrigin;
	Vector3 pixelPerfectPosition, regularPosition;
	int resolutionHeight=Screen.height;
	
	public Camera normalCamera {get {if (camera_==null) {camera_=GetComponent<Camera>();} return camera_;}} Camera camera_;
	
	Material postProcessingMaterial;
	
	void Awake() {
		//CalculateZoomForClosestResolution();
	}
	
	void OnEnable() {
		CalculatePixelPerfectPosition();
	}
	
	void LateUpdate () {
		CalculatePixelPerfectSize();
		CalculatePixelPerfectPosition();
	}
	
	void OnPreRender() {
		MoveToPixelPerfectPosition();
	}
	
	void OnRenderImage(RenderTexture src, RenderTexture dest) {
		if (postProcessingMaterial==null) {
			postProcessingMaterial=new Material(Shader.Find("Pixelatto/PixelPerfect"));
			postProcessingMaterial.hideFlags=HideFlags.DontSave;
		}
		if (pixelatedPostProcessing) {
			postProcessingMaterial.SetFloat("_Zoom", cameraZoom);
			Graphics.Blit(src, dest, postProcessingMaterial);
		} else {
			Graphics.Blit(src, dest);
		}
	}
	
	void OnDisable() {
		DestroyImmediate(postProcessingMaterial);
	}
	
	void OnPostRender() {
		MoveBackToRegularPosition();
	}
	
	void CalculatePixelPerfectSize() {
		float orthoSizeFactor=1f;
		
		if (pixelZoomMode==PixelPerfectZoomMode.ConstantZoom) {
			targetPixelHeight=Screen.height/cameraZoom;
		}
		CalculateZoomForClosestResolution();
		
		if (!pixelatedPostProcessing) {
			orthoSizeFactor*=1f/cameraZoom;
		}
		
		normalCamera.orthographicSize=(resolutionHeight*0.5f)*PixelPerfect.worldPixelSize*orthoSizeFactor;
		normalCamera.fieldOfView=Mathf.Atan(normalCamera.orthographicSize/GetCameraDepth())*Mathf.Rad2Deg*2;
	}
	
	void CalculateZoomForClosestResolution() {
		int possibleHeight=0;
		int minError=int.MaxValue;
		int targetScale=1;
		resolutionHeight=Mathf.RoundToInt(Screen.height*normalCamera.rect.height);
		for (int scale = 1; scale <= Screen.height; scale++) {
			possibleHeight=targetPixelHeight*scale;
			int error=Mathf.Abs(possibleHeight-resolutionHeight);
			if (error<minError) {
				minError=error;
				targetScale=scale;
			}
		}
		heightError=minError;
		cameraZoom=targetScale;
	}
	
	void CalculatePixelPerfectPosition() {
		cameraOrigin=(Vector2)transform.position+VectorToOrigin();
		fixedCameraOrigin=FitToPixelPerfectGrid(cameraOrigin);
		pixelPerfectPosition=(Vector3)fixedCameraOrigin-(Vector3)VectorToOrigin()+transform.position.z*Vector3.forward;
		regularPosition=(Vector3)cameraOrigin-(Vector3)VectorToOrigin()+transform.position.z*Vector3.forward;
	}
	
	Vector2 VectorToOrigin(int parallaxLayer=0) {
		if (normalCamera.orthographic) {
			return (new Vector2(-(normalCamera.pixelWidth-1), normalCamera.pixelHeight-1)+subpixelOffset)*0.5f*PixelPerfect.worldPixelSize/cameraZoom;
		} else {
			return (new Vector2(-(normalCamera.pixelWidth-1), normalCamera.pixelHeight-1)+subpixelOffset)*0.5f*PixelPerfect.worldPixelSize/cameraZoom*GetParallaxLayerScale(parallaxLayer);
		}
	}
	
	Vector2 FitToPixelPerfectGrid(Vector2 vector) {
		if (fitType==PixelPerfectFitType.Smooth) {
			return PixelPerfect.FitToGrid(vector, PixelPerfect.worldPixelSize/cameraZoom);
		} else {
			return  PixelPerfect.FitToGrid(vector, PixelPerfect.worldPixelSize);
		}
	}
	
	void MoveToPixelPerfectPosition() {
		transform.position=pixelPerfectPosition;
	}
	
	void MoveBackToRegularPosition() {
		transform.position=regularPosition;
	}
	
	public float GetParallaxLayerDepth(int parallaxLayerIndex) {
		return GetCameraDepth()*(float)parallaxLayerIndex;
	}
	
	public float GetParallaxLayerScale(int parallaxLayerIndex) {
		return parallaxLayerIndex+1;
	}
	
	Color GetParallaxLayerColor(int parallaxLayerIndex) {
		float alpha=((float)parallaxLayerIndex/(float)parallaxLayerCount);
		return new PixelPerfectHSBColor(alpha, 1, 1, 1).ToColor();
	}
	
	float GetCameraDepth() {
		return Mathf.Abs(transform.position.z);
	}
	
	#if UNITY_EDITOR
	void OnDrawGizmos() {
		if (showGizmos) {
			for (int i = 0; i < parallaxLayerCount; i++) {
				DrawRectFromParallaxIndex(i, 1);
			}
			DrawGridFromParallaxIndex(0, 1);
			Gizmos.color=Color.white;
			Gizmos.DrawLine(transform.position, pixelPerfectPosition);
		}
	}
	
	public void DrawGridFromParallaxIndex(int parallaxLayerIndex, float pixelScale) {
		float gridScaleFactor=1;
		if (!normalCamera.orthographic) {gridScaleFactor*=GetParallaxLayerScale(parallaxLayerIndex);}
		if (pixelatedPostProcessing)	{gridScaleFactor*=1f/cameraZoom;}
		
		DrawGrid2D(normalCamera.orthographicSize*normalCamera.aspect*gridScaleFactor, normalCamera.orthographicSize*gridScaleFactor, parallaxLayerIndex, pixelScale);
	}
	
	public void DrawRectFromParallaxIndex(int parallaxLayerIndex, float pixelScale) {
		float gridScaleFactor=1;
		if (!normalCamera.orthographic) {gridScaleFactor*=GetParallaxLayerScale(parallaxLayerIndex);}
		if (pixelatedPostProcessing)	{gridScaleFactor*=1f/cameraZoom;}
	
		DrawRect2D(normalCamera.orthographicSize*normalCamera.aspect*gridScaleFactor, normalCamera.orthographicSize*gridScaleFactor, parallaxLayerIndex, pixelScale);
	}
	
	float GetPixelSize(int parallaxLayerIndex) {
		float smoothFactor=(fitType==PixelPerfectFitType.Smooth)?1f/cameraZoom:1f;
		return PixelPerfect.worldPixelSize*GetParallaxLayerScale(parallaxLayerIndex)*smoothFactor;
	}
	
	void DrawGrid2D(float sizeX, float sizeY, int parallaxLayerIndex, float pixelScale) {
		Gizmos.color=GetParallaxLayerColor(parallaxLayerIndex)*0.1f;
		float depth=GetParallaxLayerDepth(parallaxLayerIndex);
		Vector2 gridOrigin=(Vector2)transform.position+VectorToOrigin(parallaxLayerIndex);
		Vector2 fixedGridOrigin=FitToPixelPerfectGrid(gridOrigin);
		Vector3 origin=(Vector3)fixedGridOrigin+depth*Vector3.forward;
		
		for (float i = 0; i <= 2*sizeX; i+=PixelPerfect.worldPixelSize*pixelScale*GetParallaxLayerScale(parallaxLayerIndex)) {
			Gizmos.DrawLine(origin+new Vector3(i,0), origin+new Vector3(i,-2*sizeY));
		}
		for (float j = 0; j <= 2*sizeY; j+=PixelPerfect.worldPixelSize*pixelScale*GetParallaxLayerScale(parallaxLayerIndex)) {
			Gizmos.DrawLine(origin+new Vector3(0,-j), origin+new Vector3(2*sizeX,-j));
		}
	}
	
	void DrawRect2D(float sizeX, float sizeY, int parallaxLayerIndex, float pixelScale) {
		Gizmos.color=GetParallaxLayerColor(parallaxLayerIndex)*0.8f;
		float depth=GetParallaxLayerDepth(parallaxLayerIndex);
		Vector2 gridOrigin=(Vector2)transform.position+VectorToOrigin(parallaxLayerIndex);
		Vector2 fixedGridOrigin=FitToPixelPerfectGrid(gridOrigin);
		Vector3 origin=(Vector3)fixedGridOrigin+depth*Vector3.forward;
		
		Gizmos.DrawLine(origin+new Vector3(0       ,0), origin+new Vector3(0      ,-2*sizeY));
		Gizmos.DrawLine(origin+new Vector3(2*sizeX ,0), origin+new Vector3(2*sizeX,-2*sizeY));
		Gizmos.DrawLine(origin+new Vector3(0       ,0), origin+new Vector3(2*sizeX,       0));
		Gizmos.DrawLine(origin+new Vector3(0,-2*sizeY), origin+new Vector3(2*sizeX,-2*sizeY));
	}
	#endif
	
}

#if UNITY_EDITOR
[CustomEditor(typeof(PixelPerfectCamera))]
public class PixelPerfectCameraEditor : Editor {
	Texture pixelPerfectLogo_;
	Texture pixelPerfectLogo {
		get {
			if (pixelPerfectLogo_==null) {
				string path=AssetDatabase.GUIDToAssetPath(AssetDatabase.FindAssets("PixelPerfectCamera")[0]).Replace("PixelPerfectCamera.cs","")+"Internal/Images/pixelperfect_logo.png";
				pixelPerfectLogo_ = (Texture)AssetDatabase.LoadAssetAtPath(path, typeof(Texture));
			}
			return pixelPerfectLogo_;
		}
	}
	Texture pixelattoIcon_;
	Texture pixelattoIcon {
		get {
			if (pixelattoIcon_==null) {
				string path=AssetDatabase.GUIDToAssetPath(AssetDatabase.FindAssets("PixelPerfectCamera")[0]).Replace("PixelPerfectCamera.cs","")+"Internal/Images/pixelatto_icon.png";
				pixelattoIcon_ = (Texture)AssetDatabase.LoadAssetAtPath(path, typeof(Texture));
			}
			return pixelattoIcon_;
		}
	}

	SerializedProperty targetPixelHeight;
	SerializedProperty fitType;
	SerializedProperty parallaxLayerCount;
	SerializedProperty pixelatedPostProcessing;
	SerializedProperty showGizmos;
	SerializedProperty pixelZoomMode;
	SerializedProperty cameraZoom;
	SerializedProperty subpixelOffset;
	
	override public void OnInspectorGUI() {
		FindSerializedProperties();
		DrawInspector();
	}
	
	void FindSerializedProperties() {
		targetPixelHeight		=serializedObject.FindProperty("targetPixelHeight");
		fitType					=serializedObject.FindProperty("fitType");
		pixelatedPostProcessing	=serializedObject.FindProperty("pixelatedPostProcessing");
		parallaxLayerCount		=serializedObject.FindProperty("parallaxLayerCount");
		showGizmos				=serializedObject.FindProperty("showGizmos");
		pixelZoomMode			=serializedObject.FindProperty("pixelZoomMode");
		cameraZoom				=serializedObject.FindProperty("cameraZoom");
		subpixelOffset			=serializedObject.FindProperty("subpixelOffset");
	}
	
	void DrawInspector() {
		DrawTitle();
		
		DrawRenderField();
		EditorGUILayout.PropertyField(fitType);
		DrawZoomAndTargetHeight();
		EditorGUILayout.PropertyField(showGizmos);
		DrawParallaxField();
		DrawOffsetField();
		
		serializedObject.ApplyModifiedProperties();
	}
	
	void DrawTitle() {
		GUILayout.Space(8f);
		if (pixelPerfectLogo!=null) {
			var headerRect = GUILayoutUtility.GetRect(Screen.width, 5.0f);
			headerRect.x=headerRect.x-16f;
			headerRect.width = pixelPerfectLogo.width;
			headerRect.height = pixelPerfectLogo.height;
			GUILayout.Space( headerRect.height );
			GUI.DrawTexture( headerRect, pixelPerfectLogo);
			
			if (GUI.Button(new Rect(Screen.width-60, headerRect.y+4, headerRect.height*0.875f, headerRect.height*0.875f), new GUIContent(pixelattoIcon, "More Pixelatto Assets"))) {
				Application.OpenURL("http://www.pixelatto.com/");
			}
		}
	}
	
	void DrawRenderField() {
		EditorGUILayout.BeginHorizontal();
		EditorGUILayout.PrefixLabel("Render Mode");
		EditorGUI.BeginChangeCheck();
		GUILayout.Toggle(!pixelatedPostProcessing.boolValue, "Normal", GUI.skin.FindStyle("Button"));
		GUILayout.Toggle(pixelatedPostProcessing.boolValue, "Pixelated", GUI.skin.FindStyle("Button"));
		if (EditorGUI.EndChangeCheck()) {
			pixelatedPostProcessing.boolValue=!pixelatedPostProcessing.boolValue;
		}
		EditorGUILayout.EndHorizontal();
	}
	
	void DrawParallaxField() {
		if (!((PixelPerfectCamera)target).normalCamera.orthographic) {
			EditorGUILayout.PropertyField(parallaxLayerCount);
		} else {
			EditorGUILayout.BeginHorizontal();
			EditorGUILayout.PrefixLabel("Parallax Layer Count");
			EditorGUILayout.LabelField("(Requires a camera set to 'Perspective')");
			EditorGUILayout.EndHorizontal();
		}
	}
	
	void DrawOffsetField() {
		EditorGUILayout.PropertyField(subpixelOffset);
	}
	
	void DrawZoomAndTargetHeight() {
		EditorGUILayout.PropertyField(pixelZoomMode);
		if (pixelZoomMode.enumValueIndex==0) {
			EditorGUILayout.PropertyField(cameraZoom, new GUIContent(" "));
			cameraZoom.intValue=Mathf.Max(cameraZoom.intValue, 1, cameraZoom.intValue);
		} else {
			EditorGUILayout.PropertyField(targetPixelHeight, new GUIContent(" "));
			
			EditorGUILayout.BeginHorizontal();
			EditorGUILayout.PrefixLabel(" ");
			if (GUILayout.Button("120"))   {targetPixelHeight.intValue=120;}
			if (GUILayout.Button("240"))   {targetPixelHeight.intValue=240;}
			if (GUILayout.Button("480"))   {targetPixelHeight.intValue=480;}
			if (GUILayout.Button("600"))   {targetPixelHeight.intValue=600;}
			if (GUILayout.Button("1080"))  {targetPixelHeight.intValue=1080;}
			EditorGUILayout.EndHorizontal();
			
			EditorGUILayout.BeginHorizontal();
			EditorGUILayout.PrefixLabel(" ");
			EditorGUILayout.LabelField("Current Zoom: ", GUILayout.Width(90));
			EditorGUILayout.LabelField("x"+((PixelPerfectCamera)target).cameraZoom);
			EditorGUILayout.EndHorizontal();
			
			EditorGUILayout.BeginHorizontal();
			EditorGUILayout.PrefixLabel(" ");
			EditorGUILayout.LabelField("Height Error: ", GUILayout.Width(90));
			EditorGUILayout.LabelField(((PixelPerfectCamera)target).heightError+" texels");
			EditorGUILayout.EndHorizontal();
		}
	}
}
#endif