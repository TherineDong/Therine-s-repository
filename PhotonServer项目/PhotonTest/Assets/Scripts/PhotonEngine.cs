using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ExitGames.Client.Photon;
using OPC;

public class PhotonEngine : MonoBehaviour,IPhotonPeerListener {

    public static PhotonPeer PhotonPeer
    {
        get
        {
            return peer;
        }
    }
    public static PhotonEngine _instance;
    private static PhotonPeer peer;
    public string username;
    private Dictionary<OperationCode, Request> requestDic = new Dictionary<OperationCode, Request>();
    private Dictionary<EventCode, EventOperation> eventDic = new Dictionary<EventCode, EventOperation>();
    private void Awake()
    {
        _instance = this;
    }
    private void Start()
    {
        if (_instance != this)
        {
            Destroy(this.gameObject);
        }
        else
        {
            DontDestroyOnLoad(this);
        }
        peer = new PhotonPeer(this, ConnectionProtocol.Udp);
        peer.Connect("218.98.52.47:5055","MyGame1");
    }


    private void OnDestroy()
    {
        if (peer != null&&peer.PeerState==PeerStateValue.Connected)
        {
            peer.Disconnect();
        }
    }
    private void Update()
    {
        peer.Service();
    }
    public void DebugReturn(DebugLevel level, string message)
    {

    }

    public void OnOperationResponse(OperationResponse operationResponse)
    {
        Request request = null;
        bool isGet= requestDic.TryGetValue((OperationCode)operationResponse.OperationCode,out request);
        if (isGet)
        {
            request.OnOperationResponse(operationResponse);
        }
        else
        {
            Debug.Log("未找到请求响应");
        }
        /*switch (operationResponse.OperationCode)
        {
            case 1:
                Debug.Log("收到服务器的响应");
                Dictionary<byte,object> dic = operationResponse.Parameters;
                object str1;
                object str2;
                dic.TryGetValue(1,out str1);
                dic.TryGetValue(2,out str2);
                Debug.Log(str1.ToString()+str2.ToString());
                break;
            case 2:
                break;
            default:
                break;
        }*/
    }

    public void OnStatusChanged(StatusCode statusCode)
    {
        Debug.Log(statusCode);
    }

    public void OnEvent(EventData eventData)
    {
        EventOperation eventOperation = null;
       bool isGet= eventDic.TryGetValue((EventCode)eventData.Code,out eventOperation);
        if (isGet)
        {
            eventOperation.OnEvent(eventData);
        }
        else
        {
            Debug.Log("未找到事件请求");
        }
    }

    public void AddRequest(Request request)
    {
        requestDic.Add(request.opCode,request);
    }

    public void RemoveRequest(Request request)
    {
        requestDic.Remove(request.opCode);
    }
    
    public void AddEvent(EventOperation eventOperation)
    {
        eventDic.Add(eventOperation.eventCode, eventOperation);
    }
    public void RemoveEvent(EventOperation eventOperation)
    {
        eventDic.Remove(eventOperation.eventCode);
    }
}
