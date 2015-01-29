#pragma strict



var speedX: float=0.1;
var speedY: float=0.1;
var points: Vector3[];

function Start () {

	points=new Vector3[5];
	points[0]=Vector3(0,0,0);
	points[1]=Vector3(2,2,0);
	points[2]=Vector3(-2,2,0);
	points[3]=Vector3(-2,-2,0);
	points[4]=Vector3(0,0,0);
	/*for (point in points){
		Debug.Log(point);
	}*/
	
	/*
	var text=Texture2D(1,1);
	text.SetPixel(0,0,Color.yellow);
	text.wrapMode=TextureWrapMode.Repeat;
	text.Apply();
	//var guiStyle=GUIStyle();
	//guiStyle.normal.background=text;
	GUI.skin.box.normal.background=text;
	GUI.Box(Rect(0,0,10,10),GUIContent.none);
	*/
	
	
	while(true){
		for (point in points){
		//	Debug.Log("Point: "+point);
			yield moveToPoint(point);
		//	Debug.Log("Object at:"+transform.position);
		}
		
	}
}

function OnGUI () {

	GUI.Box(Rect(10,10,100,100), "Test");

}

/*
function Update(){

	if(Input.GetMouseButtonDown(0)){
		//Debug.Log("MouseDown");
		for (point in points){
		//	Debug.Log("Point: "+point);
			moveToPoint(point);
		//	Debug.Log("Object at:"+transform.position);
		}
	}

}*/

function moveToPoint(point:Vector3){

	
		var newXPos=point.x;
		var newYPos=point.y;
		
		//Debug.Log("NewXPos:"+newXPos+" newYPos:"+newYPos);
	
		var objXPos: float = transform.position.x;
		var objYPos: float = transform.position.y;
		
		while(objXPos!=newXPos || objYPos!=newYPos){
		
			var curSpeedX=speedX;
			var curSpeedY=speedY;
		
			yield WaitForSeconds(0.1);
		
			var diffX=abs(newXPos-objXPos);
			var diffY=abs(newYPos-objYPos);
			
			if(diffX<curSpeedX){
				curSpeedX=diffX;
			}
			if(diffY<curSpeedY){
				curSpeedY=diffY;
			}
		
			if(newXPos<objXPos){
				objXPos=objXPos-curSpeedX;
			}
			else if(newXPos>objXPos){
				objXPos=objXPos+curSpeedX;
			}
			if(newYPos<objYPos){
				objYPos=objYPos-curSpeedY;
			}
			else if(newYPos>objYPos){
				objYPos=objYPos+curSpeedY;
			}

			//Debug.Log("New xPos "+objXPos);
			//Debug.Log("New yPos "+objYPos);
			//Debug.Log(transform.position);

			var pos=new Vector3(objXPos,objYPos,0);
			//Debug.Log("Pos="+pos);
			transform.position = pos;
		
		}
		
		Debug.Log(transform.position);
		yield WaitForSeconds(1);

}

function abs(num){

	var res: float=num;

	if(res<0){
	res=res*-1.0;
	}
	return res;
}