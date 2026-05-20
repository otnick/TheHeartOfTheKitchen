using UnityEngine;
using NativeWebSocket;
using UnityEngine.Events;
using System;
using Unity.XR.CoreUtils.Datums;



#if UNITY_EDITOR
using UnityEditor;
#endif

public class WebSocketClientExample : MonoBehaviour
{
    private WebSocket websocket;
    public string serverIP = "XXX.XXX.XXX.XXX"; // Replace with your server's IP address
    public int serverPort = 8081; // Replace with your server's port number (8081 is the default)
    private GameObject tangiblePan;
    [SerializeField]
    private MeatGrinder meatGrinder;

    private float roll, pitch, yaw;

    [Range(0, 255)]
    public int ledIntensity = 0;

    async void Start()
    {
        websocket = new WebSocket("ws://" + serverIP + ":" + serverPort);

        //Runs when connected to the server
        websocket.OnOpen += async () =>
        {
            Debug.Log("Connected to WebSocket server");
            string UUID = SystemInfo.deviceUniqueIdentifier; // Certain devices block MAC address access for privacy reasons so we send a UUID instead

            await websocket.SendText("Device (Unity):" + SystemInfo.deviceName + " ... Device's Unique Identifier: " + UUID);
        };

        //Runs when a message is received from the server
        websocket.OnMessage += (bytes) =>
        {
            string message = System.Text.Encoding.UTF8.GetString(bytes);
            Debug.Log("Received: " + message);

            IncomingMessageParser(message);

        };

        //Runs when disconnected from the server
        websocket.OnClose += (code) =>
        {
            Debug.Log("WebSocket closed");
        };

        await websocket.Connect();
        tangiblePan = GameObject.Find("Pan");
    }

    void Update()
    {
        //Although not necessary for our lab, I have left this here as a reference
        //Websockets will not work on WebGL builds so with this preprocessor directive we include all builds except WebGL as well as including the editor for testing purposes
        #if !UNITY_WEBGL || UNITY_EDITOR 

            websocket.DispatchMessageQueue();
        #endif
    }

    async void OnDestroy()
    {
        if (websocket != null)
            await websocket.Close();
    }

    public async void SendHello()
    {
        if (websocket != null && websocket.State == WebSocketState.Open)
        {
            await websocket.SendText("Hello from Unity");
            Debug.Log("Sent: Hello from Unity");
        }
        else
        {
            Debug.LogWarning("WebSocket not connected");
        }
    }

    public void IncomingMessageParser(String msg)
    {
        string valueParsed = msg.Substring( msg.IndexOf(":") + 1);

        if(msg.Contains("PAN")) {
            handlePanMessage(valueParsed);
        }
        if (msg.Contains("grinder"))
        {
            HandleGrinderMessage();
        }

    }

    public bool TryGetRotation(out float r, out float p, out float y)
    {
            r = -roll;
            p = pitch;
            y = -yaw;
        return true;
    }
    private void HandleGrinderMessage()
    {
        Debug.Log("spawninggg fiiiddd");
        meatGrinder.SpawnFood();
    }

    private void handlePanMessage(string message)
    {
        //TODO: handle the pan message
        string[] dataList = message.Split(',');
            roll = float.Parse(dataList[0]);
            pitch = float.Parse(dataList[1]);
            yaw = float.Parse(dataList[2]);
        return;
    }

}

