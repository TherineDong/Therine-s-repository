using System.Collections;
using System.Collections.Generic;
using ExitGames.Client.Photon;
using UnityEngine;
using OPC;
using UnityEngine.SceneManagement;

public class LoginRequest : Request
{
    [HideInInspector]
    public string username;
    [HideInInspector]
    public string password;

    public GameObject go;



    /*public override  void Start()
    {
        base.Start();
    }*/
    public override void DefaultRequest()
    {
        go.SetActive(false);
        Dictionary<byte, object> keys = new Dictionary<byte, object>();
        keys.Add((byte)ParameterCode.UserName,username);
        keys.Add((byte)ParameterCode.PassWord,password);
        PhotonEngine.PhotonPeer.OpCustom((byte)opCode,keys,true);
    }

    public override void OnOperationResponse(OperationResponse operationResponse)
    {
        Debug.Log(operationResponse.OperationCode);
        if (operationResponse.ReturnCode == (short)ReturnCode.success)
        {
            SceneManager.LoadScene("GameScene");
            PhotonEngine._instance.username = username;
        }
        else
        {
            go.SetActive(true);
        }
    }
}
   

