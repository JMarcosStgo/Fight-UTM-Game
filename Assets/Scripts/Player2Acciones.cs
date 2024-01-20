using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using static UnityEngine.GraphicsBuffer;

public class Player2Acciones : MonoBehaviour
{
    public float velocidad = 3.0f;
    public float rotacion = 100.0f;
    private Animator anim;
    public float x, y, mandoX, mandoY;
    private bool animacion = false;
    private int aux = 0;
    private bool fin = false;
    public UnityEvent OnAtaque;
    public UnityEvent pierde;
    public float distanciaDeteccion = 1.5f;
    Transform target;
    public ParticleSystem start;
    public ParticleSystem Light;
    public AudioClip golpe;
    public AudioClip win;
    public AudioClip lose;
    public AudioClip ouch;
    private AudioSource playerAudio;
    public int vida = 100;
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        target = GameObject.FindWithTag("Player").transform;
        start.Stop();
        Light.Stop();
        playerAudio = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!fin)
        {
            if (!animacion)
            {
                aux = 0;
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
                    animacion = true;
                    OnAtaque.Invoke();
                    playerAudio.PlayOneShot(golpe, 1.0f);
                }

                if (Input.GetKeyDown(KeyCode.I) || Input.GetKey(KeyCode.Joystick2Button3))
                {
                    anim.SetTrigger("punch2");
                    animacion = true;
                    OnAtaque.Invoke();
                    playerAudio.PlayOneShot(golpe, 1.0f);
                }

                if (Input.GetKeyDown(KeyCode.K) || Input.GetKey(KeyCode.Joystick2Button0))
                {
                    anim.SetTrigger("kick1");
                    animacion = true;
                    OnAtaque.Invoke();
                    playerAudio.PlayOneShot(golpe, 1.0f);
                }

                if (Input.GetKeyDown(KeyCode.L) || Input.GetKey(KeyCode.Joystick2Button1))
                {
                    anim.SetTrigger("kick2");
                    animacion = true;
                    OnAtaque.Invoke();
                    playerAudio.PlayOneShot(golpe, 1.0f);
                }

                float distancia = Vector3.Distance(transform.position, target.position);
                if (distancia < distanciaDeteccion)
                {
                    FindObjectOfType<Player1Acciones>().OnAtaque.AddListener(RecibirGolpe);
                }

                FindObjectOfType<Player1Acciones>().pierde.AddListener(Win);
                //if (Input.GetKeyDown(KeyCode.H))
                //{
                    //anim.SetTrigger("victory");
                    //animacion = true;
                    //fin = true;
                    //playerAudio.PlayOneShot(win, 1.7f);
                //}

                //if (Input.GetKeyDown(KeyCode.Y))
                if (vida <= 0)
                {
                    pierde.Invoke();
                    anim.SetTrigger("lose");
                    animacion = true;
                    fin = true;
                    playerAudio.PlayOneShot(lose, 2.0f);
                }
            }
            else
            {
                aux++;
                if (aux == 60)
                {
                    animacion = false;
                    start.Stop();
                    Light.Stop();
                }
            }
        }
    }

    void Win()
    {
        anim.SetTrigger("victory");
        animacion = true;
        fin = true;
        StartCoroutine(Esperar2());
    }

    void RecibirGolpe()
    {
        int hit = Random.Range(0, 3);
        vida -= 2;
        if (vida <= 0)
        {
            Debug.Log("Player 1 Win");
        }
        else if (hit == 0)
        {
            anim.SetTrigger("hit1");
            animacion = true;
            StartCoroutine(Esperar());
        }
        else if (hit == 1)
        {
            anim.SetTrigger("hit2");
            animacion = true;
            StartCoroutine(Esperar());
        }
    }

    IEnumerator Esperar()
    {
        yield return new WaitForSeconds(0.3f);
        playerAudio.PlayOneShot(ouch, 0.5f);
        start.Play();
        Light.Play();
    }

    IEnumerator Esperar2()
    {
        yield return new WaitForSeconds(2.0f);
        playerAudio.PlayOneShot(win, 1.7f);
    }
}
