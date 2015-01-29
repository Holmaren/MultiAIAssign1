#pragma strict

var speedX: float=0.1;
var speedY: float=0.1;

function Update () {

	//If left mouse is pressed
	if(Input.GetMouseButtonDown(0)){
	
		Debug.Log("Left Mouse down. Position:"+Input.mousePosition);
		//var realMousePos=Camera.main.ScreenToWorldPoint(Input.mousePosition);
		//Debug.Log("Real Mouse Pos "+realMousePos);
		
		move();
		
	
	}
	
	


}

function move(){

		var inputPosition: Vector3 = Input.mousePosition; 
		var wMousePos: Vector3 = Camera.mainCamera.ScreenToWorldPoint(new Vector3(inputPosition.x, inputPosition.y, Camera.main.transform.position.z - 2f));

		var mouseXPos: float=wMousePos.x;
		var mouseYPos: float=wMousePos.y;
	

		//var worldMousePos=Camera.main.ScreenToWorldPoint(Input.mousePosition);

		//var mouseXPos: float=worldMousePos[0];
		//var mouseYPos: float=worldMousePos[1];
	
		var objXPos: float = transform.position.x;
		var objYPos: float = transform.position.y;
		
		while(objXPos!=mouseXPos || objYPos!=mouseYPos){
		
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
			//Debug.Log(transform.position);

			//var newZ=transform.position.z - Camera.main.transform.position.z;
			var pos=new Vector3(objXPos,objYPos,0);
			Debug.Log("Pos="+pos);
			transform.position = pos;
		
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