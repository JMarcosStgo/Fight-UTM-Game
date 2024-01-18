using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PlayerAcciones : MonoBehaviour
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
    Transform target2;
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
        target = GameObject.FindWithTag("Enemy").transform;
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
                    OnAtaque.Invoke();
                    playerAudio.PlayOneShot(golpe, 1.0f);
                }

                if (Input.GetKeyDown(KeyCode.W) || Input.GetKey(KeyCode.Joystick1Button3))
                {
                    anim.SetTrigger("punch2");
                    animacion = true;
                    OnAtaque.Invoke();
                    playerAudio.PlayOneShot(golpe, 1.0f);
                }

                if (Input.GetKeyDown(KeyCode.S) || Input.GetKey(KeyCode.Joystick1Button0))
                {
                    anim.SetTrigger("kick1");
                    animacion = true;
                    OnAtaque.Invoke();
                    playerAudio.PlayOneShot(golpe, 1.0f);
                }

                if (Input.GetKeyDown(KeyCode.D) || Input.GetKey(KeyCode.Joystick1Button1))
                {
                    anim.SetTrigger("kick2");
                    animacion = true;
                    OnAtaque.Invoke();
                    playerAudio.PlayOneShot(golpe, 1.0f);
                }

                float distancia = Vector3.Distance(transform.position, target.position);
                if (distancia < distanciaDeteccion)
                {
                    FindObjectOfType<EnemyAcciones>().OnAtaque.AddListener(RecibirGolpe);
                }

                FindObjectOfType<EnemyAcciones>().pierde.AddListener(Win);
                //if (Input.GetKeyDown(KeyCode.Y))
                //{
                    //anim.SetTrigger("victory");
                    //animacion = true;
                    //fin = true;
                    //playerAudio.PlayOneShot(win, 1.7f);
                //}

                //if (Input.GetKeyDown(KeyCode.H))
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
        playerAudio.PlayOneShot(win, 1.7f);
    }

    void RecibirGolpe()
    {
        int hit = Random.Range(0, 3);
        vida -= 2;
        if (vida <= 0)
        {
            Debug.Log("Enemy Win");
        }
        else if (hit == 0)
        {
            anim.SetTrigger("hit1");
            animacion = true;
            StartCoroutine(Esperar());
        }
        else  if (hit == 1) 
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
}
