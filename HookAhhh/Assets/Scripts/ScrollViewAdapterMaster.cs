using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.UI;

public class ScrollViewAdapterMaster : MonoBehaviour
{
    public RectTransform prefab;
    public RectTransform content;
    public int countModel = 0;
    private RectTransform rect;
    
    public class ZabivMasterModel
    {
        public string guest;
        public string strength1;
        public string strength2;
        public string strength3;
        public string label1;
        public string label2;
        public string label3;
        public string comments;
    }
    
    public class ZabivMasterView
    {
        public Text guestText;
        public Text strength1Text;
        public Text strength2Text;
        public Text strength3Text;
        public Text label1Text;
        public Text label2Text;
        public Text label3Text;
        public Text commentsText;

        

        public ZabivMasterView(Transform rootView)
        {
            guestText = rootView.Find("Text guest").GetComponent<Text>();
            strength1Text = rootView.Find("Tabacco 1/Text percent").GetComponent<Text>();
            strength2Text = rootView.Find("Tabacco 2/Text percent").GetComponent<Text>();
            strength3Text = rootView.Find("Tabacco 3/Text percent").GetComponent<Text>();
            label1Text = rootView.Find("Tabacco 1/Text tabacco").GetComponent<Text>();
            label2Text = rootView.Find("Tabacco 2/Text tabacco").GetComponent<Text>();
            label3Text = rootView.Find("Tabacco 3/Text tabacco").GetComponent<Text>();
            commentsText = rootView.Find("Comments/Text comments").GetComponent<Text>();
        }
    }

    public void UpdateItems()
    {
        countModel += 1;
        StartCoroutine(GetItems(countModel, results => OnReceivedModels(results)));
    }

    void OnReceivedModels(ZabivMasterModel[] models)
    {
        foreach (Transform child in content)
        {
            Destroy(child.gameObject);
        }

        foreach (var model in models)
        {
            var instance = GameObject.Instantiate(prefab.gameObject, content, false) as GameObject;
            InitializeItemView(instance, model);
        }
    }
    
    public static void SetSize(RectTransform trans, Vector2 newSize) {
        Vector2 oldSize = trans.rect.size;
        Vector2 deltaSize = newSize - oldSize;
        trans.offsetMin = trans.offsetMin - new Vector2(deltaSize.x * trans.pivot.x, deltaSize.y * trans.pivot.y);
        trans.offsetMax = trans.offsetMax + new Vector2(deltaSize.x * (1f - trans.pivot.x), deltaSize.y * (1f - trans.pivot.y));
    }
    
    public static void SetHeight(RectTransform trans, float newSize) {
        
        SetSize(trans, new Vector2(trans.rect.size.x, newSize));
    }

    void InitializeItemView(GameObject viewGameObject, ZabivMasterModel model)
    {
        
        ZabivMasterView view = new ZabivMasterView(viewGameObject.transform);
        view.guestText.text = model.guest;
        view.strength1Text.text = model.strength1;
        view.strength2Text.text = model.strength2;
        view.strength3Text.text = model.strength3;
        view.label1Text.text = model.label1;
        view.label2Text.text = model.label2;
        view.label3Text.text = model.label3;
        view.commentsText.text = model.comments;
        rect = viewGameObject.transform.Find("Comments/Text comments").GetComponent<RectTransform>();
        /*float textWidth = LayoutUtility.GetPreferredHeight(view.commentsText.rectTransform);
        float parentWidth = rect.rect.height;
        print(textWidth + " " + parentWidth);*/
        
    }
    

    IEnumerator GetItems(int count, System.Action<ZabivMasterModel[]> callback)
    {
        yield return new WaitForSeconds(1f);
        var results = new ZabivMasterModel[count];
        for (int i = 0; i < count; i++)
        {
            results[i] = new ZabivMasterModel();
            results[i].guest = "Гость Nikita";
            results[i].strength1 = "14%";
            results[i].strength2 = "52%";
            results[i].strength3 = "34%";
            results[i].label1 = "Какой-то табак";
            results[i].label2 = "Какой-то табак";
            results[i].label3 = "Какой-то табак";
            results[i].comments = "Без комментариев";
        }

        callback(results);
    }
}
