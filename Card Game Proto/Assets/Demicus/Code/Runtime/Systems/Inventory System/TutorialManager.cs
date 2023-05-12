using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TutorialManager : MonoBehaviour
{
    public List<string> tutorStates;
    [SerializeField] TextMeshProUGUI textField;
    public int currentState = 0;
    // Start is called before the first frame update
    public void NextState()
    {
        if(currentState<tutorStates.Count-1)
        {
            currentState++;
            textField.text = tutorStates[currentState];
            
        }
    }
    public void LastState()
    {
        if (currentState-1 >= 0)
        {
            currentState--;
            textField.text = tutorStates[currentState];
            
        }
    }
}
