using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player : MonoBehaviour
{
	private GameObject body;
    float inputHorizontal;
    float inputVertical;
    Rigidbody rb;
    // Start is called before the first frame update
    void Start()
    {
        rb = this.GetComponent<Rigidbody>();
		body = this.transform.Find("body").gameObject;
    }

    // Update is called once per frame
    void Update()
    {
        inputHorizontal = Input.GetAxisRaw("Horizontal");
        inputVertical = Input.GetAxisRaw("Vertical");
        // 方向キーの入力値とカメラの向きから、移動方向を決定
        Vector3 moveForward = this.transform.forward * inputVertical + this.transform.right * inputHorizontal;
        // 移動方向にスピードを掛ける。
        Vector3 move = moveForward * 1;
		//float step = 2 * Time.deltaTime;
		float angle = Mathf.Atan2(move.x, move.z) * Mathf.Rad2Deg;
		if (move != Vector3.zero && inputVertical >= 0)
		{
			float mathAngle = Mathf.Abs(this.transform.rotation.eulerAngles.y - angle);
			mathAngle = mathAngle > 180.0f ? Mathf.Abs(mathAngle - 360.0f) : mathAngle;
			
			float parsent = mathAngle / 180.0f;
			float speed = Mathf.Max(30.0f * parsent, 1.0f);
			
			this.transform.rotation = Quaternion.RotateTowards(this.transform.rotation, Quaternion.Euler(0, angle, 0), speed);
		}
		rb.velocity = move;
	}
}
