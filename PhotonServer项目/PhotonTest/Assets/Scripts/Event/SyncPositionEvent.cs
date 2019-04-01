using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ExitGames.Client.Photon;
using OPC;
using System.IO;
using System.Xml.Serialization;
using UnityEngine;

namespace Assets.Scripts.Event
{
    public class SyncPositionEvent : EventOperation
    {
        private Player player;
        public override void Start()
        {
            base.Start();
            player=GetComponent<Player>();
        }
        public override void OnEvent(EventData eventData)
        {
            string PlayerPositionList= (string)DictTool.TryGetOPR<byte, object>(eventData.Parameters,(byte)ParameterCode.PlayerPosition);
            XmlSerializer xmlSerializer = new XmlSerializer(typeof( List<PlayerVector3Data>));
            StringReader stringReader = new StringReader(PlayerPositionList);
            List<PlayerVector3Data> playerVector3DatasList=(List<PlayerVector3Data>) xmlSerializer.Deserialize(stringReader);
            Debug.Log(playerVector3DatasList.Count);
            player.SynPlayerPositon(playerVector3DatasList);
        }
    }
}
