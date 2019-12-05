using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScrollViewAdapter : MonoBehaviour
{
    public RectTransform prefab;
    //public Text countText;
    public RectTransform content;
    public List<Zabiv> models;
    EasyHookah eh = new EasyHookah();

    public void Start()
    {
        eh.initList();
        eh.CreateZabiv();
        int modelsCount = eh.getSize();
        //int.TryParse(countText.text, out modelsCount);
        StartCoroutine(GetItems(modelsCount, results => OnReceivedModels(results)));
        models = new List<Zabiv>();
    }

    public void AddOrderOnBasket(int id)
    {
        if (ListOrderOnBasket.order == null)
        {
            Order order = new Order();
            order.addElementToOrder(models[id], ListOrderOnBasket.userName, "Бeз комкентариев");
            ListOrderOnBasket.order = new Order();
            ListOrderOnBasket.order = order;
            print("add order");
        }
        else
        {
            ListOrderOnBasket.order.addElementToOrder(models[id]);
            print("add zabiv " + models[id].getFlavour1().getFlavour());
            
        }
        
    }
    

    void OnReceivedModels(TestItemModel[] models)
    {
        foreach (Transform child in content)
        {
            Destroy(child.gameObject);
        }

        foreach (var model in models)
        {
            var instance = GameObject.Instantiate(prefab.gameObject) as GameObject;
            instance.transform.SetParent(content, false);
            InitializeItemView(instance, model);
        }
    }

    void InitializeItemView(GameObject viewGameObject, TestItemModel model)
    {
        TestItemView view = new TestItemView(viewGameObject.transform);
        view.id.text = model.id;
        view.titleText.text = model.title;
        view.clickButton.GetComponentInChildren<Text>().text = model.buttonText;
        view.clickButton.onClick.AddListener(
            () =>
            {
                Debug.Log(view.titleText.text + " is clicked!");
            }
        );
    }

    IEnumerator GetItems(int count, System.Action<TestItemModel[]> callback)
    {
        yield return new WaitForSeconds(0f);
        var results = new TestItemModel[count];
        for (int i = 0; i < count; i++)
        {
            results[i] = new TestItemModel();
            results[i].id = i.ToString();
            results[i].title = eh.getElement(i).getName();
            results[i].buttonText ="Крепкость: " + eh.getElement(i).getStrength().ToString();
            models.Add(eh.getElement(i));
        }

        callback(results);
    }

    public class TestItemView
    {
        public Text id;
        public Text titleText;
        public Button clickButton;

        public TestItemView(Transform rootView)
        {
            id = rootView.Find("TextId").GetComponent<Text>();
            titleText = rootView.Find("TitleText").GetComponent<Text>();
            clickButton = rootView.Find("ClickButton").GetComponent<Button>();
        }
    }

    public class TestItemModel//Название кнопки и текст
    {
        public string id;
        public string title;
        public string buttonText;
    }
    
    
    
}
