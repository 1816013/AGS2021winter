using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class breakShader : MonoBehaviour
{
    float frame = 0;
    float breakFrame = 0.0f;
    Material myMat;
    // Start is called before the first frame update
    void Start()
    {
        myMat = GetComponent<Renderer>().material;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        frame += Time.deltaTime;
        if (frame >= 1)
        {
            frame = 0;
            breakFrame += 0.1f;
            if(breakFrame >= 1)
            {
                breakFrame = 0;
            }
        }
        if(myMat.HasProperty("_BreakUV"))
        {
            myMat.SetFloat("_BreakUV", breakFrame);
        }
    }
}
