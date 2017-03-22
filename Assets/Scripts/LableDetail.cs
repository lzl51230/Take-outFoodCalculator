using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LableDetail : MonoBehaviour {

    public Text ChangeText;

    public void Init(string changeText)
    {
        ChangeText.text = changeText;
    }
}
