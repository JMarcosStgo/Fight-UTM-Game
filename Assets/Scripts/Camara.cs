using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camara : MonoBehaviour
{
    public float rotacion = 100.0f;
    public float y, mandoY;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        y = Input.GetAxis("Vertical1");
        mandoY = Input.GetAxis("7th axis1");

        transform.Rotate(0, y * Time.deltaTime * rotacion, 0);
        transform.Rotate(0, mandoY * Time.deltaTime * rotacion, 0);
    }
}
