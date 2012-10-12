using UnityEngine;
using System.Collections;

public class Global : MonoBehaviour {

	public GameObject minion = null;
	private bool mouseDrag = false;
	

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		
		input();
	}
	
	void input()
	{
		//camera zoom
		if(Input.GetAxis("Mouse ScrollWheel") < 0)
		{
			Camera.main.fieldOfView += 2;
		}
		else if(Input.GetAxis("Mouse ScrollWheel") > 0)
		{
			Camera.main.fieldOfView -= 2;
		}
		
		//camara drag
		bool mouseLButton = Input.GetMouseButton(0);
		
		if(mouseLButton)
		{
			Vector3 position = new Vector3(Input.GetAxis("Mouse X"), 0, Input.GetAxis("Mouse Y"));
			Debug.Log("position : " + position.ToString());
			Camera.main.transform.position -= position;
				
			float distance = (new Vector3(0, 0, 0) - position).sqrMagnitude;
			Debug.Log("distance : " + distance.ToString());
			
			if(distance >= 0.01f)
				mouseDrag = true;
		}
		else
		{
			if(mouseDrag == false)
				generationMinion();	
			
			mouseDrag = false;
		}	
	}
	
	void generationMinion()
	{
		if (minion != null && Input.GetMouseButtonUp(0))
		{
			Debug.Log("create Minion)");
			Ray ray = Camera.mainCamera.ScreenPointToRay(Input.mousePosition);
			RaycastHit hitInfo = new RaycastHit();

			if (Physics.Raycast(ray, out hitInfo))
			{
				Instantiate(minion, hitInfo.point, transform.rotation);
			}
		}
	}

	
}
