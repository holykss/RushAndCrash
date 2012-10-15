using UnityEngine;
using System.Collections;

public partial class Minion : MonoBehaviour
{
	private float range = 10.0f;

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

	private State.Manager _state = new State.Manager();


	// Use this for initialization
	void Start()
	{
		_state.changeTo(new StateGotoGoal(this));
	}

	// Update is called once per frame
	void Update()
	{
		if (_state != null)
		{
			_state.update();
		}
	}

	public void attack(GameObject target)
	{
		_state.changeTo(new StateAttack(this, target));
	}
}

public partial class Minion
{
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

		public override bool onUpdate()
		{
			GameObject golem = GameObject.Find("golem");
			Vector3 golemPosition = golem.transform.position;

			float distance = (golemPosition - parent.transform.position).sqrMagnitude;
			if (distance <= parent.range)
			{
				parent.attack(golem);
			}

			return true;
		}
	}

	class StateAttack : MinionState
	{
		private GameObject _target;

		public StateAttack(Minion parent, GameObject target)
			: base(parent)
		{
			_target = target;
		}

		public override bool onBegin()
		{
			NavMeshAgent navMeshAgent = parent.gameObject.GetComponent<NavMeshAgent>();

			if (navMeshAgent != null)
				navMeshAgent.Stop();


			parent.transform.LookAt(_target.transform);
			parent.animationBody.CrossFade(parent.animationSet.attack.name, 0.2f);
			return true;
		}
	}
}