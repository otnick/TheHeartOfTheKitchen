using UnityEngine;
using Fusion;

public class LightPuzzleController : MonoBehaviour
{
    [Header("Scene Lights")]
    [SerializeField] private Light[] sceneLights;

    [Header("Footprints")]
    [SerializeField] private Renderer[] footprintRenderers;

    [Header("Optional Target")]
    [SerializeField] private GameObject ingredientTarget;

    [Header("Meta Passthrough")]
    [SerializeField] private OVRPassthroughLayer passthroughLayer;
    [SerializeField] private float normalOpacity = 1.0f;
    [SerializeField] private float darkOpacity = 0.2f;

    [Header("Emission")]
    [SerializeField] private Color glowColor = Color.cyan;
    [SerializeField] private float glowIntensity = 6f;

    private bool lightsOff;
    private static readonly int EmissionColorId = Shader.PropertyToID("_EmissionColor");

    private void Awake()
    {
        FindPassthroughLayer();
    }

    private void Start()
    {
        ApplyState(false);
    }

    private void FindPassthroughLayer()
    {
        if (passthroughLayer == null)
        {
            passthroughLayer = FindFirstObjectByType<OVRPassthroughLayer>(
                FindObjectsInactive.Include
            );
        }

        Debug.Log("PassthroughLayer found: " + (passthroughLayer != null));
    }

    public void ToggleLights()
    {
        var playerNetwork = FindFirstObjectByType<PlayerNetwork>();

        if (playerNetwork != null)
        {
            playerNetwork.RPC_ToggleLights(!lightsOff);
        }
        else
        {
            Debug.LogWarning("PlayerNetwork not found!");
        }
    }

    public void ApplyState(bool turnLightsOff)
    {
        lightsOff = turnLightsOff;

        if (passthroughLayer == null)
            FindPassthroughLayer();

        foreach (var lightSource in sceneLights)
        {
            if (lightSource != null)
                lightSource.enabled = !lightsOff;
        }

        if (passthroughLayer != null)
        {
            passthroughLayer.overlayType = OVROverlay.OverlayType.Underlay;
            passthroughLayer.textureOpacity = lightsOff ? darkOpacity : normalOpacity;

            if (lightsOff)
            {
                passthroughLayer.SetBrightnessContrastSaturation(
                    brightness: -0.4f,
                    contrast: 0.1f,
                    saturation: -1.0f
                );
            }
            else
            {
                passthroughLayer.SetBrightnessContrastSaturation(
                    brightness: 0f,
                    contrast: 0f,
                    saturation: 0f
                );
            }
        }
        else
        {
            Debug.LogWarning("No OVRPassthroughLayer found in scene!");
        }

        foreach (var rend in footprintRenderers)
        {
            if (rend == null) continue;

            rend.enabled = lightsOff;

            var block = new MaterialPropertyBlock();
            rend.GetPropertyBlock(block);
            block.SetColor(EmissionColorId, lightsOff ? glowColor * glowIntensity : Color.black);
            rend.SetPropertyBlock(block);
        }

        if (ingredientTarget != null)
            ingredientTarget.SetActive(true);
    }
}