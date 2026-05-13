using TMPro;
using UnityEngine;
using UnityEngine.UI;
public class GameManager : MonoBehaviour
{
    int score;
    public static GameManager inst;

    public TextMeshProUGUI scoringText;

    public void Plus1Score()
    {
        score++;
        scoringText.text = "Score = " + score;
    }

    private void Awake()
    {
        inst = this;
    }
  
   
    
        
    
}
