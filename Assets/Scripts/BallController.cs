using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallController : MonoBehaviour
{
    [SerializeField] private float launchForceMultiplier = 0.1f;
    [SerializeField] private float minSwipeDistance = 50f;
    private Vector3 startSwipePos;
    private Vector3 endSwipePos;
    private float gravity = 9.8f;

    void Update()
    {
        // Detect swipe input
        if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began)
        {
            startSwipePos = Input.GetTouch(0).position;
        }
        else if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Ended)
        {
            endSwipePos = Input.GetTouch(0).position;
            Vector3 swipeDirection = endSwipePos - startSwipePos;
            swipeDirection.x = Mathf.Abs(swipeDirection.x);
            swipeDirection.y = Mathf.Abs(swipeDirection.y);
            swipeDirection.z = Mathf.Abs(swipeDirection.z);
            Debug.Log($"swipeDirection = {swipeDirection}");

            // Calculate swipe distance and force
            float swipeDistance = swipeDirection.magnitude;
            if (swipeDistance > minSwipeDistance)
            {
                float launchForce = swipeDistance * launchForceMultiplier;

                // Launch the ball
                StartCoroutine(LaunchBall(swipeDirection.normalized, launchForce));
            }
        }
    }

    private IEnumerator LaunchBall(Vector3 direction, float launchForce)
    {

        Vector3 velocity = direction * launchForce;
        Vector3 position = transform.position;

        while (position.y > 0.1f)
        {
            velocity.y -= gravity * Time.deltaTime;
            position += velocity * Time.deltaTime;
            transform.position = position;

            yield return null;
        }
    }


}