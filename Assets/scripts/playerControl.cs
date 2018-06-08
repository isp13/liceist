using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerControl : MonoBehaviour {






	private Rigidbody2D rb2d;

	 
	public float moveSpeed;
	Animator anim;

	// Use this for initialization
	void Start () {
		
		rb2d = GetComponent<Rigidbody2D> ();
		anim = GetComponent<Animator>();
		rb2d.constraints = RigidbodyConstraints2D.FreezeRotation;
		int up = Animator.StringToHash("up");

		int down = Animator.StringToHash("down");

		int left = Animator.StringToHash("left");

		int right = Animator.StringToHash("right");

	}

	void isAlreadyPlaying()
	{
		
	}
	// Update is called once per frame
	void Update () 
	{
		



	rb2d.velocity = new Vector2(Mathf.Lerp(0, Input.GetAxis("Horizontal")* moveSpeed, 0.8f),
			Mathf.Lerp(0, Input.GetAxis("Vertical")* moveSpeed, 0.8f));

		if (Input.GetAxisRaw ("Horizontal") >= 0.5f) anim.Play ("Right");
		else if (Input.GetAxisRaw ("Horizontal") < -0.5f) anim.Play ("Left");
		else if(Input.GetAxisRaw ("Vertical") >= 0.5f) anim.Play ("Up");
		else if(Input.GetAxisRaw ("Vertical") < -0.5f) anim.Play ("Down");

	
	}



}


