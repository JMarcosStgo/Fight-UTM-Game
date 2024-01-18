using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.Events;

public class EnemyAcciones : MonoBehaviour
{
    private Animator anim;
    //public GameObject player = new GameObject();
    public float distanciaDeteccion = 1.5f;
    NavMeshAgent agent;
    Transform target;
    private bool animacion = false;
    private int aux = 0;
    private bool fin = false;
    public int dificultad;
    public UnityEvent OnAtaque;
    public UnityEvent pierde;
    public ParticleSystem start;
    public ParticleSystem Light;
    public AudioClip golpe;
    public AudioClip ouch;
    private AudioSource playerAudio;
    public int vida = 100;
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        agent = GetComponent<NavMeshAgent>();
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
                float distancia = Vector3.Distance(transform.position, target.position);
                if (distancia < distanciaDeteccion)
                {
                    int accion = UnityEngine.Random.Range(0, dificultad);
                    if (accion == (dificultad / 5))
                    {
                        anim.SetTrigger("punch1");
                        animacion = true;
                        OnAtaque.Invoke();
                        playerAudio.PlayOneShot(golpe, 1.0f);
                    }
                    else if (accion == ((dificultad / 5)*2))
                    {
                        anim.SetTrigger("punch2");
                        animacion = true;
                        OnAtaque.Invoke();
                        playerAudio.PlayOneShot(golpe, 1.0f);
                    }
                    else if (accion == ((dificultad / 5)*3))
                    {
                        anim.SetTrigger("kick1");
                        animacion = true;
                        OnAtaque.Invoke();
                        playerAudio.PlayOneShot(golpe, 1.0f);
                    }
                    else if (accion == ((dificultad / 5)*4))
                    {
                        anim.SetTrigger("kick2");
                        animacion = true;
                        OnAtaque.Invoke();
                        playerAudio.PlayOneShot(golpe, 1.0f);
                    }
                }
                else
                {
                    int buscar = UnityEngine.Random.Range(0, dificultad);
                    if (buscar == (dificultad / 2.5))
                    {
                        agent.SetDestination(target.position);
                        anim.SetFloat("X", 1);
                    }
                }

                float walk = Vector3.Distance(agent.transform.position, target.position);
                if (walk <= 2)
                {
                    anim.SetFloat("X", 0);
                }

                if (distancia < distanciaDeteccion)
                {
                    FindObjectOfType<PlayerAcciones>().OnAtaque.AddListener(RecibirGolpe);
                }

                FindObjectOfType<PlayerAcciones>().pierde.AddListener(Win);
                //if (Input.GetKeyDown(KeyCode.H))
                //{
                    //anim.SetTrigger("victory");
                    //animacion = true;
                    //fin = true;
                //}

                //if (Input.GetKeyDown(KeyCode.Y))
                if (vida <= 0)
                {
                    pierde.Invoke();
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
    }

    void RecibirGolpe()
    {
        int hit = UnityEngine.Random.Range(0, 3);
        vida -= 2;
        if (vida <= 0)
        {
            Debug.Log("Player Win");
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
}
