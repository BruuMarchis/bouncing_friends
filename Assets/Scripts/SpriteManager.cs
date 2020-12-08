using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpriteManager : MonoBehaviour
{
    public Sprite[] lista;
    public Sprite[] listaDead;
    public GameObject child;

    public bool alive = true;

    // Start is called before the first frame update
    void Start()
    {
        newSprite();
    }

    public void newSprite()
    {

        if (alive)
        {
            int num = Random.Range(0, lista.Length);
            //Debug.Log(num);
            child.gameObject.GetComponent<SpriteRenderer>().sprite = lista[num];
        }
        else
        {
            int num = Random.Range(0, listaDead.Length);
            //Debug.Log(num);
            child.gameObject.GetComponent<SpriteRenderer>().sprite = listaDead[num];
        }
    }


}
