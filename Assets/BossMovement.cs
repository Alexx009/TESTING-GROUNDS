using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossMovement : MonoBehaviour
{
    public float speed = 5f;
    public float maxX = 10f;
    public float maxY = 5f;
    public float maxZ = 10f;
    public float followDistance = 20f;
    public float followSpeed = 10f;
    public Transform playerTransform;

    private Vector3 startPosition;
    private Vector3 targetPosition;

    private enum MoveState
    {
        Idle,
        Follow,
        MoveToPoint,
        StrafeLeft,
        StrafeRight
    }

    private MoveState currentState = MoveState.Idle;
    private float timeInState = 0f;
    private float stateDuration = 5f;

    void Start()
    {
        startPosition = transform.position;
        SetNewTargetPosition();
    }

    void Update()
    {
        float distanceToPlayer = Vector3.Distance(transform.position, playerTransform.position);

        switch (currentState)
        {
            case MoveState.Idle:
                if (timeInState >= stateDuration)
                {
                    currentState = MoveState.MoveToPoint;
                    timeInState = 0f;
                    Debug.Log("Switching to MoveToPoint state");
                }
                else
                {
                    timeInState += Time.deltaTime;
                }
                break;

            case MoveState.Follow:
                if (distanceToPlayer <= followDistance)
                {
                    currentState = MoveState.Idle;
                    timeInState = 0f;
                    Debug.Log("Switching to Idle state");
                }
                else
                {
                    transform.position = Vector3.MoveTowards(transform.position, playerTransform.position, followSpeed * Time.deltaTime);
                    transform.LookAt(playerTransform.position);
                    Debug.Log("Following player");
                }
                break;

            case MoveState.MoveToPoint:
                transform.position = Vector3.MoveTowards(transform.position, targetPosition, speed * Time.deltaTime);
                transform.LookAt(playerTransform.position);
                Debug.Log("Moving to random point");

                if (transform.position == targetPosition)
                {
                    timeInState = 0f;
                    currentState = MoveState.StrafeLeft;
                    Debug.Log("Switching to StrafeLeft state");
                }
                break;

            case MoveState.StrafeLeft:
                transform.Translate(Vector3.left * speed * Time.deltaTime);
                transform.LookAt(playerTransform.position);
                Debug.Log("Strafing left");

                if (timeInState >= stateDuration)
                {
                    timeInState = 0f;
                    currentState = MoveState.StrafeRight;
                    Debug.Log("Switching to StrafeRight state");
                }
                else
                {
                    timeInState += Time.deltaTime;
                }
                break;

            case MoveState.StrafeRight:
                transform.Translate(Vector3.right * speed * Time.deltaTime);
                transform.LookAt(playerTransform.position);
                Debug.Log("Strafing right");

                if (timeInState >= stateDuration)
                {
                    timeInState = 0f;
                    currentState = MoveState.Follow;
                    Debug.Log("Switching to Follow state");
                }
                else
                {
                    timeInState += Time.deltaTime;
                }
                break;
        }
    }

    void SetNewTargetPosition()
    {
        float randomX = Random.Range(startPosition.x - maxX, startPosition.x + maxX);
        float randomY = Random.Range(startPosition.y - maxY, startPosition.y + maxY);
        float randomZ = Random.Range(startPosition.z - maxZ, startPosition.z + maxZ);

        targetPosition = new Vector3(randomX, randomY, randomZ);
    }
}