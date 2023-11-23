using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class AplicationQuit : MonoBehaviour, IPointerClickHandler
{
    // Referencia al Text de comando
    public Text textMeshPro;
    private string textoo;

    // Función para salir del juego
    void exit()
    {
        // Cierra el juego si está en una plataforma de escritorio
        #if UNITY_STANDALONE
            Application.Quit();
        #endif

        // Cierra el juego si está en el editor de Unity
        #if UNITY_EDITOR
            UnityEditor.EditorApplication.isPlaying = false;
        #endif
    }
    void comenzar()
    {
        SceneManager.LoadScene("Entrada");
    }

    // Evento que captura el click sobre el botón
    public void OnPointerClick(PointerEventData eventData)
    {
        textoo = textMeshPro.text;
        if (textoo == "SALIR")
        {
            exit();
        }
        if (textoo == "COMENZAR")
        {
            comenzar();
        }
    }
}

