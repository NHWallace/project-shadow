using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.ConstrainedExecution;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Experimental.Rendering;
using UnityEngine.TextCore.Text;

[RequireComponent(typeof(CharacterController))]
[AddComponentMenu("Control Script/FPS Input")]
public class CharacterMovementCircle : MonoBehaviour
{   public float speed = 6.0f;
    public float cameraRiseSpeed = 2.0f;
public float gravity = 0f;

public float presetHeight = 5f;
public Transform target; //Target object for rotation
public float radius = 2f; //adjustable radius for camera distance
public float angle =0f; //current angle of the object CHECK WITH CAMERA CONTROLS LATER
public float height;
 private CharacterController charController;
    // Start is called before the first frame update
    void Start()
    {
         charController = GetComponent<CharacterController>();
         height = presetHeight;
    }

    // Update is called once per frame
    void Update()
    {

        float angleUpdateXZ = Input.GetAxis("Horizontal");
        float heightUpdateY= Input.GetAxis("Vertical");
        float x = target.position.x + Mathf.Cos(angle) * radius;
        height +=  heightUpdateY * cameraRiseSpeed * Time.deltaTime;
        height = Mathf.Clamp(height, 10.0f, 30.0f); 
        
        float z = target.position.z + Mathf.Sin(angle) * radius;

        transform.position = new Vector3(x, height, z);
    
        angle += angleUpdateXZ * speed * Time.deltaTime;
    }
}
