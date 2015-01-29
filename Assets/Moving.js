#pragma strict

var speedX: float=5;
var speedY: float=5;

function Update () {

	if(Input.GetMouseButtonDown(0)){
		Debug.Log("Pressed Left mouse button");
		//Debug.Log(Input.mousePosition);
		
		//Vector3 mousePos = Input.mousePosition;
		//var mouseXPos: float=mousePos[0];
		//var mouseYPos: float=mousePos[1];
		
		
		//rigidbody2D.velocity.y=speedY;
		//rigidbody2D.velocity.x=speedX;
		
		
		
		move2();
		

		
	}


}

function move(){

		var mouseXPos: float=Input.mousePosition.x;
		var mouseYPos: float=Input.mousePosition.y;
	
		var objXPos: float = transform.position.x;
		var objYPos: float = transform.position.y;
		
		
		
		while(objXPos!=mouseXPos && objYPos!=mouseYPos){
		
			var curSpeedX=speedX;
			var curSpeedY=speedY;
		
			yield WaitForSeconds(0.1);
		
			var diffX=abs(mouseXPos-objXPos);
			var diffY=abs(mouseYPos-objYPos);
			
			if(diffX<curSpeedX){
				curSpeedX=diffX;
			}
			if(diffY<curSpeedY){
				curSpeedY=diffY;
			}
		
			if(mouseXPos<objXPos){
				objXPos=objXPos-curSpeedX;
			}
			else if(mouseXPos>objXPos){
				objXPos=objXPos+curSpeedX;
			}
			if(mouseYPos<objYPos){
				objYPos=objYPos-curSpeedY;
			}
			else if(mouseYPos>objYPos){
				objYPos=objYPos+curSpeedY;
			}

			//Debug.Log("New xPos "+objXPos);
			//Debug.Log("New yPos "+objYPos);
			Debug.Log(transform.position);

			//var newZ=transform.position.z - Camera.main.transform.position.z;
			//var pos=new Vector3(objXPos,objYPos,0);
			//transform.position = pos;
		
			//Camera.main.Render;
		}

}

function move2(){

		var mouseXPos: float=Input.mousePosition.x;
		var mouseYPos: float=Input.mousePosition.y;
	
		var objXPos: float = transform.position.x;
		var objYPos: float = transform.position.y;
		
		while(objXPos!=mouseXPos && objYPos!=mouseYPos){
		
			var curSpeedX=speedX;
			var curSpeedY=speedY;
		
			yield WaitForSeconds(0.1);
		
			var diffX=abs(mouseXPos-objXPos);
			var diffY=abs(mouseYPos-objYPos);
			
			if(diffX<curSpeedX){
				curSpeedX=diffX;
			}
			if(diffY<curSpeedY){
				curSpeedY=diffY;
			}
		
			if(mouseXPos<objXPos){
				objXPos=objXPos-curSpeedX;
			}
			else if(mouseXPos>objXPos){
				objXPos=objXPos+curSpeedX;
			}
			if(mouseYPos<objYPos){
				objYPos=objYPos-curSpeedY;
			}
			else if(mouseYPos>objYPos){
				objYPos=objYPos+curSpeedY;
			}

			//Debug.Log("New xPos "+objXPos);
			//Debug.Log("New yPos "+objYPos);
			Debug.Log("Object position: "+transform.position);

			var newZ=transform.position.z - Camera.main.transform.position.z;
			var pos=new Vector3(objXPos,objYPos,newZ);
			rigidbody2D.MovePosition(pos);
			//transform.position = pos;
		
			//Camera.main.Render;
		}

}

function abs(num){

	var res: float=num;

	if(res<0){
	res=res*-1.0;
	}
	return res;
}
