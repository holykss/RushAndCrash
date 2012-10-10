using UnityEngine;
using System.Collections;

public class test : MonoBehaviour {
	
	
	
void OnMouseDown()
{
  //  screenPoint = Camera.main.WorldToScreenPoint(scanPos);

  //  offset = scanPos - Camera.main.ScreenToWorldPoint(
    //    new Vector3(Input.mousePosition.x, Input.mousePosition.y, screenPoint.z));
		Debug.Log("aaaaa");
}


void OnMouseDrag()
{
   // Vector3 curScreenPoint = new Vector3(Input.mousePosition.x, Input.mousePosition.y, screenPoint.z);

   // Vector3 curPosition = Camera.main.ScreenToWorldPoint(curScreenPoint) + offset;
   // Camera.main.transform.position = curPosition;
		Debug.Log("bbbbb");
}
}
