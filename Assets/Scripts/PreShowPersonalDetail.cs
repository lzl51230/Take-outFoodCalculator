using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PreShowPersonalDetail : PreShowPublicDetail
{
    public Text DiscountPrice;

    protected float _discountPrice;
    public virtual void Init(KeyValuePair<float,float> money)
    {
        Init(money.Key);

        _discountPrice = money.Value;
        DiscountPrice.text = money.Value.ToString("F2");
    }

    public override void Delete()
    {
        MainCal.Instance.Person.delete(_sourcePrice);
    }
}
