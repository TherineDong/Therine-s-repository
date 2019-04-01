using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using OPC;

public class Player : MonoBehaviour {
    private float MoveSpeed = 2f;
   // public bool LocalPlayer = true;
    //public string username;
    Vector3 lastPosition = Vector3.zero;
    public GameObject go;
    public GameObject goPlayer;
    private SyncPositionRequest syncPositionRequest;
    private SyncPlayersRequest syncPlayerRequest;
    Dictionary<string, GameObject> user = new Dictionary<string, GameObject>();
    private void Start()
    {
        //if (LocalPlayer)
        //{
            goPlayer.GetComponent<MeshRenderer>().material.color = Color.blue;
            syncPositionRequest = GetComponent<SyncPositionRequest>();
            syncPlayerRequest = GetComponent<SyncPlayersRequest>();
            syncPlayerRequest.DefaultRequest();
            InvokeRepeating("SyncPosition", 2, 0.2f);
        //}   
    }

    void SyncPosition()
    {
        if (Vector3.Distance(goPlayer.transform.position,lastPosition)>0.1f)
        {
            lastPosition = goPlayer.transform.position;
            syncPositionRequest.pos = goPlayer.transform.position;
            syncPositionRequest.DefaultRequest();
        }

    }

   public void InstantialPlayer(List<string> usernameList)
    {
        foreach (string username in usernameList)
        { 
            Debug.Log(username.ToString());
            InstantialCurrrentPlayer(username);
        }
    }
   public  void InstantialCurrrentPlayer(string username)
    {
        Debug.Log(username);
        GameObject goo = GameObject.Instantiate(go);
        //goo.GetComponent<Player>().LocalPlayer = false;
        //this.username = username;
        user.Add(username, goo);
    }

    public void SynPlayerPositon(List<PlayerVector3Data> playerVector3Datas)
    {
        foreach (PlayerVector3Data playerVector3Data in playerVector3Datas)
        {
            Debug.Log("syncPositionSuceess");
            GameObject go;
            user.TryGetValue(playerVector3Data.username,out go);
            if (go != null)
                go.transform.position = new Vector3() { x=playerVector3Data.vector3Date.X,y=playerVector3Data.vector3Date.Y,z=playerVector3Data.vector3Date.Z};
                //Debug.Log(go.transform.position.x);
        }
    }
    private void Update()
    {
        //if (LocalPlayer)
        //{
            float x = Input.GetAxis("Horizontal");
            float z = Input.GetAxis("Vertical");
            goPlayer.transform.Translate(new Vector3(x, 0, z) * MoveSpeed * Time.deltaTime);

        //}
    }
    
    

}
