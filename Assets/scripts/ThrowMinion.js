#pragma strict

var screenPoint:Vector2;
var offset:Vector2;

private var oldMouse:Vector2;
private var mouseSpeed:Vector2;
var speed = new int();

function Start(){
//oldMouse = Vector3.zero;
}

function Update(){
 //mouseSpeed = oldMouse - Input.mousePosition;
 //oldMouse = Input.mousePosition;
}

function OnMouseDown()
{
    oldMouse = Input.mousePosition;
    screenPoint = Camera.main.WorldToScreenPoint(gameObject.transform.position);
    offset = gameObject.transform.position - Camera.main.ScreenToWorldPoint(new Vector2(Input.mousePosition.x, Input.mousePosition.y));
}


function OnMouseDrag()
{
    var curScreenPoint:Vector2 = new Vector2(Input.mousePosition.x, Input.mousePosition.y);
    var curPosition:Vector2 = Camera.main.ScreenToWorldPoint(curScreenPoint) + offset;
    transform.position = curPosition;
}

function OnMouseUp(){
//mouseSpeed = oldMouse - Input.mousePosition;
//rigidbody2D.AddForce(mouseSpeed * speed * -1, ForceMode2D.Force);
//rigidbody.AddForce(mouseSpeed*Time.deltaTime, ForceMode.Force);
}