using System;
using System.Collections;
using System.Collections.Generic;
using PathCreation;
using UnityEngine;

[ExecuteInEditMode] 
public class CarManager : PathFollower
{
    protected override void Start()
    {
        base.Start();
        AddComponents();
    }

    private void AddComponents()
    {
        if (!GetComponent<Rigidbody>())
            gameObject.AddComponent<Rigidbody>().isKinematic = true;

        if (!GetComponent<BoxCollider>())
        {
            gameObject.AddComponent<BoxCollider>().size = new Vector3(2f,2f,4f);
            GetComponent<BoxCollider>().center = Vector3.up; // new vector3(0f,1f,0f)
            GetComponent<BoxCollider>().isTrigger = true;
        }
      
        gameObject.tag = "Car";
        endOfPathInstruction = EndOfPathInstruction.Stop;

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Car"))
        {
            moveCar = false;
            GameManager.gameManagerInstance.losebool = true;
            GameManager.gameManagerInstance.Lose();
        }
    }
}
