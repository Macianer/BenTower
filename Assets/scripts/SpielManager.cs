using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class SpielManager : MonoBehaviour
{
	// definiere feste Werte
	private static int MAXIMAL_ANZAHL_DER_KUGELN = 4;
	private static int MAXIMAL_ANZAHL_DER_FEINDE = 1;
	private static int MAXIMAL_ANZAHL_ZUTREFFENDER_FEINDE = 2;
	private static float ANNAEHERUNGSRATE_DER_FEINDE = 0.0005f;
	private static float MINIMAL_RADIUS = 3.0f;
	private static float MAXIMAL_RADIUS = 8.0f;
	public GameObject obererTurm;
	public GameObject schiessAparat1;
	public GameObject schiessAparat2;
	public GameObject schiessAparat3;
	public GameObject schiessAparat4;
	public Text getroffenenFeindeText;
	public Material ringMaterial;
	public Material discMaterial;
	public Slider powerSlider;
	private float getroffenenFeinde = 0;
	private float drehGeschwindigkeit = 0.5f;

	/**
	* Objekt welches emitiert wird. 
	*/
	private GameObject explodierendesObjekt ;
	private GameObject kanonenKugel;
	private GameObject feindObject;
	private GameObject naeherungsZone;
	private GameObject naeherungsRing;
	private bool schussBeendet;

	/**
	 * Eine Liste mit aktive Geschossen. 
	 */
	private ArrayList geschosseneKugeln;

	/**
	 * Eine Liste mit Objekten aus denen geschossen werden kann. 
	 */
	private ArrayList schiessAparate;
	private ArrayList feinde;
	private float tasteGedrücktZeit;

	// Start-funktion zum Setzen der ersten Parameter. 
	void Start ()
	{
		// lade Kanonen-Kugel  
		kanonenKugel = (GameObject)Resources.Load ("CannonSphere",
		                                                      typeof(GameObject));
		if (kanonenKugel != null) {
			Debug.Log ("KanonenKugel gefunden");
		}
				
		feindObject = (GameObject)Resources.Load ("Enemy", typeof(GameObject)); 
		// Konfiguriere eine Liste von geschosssenen Kugel ein.
		geschosseneKugeln = new ArrayList (MAXIMAL_ANZAHL_DER_KUGELN);
				
		// Konfiguriere eine Liste der Feinde ein.
		feinde = new ArrayList (MAXIMAL_ANZAHL_DER_FEINDE);

		konfiguriereSchiessAparate ();
		obererTurm.GetComponent<Animation> ().Play ("Init");
		schiessAparat1.GetComponent<Animation> ().Play ("KanoneAusfahren");
		schiessAparat2.GetComponent<Animation> ().Play ("KanoneAusfahren");
		schiessAparat3.GetComponent<Animation> ().Play ("KanoneAusfahren");
		schiessAparat4.GetComponent<Animation> ().Play ("KanoneAusfahren");

		naeherungsRing = erzeugeObjekt (new Vector3 (0.0f, 0.01f, 0.0f), ringMaterial);

		getroffenenFeindeText.text = getroffenenFeinde.ToString ();

		explodierendesObjekt = (GameObject)Resources.Load ("Explode",
		typeof(GameObject));
	}
		
	/** 
	 * Hier werden die Objekt, welche schiessen können zu geordnet.
	 */
	void konfiguriereSchiessAparate ()
	{
		// richte eine Liste von Schiess-Aparaten ein.
		schiessAparate = new ArrayList (MAXIMAL_ANZAHL_DER_KUGELN);
		// setzte erstes Objekt in die Liste; 
		schiessAparate.Add (schiessAparat1);
		// setzte zweites Objekt in die Liste; 
		schiessAparate.Add (schiessAparat2);
		// setzte drittes Objekt in die Liste; 
		schiessAparate.Add (schiessAparat3);
		// setzte viertes Objekt in die Liste; 
		schiessAparate.Add (schiessAparat4);
	}

	/** Die Update-Funktion wird zu dem Frame ausgeführt. Die meisten Spiele laufen mit etwa 60 frame per second, also 60 bilder pro Sekunde. 
	* Bei jedem neuem Bild oder Frame wird diese Funktion vom System aufgerufen. 
	 */
	void Update ()
	{
		float rotiereUm = Input.GetAxis ("Horizontal");

		dreheOberenTurm (rotiereUm * drehGeschwindigkeit);

		// Space-Taste wird gedrückt
		// Die Space-Taste ist die lange Taste auf der Tastatur
		if (Input.GetKeyDown (KeyCode.Space)) {
			// merke Zeit wann gedrückt wurde 
			tasteGedrücktZeit = Time.realtimeSinceStartup;
			schussBeendet = false;
		} 

		// berechne Zeit zwischen gedrückten und losgelassenen Taste 
		float zeitlicheDifferenz = Time.realtimeSinceStartup - tasteGedrücktZeit;
		float schiessStärke = Mathf.Clamp (zeitlicheDifferenz, 0, 1);

		// Space-Taste wird losgelassen
		if (Input.GetKeyUp (KeyCode.Space)) {
						
			schussBeendet = true;
						
			// gehe durch die Liste aller Schiessaparate und löse 
			// einen Schuss aus
			foreach (GameObject go in schiessAparate) {
				// prüfe ob das Objektschuss bereit ist.
				if (istSchiessBereit (go))
					schiessenVon (go, schiessStärke * 10);
			}
		}
		if (powerSlider != null && !schussBeendet) {
			powerSlider.value = schiessStärke;
		}
		// lass die Feinde näher kommen
		feindeKommenNäher ();
				
		// fügen ein Feindobjekt hinzu, 	
		if (feinde.Count < MAXIMAL_ANZAHL_DER_FEINDE) {
			erzeugeFeindObjekt ();
		}	
	}

	/**
	 * Erzeuge neue Feindobjekt in einem bestimmten Radius. 
	 */
	void erzeugeFeindObjekt ()
	{
		// definiert den Radius  
		float radius = MAXIMAL_RADIUS;
		float höheFeindObjekt = 0.5f;
		Vector3 punkt = new Vector3 (radius, höheFeindObjekt, 0.0f);
		float random = Random.Range (-Mathf.PI / 2, Mathf.PI / 2);
		punkt = Quaternion.Euler (0, Mathf.Rad2Deg * random, 0) * punkt;
		GameObject feind = (GameObject)Instantiate (this.feindObject, punkt, new Quaternion ());
		feinde.Add (feind);
			
	}
	
	/**
	 * Eine Funktion die feindliche Objekten näher kommen lässt. 
	 * Alle Objekte in der "feinde" Liste kommen ein kleines Stückchen näher.
	 * 
	 */
	void feindeKommenNäher ()
	{
		float minDistance = float.MaxValue;

		GameObject minObjekt = null;

		// manipuliere alle feindliche Objekte in der "feinde"-Liste.
		foreach (GameObject feindObjekt in this.feinde) {

			// bestimme Vektor des jeweiligen feindlichen Objektes
			Vector3 vektor1 = feindObjekt.transform.position;

			// bestimmte Vektor als Ziel
			Vector3 vektor2 = new Vector3 (0, feindObjekt.transform.position.y, 0);

			// bestimme die Annäherung zwischen zwei Vektoren um einem bestimmten Wert.
			Vector3 vektor3 = Vector3.Lerp (vektor1, vektor2, ANNAEHERUNGSRATE_DER_FEINDE);

			// gib den jeweiligen feindliche Objekt die errechnete Position.
			feindObjekt.transform.position = vektor3;

			// bestimme Abstand zwischen Ziel und aktueller Position 
			float curDistance = Vector3.Distance (vektor2, vektor3);

			// finde Objekt welches dem Ziel am nähesten ist. 
			if (curDistance < minDistance) {
				minDistance = curDistance;
				minObjekt = feindObjekt;
			}
		}

		//behandleNäherungsbereiche (minDistance);

		// wenn das näheste Objekt den Endzone erreicht, ist das Spiel beendet.
		if (minDistance <= MINIMAL_RADIUS && minObjekt != null) {
			endZoneErreicht (minObjekt);
		}
		float scale = minDistance / 4.5f;
		naeherungsRing.transform.localScale = new Vector3 (scale, scale, scale);

		var intense = getInterpolateDistance (minDistance, MAXIMAL_RADIUS, MINIMAL_RADIUS);

		float r = Mathf.Clamp01 (intense);
		naeherungsRing.GetComponent<Renderer> ().material.color = new Color (1.0f, 0.0f, 0.0f, r);
	}

	static float getInterpolateDistance (float distance, float maxRadius, float minRadius)
	{
		float diff = maxRadius - minRadius;
		float intense = (diff - (distance - minRadius)) / diff;
		return intense;
	}

	bool istSchiessBereit (GameObject t)
	{		
		int identifikationsnummer = schiessAparate.IndexOf (t);
		return istSchiessBereit (identifikationsnummer);
	}

	bool istSchiessBereit (int identifikationsnummer)
	{	
		object[] gos = geschosseneKugeln.ToArray ();
		Debug.Log ("istSchiessBereit() geschosseneKugeln array length:" + gos.Length + "id:" + identifikationsnummer);
		if (gos.Length == 0 || identifikationsnummer >= gos.Length) {
			Debug.Log ("istSchiessBereit() Abbruch ");
			return true;
		}
		object go = gos [identifikationsnummer];
		if (go == null) {
			Debug.Log ("istSchiessBereit() true ");
			return true;
		} else {
			Debug.Log ("istSchiessBereit() false ");
			return false;
		}	
	}
	/**
		 * Drehe oberen Turm um Y-Achse um den eingehende Wert.
	 	 */
	void dreheOberenTurm (float rotiereUm)
	{
		if (obererTurm != null) {
			Quaternion rotQuad = obererTurm.transform.localRotation;
			rotQuad.eulerAngles += new Vector3 (0.0f, rotiereUm, 0.0f);	
			obererTurm.transform.localRotation = rotQuad;	
		}
				
	}

	/**
	 * Schiesse eine Kugel vom Ursprungsobjekt ab.
	 * Das Urspungsobjekt muss aus der Liste der Schiessaparate stammen.
	 */
	void schiessenVon (GameObject ursprungsObjekt, float schiessGeschwindigkeit)
	{	
		ursprungsObjekt.GetComponent<Animation> ().Play ("Schuss");


		// prüfe ob die Kanonenkugel und das Ursprungsobjekt in Ordnung sind.
		if (kanonenKugel != null && ursprungsObjekt != null) {
			erzeugeGeschoss (ursprungsObjekt, schiessGeschwindigkeit);
		} else {
			Debug.LogWarning ("schiessenVon() hat Probleme");
		}
				
	}
		
	void erzeugeGeschoss (GameObject ursprungsObjekt, float schiessGeschwindigkeit)
	{
		Vector3 childPos = ursprungsObjekt.transform.GetChild (0).transform.position;
		GameObject geschoss = (GameObject)Instantiate (kanonenKugel, childPos, new Quaternion ());
		
		geschoss.GetComponent<Rigidbody> ().velocity = ursprungsObjekt.transform.TransformDirection (Vector3.forward * schiessGeschwindigkeit);
		GeschossAktionen script = geschoss.GetComponent<GeschossAktionen> ();
		script.Manager = this;
		
		int identifikationsnummer = schiessAparate.IndexOf (ursprungsObjekt);
		geschosseneKugeln.Insert (identifikationsnummer, geschoss);
	}
		
	/**
		 * Behandle aufruf von OnTriggerEnter vom GeschossAktionen
		 * .cs
	 	*/
	public void landetAufDemBoden (GameObject kanonenKugel)
	{

		Vector3 pos = new Vector3 (kanonenKugel.transform.position.x, 0.01f, kanonenKugel.transform.position.z);
		zeigeExplosion (pos);

		// Kanonenkugel wird aus der Liste der geschossenen Kugeln gelöscht.
		this.geschosseneKugeln.Remove (kanonenKugel);

		// Kanonenkugel wird aus der Szene gelöscht.
		Destroy (kanonenKugel);



	}

	void zeigeExplosion (Vector3 position)
	{
		// Erzeuge ein neues explodierende
		GameObject o = (GameObject)Instantiate (
			explodierendesObjekt);

		o.GetComponent<Animation> ().Play ("explode");
		Animation ani = o.GetComponent<Animation> ();

		float animationsDauer = ani.GetClip ("explode").length;


		GameObject parent = new GameObject ();
		o.transform.parent = parent.transform;

		parent.transform.position = position;
		float scale = 0.1f;
		parent.transform.localScale = new Vector3 (scale, scale, scale);

		StartCoroutine (ZerstöreObjekt (parent, animationsDauer));
	}

	private IEnumerator ZerstöreObjekt (GameObject o, float sekunden)
	{
		yield return new WaitForSeconds (sekunden);
		Destroy (o);
	}

	public void feindGetroffen (GameObject feind)
	{
		if (feind != null) {

			zerstöreFeind (feind);

			// zähle getroffene Feindeanzahl um eins hoch
			getroffenenFeinde++;

			getroffenenFeindeText.text = getroffenenFeinde.ToString ();
			if (getroffenenFeinde > MAXIMAL_ANZAHL_ZUTREFFENDER_FEINDE) {
				SzenenManager.spielGewonnen ();
			}
		}
	}

	public void endZoneErreicht (GameObject kanonenKugel)
	{
		Debug.Log ("endZoneErreicht");
		SzenenManager.spielVerloren ();
	}

	void zerstöreFeind (GameObject feindObjekt)
	{
		// entferne das Feindobjekt aus der Liste der Feinde
		feinde.Remove (feindObjekt);
		// zerstöre das Feindobjekt
		Destroy (feindObjekt);
	}

	GameObject erzeugeObjekt (Vector3 position, Material material)
	{
		GameObject objekt = GameObject.CreatePrimitive (PrimitiveType.Plane);
		if (material != null) {
			objekt.GetComponent<Renderer> ().material = material;
		}

		objekt.transform.position = position;

		return objekt;
	}	
}
