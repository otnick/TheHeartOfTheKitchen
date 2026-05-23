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

    [Networked, OnChangedRender(nameof(OnDecayChanged))]
    public float DecayProgress { get; set; } // 0 = fresh, 1 = black

    private Renderer _renderer;

    [SerializeField] private Color _freshColor = new Color(0f, 0f, 0f);
    [SerializeField] private Color _brownColor = new Color(0.4f, 0.2f, 0f);
    [SerializeField] private Color _blackColor = Color.black;
    [SerializeField] private float cookingSpeed = 0.05f;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public override void Spawned()
    {
        pan = GameObject.Find("Pan");
        nt = gameObject.GetComponent<NetworkTransform>();
        _renderer = gameObject.GetComponentInChildren<Renderer>();
        rb = gameObject.GetComponent<Rigidbody>();
    }
    private void Start()
    {
        particles = transform.Find("smokeParticles").gameObject;
    }

    public override void FixedUpdateNetwork()
    {
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
        // Snap it back to the floor if it fell through
        nt.Teleport(
    new Vector3(
        transform.position.x,
        pan.transform.position.y + transform.localScale.y / 2,
        transform.position.z),
        transform.rotation); //TODO: later on check the pivot points of the tangible pan and real pan.
        Debug.Log("teleporting food.");
        return;
    }

    private void OnDecayChanged()
    {
        ApplyColor(DecayProgress);
    }

    private void ApplyColor(float t)
    {
        // Two-stage lerp: 0-0.5 = fresh→brown, 0.5-1 = brown→black
        Color color = t < 0.5f
            ? Color.Lerp(_freshColor, _brownColor, t * 2f) // lerp from 0-1, but our value matters only up until 0.5 so we *2f makes sense no?>
            : Color.Lerp(_brownColor, _blackColor, (t - 0.5f) * 2f);

        _renderer.material.color = color;
    }

    public void CookingFood()
    {
        DecayProgress += Runner.DeltaTime * cookingSpeed;
        DecayProgress = Mathf.Clamp01(DecayProgress);
        Debug.Log("cooking");
    }
    public void EnableParticles(bool setActive)
    {
        particles.SetActive(setActive);
    }
    public bool ParticlesEnabled()
    {
        return particles.activeSelf;
    }
}
