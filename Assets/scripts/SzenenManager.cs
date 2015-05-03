using UnityEngine;
using System.Collections;

public class SzenenManager : MonoBehaviour {

	/**
	 * Zeige das traurige Ende.
	 */
	public static void spielVerloren ()
	{
		Debug.Log ("spielVerloren");
		Application.LoadLevel ("Ende");
	}

	/**
	 * Zeige das "Happy" Ende.
	 */
	public static void spielGewonnen ()
	{
		Debug.Log ("spielGewonnen");
		Application.LoadLevel ("HappyEnd");
	}

	/**
	 * Starte Spiel. 
	 */
	public static void spielStarten ()
	{
		Debug.Log ("spielStarten");
		Application.LoadLevel ("Spiel");
	}
}
