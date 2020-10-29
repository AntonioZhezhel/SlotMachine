using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class GraphicRaycasterRaycasterExample : MonoBehaviour
{
    GraphicRaycaster m_Raycaster;

    PointerEventData m_PointerEventData;
    PointerEventData m_PointerEventData2;
    PointerEventData m_PointerEventData3;


    public string slot;
    public string slot2;
    public string slot3;
    
    EventSystem m_EventSystem;
    void Start()
    {
        // Получаем Raycaster из GameObject (Canvas))
        m_Raycaster = GetComponent<GraphicRaycaster>();
        //Извлекаем систему событий из сцены
        m_EventSystem = GetComponent<EventSystem>();
    }

    void Update()
    {
	    }
public void CombinationDefinition()
 {
	//Настраиваем новое событие указателя
	m_PointerEventData = new PointerEventData(m_EventSystem);
	m_PointerEventData2 = new PointerEventData(m_EventSystem);
	m_PointerEventData3 = new PointerEventData(m_EventSystem);
	//Устанавливаем положение события указателя равным положению мыши
	//m_PointerEventData.position = Input.mousePosition;
            
	float x1 = 610.0f;
	float x2 = 960.0f;
	float x3 = 1290.0f;
	float y = 410.0f;
	var ori1 = Camera.main.ViewportToScreenPoint (new Vector3(x1/1920, y/1080, 0));
	var ori2 = Camera.main.ViewportToScreenPoint (new Vector3(x2/1920, y/1080, 0));
	var ori3 = Camera.main.ViewportToScreenPoint (new Vector3(x3/1920, y/1080, 0));	
			
	m_PointerEventData.position = ori1;
	m_PointerEventData2.position = ori2;
	m_PointerEventData3.position = ori3;

    //m_PointerEventData.GetComponent<RectTransform>().position = new Vector3(-338f,-124f,0);
    
    
    //Создаем список результатов Raycast
    List<RaycastResult> results = new List<RaycastResult>();
    List<RaycastResult> results2 = new List<RaycastResult>();
    List<RaycastResult> results3 = new List<RaycastResult>();
	//Raycast с использованием Graphics Raycaster и позиции щелчка мыши
     m_Raycaster.Raycast(m_PointerEventData, results);
     m_Raycaster.Raycast(m_PointerEventData2, results2);
     m_Raycaster.Raycast(m_PointerEventData3, results3);
    //Для каждого возвращенного результата вывести имя GameObject на холсте, на которое попал Луч
    
	foreach (RaycastResult result in results)
	{

		if(result.gameObject.tag == "Slot")
		{
			slot = result.gameObject.name;
			Debug.Log(":: " + result.gameObject.name   );
		}

	}
	foreach (RaycastResult result in results2)
	{
	
		if(result.gameObject.tag == "Slot")
		{
			slot2 = result.gameObject.name;
			Debug.Log(":: " + result.gameObject.name   );
		}
	
	}
	foreach (RaycastResult result in results3)
	{
	
		if(result.gameObject.tag == "Slot")
		{
			slot3 = result.gameObject.name;
			Debug.Log(": " + result.gameObject.name   );
		}
	
	}


	if (string.Equals(slot,slot3))
	{
		Debug.Log("Jackpot");
	}
	
 }
}