using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class MainManu : MonoBehaviour
{
    public void Jugar()
    {
        SceneManager.LoadScene(1); // build index de la escena a cargar
    }
    public void Salir()
    {
        Application.Quit();
    }
}
