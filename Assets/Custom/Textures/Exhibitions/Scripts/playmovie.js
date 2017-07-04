var movTexture : MovieTexture;
var audiofind : AudioSource;
var go;

function Start () {

movTexture.loop = true;
GetComponent.<Renderer>().material.mainTexture = movTexture;

}

function OnEnable(){
	
	movTexture.Play();
		
		if(audiofind!=null){
		audiofind.Play();
		}
}

function OnDisable(){
	
	movTexture.Pause();
		
		if(audiofind!=null){
		audiofind.Pause();
		}
}

function Update ()
{







	 
}	         