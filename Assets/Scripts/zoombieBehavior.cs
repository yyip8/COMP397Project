using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class zoombieBehavior : MonoBehaviour
{
	#region variable
	[SerializeField]
	private float speed = 3f;
	[SerializeField]
	private WayPoint targetPoint, startPoint;
	[SerializeField]
	private Hero mage;
	//Set player invincibility interval
	[SerializeField]
	public float timelnvincible = 2.0f;

	#endregion
	private Animator animator;

	
	//Set whether invincible variable
	bool islnvincible;
	//Define variables, time the invincible time, invincible time timer
	float invincibleTimer;


	// Use this for initialization
	void Start()
	{
		animator = GetComponent<Animator>();
		if (Vector3.Distance(transform.position, startPoint.transform.position) < 1e-2f)
		{
			targetPoint = startPoint.nextWayPoint;
		}
		else
		{
			targetPoint = startPoint;
		}
		StartCoroutine(AINavMesh());
	}

    void Update()
    {
		// whether you are in an invincible state, to count down the timer
		if (islnvincible)
		{
			//If invincible, enter the countdown
			//The time consumed by subtracting one frame from each update
			invincibleTimer -= Time.deltaTime;
			if (invincibleTimer < 0)
			{
				islnvincible = false;
			}
		}
	}

    IEnumerator AINavMesh()
	{
		while (true)
		{
			//reach the point (idle)
			if (Vector3.Distance(transform.position, targetPoint.transform.position) < 1e-2f)
			{
				targetPoint = targetPoint.nextWayPoint;
				animator.SetBool("idle", true);
				yield return new WaitForSeconds(1f);
			}
			//find player
			if (mage != null && Vector3.Distance(transform.position, mage.gameObject.transform.position) <= 5f)
			{
				//Debug.Log("侦测到敌人，开始追击！！！");
				yield return StartCoroutine(AIFollowHero());
			}
			//walk to next point
			Vector3 dir = targetPoint.transform.position - transform.position;
			animator.SetBool("idle", false);
			transform.LookAt(targetPoint.transform.position);
			transform.Translate(dir.normalized * Time.deltaTime * speed, Space.World);
			//Debug.Log(targetPoint.name);
			yield return new WaitForEndOfFrame();
		}
	}
	IEnumerator AIFollowHero()
	{
		while (true)
		{
			if (mage != null && Vector3.Distance(transform.position, mage.gameObject.transform.position) > 5f)
			{
				//Debug.Log("敌人已走远，放弃攻击！！！");
				animator.SetBool("run", false);
				yield break;
			}
			Vector3 dir = mage.transform.position - transform.position;
			animator.SetBool("run", true);
			animator.SetBool("idle", false);
			transform.LookAt(mage.transform.position);
			transform.Translate(dir.normalized * Time.deltaTime * speed * 1.5f, Space.World);
			yield return new WaitForEndOfFrame();
		}
	}

	/*
    private void OnTriggerStay(Collider other)
    {
		if (other.tag == "Player")
		{
			Debug.Log("OnTriggerStay");
		}

    }
	*/

    private void OnTriggerEnter(Collider other)
    {
		if (other.tag == "Player")
		{
			Debug.Log("OnTriggerEnter");
			//Determine whether the player is currently invincible
			if (islnvincible)
			{
				//When the player is in an invincible state
				//the statements in all functions after return will not be executed
				//no blood or key will be lost and no information will be output
				return;
			}
			//animator.SetBool("attack", true);
			islnvincible = true;
			invincibleTimer = timelnvincible;
			GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerKeyCollect>().decreaseKeyCollected();
		}
	}
}
