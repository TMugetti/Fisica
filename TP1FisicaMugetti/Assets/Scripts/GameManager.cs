using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    [SerializeField] Text TurnCounter;
    [SerializeField] Text LeftLife;
    [SerializeField] Text RightLife;
    private int leftLifeCounter;
    private int rightLifeCounter;
    private bool LeftTurn;
    void Start()
    {
        LeftTurn = true;
        leftLifeCounter = 3;
        rightLifeCounter = 3;
        TurnCounter.text = "Left's turn";
        LeftLife.text = leftLifeCounter.ToString();
        RightLife.text = rightLifeCounter.ToString();
    }

    // Update is called once per frame
   public void EndTurn(){ LeftTurn = !LeftTurn; if(LeftTurn){ TurnCounter.text = "Left's turn";} else{ TurnCounter.text = "Right's turn";}}
   public bool IsLeftTurn(){return LeftTurn;}
   public void UpdateLife(bool Left){
       if(Left){leftLifeCounter--; LeftLife.text = leftLifeCounter.ToString();} 
       else { rightLifeCounter--; RightLife.text = rightLifeCounter.ToString();}
       if(leftLifeCounter <= 0 || rightLifeCounter <= 0){ TurnCounter.text = "Match ended";}

   }
}
