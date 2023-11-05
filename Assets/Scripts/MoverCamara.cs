using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoverCamara : MonoBehaviour
{
    public Vector3 updateZ = new Vector3(0, 0, 1);
    public Vector3 updateY = new Vector3(0, 1, 0);
    private float update = 0;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (update > 30)
        {
            if (transform.position.y > 2)
            {
                transform.position -= updateY;
            }
        }
        update++;
        //Debug.Log(transform.position);
        if (transform.position.z > -5)
        {
            transform.position -= updateZ;
        }
    }
}
