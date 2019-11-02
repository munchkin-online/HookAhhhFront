using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExampleSerializer : MonoBehaviour
{
    void Start()
    {
        //чтобы сериализовать вам нужно создать экземпляр TobaccoState. В нем добавить в массив все элементы что вам нужно
        TobaccoState state = new TobaccoState();
        
        state.Add(new Tobacco("g", 1, "f", "f"));
        
        //Теперь с помощью класса Serializer либо сохранить xml, либо вытащить его, SaveXml принимает на вход образец TobaccoState и название файла
        //используйте Serializer.FileName чтобы сохранить массив табаков, ну или просто "tobacco"
        Serializer.SaveXml(state, Serializer.FileName);
        //Функция DeXml возвращает объект TobaccoState который хранит в себе массив с табаками, на вход функции указывается путь до xml
        //он записан в качестве констранты в Serializer.DataPathTobaccos
        print(Serializer.DeXml(Serializer.DataPathTobaccos).tobaccos[0].Strength);
        
        
        //ПАМЯТКА: НИ В КОЕМ СЛУЧАЕ ДЕЛАЙТЕ СЕРИЛИЗУЕМЫЕ ОБЪЕКТЫ НАСЛЕДНИКАМИ MonoBehaviour. ДАННОЕ ДЕЙСТВИЕ МГНОВЕННО УБЬЕТ ВАС
       
    }
}
