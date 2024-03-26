using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollidableBlock : MonoBehaviour {
    private bool isKnockedOver = false;
    private bool hasComeToRest = false;

    private float currentSpeed = 0f;
    private Vector3 positionOfCollision;

    Rigidbody rb;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update(){
        if (isKnockedOver) {
            currentSpeed = rb.velocity.magnitude;
        }
        if (!hasComeToRest) {
            if (Mathf.Approximately(0, currentSpeed)) {
                hasComeToRest = true;
                Debug.Log("The block has stopped moving!");

                Vector3 newPosition = transform.position;

                float distance = Vector3.Distance(newPosition, positionOfCollision);
                Debug.Log($"The block has moved {distance} from its OG poistion");
            }

        }
    }

    public void KnockOver(){
        if (!isKnockedOver) {
            isKnockedOver = true;
            Debug.Log("Block has been knocked over!");

            positionOfCollision = transform.position;
        }
    }
}