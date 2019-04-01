using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using OPC;
using ExitGames.Client.Photon;

public abstract class Request : MonoBehaviour {
    public OperationCode opCode;
    public abstract void DefaultRequest();
    public abstract void OnOperationResponse(OperationResponse operationResponse);

    public virtual void Start()
    {
        PhotonEngine._instance.AddRequest(this);
    }

    private void OnDestroy()
    {
        PhotonEngine._instance.RemoveRequest(this);
    }
}
