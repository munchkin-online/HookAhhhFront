using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.UI;

public class ScrollViewAdapterMaster : MonoBehaviour
{
    public RectTransform prefab;
    public RectTransform content;
    public int countModel = 0;
    private RectTransform rectTransform;
    
    
    private Vector3 fp;   //Первая позиция касания
    private Vector3 lp;   //Последняя позиция касания
    private float dragDistance;  //Минимальная дистанция для определения свайпа
    private List<Vector3> touchPositions = new List<Vector3>(); //Храним все позиции касания в списке
    
    void Start(){
        dragDistance = Screen.height*30/100; //dragDistance это 30% высоты экрана
    }
    
    void Update(){
        foreach (Touch touch in Input.touches)  //используем цикл для отслеживания больше одного свайпа
        {//должны быть закоментированы, если вы используете списки 
            /*if (touch.phase == TouchPhase.Began) //проверяем первое касание
            {
                fp = touch.position;
                lp = touch.position;
         
            }*/
            
         
            if (touch.phase == TouchPhase.Moved) //добавляем касания в список, как только они определены
            {
                touchPositions.Add(touch.position);
            }
         
            if (touch.phase == TouchPhase.Ended && touchPositions.Count > 1) //проверяем, если палец убирается с экрана
            {
                //lp = touch.position;  //последняя позиция касания. закоментируйте если используете списки
                fp =  touchPositions[0]; //получаем первую позицию касания из списка касаний
                lp =  touchPositions[touchPositions.Count-1]; //позиция последнего касания
                //Debug.Log(fp + " " + lp);
         
                //проверяем дистанцию перемещения больше чем 20% высоты экрана
                if (Mathf.Abs(lp.x - fp.x) > dragDistance || Mathf.Abs(lp.y - fp.y) > dragDistance)
                {//это перемещение
                      //проверяем, перемещение было вертикальным или горизонтальным 
                      if (Mathf.Abs(lp.x - fp.x) > Mathf.Abs(lp.y - fp.y))
                      {   //Если горизонтальное движение больше, чем вертикальное движение ...
                          if ((lp.x>fp.x))  //Если движение было вправо
                          {   //Свайп вправо
                              Debug.Log("Right Swipe");
                          }
                          else
                          {   //Свайп влево
                              Debug.Log("Left Swipe"); 
                          }
                      }
                    else
                    {   //Если вертикальное движение больше, чнм горизонтальное движение
                         if (lp.y>fp.y)  //Если движение вверх
                         {   //Свайп вверх
                             Debug.Log("Up Swipe"); 
                         }
                         else
                         {   //Свайп вниз
                             Debug.Log("Down Swipe " + lp.y);
                             AcceptOrders();
                         }
                    }
                } 
                touchPositions.Clear();
            }
            else
            {   //Это ответвление, как расстояние перемещения составляет менее 20% от высоты экрана
         
            }
       }
    }
    
    public class ZabivMasterModel
    {
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
    [System.Serializable]
    public class Orders
    {
        [SerializeField]
        public List<Order> orders;

        public static Orders CreateFromJSON(string jsonString)
        {
            return JsonUtility.FromJson<Orders>(jsonString);
        }

        public Orders()
        {
            orders = new List<Order>();
        }
    }
    

    public void AddOrder(Order order)
    {
        for (int i = 0; i < order.getCountZabiv(); i++)
        {
            AddZabiv(order.getZabiv(i), order.getComments(), order.getGuestName());
        }
    }

    public void AddZabiv(Zabiv zabiv, string comments, string name)
    {
        countModel += 1;
        StartCoroutine(GetItems(countModel, zabiv, comments, name, results => OnReceivedModels(results)));
    }

    public void AcceptOrders()
    {
        var httpWebRequest = (HttpWebRequest) WebRequest.Create("https://hookahserver.herokuapp.com/order/list");
        httpWebRequest.ContentType = "";
        httpWebRequest.Method = "POST";
        var httpResponse = (HttpWebResponse) httpWebRequest.GetResponse();
        using(var streamReader = new StreamReader(httpResponse.GetResponseStream()))
        {
            var result = streamReader.ReadToEnd();
            result = "{\"orders\":" + result + "}";
            var answer = Orders.CreateFromJSON(result).orders;
            foreach (var order in answer)
            {
                AddOrder(order);
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
    

    IEnumerator GetItems(int count, Zabiv zabiv, string comments, string name, System.Action<ZabivMasterModel[]> callback)
    {
        yield return new WaitForSeconds(0f);
        var results = new ZabivMasterModel[count];
        for (int i = 0; i < count; i++)
        {
            
            results[i] = new ZabivMasterModel();
            results[i].guest = name;

            if (zabiv.getFlavour1() != null)
            {
                results[i].strength1 = zabiv.getFlavour1().getStrength().ToString() + "%";
                results[i].flavour1 = zabiv.getFlavour1().getFlavour();
            }

            if (zabiv.getFlavour2() != null)
            {
                results[i].strength2 = zabiv.getFlavour2().getStrength().ToString() + "%";
                results[i].flavour2 = zabiv.getFlavour2().getFlavour();
            }
            
            if (zabiv.getFlavour3() != null)
            {
                results[i].strength3 = zabiv.getFlavour3().getStrength().ToString() + "%";
                results[i].flavour3 = zabiv.getFlavour3().getFlavour();
            }
            
            results[i].comments = comments;
        }

        callback(results);
    }
}
