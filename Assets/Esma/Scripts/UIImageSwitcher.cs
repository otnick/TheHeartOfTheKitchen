using Fusion;
using UnityEngine;

public class UIImageSwitcher : MonoBehaviour
{
    [Header("Images")]
    public GameObject image1;
    public GameObject image2;

    private bool pressed = false;

    private void OnTriggerEnter(Collider other)
    {
        if (pressed) return;

        Debug.Log("Button touched by: " + other.name);

        pressed = true;
        RPC_SwitchImages();
    }

    [Rpc(RpcSources.All, RpcTargets.All)]
    private void RPC_SwitchImages()
    {
        if (image1 != null)
            image1.SetActive(false);

        if (image2 != null)
            image2.SetActive(true);
    }
}
