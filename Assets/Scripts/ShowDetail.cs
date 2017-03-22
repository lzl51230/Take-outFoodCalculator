using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class ShowDetail : MonoBehaviour
{
    private VerticalLayoutGroup _layout;
    private string _labelPath = "Perfebs/Lable", _personalPath = "Perfebs/PreShowPersonalDetail", _publicPath = "Perfebs/PreShowPublicDetail";

	void Awake ()
	{
	    _layout = GetComponentInChildren<VerticalLayoutGroup>();
	}

    public void UpdateShow(List<KeyValuePair<float,float>> personalList,List<float> allPersonList)
    {
        var deleteList = _layout.GetComponentsInChildren<Transform>();
        for (int i = 0; i < deleteList.Count(); i++)
        {
            if (deleteList[i] == _layout.transform)
            {
                continue;
            }

            GameObject.Destroy(deleteList[i].gameObject);
        }

        UpdatePersonal(personalList);
        UpdatePublic(allPersonList);

        StartCoroutine(UpadteHeight());
    }

    private void UpdatePersonal(List<KeyValuePair<float, float>> personalList)
    {
        var lable = Instantiate(Resources.Load<GameObject>(_labelPath));
        lable.transform.parent = _layout.transform;
        lable.GetComponent<LableDetail>().Init("每人外卖价：");

        var personalItem = Resources.Load<GameObject>(_personalPath);
        foreach (KeyValuePair<float, float> pair in personalList)
        {
            var item = Instantiate(personalItem);
            item.transform.parent = _layout.transform;
            item.GetComponent<PreShowPersonalDetail>().Init(pair);
        }
    }

    private void UpdatePublic(List<float> allPersonList)
    {
        var lable = Instantiate(Resources.Load<GameObject>(_labelPath));
        lable.transform.parent = _layout.transform;
        lable.GetComponent<LableDetail>().Init("一起分摊费用：");

        var publicItem = Resources.Load<GameObject>(_publicPath);
        foreach (float money in allPersonList)
        {
            var item = Instantiate(publicItem);
            item.transform.parent = _layout.transform;
            item.GetComponent<PreShowPublicDetail>().Init(money);
        }
    }
    IEnumerator UpadteHeight()
    {
        yield return new WaitForEndOfFrame();
        var height = _layout.preferredHeight;
        _layout.GetComponent<RectTransform>().sizeDelta = new Vector2(0, height);
    }
}
