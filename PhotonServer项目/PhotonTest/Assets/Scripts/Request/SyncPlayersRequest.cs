using System.Collections;
using System.Collections.Generic;
using ExitGames.Client.Photon;
using UnityEngine;
using OPC;
using System.Xml.Serialization;
using System.IO;

public class SyncPlayersRequest : Request
{
    private Player player;
    public override void Start()
    {
        base.Start();
        player = GetComponent<Player>();
    }
    public override void DefaultRequest()
    {
        PhotonEngine.PhotonPeer.OpCustom((byte)opCode,null,true);
    }

    public override void OnOperationResponse(OperationResponse operationResponse)
    {
        XmlSerializer xmlSerializer = new XmlSerializer(typeof(List<string>));
        Dictionary<byte, object> keys = new Dictionary<byte, object>();
        keys = operationResponse.Parameters;
        object usernameListTostring;
        keys.TryGetValue((byte)ParameterCode.UserNameList,out usernameListTostring);
        StringReader stringReader = new StringReader((string)usernameListTostring);
        List<string> usernameList= (List<string>)xmlSerializer.Deserialize(stringReader);
        player.InstantialPlayer(usernameList);
        
    }
}
