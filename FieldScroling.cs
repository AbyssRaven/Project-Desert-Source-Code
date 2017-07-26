using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FieldScroling : MonoBehaviour {

    public GameObject Cam;
    public int scrollSpeed = 500;

    int min_y;
    int numFields = 22;
    int numRows;

    // Use this for initialization
    void Start ()
    {
		
	}
	
	// Update is called once per frame
	void Update ()
    {
        numRows = numFields / 7;
        if (0 < numFields % 7)
        {
            numRows++;
        }
        min_y = 830 - numRows * 290;

        var s = Input.GetAxis("Mouse ScrollWheel");
        Cam.transform.position = new Vector3(2880, Mathf.Clamp(Cam.transform.position.y + s * scrollSpeed, min_y, 540), -10);
    }
}
