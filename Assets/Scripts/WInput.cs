using UnityEngine;
using System.Collections;


public class WHumanInput
{
	private Vector2 _deltaPosition;
	private float _deltaTime;
	private int _buttonIndex;
	private TouchPhase _phase;
	private Vector2 _position;
	private int _tapCount;

	public WHumanInput(Vector2 deltaPosition, float deltaTime, int buttonIndex, TouchPhase phase, Vector2 position, int tapCount)
	{
		_deltaPosition = deltaPosition;
		_deltaTime = deltaTime;
		_buttonIndex = buttonIndex;
		_phase = phase;
		_position = position;
		_tapCount = tapCount;
	}

	public Vector3 deltaPosition { get { return _deltaPosition; } }
	public float deltaTime { get { return _deltaTime; } }
	public int buttonIndex { get { return _buttonIndex; } }
	public TouchPhase phase { get { return _phase; } }
	public Vector3 position { get { return _position; } }
	public int tapCount { get { return _tapCount; } }
}

public class WInput
{
	private class WPreviousInputState
	{
		private Vector3 _startPosition;
		private Vector3 _previousPosition;
		private float _previousTime;
		private int _previousTapCount;

		internal WPreviousInputState()
		{
			clear();
		}

		private void clear()
		{
		}

		internal WHumanInput generateMouseInput()
		{
			float currentTime = Time.time;
			float deltaTime = currentTime - _previousTime;
			_previousTime = currentTime;

			Vector3 position = Input.mousePosition;
			Vector3 deltaPosition = position - _previousPosition;
			_previousPosition = position;

			TouchPhase phase = TouchPhase.Canceled;
			if (Input.GetMouseButtonDown(0))
			{
				phase = TouchPhase.Began;
				_startPosition = position;
			}
			else if (Input.GetMouseButtonUp(0))
			{
				if (_startPosition == position)
					phase = TouchPhase.Stationary;
				else
					phase = TouchPhase.Ended;
			}
			else if (Input.GetMouseButton(0))
			{
				//if (deltaPosition != Vector2.zero)
				phase = TouchPhase.Moved;

			}

			int tapCount = _previousTapCount + 1;
			_previousTapCount = tapCount;

			return new WHumanInput(deltaPosition, deltaTime, 0, phase, position, tapCount);
		}

		internal bool hasInput()
		{
			int button = 0;
			return Input.GetMouseButtonDown(button) || 
				(Input.GetMouseButton(button) && (_previousPosition != Input.mousePosition)) ||
				Input.GetMouseButtonUp(button);
		}
	}

	private static WPreviousInputState _PreviousMouseState = new WPreviousInputState();

	public static bool HasInput()
	{
		return _PreviousMouseState.hasInput();
	}

	public static WHumanInput GetInput()
	{
		return _PreviousMouseState.generateMouseInput();
	}



}

