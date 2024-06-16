using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GiveValue : MonoBehaviour
{
    [SerializeField] Text myText;
    // Start is called before the first frame update
    public void Start()
    {
        string newText = StaticData.valueToKeep;
        myText.text = string.Format(newText);;
        Debug.Log("many times: " + newText);
    }
}
