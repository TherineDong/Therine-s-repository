using System.Collections;
using System.Collections.Generic;
using ExitGames.Client.Photon;
using UnityEngine;
using OPC;

public class RegisterRequest : Request
{ 
    [HideInInspector]
    public string username;
    [HideInInspector]
    public string password;

    public override void DefaultRequest()
    {
        Dictionary<byte, object> keys = new Dictionary<byte, object>();
        keys.Add((byte)ParameterCode.UserName, username);
        keys.Add((byte)ParameterCode.PassWord, password);
        PhotonEngine.PhotonPeer.OpCustom((byte)opCode, keys, true);
    }

    public override void OnOperationResponse(OperationResponse operationResponse)
    {
        if (operationResponse.ReturnCode == (short)ReturnCode.success)
        {
            Debug.Log("register seccess");
        }
        else
        {
            Debug.Log("username exist,please input another username");
        }
        
    }
}
