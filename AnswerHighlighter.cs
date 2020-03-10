using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;

public class AnswerHighlighter : MonoBehaviour
{

    ToggleGroup toggleGroupInstance;

    public Toggle currentSelection{ 
        get {
            return toggleGroupInstance.ActiveToggles().FirstOrDefault();
        }
            
    }    // Start is called before the first frame update
    void Start()
    {
        toggleGroupInstance = GetComponent<ToggleGroup>();
        SelectToggle(1);
    }

    public void SelectToggle(int id)
    {
        var toggles = toggleGroupInstance.GetComponentsInChildren<Toggle>();
        toggles[id].isOn = true;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
