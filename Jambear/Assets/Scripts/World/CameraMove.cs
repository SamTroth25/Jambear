using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class CameraMove : MonoBehaviour
{
    public Transform[] patrolPoints;
    public float moveSpeed, totalMoveSpeed;
    private int currentPoint;

    private bool FacingRight;

    public float timeLeft;

    public GameObject timeLeftUI;
    public Text countdownText;

    bool canMove;

    // Use this for initialization
    void Start()
    {
        canMove = true;
        //player.canMove = false;
        transform.position = patrolPoints[0].position;
        currentPoint = 0;
    }

    // Update is called once per frame
    void Update()
    {
        countdownText.text = ("" + Mathf.Round(timeLeft));

        timeLeft -= Time.deltaTime;
        if (timeLeft < 0)
        {
            timeLeft = 0;
            timeLeftUI.SetActive(false);
            if (canMove)
            {
                float step = moveSpeed * Time.deltaTime;
                transform.position = Vector3.MoveTowards(transform.position, patrolPoints[1].position, step);
            }
        }
    }

    public void StartMovement()
    {
        canMove = true;
        moveSpeed = totalMoveSpeed;
    }
}
