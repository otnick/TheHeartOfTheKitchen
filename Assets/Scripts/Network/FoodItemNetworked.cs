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

    [SerializeField] private Color _freshColor = new Color(0f, 0f, 0f);
    [SerializeField] private Color _brownColor = new Color(0.4f, 0.2f, 0f);
    [SerializeField] private Color _blackColor = Color.black;

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

        ApplyColor(DecayProgress);
    }

    private void Start()
    {
        if (particles == null)
        {
            Transform particleTransform = transform.Find("smokeParticles");
            if (particleTransform != null)
                particles = particleTransform.gameObject;
        }
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

    private void ApplyColor(float t)
    {
        if (_renderer == null) return;

        Color color = t < 0.5f
            ? Color.Lerp(_freshColor, _brownColor, t * 2f)
            : Color.Lerp(_brownColor, _blackColor, (t - 0.5f) * 2f);

        _renderer.material.color = color;
    }

    public void SetColors(Color fresh, Color brown, Color black)
    {
        _freshColor = fresh;
        _brownColor = brown;
        _blackColor = black;

        ApplyColor(DecayProgress);
    }

    public void CookingFood()
    {
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