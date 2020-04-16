using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
[RequireComponent(typeof(SphereCollider))]
public class Tools : MonoBehaviour
{
    [HideInInspector]
    public SphereCollider collider;
    public string toolName;
    public float radius = 1f;
    private void Start()
    {
        collider = GetComponent<SphereCollider>();
    }

    private void Update()
    {
        collider.isTrigger = true;
        collider.radius = radius;
    }
}
