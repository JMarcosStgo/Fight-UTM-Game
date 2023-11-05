using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAcciones : MonoBehaviour
{
    private Animator anim;
    public GameObject player = new GameObject();
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (player.transform.position.x-1.5 < transform.position.x)
        {
            int accion = Random.Range(0, 5);
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
    }
}
