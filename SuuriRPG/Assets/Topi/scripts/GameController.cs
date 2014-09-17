using UnityEngine;
using System.Collections;

public class GameController : MonoBehaviour {

	public GameObject pelaaja;
	public GameObject vihollinen;

	void Start () {
		Instantiate (pelaaja, new Vector3 (-4, 1, 0), new Quaternion ());
		Instantiate(vihollinen, new Vector3(4,1,0),new Quaternion());
	}

	void Update (){
		StartCoroutine (Tappelu());
	}

	IEnumerator Tappelu(){
		bool juu = GameObject.Find ("Pelaaja").GetComponent<Agent> ().valittu;
		print (juu);
		while (!juu){
			Debug.Log ("2");
			juu = GameObject.Find ("Pelaaja").GetComponent<Agent> ().valittu;
			yield return null;
		}

		//while (!vihollinen.GetComponent("valittu")) {
		//	yield return null;
		//}
		//Debug.Log ("2");

	}

	

}
