using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FPSInput : MonoBehaviour
{
    // Ensures the player doesn't move too fast
    public float speed = 3.0f;
    // Apply gravity
    public float gravity = -9.8f;

    private CharacterController charController;

    // Start is called before the first frame update
    void Start()
    {
        charController = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        float deltaX = Input.GetAxis("Horizontal") * speed;
        float deltaZ = Input.GetAxis("Vertical") * speed;

        // Instead of moving the player using transofmr.Translate, use the character controller
        Vector3 movement = new Vector3(deltaX, 0, deltaZ);

        // Enusres the player doesn't move too fast
        movement = Vector3.ClampMagnitude(movement, speed);

        // Since speed (technically velocity) times time equals distance,
        // multiply by Time.deltaTime to move a certain amount within one frame.
        movement *= Time.deltaTime;

        // Transform movement from local to world coordinates
        movement = transform.TransformDirection(movement);

        // Ensure player can't move vertically up and down with their movement
        // This is set AFTER the transform, because gravity should be local coordinates (local=relation to world world=relation to object)
        movement.y = gravity * Time.deltaTime;

        // Move the chracter controller using the Move() method
        charController.Move(movement);

    }
}
