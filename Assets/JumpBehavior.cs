using System.Collections;
using System.Collections.Generic;
using MoreMountains.Feedbacks;
using UnityEngine;
using UnityEngine.Serialization;

public class JumpBehavior : MonoBehaviour
{
    public Rigidbody rigidbody;

    public KeyCode jumpkey;

    public float low_velocity;
    public float gravity_multiplier;
    public float jumpforce;
    private bool isJumping = false;
    private float y_velocity_lastFrame = 0;

    public MMFeedbacks jumpingFeedbacks;
    public MMFeedbacks landingFeedbacks;
    public MMFeedbacks scatterCubesFeedbacks;
    
    // Start is called before the first frame update
    void Start()
    {
        Physics.gravity = Vector3.down * gravity_multiplier;
        rigidbody = this.gameObject.GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(jumpkey) && !isJumping)
        {
            jump();
        }

        if ( isJumping && y_velocity_lastFrame<0 && Mathf.Abs(y_velocity_lastFrame) < low_velocity )
        {
            isJumping = false;
            landingFeedbacks?.PlayFeedbacks();
        }

        y_velocity_lastFrame = rigidbody.velocity.y;
    }

    public void jump()
    {
        jumpingFeedbacks?.PlayFeedbacks();
        scatterCubesFeedbacks?.PlayFeedbacks();
        rigidbody.AddForce(Vector3.up * jumpforce, ForceMode.Impulse);
        isJumping = true;
    }
}
