using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ArmRotation : MonoBehaviour {

	public int rotationOffset = 90;
    public bool controllerOn;

    public Vector2 mouse;

    [Header("MouseCursors")]
    public Texture2D yourCursor;
    public Texture2D clickCursor;

    public GameObject controllerCrosshair;

    public int sizeX = 16;
    public int sizeY = 16;

    public float octoAimThreshold = 22.5f;

    private bool mouseDown;

    public Animator headAnim;

    public Text armRotText;
  
    void Start()
    {
        Cursor.visible = false;
    }

    // Update is called once per frame
    void Update()
    {
        mouse = new Vector2(Input.mousePosition.x, Screen.height - Input.mousePosition.y);

        if (Input.GetMouseButtonDown(0))
        {
            mouseDown = true;
        }
        else if (Input.GetMouseButtonUp(0))
        {
            mouseDown = false;
            //audioSource.PlayOneShot (click, 0.7f);
        }

        float xMou = Input.GetAxisRaw("Mouse X");
        float yMou = Input.GetAxisRaw("Mouse Y");

        if (xMou != 0.0 || yMou != 0.0)
        {
            controllerOn = false;
            sizeX = 64;
            sizeY = 64;
            controllerCrosshair.SetActive(false);
        }

        if (!controllerOn)
        {
            // subtracting the position of the player from the mouse position
            Vector3 difference = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
            difference.Normalize();     // normalizing the vector. Meaning that all the sum of the vector will be equal to 1

            float rotZ = Mathf.Atan2(difference.y, difference.x) * Mathf.Rad2Deg;   // find the angle in degrees

            if (rotZ > 60 && rotZ < 120)
            {
                rotZ = 90;
            }
            if (rotZ > 30 && rotZ < 60)
            {
                rotZ = 45;
            }
            if (rotZ > 120 && rotZ < 150)
            {
                rotZ = 135;
            }
            if (rotZ > 150)
            {
                rotZ = 180;
            }
            if (rotZ < 30 && rotZ > -30)
            {
                rotZ = 0;
            }
            if (rotZ < -30 && rotZ > -60)
            {
                rotZ = -45;
            }
            if (rotZ < -60 && rotZ > -120)
            {
                rotZ = -90;
            }
            if (rotZ < -120 && rotZ > -150)
            {
                rotZ = -135;
            }
            if (rotZ < -150)
            {
                rotZ = 180;
            }

            transform.rotation = Quaternion.Euler(0f, 0f, rotZ + rotationOffset);
            armRotText.text = ("Arm Angle Mou: " + rotZ);

            headAnim.SetFloat("MouseX", -difference.y);
            headAnim.SetFloat("MouseY", -difference.x);
        }

        //Controller Support for Aim.
        var xCon = Input.GetAxis("RHor");
        var yCon = Input.GetAxis("RVer");

        if (xCon != 0.0 || yCon != 0.0)
        {
            sizeX = 0;
            sizeY = 0;
            controllerOn = true;
            controllerCrosshair.SetActive(true);
            var angle = Mathf.Atan2(xCon, yCon) * Mathf.Rad2Deg;

            if (angle > 60 && angle < 120)
            {
                angle = 90;
            }
            if (angle > 30 && angle < 60)
            {
                angle = 45;
            }
            if (angle > 120 && angle < 150)
            {
                angle = 135;
            }
            if(angle > 150)
            {
                angle = 180;
            }
            if (angle < 30 && angle > -30)
            {
                angle = 0;
            }
            if (angle < -30 && angle > -60)
            {
                angle = -45;
            }
            if (angle < -60 && angle > -120)
            {
                angle = -90;
            }
            if (angle < -120 && angle > -150)
            {
                angle = -135;
            }
            if(angle < -150)
            {
                angle = 180;
            }

            armRotText.text = ("Arm Angle Con: " + angle);
            transform.rotation = Quaternion.Euler(0f, 0f, angle + 180.0f);
            headAnim.SetFloat("MouseX", xCon);
            headAnim.SetFloat("MouseY", yCon);
        }
    }
    void OnGUI()
    {
        if (mouseDown)
        {
            GUI.DrawTexture(new Rect(mouse.x - (sizeX / 2), mouse.y - (sizeY / 2), sizeX, sizeY), clickCursor);
        }
        else
        {
            GUI.DrawTexture(new Rect(mouse.x - (sizeX / 2), mouse.y - (sizeY / 2), sizeX, sizeY), yourCursor);
        }
    }
}
