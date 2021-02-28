using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player : MonoBehaviour
{
    [SerializeField]
    private float touchMargine = 200.0f;
    [SerializeField]
    private GameObject body;
    private Animator animator_;

    float inputHorizontal;
    float inputVertical;
    Vector2 touchStart;
    Rigidbody rb;


    // Start is called before the first frame update
    void Start()
    {
        rb = this.GetComponent<Rigidbody>();
        animator_ = transform.Find("orange").GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        PlayerInput();
        Vector2 axis = GetAxisRawByInput();

        inputHorizontal = axis.x;
        inputVertical = axis.y;

        // 移動モーション
        animator_.SetFloat("axis", axis.y);
    }

    private void FixedUpdate()
    {
        // 方向キーの入力値とカメラの向きから、移動方向を決定
        Vector3 moveDir = this.transform.forward * inputVertical + this.transform.right * inputHorizontal;
        float angle = Mathf.Atan2(moveDir.x, moveDir.z) * Mathf.Rad2Deg;
        if (moveDir != Vector3.zero && inputVertical > -0.2)
        {
            float mathAngle = Mathf.Abs(this.transform.rotation.eulerAngles.y - angle);
            mathAngle = mathAngle > 180.0f ? Mathf.Abs(mathAngle - 360.0f) : mathAngle;

            float parsent = mathAngle / 180.0f;
            float speed = Mathf.Max(20.0f * parsent, 1.0f);

            this.transform.rotation = Quaternion.RotateTowards(this.transform.rotation, Quaternion.Euler(0, angle, 0), speed);
        }

        // 移動は前か後ろしかしないためVerticalのみ
        Vector3 move = this.transform.forward * inputVertical;
        // 移動方向にスピードを掛ける。
        move *= 5;
        rb.velocity = move;
    }

    private void PlayerInput()
    {
        if (Application.isEditor||Application.platform==RuntimePlatform.WindowsPlayer)
        {
            if (Input.GetMouseButton(0))
            {
                SetIsDig(true);
            }
            else
            {
                SetIsDig(false);
            }
        }
        else
        {
            if (Input.touchCount >= 0)
            {
                SetIsDig(true);
            }
            else
            {
                SetIsDig(false);
            }
        }
    }

    public void SetIsDig(bool isDig)
    {
        animator_.SetBool("isDig", isDig);
        
    }

    Vector2 GetAxisRawByInput()
    {
        Vector2 ret = Vector2.zero;
        if (Application.isEditor || Application.platform == RuntimePlatform.WindowsPlayer)
        {
            ret.x = Input.GetAxisRaw("Horizontal");
            ret.y = Input.GetAxisRaw("Vertical");
        }
        else
        {
            //タップ情報の取得
            if(Input.touchCount <= 0)
            {
                return ret;
            }
            Touch touch = Input.GetTouch(0);
            //タップ状態の分岐
            switch (touch.phase)
            {
                //タップ開始
                case TouchPhase.Began:
                    //タッチ開始座標、時間取得
                    touchStart = touch.position;
                    break;

                // タップ中(スワイプ)
                case TouchPhase.Moved:
                case TouchPhase.Stationary:
                    Vector2 vec = touch.position - touchStart;
                    Debug.Log(vec.magnitude);
                    if (vec.magnitude > touchMargine)
                    {
                        vec.Normalize();
                        ret.x = vec.x;
                        ret.y = vec.y;
                    }
                    break;

                // タップ終了
                case TouchPhase.Ended:
                    // タップ終了位置取得
                    Vector2 endPos = Input.mousePosition;
                    break;
                default:
                    break;
            }
        }

        return ret;
    }
}
