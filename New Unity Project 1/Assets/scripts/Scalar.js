#pragma strict

public var escala: float =0.3 ;
 var velocidad: float =1.0 ;


function Start () {
 
}

function Update () {
// Modificando el escalado de nuestro objeto.

if (escala < 3.0){
escala = escala + (velocidad * (Time.deltaTime));
transform.localScale= Vector3 (escala , escala , escala);
}else { 

 
}

 


/*
if (escala < 0.3){

escala = 0.3;
 velocidad =  velocidad*  - 1 ; 
 
}*/


}