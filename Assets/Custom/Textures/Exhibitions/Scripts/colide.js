#pragma strict
var A : GameObject;
var B : GameObject;
var C : GameObject;
var D : GameObject;
var E : GameObject;
var F : GameObject;

function Start () {
	
}

function Update () {
	
}

function OnTriggerEnter (other : Collider) {

		A.GetComponent(playmovie).enabled = true;
		B.GetComponent(playmovie).enabled = true;
		C.GetComponent(playmovie).enabled = true;
		D.GetComponent(playmovie).enabled = true;
		E.GetComponent(playmovie).enabled = true;


	}
	
function OnTriggerExit (other : Collider) {

		A.GetComponent(playmovie).enabled = false;
		B.GetComponent(playmovie).enabled = false;
		C.GetComponent(playmovie).enabled = false;
		D.GetComponent(playmovie).enabled = false;
		E.GetComponent(playmovie).enabled = false;


	}