using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float speed = 6f;

    private Vector3 movement;
    private Animator animator;
    private Rigidbody rb;
    private int floorMask;
    private float camRayLength = 100f;

    private void Awake()
    {
        floorMask = LayerMask.GetMask("Floor");
        animator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody>();
    }

    private void FixedUpdate()
    {
        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");

        Move(horizontal, vertical);
        Turning();
        Animating(horizontal, vertical);
    }

    private void Move(float horizontal, float vertical)
    {
        movement.Set(horizontal, 0.0f, vertical);

        movement = movement.normalized * speed * Time.deltaTime;

        rb.MovePosition(transform.position + movement);
    }

    private void Turning()
    {
        Ray camRay = Camera.main.ScreenPointToRay(Input.mousePosition);

        RaycastHit floorHit;

        if (Physics.Raycast(camRay, out floorHit, camRayLength, floorMask))
        {
            Vector3 playerToMouse = floorHit.point - transform.position;
            playerToMouse.y = 0f;

            Quaternion newRotation = Quaternion.LookRotation(playerToMouse);

            rb.MoveRotation(newRotation);
        }
    }

    private void Animating(float horizontal, float vertical)
    {
        bool walking = horizontal != 0f || vertical != 0f;

        animator.SetBool("IsWalking", walking);
    }
}
