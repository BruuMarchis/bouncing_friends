using System.Collections;
using System.Collections.Generic;
//using System.Diagnostics;
using UnityEngine;
using UnityEngine.UI;

public class FriendsController : MonoBehaviour
{

    public GameObject friend_prefab;
    public GameObject[] friends;
    public int friend_count = 0;



    private Vector3 oldVelocity;
    void FixedUpdate()
    {
        // because we want the velocity after physics, we put this in fixed update
        oldVelocity = this.GetComponent<Rigidbody2D>().velocity;
    }

    public void createFriend(Vector3 position)
    {

        if (friend_count < 10)
        {

            if (friend_count == 0)
            {
                //friends[friend_count] = Instantiate(friend_prefab, this.transform.position - new Vector3(-4, 0, 0), Quaternion.identity);
                friends[friend_count] = Instantiate(friend_prefab, position, Quaternion.identity);
                friends[friend_count].GetComponent<DistanceJoint2D>().connectedBody = this.GetComponent<Rigidbody2D>();
                friends[friend_count].transform.SetParent(this.transform);
                friend_count++;
            }
            else
            {
                friends[friend_count] = Instantiate(friend_prefab, friends[friend_count-1].transform.position - new Vector3(-4, 0, 0), Quaternion.identity);
                friends[friend_count].GetComponent<DistanceJoint2D>().connectedBody = friends[friend_count - 1].GetComponent<Rigidbody2D>();
                friends[friend_count].transform.SetParent(this.transform);
                friend_count++;
            }
            //Debug.Log(GameManager.points);
            GameManager.points += 10;
            //Debug.Log(GameManager.points);

        }

    }

    public void deleteFriend()
    {
        //Debug.Log(friend_count);
        friend_count--;
        if (friend_count <0)
        {
            //Debug.Log(friend_count);
            friend_count = 0;
            GameManager.points -= 5;
            this.gameObject.GetComponent<SpriteManager>().alive = false;
            this.gameObject.GetComponent<SpriteManager>().newSprite();
            //Debug.Log(friend_count);
            menu.EndGame();


        }
        else
        {
            Debug.Log(friend_count);
            friends[friend_count].GetComponent<Friend>().isConnected = false;
            friends[friend_count].GetComponent<SpriteManager>().alive = false;
            friends[friend_count].GetComponent<SpriteManager>().newSprite();
            friends[friend_count].GetComponent<DistanceJoint2D>().enabled = false;
            GameManager.points -= 5;
        }

    }


        

    private void OnCollisionEnter2D(Collision2D collision)
    {

        if (collision.transform.tag == "future-friend")
        {
            createFriend(collision.transform.position);
            Destroy(collision.gameObject);            
        }

        if (collision.transform.tag == "saw")
        {
            deleteFriend();

            ContactPoint2D contact = collision.GetContact(0);

            //Debug.Log(this.GetComponent<Rigidbody2D>().velocity);
            //reflect our old velocity off the contact point's normal vector
            Vector2 reflectedVelocity = Vector2.Reflect(oldVelocity, contact.normal);

            //Debug.Log(this.GetComponent<Rigidbody2D>().velocity);
            //Debug.Log(reflectedVelocity);
            this.GetComponent<Rigidbody2D>().velocity = reflectedVelocity*2;
            //this.GetComponent<Rigidbody2D>().AddForce(reflectedVelocity);
            //Debug.Log(this.GetComponent<Rigidbody2D>().velocity);


        }
    }
}
