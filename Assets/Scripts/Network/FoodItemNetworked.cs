using UnityEngine;
using Fusion;
using Unity.XR.CoreUtils;

public class FoodItemNetworked : NetworkBehaviour
{
    public bool isCooking { get; set; } = false;
    public bool fallingThroughThePan { get; set; } = false;

    private GameObject pan;
    private NetworkTransform nt;
    private Rigidbody rb;
    private GameObject particles;
    private Renderer _renderer;

    [Networked, OnChangedRender(nameof(OnDecayChanged))]
    public float DecayProgress { get; set; }

    [Networked, OnChangedRender(nameof(OnColorChanged))]
    public Color FreshColor { get; set; }

    [Networked, OnChangedRender(nameof(OnColorChanged))]
    public Color BrownColor { get; set; }

    [Networked, OnChangedRender(nameof(OnColorChanged))]
    public Color BlackColor { get; set; }

    [SerializeField] private Color defaultFreshColor = Color.white;
    [SerializeField] private Color defaultBrownColor = new Color(0.4f, 0.2f, 0f);
    [SerializeField] private Color defaultBlackColor = Color.black;

    [SerializeField] private float cookingSpeed = 0.05f;

    public override void Spawned()
    {
        pan = GameObject.Find("Pan");
        nt = GetComponent<NetworkTransform>();
        rb = GetComponent<Rigidbody>();
        _renderer = GetComponentInChildren<Renderer>();

        Transform particleTransform = transform.Find("smokeParticles");
        if (particleTransform != null)
            particles = particleTransform.gameObject;

        if (Object.HasStateAuthority)
        {
            FreshColor = defaultFreshColor;
            BrownColor = defaultBrownColor;
            BlackColor = defaultBlackColor;
        }

        ApplyColor(DecayProgress);
    }

    public override void FixedUpdateNetwork()
    {
        if (rb != null)
            rb.isKinematic = !Object.HasStateAuthority;

        if (!Object.HasStateAuthority) return;

        if (fallingThroughThePan)
        {
            TeleportItem();
            fallingThroughThePan = false;
        }
    }

    private void TeleportItem()
    {
        if (pan == null || nt == null) return;

        nt.Teleport(
            new Vector3(
                transform.position.x,
                pan.transform.position.y + transform.localScale.y / 2,
                transform.position.z
            ),
            transform.rotation
        );

        Debug.Log("teleporting food.");
    }

    private void OnDecayChanged()
    {
        ApplyColor(DecayProgress);
    }

    private void OnColorChanged()
    {
        ApplyColor(DecayProgress);
    }

    private void ApplyColor(float t)
    {
        if (_renderer == null) return;

        Color color = t < 0.5f
            ? Color.Lerp(FreshColor, BrownColor, t * 2f)
            : Color.Lerp(BrownColor, BlackColor, (t - 0.5f) * 2f);

        _renderer.material.color = color;
    }

    public void SetColors(Color fresh, Color brown, Color black)
    {
        if (!Object.HasStateAuthority) return;

        FreshColor = fresh;
        BrownColor = brown;
        BlackColor = black;

        ApplyColor(DecayProgress);
    }

    public void CookingFood()
    {
        if (!Object.HasStateAuthority) return;

        DecayProgress += Runner.DeltaTime * cookingSpeed;
        DecayProgress = Mathf.Clamp01(DecayProgress);

        Debug.Log("cooking");
    }

    public void EnableParticles(bool setActive)
    {
        if (particles != null)
            particles.SetActive(setActive);
    }

    public bool ParticlesEnabled()
    {
        return particles != null && particles.activeSelf;
    }
}