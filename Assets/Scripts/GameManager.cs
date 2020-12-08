using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    public static Dictionary<int, PlayerManager> players = new Dictionary<int, PlayerManager>();

    public GameObject localPlayerPrefab;
    public GameObject playerPrefab;
    public GameObject friendPrefab;

    public GameObject spots;

    public int countdownSecs;
    public Text countDown;


    public Text pointsText;
    public static int points;


    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else if (instance != this)
        {
            Debug.Log("Instance already exists, destroying object!");
            Destroy(this);
        }

        countdownSecs = 120;
        countDown.text = "Timer: " + countdownSecs.ToString();


        points = 0;
        pointsText.text = "Points: " + points.ToString();

    }



    void Start()
    {
        StartCoroutine(countdown());

        for(int i=0; i<5; i++)
        {
            spawnFriend();
        }


    }


    private void Update()
    {

        pointsText.text = "Points: " + points.ToString();
        if(countdownSecs <= 0 || points <0)
        {            
            menu.EndGame();
        }

    }

    IEnumerator countdown()
    {


        while (countdownSecs > 0)
        {
            countDown.text = "Timer: " + countdownSecs.ToString();
            yield return new WaitForSeconds(1f);
            countdownSecs--;
        }



    }

    public void spawnFriend()
    {
        //
        bool canSpawn = false;

        while (!canSpawn)
        {
            int num = Random.Range(0,10);

            //Debug.Log(num);

            if (spots.transform.GetChild(num).transform.childCount == 0)
            {

                GameObject novoAmigo = Instantiate(friendPrefab, spots.transform.GetChild(num).transform.position, Quaternion.identity);
                
                novoAmigo.transform.SetParent(spots.transform.GetChild(num).transform);

                canSpawn = true;
            }
        }


        





    }

    /// <summary>Spawns a player.</summary>
    /// <param name="_id">The player's ID.</param>
    /// <param name="_name">The player's name.</param>
    /// <param name="_position">The player's starting position.</param>
    /// <param name="_rotation">The player's starting rotation.</param>
    public void SpawnPlayer(int _id, string _username, Vector3 _position)
    {
        GameObject _player;
        if (_id == Client.instance.myId)
        {
            _player = Instantiate(localPlayerPrefab, _position, Quaternion.identity);
        }
        else
        {
            _player = Instantiate(playerPrefab, _position, Quaternion.identity);
        }

        _player.GetComponent<PlayerManager>().id = _id;
        _player.GetComponent<PlayerManager>().username = _username;

        _player.transform.SetParent(this.transform.parent);

        players.Add(_id, _player.GetComponent<PlayerManager>());


    }
}