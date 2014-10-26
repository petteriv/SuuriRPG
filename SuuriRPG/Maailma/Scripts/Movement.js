private var jumpSpeed:float = 18.0;
private var gravity:float = 32.0;
private var runSpeed:float = 50.0;
private var walkSpeed:float = 45.0;
private var rotateSpeed:float = 100.0;

private var grounded:boolean = false;
private var moveDirection:Vector3 = Vector3.zero;
private var isWalking:boolean = false;
private var moveStatus:String = "idle";



function Update ()
{


	if(grounded) {
		moveDirection = new Vector3((Input.GetMouseButton(1) ? Input.GetAxis("Horizontal") : 0),0,Input.GetAxis("Vertical"));
		
		moveDirection = transform.TransformDirection(moveDirection);
		moveDirection *= isWalking ? walkSpeed : runSpeed;
		
		moveStatus = "idle";
		if(moveDirection != Vector3.zero)
			moveStatus = isWalking ? "walking" : "running";

		if (Input.GetKeyDown(KeyCode.Space))
		
			moveDirection.y = jumpSpeed;
	}
	
	
	if(Input.GetMouseButton(1)) {
		transform.rotation = Quaternion.Euler(0,Camera.main.transform.eulerAngles.y,0);
	} else {
		transform.Rotate(0,Input.GetAxis("Horizontal") * rotateSpeed * Time.deltaTime, 0);
		
	}

	
	//painovoima
	moveDirection.y -= gravity * Time.deltaTime;

	
	//Move controller
	var controller:CharacterController = GetComponent(CharacterController);
	var flags = controller.Move(moveDirection * Time.deltaTime);
	grounded = (flags & CollisionFlags.Below) != 0;
	

	
	
	
	
	
}

@script RequireComponent(CharacterController)