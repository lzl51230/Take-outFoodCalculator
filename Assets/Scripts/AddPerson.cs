using System;
using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.EventSystems;

public class AddPerson : MonoBehaviour
{
    //public Text _result;
    public List<float> CacheList;
    public Action UpdateAction;

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
            float inputMoney;
            if (float.TryParse(_input.text,out inputMoney))
            {
                CacheList.Add(float.Parse(_input.text));
                _input.text = "";
                _input.ActivateInputField();

                if (UpdateAction != null)
                {
                    UpdateAction();
                }
            }
        }
    }

    public void delete()
    {
        if (CacheList.Count > 0)
        {
            CacheList.RemoveAt(CacheList.Count - 1);

            if (UpdateAction != null)
            {
                UpdateAction();
            }
        }
    }

    public void delete(float money)
    {
        if (CacheList.Contains(money))
        {
            CacheList.Remove(money);

            if (UpdateAction != null)
            {
                UpdateAction();
            }
        }
    }
}
