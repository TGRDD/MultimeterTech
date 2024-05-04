using UnityEngine;

[RequireComponent(typeof(MeshRenderer))]
public class GlowEffector : MonoBehaviour
{
    [SerializeField] private MeshRenderer _meshRenderer;
    [SerializeField] private Color _glowColor;
    [SerializeField] private float _glowIntensity;

    private bool isGlow;

    private Material mainMaterial => _meshRenderer.material;

    private void OnValidate()
    {
        _meshRenderer ??= GetComponent<MeshRenderer>();
    }

    public void GlowUp()
    {
        if (!isGlow)
        {
            mainMaterial.SetColor("_EmissionColor", _glowColor * _glowIntensity);
            mainMaterial.EnableKeyword("_EMISSION");
            _meshRenderer.UpdateGIMaterials();
            isGlow = true;
        }
    }

    public void GlowDown()
    {
        if (isGlow)
        {
            mainMaterial.DisableKeyword("_EMISSION");
            _meshRenderer.UpdateGIMaterials();
            isGlow = false;
        }
    }

}
