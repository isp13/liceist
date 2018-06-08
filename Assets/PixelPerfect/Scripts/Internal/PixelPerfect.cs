using UnityEngine;
using System.Collections;


public static class PixelPerfect {
	//You can change this value if you want to use a different world pixel size
	public static float pixelsPerUnit=32;
	public static float worldPixelSize {get {return 1f/pixelsPerUnit;}}
	public static PixelPerfectCamera mainCamera {get {if (mainCamera_==null) {mainCamera_=MonoBehaviour.FindObjectOfType<PixelPerfectCamera>();} return mainCamera_;}}
	public static PixelPerfectCamera mainCamera_;
	
	public static Vector3 FitToGrid(Vector3 input, float gridSize=0) {
		if (gridSize<=0) {gridSize=worldPixelSize;}
		return new Vector3((Mathf.Round(input.x/gridSize)*gridSize), (Mathf.Round(input.y/gridSize)*gridSize), input.z);
	}
}

public enum PixelPerfectFitType {Retro, Smooth}

public enum PixelPerfectZoomMode {ConstantZoom, TargetHeight}