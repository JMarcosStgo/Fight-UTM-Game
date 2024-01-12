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
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        agent = GetComponent<NavMeshAgent>();
        target = GameObject.FindWithTag("Player").transform;
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
                    }
                    else if (accion == ((dificultad / 5)*2))
                    {
                        anim.SetTrigger("punch2");
                        animacion = true;
                        OnAtaque.Invoke();
                    }
                    else if (accion == ((dificultad / 5)*3))
                    {
                        anim.SetTrigger("kick1");
                        animacion = true;
                        OnAtaque.Invoke();
                    }
                    else if (accion == ((dificultad / 5)*4))
                    {
                        anim.SetTrigger("kick2");
                        animacion = true;
                        OnAtaque.Invoke();
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

                if (Input.GetKeyDown(KeyCode.H))
                {
                    anim.SetTrigger("victory");
                    animacion = true;
                    fin = true;
                }

                if (Input.GetKeyDown(KeyCode.Y))
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

    void RecibirGolpe()
    {
        int hit = UnityEngine.Random.Range(0, 3);
        if (hit == 0)
        {
            anim.SetTrigger("hit1");
            animacion = true;
        }
        else
        {
            anim.SetTrigger("hit2");
            animacion = true;
        }
    }
}
