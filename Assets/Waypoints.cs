using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Waypoints : MonoBehaviour {

	List<Vector3> path;
	public float kinematic_vel;// = 0.1f;
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
}
