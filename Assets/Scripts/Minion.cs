using UnityEngine;
using System.Collections;

public class Minion : MonoBehaviour
{

	[System.Serializable]
	public class AnimationSet
	{
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

	class StateGotoGoal : MinionState
	{
		public StateGotoGoal(Minion parent)
			: base(parent)
		{ }

		public override bool onBegin()
		{
			parent.animationBody.clip = parent.animationSet.walk;
			parent.animationBody.Play();

			NavMeshAgent navMeshAgent = parent.gameObject.GetComponent<NavMeshAgent>();
			if (navMeshAgent != null)
				navMeshAgent.destination = GameObject.Find("golem").transform.position;


			return true;
		}
	}

	private State.Manager _state = new State.Manager();

	// Use this for initialization
	void Start()
	{
		_state.changeTo(new StateGotoGoal(this));
	}

	// Update is called once per frame
	void Update()
	{
	}
}
