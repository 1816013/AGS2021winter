using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameraCtr : MonoBehaviour
{
    [SerializeField]
    private GameObject target = null;
    [SerializeField]
    private float distance = 1;
    [SerializeField]
    private float height = 5;

    // Start is called before the first frame update
    void Start()
    {
 
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 targetNVec = Vector3.Normalize(transform.position - target.transform.position);
        Ray ray = new Ray(target.transform.position, targetNVec);
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit, distance))
        {
            Vector3 pos = target.transform.position + (hit.point - targetNVec);
            Debug.Log(pos);
            this.transform.position = new Vector3(pos.x, height, pos.z);
            Vector3 targetVec = target.transform.position - transform.position + new Vector3(0, 1, 0);
            this.transform.rotation = Quaternion.LookRotation(targetVec);
            //Vector3 pos = target.transform.position + (-targetNVec * distance);
            //// Debug.Log(pos);
            //this.transform.position = new Vector3(pos.x, height, pos.z);
            //Vector3 targetVec = target.transform.position - transform.position + new Vector3(0, 1, 0);
            //this.transform.rotation = Quaternion.LookRotation(targetVec);
            // Debug.Log("hit");
        }
        else
        {
            //Debug.Log(targetNVec);
            //Vector3 pos = target.transform.position + (targetNVec * distance);
            //Debug.Log(pos);
            //this.transform.position = new Vector3(0, 10, 0);
            //Vector3 targetVec = (target.transform.position - transform.position) + new Vector3(0, 1, 0);
            //this.transform.rotation = Quaternion.LookRotation(targetVec);
        }
    }
}
