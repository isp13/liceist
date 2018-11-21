 using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class MovingObject : MonoBehaviour {

	public LayerMask blockingLayer;
	public float movetime=0.1f;

	private BoxCollider2D boxCollider;
	private Rigidbody2D rb2D;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
