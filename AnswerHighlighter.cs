using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;

public class AnswerHighlighter : MonoBehaviour
{

    ToggleGroup toggleGroupInstance;
    int toggleId = 3;

    public Toggle currentSelection{ 
        get {
            return toggleGroupInstance.ActiveToggles().FirstOrDefault();
        }
            
    }    // Start is called before the first frame update
    void Start()
    {
        toggleGroupInstance = GetComponent<ToggleGroup>();
        SelectToggle(3);
    }

    public void SelectToggle(int id)
    {
        toggleId = id;
        var toggles = toggleGroupInstance.GetComponentsInChildren<Toggle>();
        toggles[id].isOn = true;
      
    }

    public void changeToggleID(int direction)
    {
        if(toggleId == 5 && direction == 1)
        {  
            SelectToggle(0);

        } else if (toggleId == 0 && direction == -1)
        {
            
            SelectToggle(5);
        }
        else { SelectToggle(toggleId + direction); }
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
