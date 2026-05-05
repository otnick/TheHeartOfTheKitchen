using UnityEngine;

public class PanController : MonoBehaviour
{
    public WebSocketClientExample panReceiver;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        panReceiver = GameObject.Find("WebsocketClient").gameObject.GetComponent<WebSocketClientExample>();
    }

    // Update is called once per frame
    void Update()
    {
        if (panReceiver.TryGetRotation(out float roll, out float pitch, out float yaw)) { 
            transform.rotation = Quaternion.Euler(pitch,  yaw, roll);
        }
    }
}
