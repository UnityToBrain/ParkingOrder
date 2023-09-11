using System;
using System.Collections;
using System.Collections.Generic;
using PathCreation;
using UnityEngine;

[ExecuteInEditMode] 
public class CarManager : PathFollower
{

    private Rigidbody _rigidbody;
    private Collider _collider;
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

        _rigidbody = GetComponent<Rigidbody>();
        _collider = GetComponent<Collider>();

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Car"))
        {
            moveCar = false;
            GameManager.gameManagerInstance.losebool = true;
            GameManager.gameManagerInstance.Lose();

            _rigidbody.isKinematic = _collider.isTrigger = false;
            other.GetComponent<Rigidbody>().AddForceAtPosition(other.transform.position * 100f, other.transform.position);
        }
    }
}
