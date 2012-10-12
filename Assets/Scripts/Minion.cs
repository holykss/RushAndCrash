using UnityEngine;
using System.Collections;


class State
{
	public bool changeTo(State newState)
	{
		if (onEnd())
		{
			if (newState.onBegin())
			{
				return true;
			}
		}
		return false;
	}

	public bool onBegin()
	{
		return true;
	}

	public bool onUpdate()
	{
		return true;
	}

	public bool onEnd()
	{
		return true;
	}
}

public class Minion : MonoBehaviour {

	[System.Serializable]
	public class AnimationSet {
		public AnimationClip idle;
		public AnimationClip walk;
		public AnimationClip attack;
		public AnimationClip damaged;
		public AnimationClip dead;
	}

	public AnimationSet animationSet;
	public Animation animationBody;


	private class StateIdle : State
	{
		public bool onBegin()
		{
			//animationBody.clip = walk;
			//animationBody.Play();
			return true;
		}
	}

	private State state;

	// Use this for initialization
	void Start () {
		
		NavMeshAgent navMeshAgent = gameObject.GetComponent<NavMeshAgent>();
		navMeshAgent.destination = GameObject.Find("golem").transform.position;
		
		animationBody.clip = animationSet.walk;
		animationBody.Play();
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
