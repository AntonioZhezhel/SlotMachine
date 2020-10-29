using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Reel : MonoBehaviour
{
    public bool spin;
    public int speed;


    // Start is called before the first frame update
    void Start()
    {
        spin = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (spin)
        {
            foreach (Transform image in transform)//Все дочерние объекты основного родительского объекта
            {
                // Направление и скорость движения
                image.transform.Translate(Vector3.down * Time.smoothDeltaTime * speed, Space.World);
                // Как только изображение переместится ниже определенной точки, сбрасываем его положение вверх
                if (image.transform.position.y <= 0)
                {
                    image.transform.position = new Vector3(image.transform.position.x,
                        image.transform.position.y + 2888, image.transform.position.z);
                }
            }
        }
        
    }
    // После того, как барабан закончит вращение, изображения будут размещены в случайном месте
     /*public void RandomPosition()
    {
        List<int> parts = new List<int>();
        parts.Add(976);
        parts.Add(756);
        parts.Add(536);
        parts.Add(316);
        parts.Add(96);
        parts.Add(-124);
        parts.Add(-344);
        parts.Add(-564);
        parts.Add(-784);
        parts.Add(-1004);
        parts.Add(-1224);
        parts.Add(-1444);

       
        foreach (Transform image in transform)
        {
            int rand = Random.Range(0, parts.Count);
            //"transform.parent.GetComponent<RectTransform>().transform.position.y"- Позволяет регулировать положение холста по оси Y
            image.transform.position = new Vector3(image.transform.position.x,
                parts[rand] + transform.parent.GetComponent<RectTransform>().transform.position.y,
                image.transform.position.z);
            parts.RemoveAt(rand);

        }

    }*/
    
    
    public void AlignMiddle(string combinationToAlign)
    {
        List<int> parts = new List<int>();
        List<int> middlePart = new List<int>();
        
        parts.Add(976);
        parts.Add(756);
        parts.Add(536);
        parts.Add(316);
        parts.Add(96);
        middlePart.Add(-124);
        parts.Add(-344);
        parts.Add(-564);
        parts.Add(-784);
        parts.Add(-1004);
        parts.Add(-1224);
        parts.Add(-1444);
        
    
        foreach (Transform image in transform)
        {
    
            if (image.name.Equals(combinationToAlign) == true && middlePart.Count > 0)
            {
                
                
                int rand = Random.Range(0, middlePart.Count);
                image.transform.position = new Vector3(image.transform.position.x,
                    middlePart[rand] + transform.parent.GetComponent<RectTransform>().transform.position.y,
                    image.transform.position.z);
                middlePart.RemoveAt(rand); 
            }
            else
            {
                int rand = Random.Range(0, parts.Count);
                //"transform.parent.GetComponent<RectTransform>().transform.position.y"- Позволяет регулировать положение холста по оси Y
                image.transform.position = new Vector3(image.transform.position.x,
                    parts[rand] + transform.parent.GetComponent<RectTransform>().transform.position.y,
                    image.transform.position.z);
                parts.RemoveAt(rand);
               
            }
            
        }
    }
}
