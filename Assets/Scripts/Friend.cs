using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Friend : MonoBehaviour
{
    // Start is called before the first frame update

    public bool isConnected;
    public bool alive;

    void Start()
    {
        isConnected = true;
        alive = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (!isConnected & alive)
        {
            StartCoroutine(die());
            alive = false;
        }
    }


    IEnumerator die()
    {
        yield return new WaitForSeconds(10f);
        Destroy(this.gameObject);

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.transform.tag == "saw")
        {
            GameObject player = GameObject.Find("char");

            player.GetComponent<FriendsController>().deleteFriend();


        }
    }
}
