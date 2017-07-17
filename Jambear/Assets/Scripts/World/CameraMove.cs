using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class CameraMove : MonoBehaviour
{
    public Transform[] patrolPoints;
    public float moveSpeed;
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
            timeLeftUI.SetActive(false);
            if (transform.position == patrolPoints[currentPoint].position && canMove)
            {
                //player.canMove = true;
                currentPoint++;
            }
            if (currentPoint >= patrolPoints.Length)
            {
                canMove = false;
                currentPoint = patrolPoints.Length;
            }
            if (canMove)
            {
                transform.position = Vector3.MoveTowards(transform.position, patrolPoints[currentPoint].position, moveSpeed * Time.deltaTime);
            }
        }     
    }
}
