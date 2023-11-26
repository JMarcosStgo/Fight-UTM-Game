using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class selecSeceneHide : MonoBehaviour, IPointerClickHandler
{
    public GameObject gameobjet;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        GameObject[] objectsWithTag = GameObject.FindGameObjectsWithTag("audioManager");
        foreach (GameObject obj in objectsWithTag)
        {
            Destroy(obj);
        }

        if (gameObject.tag== "selectSceneEntradautm")
        {
            SceneManager.LoadScene("Entrada");
        }
        if (gameObject.tag == "selectSceneComputacion")
        {
            SceneManager.LoadScene("Computación");
        }

    }
}
