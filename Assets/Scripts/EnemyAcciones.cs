using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyAcciones : MonoBehaviour
{
    private Animator anim;
    public GameObject player = new GameObject();
    public float distanciaDeteccion = 1.5f;
    NavMeshAgent agent;
    Transform target;
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        agent = GetComponent<NavMeshAgent>();
        target = player.transform;
    }

    // Update is called once per frame
    void Update()
    {
        float distancia = Vector3.Distance(transform.position, player.transform.position);
        if (distancia < distanciaDeteccion)
        {
            int accion = UnityEngine.Random.Range(0, 5);
            if (accion == 0) 
            {
                anim.SetTrigger("punch1");
            }
            else if (accion == 1)
            {
                anim.SetTrigger("punch2");
            }
            else if (accion == 2) 
            {
                anim.SetTrigger("kick1");
            }
            else if (accion == 3)
            {
                anim.SetTrigger("kick2");
            }
        }
        else
        {
            //Vector3 direccion = player.transform.position - transform.position;
            //direccion.Normalize();
            //transform.Translate(direccion * Time.deltaTime);
            agent.SetDestination(target.position);
            float speed;
            speed = agent.velocity.magnitude;
            speed = Mathf.Clamp01(speed);
            anim.SetFloat("X", speed, 0.1f, Time.deltaTime);
            //transform.Translate(0, 0, speed * Time.deltaTime);
        }
    }
}
