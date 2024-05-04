using UnityEngine;

[RequireComponent(typeof(MeshRenderer))]
public class MaterialEffector : MonoBehaviour
{
    [SerializeField] private MeshRenderer _meshRenderer;

    [SerializeField] private Material _defaultMaterial;
    [SerializeField] private Material _changeMaterial;
    private bool isGlow;

    private void OnValidate()
    {
        _meshRenderer ??= GetComponent<MeshRenderer>();
    }

    public void SetEffect()
    {
        if (!isGlow)
        {
            _meshRenderer.material = _changeMaterial;
            _meshRenderer.UpdateGIMaterials();
            isGlow = true;
        }
    }

    public void SetDefault()
    {
        if (isGlow)
        {
            _meshRenderer.material = _defaultMaterial;
            _meshRenderer.UpdateGIMaterials();
            isGlow = false;
        }
    }

}
