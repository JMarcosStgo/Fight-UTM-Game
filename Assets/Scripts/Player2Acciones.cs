using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player2Acciones : MonoBehaviour
{
    public float velocidad = 0.0f;
    public float rotacion = 100.0f;
    private Animator anim;
    public float x, y, mandoX, mandoY;
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        x = Input.GetAxis("Horizontal2");
        y = Input.GetAxis("Vertical2");

        mandoX = Input.GetAxis("6th axis2");
        mandoY = Input.GetAxis("7th axis2");

        transform.Rotate(0, y * Time.deltaTime * rotacion, 0);
        transform.Translate(0, 0, x * Time.deltaTime * velocidad);

        transform.Rotate(0, mandoY * Time.deltaTime * rotacion, 0);
        transform.Translate(0, 0, mandoX * Time.deltaTime * velocidad * -1);

        //transform.Translate(-y * Time.deltaTime * velocidad, 0, 0);
        anim.SetFloat("X", x);
        //anim.SetFloat("X", mandoX);

        if (Input.GetKeyDown(KeyCode.J) || Input.GetKey(KeyCode.Joystick2Button2))
        {
            anim.SetTrigger("punch1");
        }

        if (Input.GetKeyDown(KeyCode.I) || Input.GetKey(KeyCode.Joystick2Button3))
        {
            anim.SetTrigger("punch2");
        }

        if (Input.GetKeyDown(KeyCode.K) || Input.GetKey(KeyCode.Joystick2Button0))
        {
            anim.SetTrigger("kick1");
        }

        if (Input.GetKeyDown(KeyCode.L) || Input.GetKey(KeyCode.Joystick2Button1))
        {
            anim.SetTrigger("kick2");
        }

        if (Input.GetKeyDown(KeyCode.H))
        {
            anim.SetTrigger("victory");
            return;
        }

        if (Input.GetKeyDown(KeyCode.Y))
        {
            anim.SetTrigger("lose");
            return;
        }
    }
}
