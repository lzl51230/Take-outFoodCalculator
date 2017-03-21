using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.EventSystems;

public class AddPerson : MonoBehaviour
{
    //public Text _result;
    public List<float> CacheList;

    private EventSystem system;
    private InputField _input;
    

    void Start()
    {
        system = EventSystem.current;
        _input = transform.GetComponent<InputField>();
        CacheList = new List<float>();
    }

    // Update is called once per frame
    private void Update()
    {
        if ((Input.GetKeyDown(KeyCode.KeypadEnter) || Input.GetKeyDown(KeyCode.Return)) &&
            system.currentSelectedGameObject == gameObject)
        {
            CacheList.Add(float.Parse(_input.text));
            _input.text = "";
            _input.ActivateInputField();
        }
    }

    public void delete()
    {
        if (CacheList.Count > 0)
        {
            CacheList.RemoveAt(CacheList.Count - 1);
        }
    }
}
