using System.Collections;
using System.Collections.Generic;
using ExitGames.Client.Photon;
using UnityEngine;
using OPC;
public class SyncPositionRequest : Request
{
    [HideInInspector]
    public Vector3 pos;
    public override void DefaultRequest()
    {
        Dictionary<byte, object> keys = new Dictionary<byte, object>();
        keys.Add((byte)ParameterCode.x, pos.x);
        keys.Add((byte)ParameterCode.y, pos.y);
        keys.Add((byte)ParameterCode.z, pos.z);
        PhotonEngine.PhotonPeer.OpCustom((byte)opCode, keys, true);
    }

    public override void OnOperationResponse(OperationResponse operationResponse)
    {
        throw new System.NotImplementedException();
    }
}
