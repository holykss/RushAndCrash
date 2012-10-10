using UnityEngine;
using System.Collections;

public class test : MonoBehaviour {
	
	Vector3 offset;
	
	void OnMouseDown()
	{
		Debug.Log("다운 들어왔다");
		offset = Camera.mainCamera.transform.position - Camera.mainCamera.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, 0, Input.mousePosition.z));
	}
	void OnMouseDrag()
	{
		Vector3 curScreenPosition = new Vector3(Input.mousePosition.x, 0, Input.mousePosition.z);
		Vector3 curPosition = Camera.mainCamera.ScreenToWorldPoint(curScreenPosition) + offset;
		
		Camera.mainCamera.transform.position = curPosition;
	}
}
