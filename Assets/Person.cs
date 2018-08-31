using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
public class Person : MonoBehaviour{
	[SerializeField] private string PersonName;
	[SerializeField] private bool HasAllAnimations;
	public Dialogue dialogue;

	public float MoveSpeed;
	private Rigidbody2D myRigidbody;

	public bool isWalking;

	public bool onlyforwardback;
	public bool forwardornot;

	public float walkTime;
	private float walkCounter;
	public float waitTime;
	private float waitCounter;

	Animator an;
	private int WalkDircection;
	// Use this for initialization
	void Start () {
		an = GetComponent<Animator>();
		myRigidbody = GetComponent<Rigidbody2D> ();
		waitCounter = waitTime;
		walkCounter = walkTime;

		ChooseDircetcion();
	}
	
	// Update is called once per frame
	void Update () {

		myRigidbody.constraints = RigidbodyConstraints2D.FreezeRotation;

		if (isWalking) 
		{
			walkCounter -= Time.deltaTime;
			if (walkCounter < 0) {
				isWalking = false;
				waitCounter = waitTime;
			}

			switch (WalkDircection) 
			{
			case 0:
				myRigidbody.velocity = new Vector2 (0, MoveSpeed);
				if (HasAllAnimations==true)an.Play ("Up");
				break;

			case 1:
				myRigidbody.velocity = new Vector2 (MoveSpeed,0);
				if (HasAllAnimations==true)an.Play ("Right");
				break;

			case 2:
				myRigidbody.velocity = new Vector2 (0, -MoveSpeed);
				if (HasAllAnimations==true)an.Play ("Down");
				break;

			case 3:
				myRigidbody.velocity = new Vector2 (-MoveSpeed, 0);
				if (HasAllAnimations==true)an.Play ("Left");
				break;

				
			}
		} 
		else 
		{
			waitCounter -= Time.deltaTime;
			myRigidbody.velocity = Vector2.zero;
			if (waitCounter < 0) 
			{
				ChooseDircetcion ();

			}
		}
	}

	public void ChooseDircetcion()
	{

		WalkDircection = Random.Range (0, 4);
		if (onlyforwardback)
		{
			if (forwardornot==true)
			{
				WalkDircection=1;
				forwardornot=false;
			}
			else
			{
				WalkDircection=3;
				forwardornot=true;
			}
		}
		isWalking = true;
		walkCounter = walkTime;

	}






	void OnTriggerEnter2D (Collider2D other)//начинаем диалог когда гг приближается к персу
	{
		if (other.CompareTag("Player"))
			FindObjectOfType<DialogSystem> ().StartDialogue (dialogue);
	}
}
