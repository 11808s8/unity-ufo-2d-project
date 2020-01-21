using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotator : MonoBehaviour
{
    public float xAngle;
    public float yAngle;
    public float zAngle;

    void Update()
    {
        transform.Rotate(new Vector3(xAngle, yAngle, zAngle) * Time.deltaTime); 
    }
}
