using UnityEngine;
using System.Collections;

public class State
{
	public class Manager
	{
		State _state;

		public Manager()
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

	public virtual bool onBegin()
	{
		return true;
	}

	public virtual bool onUpdate()
	{
		return true;
	}

	public virtual bool onEnd()
	{
		return true;
	}
}


