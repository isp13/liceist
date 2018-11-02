//система управление героем
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerControl : MonoBehaviour {






	private Rigidbody2D rb2d;
	protected Joystick joystick;
	 
	public float moveSpeed;
	Animator anim;

	// Use this for initialization
	void Start () {
		
		rb2d = GetComponent<Rigidbody2D> ();
		anim = GetComponent<Animator>();
		rb2d.constraints = RigidbodyConstraints2D.FreezeRotation;
		joystick = FindObjectOfType<Joystick> ();
		int up = Animator.StringToHash("up");

		int down = Animator.StringToHash("down");

		int left = Animator.StringToHash("left");

		int right = Animator.StringToHash("right");

	}

	void isAlreadyPlaying()
	{
		
	}

	public void freezemovement(){
		rb2d.constraints = RigidbodyConstraints2D.FreezeAll;
		Debug.Log("rigitbody has been frozen");
	}

	public void unfreezemovement()
	{
		rb2d.constraints = RigidbodyConstraints2D.None;
		rb2d.constraints = RigidbodyConstraints2D.FreezeRotation;
		Debug.Log("rigitbody has been unfrozen");
	}

	// Update is called once per frame
	void Update () 
	{
		
		rb2d.velocity = new Vector2(Mathf.Lerp(0, joystick.Horizontal* moveSpeed, 0.8f),
			Mathf.Lerp(0, joystick.Vertical* moveSpeed, 0.8f));
		if (joystick.Horizontal >= 0.5f) anim.Play ("Right");
		else if (joystick.Horizontal  < -0.5f) anim.Play ("Left");
		else if(joystick.Vertical >= 0.5f) anim.Play ("Up");
		else if(joystick.Vertical < -0.5f) anim.Play ("Down");
	}
}


