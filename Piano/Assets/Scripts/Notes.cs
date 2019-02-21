using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Notes : MonoBehaviour {

    public float beatTemp;
    public bool hasStarted;

	// Use this for initialization
	void Start () {
        beatTemp = beatTemp / 60f;
	}
	
	// Update is called once per frame
	void Update () {
		
        if(!hasStarted)
        {
            if(Input.anyKeyDown)
            {
                hasStarted = true;
            }
        } else{
            transform.position -= new Vector3(0f, beatTemp * Time.deltaTime, 0f);
        }
	}
}
