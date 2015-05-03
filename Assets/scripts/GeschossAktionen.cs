using UnityEngine;
using System.Collections;

public class GeschossAktionen : MonoBehaviour {

	private SpielManager manager;


	public SpielManager Manager {
		get {
			return manager;
		}
		set {
			manager = value;
		}
	}

	/**
	 *	Hier werden alle Kollisionen mit der Szene behandelt. 
	 */
	void OnTriggerEnter (Collider other)
	{
		// Wenn die Kugel ein Objekt trifft, welches mit dem Name "Enemy" beginnt,
		// wird im SpielManager die Methode <code>feindGetroffen(GameObject other)</code> 
		// aufgerufen. 
		if(other.gameObject.name.StartsWith ("Enemy")) {
			manager.feindGetroffen (other.gameObject);
		}	
		// Wenn die Kugel ein Objekt trifft, welches mit den Tag "finish" hat,
		// wird im SpielManager die Methode <code>landetAufDemBoden(GameObject other)</code> 
		// aufgerufen. 
		if (other.gameObject.tag == "Finish") {
			manager.landetAufDemBoden (this.gameObject);
		}
	}
}