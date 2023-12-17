using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Timer : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI timerText;
    [SerializeField] float remainingTime;
    [SerializeField] private GameObject timerPanel;

    void Update()
    {
        if (remainingTime > 0){
            remainingTime -= Time.deltaTime;
        }
        else if(remainingTime < 0){
            remainingTime = 0;
            timerPanel.SetActive(false);
            GameManager.Instance.GameOver();
            
        }
        int minutos = Mathf.FloorToInt(remainingTime / 60);
        int segundos = Mathf.FloorToInt(remainingTime % 60);
        timerText.text = string.Format("{0:00}:{1:00}", minutos, segundos);
        

    }
}
