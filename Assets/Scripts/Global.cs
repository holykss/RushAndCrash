using UnityEngine;
using System.Collections;

public class Global : MonoBehaviour {
	
	public UILabel minionCount = null;
	public GameObject minion = null;

	// Update is called once per frame
	void Update () {
		
		input();
		updateGui();
	}
	
	void input()
	{
		//camera zoom
		updateZoomInOut();

		updateTouch();
	}

	private static void updateZoomInOut()
	{
		if (Input.GetAxis("Mouse ScrollWheel") < 0)
		{
			Camera.main.fieldOfView += 2;
		}
		else if (Input.GetAxis("Mouse ScrollWheel") > 0)
		{
			Camera.main.fieldOfView -= 2;
		}
	}

	Vector3 _startRayPosition = Vector3.zero;

	private void updateTouch()
	{
		if (WInput.HasInput() == false)
			return;

		WHumanInput input = WInput.GetInput();

		if (input.phase == TouchPhase.Stationary)
		{
			Ray ray = Camera.mainCamera.ScreenPointToRay(input.position);
			RaycastHit hitInfo = new RaycastHit();

			if (Physics.Raycast(ray, out hitInfo))
				generationMinionWithPosition(hitInfo.point);
		}
		else if (input.phase == TouchPhase.Began)
		{
			Ray ray = Camera.mainCamera.ScreenPointToRay(input.position);
			RaycastHit hitInfo = new RaycastHit();

			if (Physics.Raycast(ray, out hitInfo))
				_startRayPosition = hitInfo.point;
			else
				_startRayPosition = Vector3.zero;
		}
		else if (_startRayPosition != Vector3.zero && input.phase == TouchPhase.Moved)
		{
			Ray ray = Camera.mainCamera.ScreenPointToRay(input.position);
			RaycastHit hitInfo = new RaycastHit();

			if (Physics.Raycast(ray, out hitInfo))
			{
				Vector3 newPosition = hitInfo.point;

				Vector3 touchDeltaPosition = newPosition - _startRayPosition;
				touchDeltaPosition.y = 0;
				
				Camera.mainCamera.transform.position -= touchDeltaPosition;

				Debug.Log("camera(" + Camera.mainCamera.transform.position + ") start(" + _startRayPosition + ") new(" + newPosition + ") deltaPosition (" + touchDeltaPosition + ")");
			}

		}

	}


	
	void generationMinionWithPosition(Vector3 position)
	{
		Debug.Log("create Minion)");
		Instantiate(minion, position, minion.transform.rotation);
	}
	
	void updateGui()
	{
		minionCount.text = "minionCount : " + GameObject.FindGameObjectsWithTag("MINION").Length;
	}	
}
