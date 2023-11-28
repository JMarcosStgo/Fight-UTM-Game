using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class selecSeceneHide : MonoBehaviour, IPointerClickHandler, IPointerEnterHandler , IPointerExitHandler
{
    public GameObject gameobjet;
    public Canvas canvas;
    private Image myImage;
    public AudioSource audio;
    // Start is called before the first frame update
    void Start()
    {

        myImage = canvas.GetComponent<Image>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void OnPointerClick(PointerEventData eventData)
    {
        Debug.Log("OnPointerClick");
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

    public void OnPointerEnter(PointerEventData eventData)
    {
        audio.Play();
        Color color;
        if (UnityEngine.ColorUtility.TryParseHtmlString("#1313EB", out color))
        {
            myImage.color = color;
        }
        // myImage.color = Color.RGBToHSV();
    }
    public void OnPointerExit(PointerEventData eventData)
    {
        audio.Stop();
        myImage.color = Color.white; //esta linea ay q checarlo   

    }
}
