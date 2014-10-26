//private var todennakoisyys:int = 0;

function OnCollisionEnter (myCollision : Collision){

	
	// "testi" tilalle laitetaan kyseinen bossitaistelu
	if(myCollision.gameObject.name == "BOSS"){
	Application.LoadLevel("testi");
	}
	
	if(myCollision.gameObject.name == "BOSS2"){
	Application.LoadLevel("testi");
	}
	
	if(myCollision.gameObject.name == "Enqounter"){
	Application.LoadLevel("testi");
	}
	
	//if(myCollision.gameObject.name == "Enqounter"){
	//todennakoisyys++;
	//Application.LoadLevel("testi);		
	//}
	//if(todennakoisyys>5){
		//todennakoisyys =0;
		
		//}

}