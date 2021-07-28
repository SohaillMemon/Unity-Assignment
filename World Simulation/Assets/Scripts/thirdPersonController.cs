using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class thirdPersonController : MonoBehaviour
{
    // Start is called before the first frame update

   
    [SerializeField]float speed;
    public Transform cam;
    Vector3 direction;
    [SerializeField] CharacterController playerController;
    float refVel;
    [SerializeField] float smoothTime=0.1f;
    public Animator anim;
    // Update is called once per frame
    void Update()
    {
        updateMovment();
        anim.SetFloat("speed", playerController.velocity.magnitude);
    }

    public void updateMovment()
    {
        direction.x = Input.GetAxisRaw("Horizontal");
        direction.z = Input.GetAxisRaw("Vertical");
        direction = direction.normalized;
        if (direction.magnitude >= 0.1)
        {
            float angle = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg + cam.eulerAngles.y;
            float targetAngle = Mathf.SmoothDampAngle(transform.eulerAngles.y, angle,ref refVel, smoothTime);
            transform.rotation = Quaternion.Euler(0f, targetAngle, 0f);
            Vector3 movDir = Quaternion.Euler(0f, angle, 0f) * Vector3.forward;
            playerController.Move(movDir * speed * Time.deltaTime);
        }
    }
}
