using UnityEngine;
using UnityEngine.UI;

public class NumberPickScript : MonoBehaviour
{
    public int currentNumber = 1;
    public int correctNumber = 0;
    public bool isCorrect = false;
    public NumberBoard numberBoard;

    public TextMesh text;
    void Start()
    {
        text.text = currentNumber.ToString();
        isCorrect = IsCorrect();
    }
    public void IncreaseNumber(){
        if(currentNumber>=0&&currentNumber < 9){
            currentNumber++;
            text.text = currentNumber.ToString();
            isCorrect = IsCorrect();
            numberBoard.allCorrect();
        }
    }
    public void DecreaseNumber(){
        if(currentNumber>0&&currentNumber <= 9){
            currentNumber--;
            text.text = currentNumber.ToString();
            isCorrect = IsCorrect();
            numberBoard.allCorrect();
        }
    }

    bool IsCorrect(){
        return currentNumber==correctNumber;
    }
}
