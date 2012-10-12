using UnityEngine;
using System.Collections;

public class SpartanKingControl : MonoBehaviour 
{
	private GameObject target;
	void Start () 
	{	
		//navigation
		target = GameObject.Find("golem");
		NavMeshAgent navMeshAgent = gameObject.GetComponent<NavMeshAgent>();
		navMeshAgent.destination = target.transform.position;
		
		gameObject.animation.CrossFade("run");
		
	}
}
