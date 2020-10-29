using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Slots : MonoBehaviour
{
    public Reel[] reel;

    public GraphicRaycasterRaycasterExample graphicRaycasterRaycasterExample;
    public bool[] chec = new bool[3] ;
    private bool startSpin;
	public string combination;	

    // Start is called before the first frame update
    void Start()
    {
        startSpin = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (!startSpin)// Предотвращает помехи, если барабаны все еще вращаются
        {
            if (Input.GetMouseButtonDown(0))
            {
                startSpin = true;
                StartCoroutine(Spinning());
                chec[0] = false;
                chec[1] = false;
                chec[2] = false;
            }
        }
    }

    IEnumerator Spinning()
    {
        foreach (Reel spinner in reel)
        {
            // Сообщает каждой катушке начать вращение
            spinner.spin = true;

        }

        for (int i = 0; i < reel.Length; i++)
        {
            // Позволяем барабанам вращаться в течение произвольного количества времени, а затем останавливаем их
            yield return new WaitForSeconds(Random.Range(1, 3));
            reel[i].spin = false;
            //reel[i].RandomPosition();
            chec[i] = true;
            if (chec[2] == true)
            {
                graphicRaycasterRaycasterExample.CombinationDefinition();
                Debug.Log("Stop");
            }
            
            
            reel[i].AlignMiddle(combination);
        }
        // Позволяет снова запустить машину
        startSpin = false;
    }
}
