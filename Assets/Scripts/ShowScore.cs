using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ShowScore : MonoBehaviour
{
    public TextMeshProUGUI scoreText;

    void Start()
    {
        // Result sahnesine geçildiğinde score değerini ekranda göster
        scoreText.text = "Your Score is: " + UiManager.score;
    }
}
