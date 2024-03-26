using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileShooter : MonoBehaviour
{
    [SerializeField] GameObject catapultProjectile;
    public float cooldown = 2f;
    public float spawnOffset = 3f; // Relative to direction player is facing
    public float projectileTTL = 8f; // Time to live
    private float timeSinceLastShot = 0f;
    public float fireAngle = -35f;
    public float fireForce = 70f;
    [SerializeField] GameObject pivotPoint;



    void Start()
    {
        if (catapultProjectile == null)
        {
            catapultProjectile = GameObject.CreatePrimitive(PrimitiveType.Sphere);
            catapultProjectile.AddComponent<SphereCollider>();
            Rigidbody rb = catapultProjectile.AddComponent<Rigidbody>();
            rb.mass = 5;
        }
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    // Update is called once per frame
    void Update()
    {
        timeSinceLastShot += Time.deltaTime;
        // Run the following code if the player clicks the left mouse button
        if ((Input.GetMouseButtonDown(0)) && (timeSinceLastShot > cooldown))
        {
            StartCoroutine(Fire());
            timeSinceLastShot = 0f;
        }
    }

    private IEnumerator Fire()
    {
        transform.LookAt(pivotPoint.transform.position);
        // Copy player position, direction, and rotation to use for projectile spawn
        Vector3 playerPos = transform.position;
        Vector3 playerDirection = transform.forward;
        Quaternion playerRotation = transform.rotation;

        // Offset projectile spawn by spawnOffset
        Vector3 spawnPos = playerPos + playerDirection * spawnOffset;

        // Spawn projectile
        GameObject projectile = Instantiate(catapultProjectile, spawnPos, playerRotation);
        // Adjust projectile's up-down (x) angle by fireAngle
        projectile.transform.Rotate(fireAngle, 0, 0);

        // Add Force to fire the projectile
        Rigidbody projectileRb = projectile.GetComponent<Rigidbody>();
        projectileRb.AddForce(projectile.transform.forward * fireForce, ForceMode.Impulse);

        // Wait a predetermined amount of seconds, then destroy projectile
        yield return new WaitForSeconds(this.projectileTTL);
        Destroy(projectile);
    }
}
