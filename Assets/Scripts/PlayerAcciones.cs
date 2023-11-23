using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAcciones : MonoBehaviour
{
    public float velocidad = 0.0f;
    public float rotacion = 100.0f;
    private Animator anim;
    public float x, y, mandoX, mandoY;
    private bool animacion = false;
    private int aux = 0;
    private bool fin = false;
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!fin)
        {
            if (!animacion)
            {
                aux = 0;
                x = Input.GetAxis("Horizontal1");
                y = Input.GetAxis("Vertical1");

                mandoX = Input.GetAxis("6th axis1");
                mandoY = Input.GetAxis("7th axis1");

                transform.Rotate(0, y * Time.deltaTime * rotacion, 0);
                transform.Translate(0, 0, x * Time.deltaTime * velocidad);

                transform.Rotate(0, mandoY * Time.deltaTime * rotacion, 0);
                transform.Translate(0, 0, mandoX * Time.deltaTime * velocidad);

                //transform.Translate(-y * Time.deltaTime * velocidad, 0, 0);
                anim.SetFloat("X", x);
                //anim.SetFloat("X", mandoX);

                if (Input.GetKeyDown(KeyCode.A) || Input.GetKey(KeyCode.Joystick1Button2))
                {
                    anim.SetTrigger("punch1");
                    animacion = true;
                }

                if (Input.GetKeyDown(KeyCode.W) || Input.GetKey(KeyCode.Joystick1Button3))
                {
                    anim.SetTrigger("punch2");
                    animacion = true;
                }

                if (Input.GetKeyDown(KeyCode.S) || Input.GetKey(KeyCode.Joystick1Button0))
                {
                    anim.SetTrigger("kick1");
                    animacion = true;
                }

                if (Input.GetKeyDown(KeyCode.D) || Input.GetKey(KeyCode.Joystick1Button1))
                {
                    anim.SetTrigger("kick2");
                    animacion = true;
                }

                if (Input.GetKeyDown(KeyCode.Y))
                {
                    anim.SetTrigger("victory");
                    animacion = true;
                    fin = true;
                }

                if (Input.GetKeyDown(KeyCode.H))
                {
                    anim.SetTrigger("lose");
                    animacion = true;
                    fin = true;
                }
            }
            else
            {
                aux++;
                if (aux == 60)
                {
                    animacion = false;
                }
            }
        }
    }
}
