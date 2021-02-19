using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player : MonoBehaviour
{
	private GameObject body;
    // Start is called before the first frame update
    void Start()
    {
		body = this.transform.Find("body").gameObject;
    }

    // Update is called once per frame
    void Update()
    {
		Vector3 move = new Vector3(0,0,0);
		float step = 2 * Time.deltaTime;
		if (Input.GetKey(KeyCode.W))
		{
			//body.transform.rotation = Quaternion.Slerp(body.transform.rotation, Quaternion.Euler(0, 0, 0), step);
			move += Vector3.forward * 2 * Time.deltaTime;
		}
		if (Input.GetKey(KeyCode.A))
		{
			//body.transform.rotation = Quaternion.Slerp(body.transform.rotation, Quaternion.Euler(0, 270.0f, 0), step);
			move -= Vector3.right * 2 * Time.deltaTime;
		}
		if (Input.GetKey(KeyCode.S))
		{
			//body.transform.rotation = Quaternion.Slerp(body.transform.rotation, Quaternion.Euler(0, 180.0f, 0), step);
			move -= Vector3.forward * 2 * Time.deltaTime;
		}
		if (Input.GetKey(KeyCode.D))
		{
			//body.transform.rotation = Quaternion.Slerp(body.transform.rotation, Quaternion.Euler(0, 90.0f, 0), step);
			move += Vector3.right * 2 * Time.deltaTime;
		}
		float angle = Mathf.Atan2(move.x, move.z) * Mathf.Rad2Deg;
		if (move != Vector3.zero)
		{
			float mathAngle = Mathf.Abs(body.transform.rotation.eulerAngles.y - angle);
			Debug.Log(mathAngle);
			mathAngle = mathAngle > 180.0f ? Mathf.Abs(mathAngle - 360.0f) : mathAngle;
			
			float parsent = mathAngle / 180.0f;
			float speed = Mathf.Max(30.0f * parsent, 1.0f);
			
			body.transform.rotation = Quaternion.RotateTowards(body.transform.rotation, Quaternion.Euler(0, angle, 0), speed);
		}
		transform.position += move;
	}
}
