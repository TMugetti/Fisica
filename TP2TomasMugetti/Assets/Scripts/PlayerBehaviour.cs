using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MPhysics;

public class PlayerBehaviour : MonoBehaviour
{
    [SerializeField] float radioRuedas = 1;
    [SerializeField] float maxRPM = 10;
    [SerializeField] float aceleracion = 1;
    private float RPMLeft = 0;
    private float RPMRight = 0;

    void Start(){
        GetComponent<MCollider>().OnColEnter.AddListener(die);
    }
    void FixedUpdate()
    {
        if(Input.GetKey(KeyCode.Q)){ RPMLeft += aceleracion * Time.deltaTime;}
        if(Input.GetKey(KeyCode.A)){ RPMLeft -= aceleracion * Time.deltaTime;}
        if(Input.GetKey(KeyCode.E)){ RPMRight += aceleracion * Time.deltaTime;}
        if(Input.GetKey(KeyCode.D)){ RPMRight -= aceleracion * Time.deltaTime;}

        RPMLeft = Mathf.Clamp(RPMLeft,maxRPM *-1,maxRPM);
        RPMRight = Mathf.Clamp(RPMRight,maxRPM *-1,maxRPM);

        var angVelLeft = MugettiPhysics.AngularVelocity(RPMLeft);
        var velLeft = MugettiPhysics.AngularToLinearVelocity(angVelLeft, radioRuedas);

        var angVelRight = MugettiPhysics.AngularVelocity(RPMRight);
        var velRight = MugettiPhysics.AngularToLinearVelocity(angVelRight, radioRuedas);


        MugettiPhysics.MVec2 vecZero;
        vecZero.X = 0.0f;
        vecZero.Y = 0.0f;

        MugettiPhysics.MVec2 leftSpeeds;
        leftSpeeds.X = Mathf.Cos(45 * Mathf.Deg2Rad) * velLeft;
        leftSpeeds.Y = Mathf.Sin(45 * Mathf.Deg2Rad) * velLeft;
        MugettiPhysics.MVec2 leftMovementVector = MugettiPhysics.MRU(0,Time.deltaTime, vecZero, leftSpeeds);
        if(leftMovementVector.X > 0.0f){leftMovementVector.X *= -1.0f;}

        MugettiPhysics.MVec2 rightSpeeds;
        rightSpeeds.X = Mathf.Cos(45 * Mathf.Deg2Rad) * velRight;
        rightSpeeds.Y = Mathf.Sin(45 * Mathf.Deg2Rad) * velRight;
        MugettiPhysics.MVec2 rightMovementVector = MugettiPhysics.MRU(0,Time.deltaTime, vecZero, rightSpeeds);
        if(rightMovementVector.X < 0.0f){rightMovementVector.X *= -1.0f;}

        Vector3 newPos = transform.position;
        newPos.x += leftMovementVector.X + rightMovementVector.X;
        newPos.y += leftMovementVector.Y + rightMovementVector.Y;
        Debug.Log("X: " + leftMovementVector.X + " " + rightMovementVector.X);
        Debug.Log("Y: " + leftMovementVector.Y + " " + rightMovementVector.Y);
        transform.position = newPos;
    }

    private void die(){
        gameObject.SetActive(false);
    }
}
