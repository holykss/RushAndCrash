using UnityEngine;
using System.Collections;

public class Global : MonoBehaviour {

	public GameObject spartanKing;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetButtonDown("Fire1"))
		{
			Ray ray = Camera.mainCamera.ScreenPointToRay(Input.mousePosition);
			RaycastHit hitInfo = new RaycastHit();

			if (Physics.Raycast(ray, out hitInfo))
			{
				Instantiate(spartanKing, hitInfo.point, transform.rotation);
			}
		}
	
	}

	
}
