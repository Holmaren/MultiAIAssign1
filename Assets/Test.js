#pragma strict


	var c1 : Color = Color.yellow;
	var c2 : Color = Color.red;
	var lengthOfLineRenderer : int = 2;
	var aMaterial : Material;

function Start () {

	 var lineRenderer : LineRenderer = gameObject.AddComponent(LineRenderer);
		 lineRenderer.material = aMaterial;
		 lineRenderer.SetColors(c1, c2);
		 lineRenderer.SetWidth(0.1,0.1);
		 lineRenderer.SetVertexCount(lengthOfLineRenderer);
	

}

function Update () {

		//Debug.Log("Inside Update");

		if(Input.GetMouseButtonDown(0)){
			Debug.Log("Left Mouse down. Position:"+Input.mousePosition);
		
			var realMousePos=Camera.main.ScreenToWorldPoint(Input.mousePosition);
		
			Debug.Log("Real Mouse Pos "+realMousePos);
		
			var lineRenderer : LineRenderer = GetComponent(LineRenderer);
		//for(var i : int = 0; i < lengthOfLineRenderer; i++) {
			var pos : Vector3 = Vector3(0 , 0 , 0);
			lineRenderer.SetPosition(0, pos);
			//var posMouse=Input.mousePosition;
			var pos2 : Vector3 = realMousePos;
			lineRenderer.SetPosition(1,pos2);
		//}
		
		}

		


}