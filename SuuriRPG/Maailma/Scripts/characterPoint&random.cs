using UnityEngine;
using System.Collections;

public class characterInfo : MonoBehaviour
{

	Vector3 currentPosition;
	Vector3 alkuPiste;
		//tänne voisi tallentaa hahmojen tiedot ja ylläpitää HP tiedot yms
		void Start ()
		{

		currentPosition = transform.TransformPoint(Vector3.zero);
		alkuPiste = currentPosition;
		//if(currentPosition 
		}
	
		
		void Update ()
		{
		//tässä PITÄISI olla tallessa hahmon sijainti kartalla
		currentPosition = transform.TransformPoint(Vector3.zero);

		}
}

