using UnityEngine;
using System.Collections;

public class Character : MonoBehaviour {

	public bool valmis;
	public bool valittu;
	public ISkill ChosenSkill=null;

	void Start(){
		valmis = true;
	}

	public IEnumerator Move(Vector3 vector){     //liikutetaan kohde tiettyyn pisteeseen
		valmis = false;
		while(Vector3.Distance(transform.position, vector) > 1.5f)       //kuinka lähelle mennään
			{
			transform.position = Vector3.Lerp(transform.position, vector, 1f * Time.deltaTime);  //liikkuttaa smoothisti hahmoa
			if (valmis){
			yield break;
			} else {
			yield return null;
				}
			}
		valmis=true;
		}

	void OnTriggerEnter(Collider other){   //pitäisi pysäyttää ekaan ei-kaveriin;
		if(other.tag!=this.tag){
		valmis = true;
		}
		}

	void OnMouseDown(){
		valittu = true;
	}

	public IEnumerator ChooseSkill(){
		yield return null;
	}

	public ISkill GetSkill(){
		return ChosenSkill;
	}

}
