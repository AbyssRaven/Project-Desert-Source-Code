using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interface_Test : MonoBehaviour {

    public GameObject Cam;

	// Use this for initialization
	void Start ()
    {

	}
	
	// Update is called once per frame
	void Update ()
    {
        float valueSlider = this.GetComponent<UnityEngine.UI.Slider>().value;
        Cam.transform.position = new Vector3(2880, 540 - valueSlider, -10);
    }
}
