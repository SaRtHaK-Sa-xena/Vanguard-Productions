using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hook_Line : MonoBehaviour
{
    public LineRenderer line;

    public Transform Player_Position;

    public Vector3 start_Point;
    public Transform end_Point;
    public Vector3 direction;
    Vector3 Position;

    public bool set_StartLine;

    private void Start()
    {
        line = GetComponent<LineRenderer>();

        Player_Position.position = start_Point;
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.F))
        {
            set_StartLine = true;
        }
        else if(Input.GetKeyDown(KeyCode.G))
        {
            set_StartLine = false;
        }

        //start 
        if(set_StartLine)
        {
            StartLine();
        }
    }

    public Vector3 UpdateLine()
    {
        Vector3 result = new Vector3();

        // result 
        result = start_Point - end_Point.position;
        return result;
    }

    private void StartLine()
    {
        direction = UpdateLine();

        //end_Point.position += direction * 2 * Time.deltaTime;

        //Transform Updated_Position = end_point

        line.SetPosition(0, start_Point);

        Position += direction * 2 * Time.deltaTime;

        line.SetPosition(line.positionCount - 1, Position);
    }
}
