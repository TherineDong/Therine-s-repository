using System.Collections;
using System.Collections.Generic;
using ExitGames.Client.Photon;
using UnityEngine;
using OPC;
using System;

public class SyncCurrentPlayerEvent : EventOperation
{
    private Player player;
    public override void Start()
    {
        base.Start();
        player = GetComponent<Player>();
    }
    public override void OnEvent(EventData eventData)
    {
        string username = (string)DictTool.TryGetOPR<byte, object>(eventData.Parameters, (byte)ParameterCode.UserName);
        player.InstantialCurrrentPlayer(username);
    }
}
