using UnityEngine;
using System.Collections;

public class ObjektAktionen : MonoBehaviour
{

	// Use this for initialization
	void Start ()
	{
	
	}
	
	// Update is called once per frame
	void Update ()
	{
		if (Input.touchCount == 1) {
			if (Input.GetTouch (0).phase == TouchPhase.Ended) {
				Ray ray = Camera.main.ScreenPointToRay
					(Input.GetTouch (0).position);
				RaycastHit hit = new RaycastHit ();
				if (Physics.Raycast (ray, out hit, 100.0f)) {
					OnMouseUp ();
				}
			}
		}
	}

	void OnMouseUp ()
	{
		SzenenManager.spielStarten ();
	}
	void OnGUI()
	{
		GUILayout.Button("OK");
		GUILayout.FlexibleSpace();
		GUILayout.EndHorizontal();
		GUILayout.FlexibleSpace();
		GUILayout.EndArea();
	}
}
