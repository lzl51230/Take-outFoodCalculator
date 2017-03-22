using System;
using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;
using System.Text;

public class cal : MonoBehaviour
{
    public AddPerson Person, AllPerson;
    public InputField total;

    private Text Result;
    private List<KeyValuePair<float, float>> _calResult = new List<KeyValuePair<float, float>>(); 
    // Use this for initialization
    void Start ()
    {
        Result = transform.GetComponent<Text>();
    }
	
	// Update is called once per frame
    private void Update()
    {
        //排除所有商品单价总和小于等于0
        float temp = 0;
        foreach (var money in Person.CacheList)
        {
            temp += money;
        }
        if (temp<=0)
        {
            temp = 1;
        }

        //排除当allPersonPrice有值，PersonList无值时的错误
        float allPersonPrice = 0;
        foreach (var money in AllPerson.CacheList)
        {
            allPersonPrice += money;
        }

        if (Person.CacheList.Count > 0)
        {
            allPersonPrice = allPersonPrice / Person.CacheList.Count;
        }

        //排除总价小于allPersonPrice的情况
        float pecent;
        var totalPrice = float.Parse(total.text);
        if (totalPrice>0 && totalPrice> allPersonPrice && temp > 0)
        {
            pecent = (float.Parse(total.text) - allPersonPrice) / temp;
        }
        else
        {
            pecent = 1;
        }

        //计算每个商品
        _calResult = new List<KeyValuePair<float, float>>();
        foreach (var money in Person.CacheList)
        {
            var calPrice = money*pecent + allPersonPrice;
            _calResult.Add(new KeyValuePair<float, float>(money, calPrice));
        }

        var uiString = frontMoney();
        Result.text = uiString;
    }


    private string frontMoney()
    {
        var str = new StringBuilder();
        str.AppendLine("每人外卖价：");
        foreach (var money in _calResult)
        {
            str.AppendLine("原价: "+money.Key.ToString("F2")+"   折后价："+ money.Value.ToString("F2"));
        }

        str.AppendLine("");
        str.AppendLine("一起分摊费用：");
        foreach (var money in AllPerson.CacheList)
        {
            str.AppendLine(money.ToString("F2"));
        }

        return str.ToString();
    }
}
