using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class DifferentialDrive : MonoBehaviour {

	public float vMax;
	public float thetaMax;
	public bool isRunning=false;
	public bool moving = false;
	List<Vector3> path;

	// Use this for initialization
	void Start () {
		
		Vector3 pos1 = new Vector3 (1, 1, 0);
		Vector3 pos2 = new Vector3 (0, 3, 0);
		Vector3 pos3 = new Vector3 (-2, 1, 0);
		Vector3 pos4 = new Vector3 (1, -1, 0);
		Vector3 pos5 = new Vector3 (2, -3, 0);
		path = new List<Vector3> ();
		path.Add (pos1);
		path.Add (pos2);
		path.Add (pos3);
		path.Add (pos4);
		path.Add (pos5);
		
		
	}
	
	// Update is called once per frame
	void Update () {
		
		if (Input.GetMouseButtonDown (0) && !isRunning) {
			Debug.Log("Left Mouse Click");
			isRunning=true;
			StartCoroutine("Move");
		}
		
	}
	
	IEnumerator Move() {
		int index = 0;
		Vector3 current = path[0];
		while (true) {
			if(transform.position == current) {
				Debug.Log("Pos:"+transform.position);
				index++;
				if(index >= path.Count) {
					isRunning=false;
					yield break;
				}
				current = path[index];
			}
			
			if(!moving){
				moving = true;
				StartCoroutine(moveToPoint(current));
			}
			
			//transform.position = Vector3.MoveTowards (transform.position, current, kinematic_vel);
			//transform.position = Vector3.MoveTowards (transform.position, current, kinematic_vel * Time.deltaTime);
			yield return new WaitForSeconds(1.0f);
		}
	}
	
	IEnumerator moveToPoint(Vector3 point){

		float newXPos=point.x;
		float newYPos=point.y;


		//First calculate the angle between the x-axis and where to go.
		//The angle of the x-axis and the "tank" is the rotation of the z-axis
		//We want to change this rotation to point in the direction where to go
		float targetAngle = Vector3.Angle ((transform.position-point), Vector3.right);
		float currentAngle = transform.eulerAngles.z;
		//Debug.Log ("Target Angle Before=" + targetAngle);
		targetAngle = 90 - targetAngle;

		//Debug.Log ("Target Angle=" + targetAngle);
		//Debug.Log ("CurrentAngle=" + currentAngle);

		float curTheta = thetaMax;
		while (Mathf.Abs(currentAngle-targetAngle)>Mathf.Pow(10,-6)) {

			float diffAngle=Mathf.Abs(currentAngle-targetAngle);
			
			if(diffAngle<curTheta){
				curTheta=diffAngle;
			}

			if(currentAngle<targetAngle){
				currentAngle=currentAngle+curTheta;
				transform.Rotate(0,0,curTheta);
			}
			else{
				currentAngle=currentAngle-curTheta;
				transform.Rotate(0,0,-curTheta);
			}

			//Debug.Log ("CurrentAngle=" + currentAngle);
			yield return new WaitForSeconds(0.1f);

			}


		
		//Debug.Log("NewXPos:"+newXPos+" newYPos:"+newYPos);
		
		float objXPos = (float) transform.position.x;
		float objYPos = (float) transform.position.y;
		
		float curSpeedX = Mathf.Abs(vMax * Mathf.Cos (currentAngle));
		float curSpeedY = Mathf.Abs(vMax * Mathf.Sin (currentAngle));

		Debug.Log ("CurSpeedX:" + curSpeedX);
		Debug.Log ("CurSpeedY:" + curSpeedY);
		Debug.Log ("CurrentAngle:" + currentAngle);
		Debug.Log (transform.eulerAngles);

		while(objXPos!=newXPos || objYPos!=newYPos){
			
			float diffX=Mathf.Abs(newXPos-objXPos);
			float diffY=Mathf.Abs(newYPos-objYPos);

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
			
			yield return new WaitForSeconds(0.3f);
			//StartCoroutine(myWait(0.1f));
			
			Vector3 pos=new Vector3(objXPos,objYPos,0);
			//Debug.Log("Pos="+pos);
			transform.position = pos;
			
		}
		
		//StartCoroutine(myWait(1.0f));
		//yield return new WaitForSeconds(1.0f);
		//Debug.Log(transform.position);
		moving = false;
		yield return null;
		
	}
	
	public float abs(float num){
		
		float res=num;
		
		if(res<0){
			res=res*-1.0f;
		}
		return res;
	}
}
