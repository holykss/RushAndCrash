using UnityEngine;
using System.Collections;

class State
{
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


class StateManager
{
	State _state;

	public StateManager()
	{
		_state = new State();
	}

	public bool changeTo(State newState)
	{
		if (_state.onEnd())
		{
			if (newState.onBegin())
			{
				_state = newState;
				return true;
			}
		}
		return false;
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

	class MinionState : State
	{
		private Minion _parent;
		public Minion parent
		{
			get { return _parent; }
		}
	

		public MinionState(Minion parent)
		{
			_parent = parent;
		}
	}

	class StateIdle : MinionState
	{
		public StateIdle(Minion parent) : base(parent)
		{}

		public new bool onBegin()
		{
			parent.animationBody.clip = parent.animationSet.walk;
			parent.animationBody.Play();
			return true;
		}
	}

	private StateManager _state = new StateManager();

	// Use this for initialization
	void Start () {
		
		NavMeshAgent navMeshAgent = gameObject.GetComponent<NavMeshAgent>();
		navMeshAgent.destination = GameObject.Find("golem").transform.position;
		
		_state.changeTo(new StateIdle(this));
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
