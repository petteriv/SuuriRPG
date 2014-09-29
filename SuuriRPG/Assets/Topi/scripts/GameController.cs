using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class GameController : MonoBehaviour {

	public PlayerCharacter pelaaja;
	public PlayerCharacter pelaaja2;
	public EnemyCharacter vihollinen;
	public EnemyCharacter vihollinen2;
	int i;
	List<Character> tappelijat = new List<Character>();//lista tappelussa olevista
	bool vuoro=true;    //tarkistaa onko joku suorittamassa vuoroa

	void Start () {


		tappelijat.Add (pelaaja);
		tappelijat.Add (pelaaja2);
		tappelijat.Add (vihollinen);
		tappelijat.Add (vihollinen2);
		i = 0;

	}

	void Update(){

		Character aktiivinen = tappelijat [i];
		if (vuoro){
			Debug.Log (i);
			print (aktiivinen);
		StartCoroutine(Vuoronhoito(aktiivinen));   //suorittaa vuorossa olevan hahmon vuoron
		}
	}

	IEnumerator Vuoronhoito(Character aktiivinen){  //siivottava
		vuoro = false;
		ISkill skill = new MoveSkill();
		//aktiivinen.ChooseSkill ();      //valitaan taito, jonka hahmo tekee
		//while (skill==null) {
		//	skill=aktiivinen.GetSkill();
		//	yield break;
		//		}

		Character kohde=null;        //valitaan kohde, pitää muokata jos taito kohdistaa kaveria/eiketään
		while(kohde==null){
			foreach (Character hahmo in tappelijat) {
				if ( hahmo.tag!=aktiivinen.tag&&hahmo.valittu){
					kohde=hahmo;
					break;
				}
			}
			yield return null;
		}
		if (skill.Do (aktiivinen, kohde)) {
			StartCoroutine(aktiivinen.Move(kohde.transform.position));
				}
		i++;                           //seuraava hahmo
		if (i == tappelijat.Count) {
			i = 0;
		}

		while (!aktiivinen.valmis) {
			yield return null;		
		}
		foreach (Character hahmo in tappelijat) {
			hahmo.valittu=false;
			hahmo.valmis=false;
				}

		vuoro = true;
		yield return null;
		}


}