using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
		if (Input.GetKey(KeyCode.W))
		{
			transform.position += transform.forward * 2 * Time.deltaTime;
		}
		if (Input.GetKey(KeyCode.S))
		{
			transform.position -= transform.forward * 2 * Time.deltaTime;
		}
		if (Input.GetKey(KeyCode.D))
		{
			transform.Rotate(new Vector3(0, 1, 0));
			transform.position += transform.right * 2 * Time.deltaTime;
		}
		if (Input.GetKey(KeyCode.A))
		{
			transform.Rotate(new Vector3(0, -1, 0));
			transform.position -= transform.right * 2 * Time.deltaTime;
		}
	}
}
