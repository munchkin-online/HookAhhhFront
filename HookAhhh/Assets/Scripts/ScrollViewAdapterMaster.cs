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
    private RectTransform rectTransform;
    
    
    private Vector3 fp;   //Первая позиция касания
    private Vector3 lp;   //Последняя позиция касания
    private float dragDistance;  //Минимальная дистанция для определения свайпа
    private List<Vector3> touchPositions = new List<Vector3>(); //Храним все позиции касания в списке
    
    void Start(){
        dragDistance = Screen.height*20/100; //dragDistance это 20% высоты экрана
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
                             Debug.Log("Down Swipe");
                             UpdateItems();
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
    
    public static void AddHeight(RectTransform trans, float newSize) {
        
        SetSize(trans, new Vector2(trans.rect.size.x, trans.rect.size.y + newSize));
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
