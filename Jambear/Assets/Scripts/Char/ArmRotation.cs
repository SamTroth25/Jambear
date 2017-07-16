using UnityEngine;
using System.Collections;

public class ArmRotation : MonoBehaviour {

	public int rotationOffset = 90;
    public bool controllerOn;

    public Vector2 mouse;

    [Header("MouseCursors")]
    public Texture2D yourCursor;
    public Texture2D clickCursor;

    public int sizeX = 16;
    public int sizeY = 16;

    private bool mouseDown;

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

        var xMou = Input.GetAxis("Mouse X");
        var yMou = Input.GetAxis("Mouse Y");

        if (xMou != 0.0 || yMou != 0.0)
        {
            controllerOn = false;
            sizeX = 64;
            sizeY = 64;
        }

        if (!controllerOn)
        {            
        // subtracting the position of the player from the mouse position
        Vector3 difference = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
        difference.Normalize();     // normalizing the vector. Meaning that all the sum of the vector will be equal to 1

        float rotZ = Mathf.Atan2(difference.y, difference.x) * Mathf.Rad2Deg;   // find the angle in degrees
        transform.rotation = Quaternion.Euler(0f, 0f, rotZ + rotationOffset);
    }

        //Controller Support for Aim.
        var xCon = Input.GetAxis("RHor");
        var yCon = Input.GetAxis("RVer");

        if (xCon != 0.0 || yCon != 0.0)
        {
            sizeX = 0;
            sizeY = 0;
            controllerOn = true;
            var angle = Mathf.Atan2(xCon, yCon) * Mathf.Rad2Deg;
            transform.rotation = Quaternion.AngleAxis(180.0f + angle, Vector3.forward);
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
