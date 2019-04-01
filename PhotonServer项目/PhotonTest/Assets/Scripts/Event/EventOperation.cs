using ExitGames.Client.Photon;
using OPC;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class EventOperation : MonoBehaviour {
    public EventCode eventCode;
    public abstract void OnEvent(EventData eventData);
    public virtual void Start()
    {
        PhotonEngine._instance.AddEvent(this);
    }

    private void OnDestroy()
    {
        PhotonEngine._instance.RemoveEvent(this);
    }
}
