using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;
using Button = UnityEngine.UIElements.Button;
using Image = UnityEngine.UI.Image;

public class ScrollContentBasket : MonoBehaviour
{
    public GameObject scrollView;
    public Camera main_camera;
    private bool canChange = false;
    public GameObject buttonDelete;
    public Order order = new Order();
    public RectTransform prefab;
    public RectTransform content;
    public int countModel = 0;
    private RectTransform rectTransform;
    
    
    
    void Start()
    {
        countModel += ListOrderOnBasket.order.getCountZabiv();
        StartCoroutine(GetItems(countModel, results => OnReceivedModels(results)));
    }

    
    private void Update()
    {
        if(Input.GetKeyDown("mouse 0"))
        {
            Ray ray = main_camera.ScreenPointToRay(Input.mousePosition);
            RaycastHit[] hits;    
            hits = Physics.RaycastAll(ray, 100000.0f);
            for(int i = 0; i < hits.Length; i++)
            {
                if(hits[i].transform.CompareTag("ElementOfContent"))
                {
                    Destroy(hits[i].collider.gameObject);
                    break;
                }
            }
        }
    }

    public void RemoveOrder(int i)
    {
        ListOrderOnBasket.order.removeElementForId(i);
        countModel -= 1;
        StartCoroutine(GetItems(countModel, results => OnReceivedModels(results)));
    }

    public void change()
    {
        if(canChange == false)
        {
            buttonDelete.GetComponent<Image>().color = Color.red;
            canChange = true;
        }
        else
        {
            buttonDelete.GetComponent<Image>().color = Color.blue;
            canChange = false;
        }
    }

    public class ZabivMasterModel
    {
        public string id;
        public string guest;
        public string strength1;
        public string strength2;
        public string strength3;
        public string flavour1;
        public string flavour2;
        public string flavour3;
        public string comments;
    }
    
    public class ZabivMasterView
    {
        public Text idText;
        public Text guestText;
        public Text strength1Text;
        public Text strength2Text;
        public Text strength3Text;
        public Text flavourl1Text;
        public Text flavour2Text;
        public Text flavour3Text;
        public Text commentsText;

        

        public ZabivMasterView(Transform rootView)
        {
            idText = rootView.Find("Id").GetComponent<Text>();
            guestText = rootView.Find("Text guest").GetComponent<Text>();
            strength1Text = rootView.Find("Tabacco 1/Text percent").GetComponent<Text>();
            strength2Text = rootView.Find("Tabacco 2/Text percent").GetComponent<Text>();
            strength3Text = rootView.Find("Tabacco 3/Text percent").GetComponent<Text>();
            flavourl1Text = rootView.Find("Tabacco 1/Text tabacco").GetComponent<Text>();
            flavour2Text = rootView.Find("Tabacco 2/Text tabacco").GetComponent<Text>();
            flavour3Text = rootView.Find("Tabacco 3/Text tabacco").GetComponent<Text>();
            commentsText = rootView.Find("Comments/Text comments").GetComponent<Text>();
        }
    }
    

    public void SendingOrderOnServer()
    {
        print("click");
        if(countModel > 0)
        {
            var httpWebRequest = (HttpWebRequest) WebRequest.Create("https://hookahserver.herokuapp.com/order/add");
            httpWebRequest.ContentType = "";
            httpWebRequest.Method = "POST";
            using (var streamWriter = new StreamWriter(httpWebRequest.GetRequestStream()))
            {
                string json = JsonUtility.ToJson(ListOrderOnBasket.order);

                streamWriter.Write(json);
            }

            var httpResponse = (HttpWebResponse) httpWebRequest.GetResponse();
            using (var streamReader = new StreamReader(httpResponse.GetResponseStream()))
            {
                var result = streamReader.ReadToEnd();
                print(result);
            }
        }
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
    
    public static void AddHeight(RectTransform trans, float newSize) {
        
        SetSize(trans, new Vector2(trans.rect.size.x, trans.rect.size.y + newSize));
    }
    

    void InitializeItemView(GameObject viewGameObject, ZabivMasterModel model)
    {
        
        ZabivMasterView view = new ZabivMasterView(viewGameObject.transform);
        view.idText.text = model.id;
        view.guestText.text = "Гость " + model.guest;
        view.strength1Text.text = model.strength1;
        view.strength2Text.text = model.strength2;
        view.strength3Text.text = model.strength3;
        view.flavourl1Text.text = model.flavour1;
        view.flavour2Text.text = model.flavour2;
        view.flavour3Text.text = model.flavour3;
        if (model.comments == null)
        {
            view.commentsText.text = "Без комментариев";
        }
        view.commentsText.text = model.comments;
        rectTransform = viewGameObject.transform.Find("Comments/Text comments").GetComponent<RectTransform>();
        float textWidth = LayoutUtility.GetPreferredHeight(view.commentsText.rectTransform);
        float parentWidth = rectTransform.rect.height;
        if (textWidth >= parentWidth)
        {
            float differance = textWidth - parentWidth;
            AddHeight(viewGameObject.transform.GetComponent<RectTransform>(), differance); 
            AddHeight(viewGameObject.transform.Find("Comments").GetComponent<RectTransform>(), differance);
        }
        
    }
    

    IEnumerator GetItems(int count, System.Action<ZabivMasterModel[]> callback)
    {
        yield return new WaitForSeconds(0f);
        var results = new ZabivMasterModel[count];
        for (int i = 0; i < count; i++)
        {
            results[i] = new ZabivMasterModel();
            results[i].id = i.ToString();
            results[i].guest = ListOrderOnBasket.order.getGuestName();

            if (ListOrderOnBasket.order.getZabiv(i).getFlavour1() != null)
            {
                results[i].strength1 = ListOrderOnBasket.order.getZabiv(i).getFlavour1().getStrength().ToString() + "%";
                results[i].flavour1 = ListOrderOnBasket.order.getZabiv(i).getFlavour1().getFlavour();
            }

            if (ListOrderOnBasket.order.getZabiv(i).getFlavour2() != null)
            {
                results[i].strength2 = ListOrderOnBasket.order.getZabiv(i).getFlavour2().getStrength().ToString() + "%";
                results[i].flavour2 = ListOrderOnBasket.order.getZabiv(i).getFlavour2().getFlavour();
            }
            
            if (ListOrderOnBasket.order.getZabiv(i).getFlavour3() != null)
            {
                results[i].strength3 = ListOrderOnBasket.order.getZabiv(i).getFlavour3().getStrength().ToString() + "%";
                results[i].flavour3 = ListOrderOnBasket.order.getZabiv(i).getFlavour3().getFlavour();
            }
            
            results[i].comments = ListOrderOnBasket.order.getComments();
        }
        callback(results);
    }
}
