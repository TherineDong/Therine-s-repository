using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test : MonoBehaviour{ 
    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            SeedRequest();
        }
        
    }

    private void SeedRequest()
    {
        Dictionary<byte,object> dic=new Dictionary<byte,object>();
        dic.Add(1,12345);
        dic.Add(2,"字符数据abc");
        PhotonEngine.PhotonPeer.OpCustom(1, dic, true);
    }
}
