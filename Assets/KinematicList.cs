using UnityEngine;
using System.Collections;

public class KinematicList : MonoBehaviour {

	private float speedX=0.1f;
	private float speedY=0.1f;
	public Vector3[] points=new Vector3[5];


	// Use this for initialization
	void Start () {

		points=new Vector3[5];
		points[0]=new Vector3(0,0,0);
		points[1]=new Vector3(2,2,0);
		points[2]=new Vector3(-2,2,0);
		points[3]=new Vector3(-2,-2,0);
		points[4]=new Vector3(0,0,0);

		//Debug.Log ("Hej");
		for (int i=0;i<points.Length;i++){
			Vector3 point=points[i];
			//Debug.Log("Point: "+point);
			this.moveToPoint(point);

			//	Debug.Log("Object at:"+transform.position);
		}

	}
	
	// Update is called once per frame
	/*void Update () {
	
	}*/

	private IEnumerator myWait(float waitTime){

		yield return new WaitForSeconds(waitTime);

		}


	private static Texture2D _staticRectTexture;
	private static GUIStyle _staticRectStyle;
	
	// Note that this function is only meant to be called from OnGUI() functions.
	public static void GUIDrawRect( Rect position, Color color )
	{
		if( _staticRectTexture == null )
		{
			_staticRectTexture = new Texture2D( 1, 1 );
		}
		
		if( _staticRectStyle == null )
		{
			_staticRectStyle = new GUIStyle();
		}
		
		_staticRectTexture.SetPixel( 0, 0, color );
		_staticRectTexture.Apply();
		
		_staticRectStyle.normal.background = _staticRectTexture;
		
		GUI.Box( position, GUIContent.none, _staticRectStyle );
		
		
	}



	public void moveToPoint(Vector3 point){
		
		
		float newXPos=point.x;
		float newYPos=point.y;
		
		//Debug.Log("NewXPos:"+newXPos+" newYPos:"+newYPos);
		
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
			
			//Debug.Log("New xPos "+objXPos);
			//Debug.Log("New yPos "+objYPos);
			//Debug.Log(transform.position);

			//yield return new WaitForSeconds(0.1f);
			StartCoroutine(myWait(0.1f));

			Vector3 pos=new Vector3(objXPos,objYPos,0);
			//Debug.Log("Pos="+pos);
			transform.position = pos;

		}

		StartCoroutine(myWait(1.0f));
		//yield return new WaitForSeconds(1.0f);
		Debug.Log(transform.position);

		
	}
	
	public float abs(float num){
		
		float res=num;
		
		if(res<0){
			res=res*-1.0f;
		}
		return res;
	}


}
