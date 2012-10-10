using UnityEngine;
using System.Collections;

public class Global : MonoBehaviour {

	public GameObject spartanKing = null;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		
		if (spartanKing != null && Input.GetButtonDown("Fire1"))
		{
			Ray ray = Camera.mainCamera.ScreenPointToRay(Input.mousePosition);
			RaycastHit hitInfo = new RaycastHit();

			if (Physics.Raycast(ray, out hitInfo))
			{
				Instantiate(spartanKing, hitInfo.point, transform.rotation);
			}
		}
		
		input();
	
	}
	
	void input()
	{
		
		//camera zoom
		if(Input.GetAxis("Mouse ScrollWheel") < 0)
		{
			Camera.main.fieldOfView++;
		}
		else if(Input.GetAxis("Mouse ScrollWheel") > 0)
		{
			Camera.main.fieldOfView--;
		}
		
		//camara drag
		bool mouseLButton = Input.GetMouseButton(0);
		
		if(mouseLButton)
		{
			Vector3 position = new Vector3(Input.GetAxis("Mouse X"), 0, Input.GetAxis("Mouse Y"));
			Debug.Log("position : " + position.ToString());
			Camera.main.transform.position -= position;
		}
	}

	
}
