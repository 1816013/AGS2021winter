using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainModel : MonoBehaviour
{
    // Update is called once per frame
    void Update()
    {
        Transform model = this.transform;

        Vector3 rotation = model.eulerAngles;
        rotation.y += 0.05f;
        model.eulerAngles = rotation;
    }
}
