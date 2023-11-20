using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class MainManu : MonoBehaviour
{
    // Use this for initialization
    public void Jugar()
    {
        SceneManager.LoadScene("Prototype"); //nombre de la escena a cargar
    }
    public void Salir()
    {
        Application.Quit();
    }
}
