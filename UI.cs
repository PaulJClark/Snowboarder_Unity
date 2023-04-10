using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class UI : MonoBehaviour

{
    [SerializeField] TextMeshProUGUI scoreText;
    [SerializeField] PlayerController player;

    void Start() 
    {
        scoreText.text = player.GetCurrentScore();
    }

    void Update() 
    {
       scoreText.text = player.GetCurrentScore(); 
    }
}
