#pragma strict

	var speed : float = 1.0;

function Update () {
	var hit1 : RaycastHit;
	var move = Vector3(Input.GetAxis("Horizontal"), 10*Input.GetAxis("Vertical"),0);
	transform.position += move * speed * Time.deltaTime;

	if(Physics.Raycast(transform.position, -Vector3.up,hit1))
	{
		var objectForward : Vector3 = transform.TransformDirection(Vector3.forward);
		transform.rotation = Quaternion.LookRotation(objectForward, hit1.normal);
	}
}