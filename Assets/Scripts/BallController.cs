using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Events;

public class BallController : MonoBehaviour
{
    [SerializeField] private float launchForceMultiplier = 0.1f;
    [SerializeField] private float minSwipeDistance = 50f;
    [SerializeField] private float maxX = 600f;
    [SerializeField] private float maxY = 1500f;

    private Vector3 startSwipePos;
    private Vector3 endSwipePos;
    private float gravity = 9.8f;

    private void Start()
    {

    }

    private void Update()
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
            swipeDirection.x = Mathf.Min(Mathf.Abs(swipeDirection.x), maxX);
            swipeDirection.y = Mathf.Min(Mathf.Abs(swipeDirection.y), maxY);
            Debug.Log($"swipeDirection = {swipeDirection}");

            // Calculate swipe distance and force
            float swipeDistance = swipeDirection.magnitude;
            if (swipeDistance > minSwipeDistance)
            {
                float launchForce = swipeDistance * launchForceMultiplier;
                // Launch the ball
                StartCoroutine(LaunchBall(swipeDirection.normalized, launchForce));
                EventsModel.BALL_LAUNCHED?.Invoke();
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
        EventsModel.BALL_TOUCHED_GROUND?.Invoke(gameObject);
    }


}