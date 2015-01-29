using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Waypoints : MonoBehaviour {

	List<Vector3> path;
	public float kinematic_vel;// = 0.1f;
	public float speedX=0.1f;
	public float speedY=0.1f;
	public float dynFx = 1.0f;
	public float dynFy = 1.0f;
	public float dynM = 1.0f;
	public bool isRunning=false;


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

	
					//	StartCoroutine ("Move");

				
	}


	void Update(){
		//print ("Hej");
		if (Input.GetMouseButtonDown (0) && !isRunning) {
				Debug.Log("Left Mouse Click");
				isRunning=true;
				StartCoroutine ("Move");
			}
	}

	Vector3 DiscretePoint(Vector3 nextPos) {
		return nextPos;
	}
	
	Vector3 KinematicPoint(Vector3 startPos, Vector3 nextPos, float vel) {
		return Vector3.MoveTowards (startPos, nextPos, vel);
	}

	Vector3 DynamicPoint(Vector3 startPos, Vector3 nextPos, float vel) {
		return Vector3.MoveTowards (startPos, nextPos, kinematic_vel);
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

			//StartCoroutine(moveToPoint(current));

			transform.position = Vector3.MoveTowards (transform.position, current, kinematic_vel);
			//transform.position = Vector3.MoveTowards (transform.position, current, kinematic_vel * Time.deltaTime);
			yield return new WaitForSeconds(0.2f);
		}
	}

	public void OnDrawGizmos() {
		if (path != null) {
			for(int i = 0; i < path.Count; i++) {
				Gizmos.color = Color.black;
				Gizmos.DrawCube (path[i], Vector3.one);

				if(i == 0) {
				//	Gizmos.DrawLine (transform.position, path[i]);
				}
				else {
					Gizmos.DrawLine (path[i-1], path[i]);
				}
			}
		}
	}

	IEnumerator moveToPoint(Vector3 point){

		Debug.Log ("Hej");
		yield return new WaitForSeconds (0.1f);

		/*float newXPos=point.x;
		float newYPos=point.y;
		
		Debug.Log("NewXPos:"+newXPos+" newYPos:"+newYPos);
		
		float objXPos = (float) transform.position.x;
		float objYPos = (float) transform.position.y;
		
		while(objXPos!=newXPos || objYPos!=newYPos){
			
			float curSpeedX=speedX;
			float curSpeedY=speedY;
			
			
			float diffX=abs(newXPos-objXPos);
			float diffY=abs(newYPos-objYPos);
			
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
			
			Debug.Log("New xPos "+objXPos);
			Debug.Log("New yPos "+objYPos);
			Debug.Log(transform.position);

			yield return new WaitForSeconds(0.1f);

			Vector3 pos=new Vector3(objXPos,objYPos,0);
			//Debug.Log("Pos="+pos);
			transform.position = pos;
			
		}

		yield return new WaitForSeconds(1.0f);
		Debug.Log(transform.position);*/
		
		
	}
	
	public float abs(float num){
		
		float res=num;
		
		if(res<0){
			res=res*-1.0f;
		}
		return res;
	}

}
