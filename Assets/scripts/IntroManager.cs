using UnityEngine;
using System.Collections;

public class IntroManager : MonoBehaviour
{
	public GameObject obererTurm;
	public GameObject schiessAparat1;
	public GameObject schiessAparat2;
	public GameObject schiessAparat3;
	public GameObject schiessAparat4;

	private float drehGeschwindigkeit = 0.5f;

	/**
	 * Eine Liste mit Objekten aus denen geschossen werden kann. 
	 */
	private ArrayList schiessAparate;

	// Use this for initialization
	void Start ()
	{
		konfiguriereSchiessAparate ();
		obererTurm.GetComponent<Animation> ().Play ("Init");
	
		schiessAparat1.GetComponent<Animation> ().Play ("KanoneAusfahren");
		schiessAparat2.GetComponent<Animation> ().Play ("KanoneAusfahren");
		schiessAparat3.GetComponent<Animation> ().Play ("KanoneAusfahren");
		schiessAparat4.GetComponent<Animation> ().Play ("KanoneAusfahren");

	}
		
	void konfiguriereSchiessAparate ()
	{
		// richte eine Liste von Schiess-Aparaten ein.
		schiessAparate = new ArrayList (4);
		// setzte erstes Objekt in die Liste; 
		schiessAparate.Add (schiessAparat1);
		// setzte zweites Objekt in die Liste; 
		schiessAparate.Add (schiessAparat2);
		// setzte drittes Objekt in die Liste; 
		schiessAparate.Add (schiessAparat3);
		// setzte viertes Objekt in die Liste; 
		schiessAparate.Add (schiessAparat4);
	}

	// Update is called once per frame
	void Update ()
	{
		dreheOberenTurm (drehGeschwindigkeit);			
	}

	/**
	 * Drehe oberen Turm um Y-Achse um den eingehende Wert.
	 */
	void dreheOberenTurm (float rotiereUm)
	{
		// prüfe ob der "obererTurm" wirklich existiert
		if (obererTurm != null) {
			// hole den aktuellen Rotationswert
			Quaternion rotQuad = obererTurm.transform.localRotation;
			// addiert den "rotiereUm"-Wert zur aktuellen Rotation 
			rotQuad.eulerAngles += new Vector3 (0.0f, rotiereUm, 0.0f);	
			// setzt die neuerrechnete Rotation
			obererTurm.transform.localRotation = rotQuad;	
		}
				
	}

}
