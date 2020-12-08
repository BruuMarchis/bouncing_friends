using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class trampolineManager : MonoBehaviour
{
	public bool customSpeed;
	public Vector2 customVelocity;
	public float multiplier;


	bool onTop;
	public GameObject bouncer;
	Animator anim;
	Vector2 velocity;

	// Use this for initialization
	void Start()
	{
		anim = gameObject.GetComponent<Animator>();
	}

	// Update is called once per frame
	void Update()
	{

	}

	private void OnCollisionEnter2D(Collision2D other)
	{
		if (onTop)
		{
			anim.SetBool("jumped", true);
			bouncer = other.gameObject;
		}

		if (other.gameObject.tag == "Player")
		{

			//other.gameObject.GetComponent<CharacterController2D>().BaseSpeed = velocity.x;
		}
	}

	void OnCollisionStay2D(Collision2D other)
	{

		if (onTop)
		{
			anim.SetBool("stay", true);
			bouncer = other.gameObject;
		}
		else
		{
			anim.SetBool("jumped", true);
			bouncer = other.gameObject;
		}

		if (other.gameObject.tag == "Player")
		{

			//other.gameObject.GetComponent<CharacterController2D>().BaseSpeed = velocity.x;
		}
	}



	void OnTriggerEnter2D()
	{
		onTop = true;
	}
	void OnTriggerExit2D()
	{
		onTop = false;
		anim.SetBool("jumped", false);
		anim.SetBool("stay", false);
		Debug.Log("saiu");
	}

	void OnTriggerStay2D()
	{
		onTop = true;
	}


	void Jump()
	{

		if (customSpeed)
			velocity = customVelocity;
		else
			velocity = transform.up * multiplier;

		bouncer.GetComponent<Rigidbody2D>().velocity = velocity;

	}

}
