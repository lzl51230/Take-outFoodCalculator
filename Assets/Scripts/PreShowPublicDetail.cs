using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PreShowPublicDetail : MonoBehaviour
{
    public Text SourcePrice;

    protected float _sourcePrice;
    public virtual void Init(float sourcePrice)
    {
        _sourcePrice = sourcePrice;
        SourcePrice.text = sourcePrice.ToString("F2");
    }

    public virtual void Delete()
    {
        MainCal.Instance.AllPerson.delete(_sourcePrice);
    }
}
