using UnityEngine;

[RequireComponent(typeof(Camera))]
public class CameraPro : MonoBehaviour
{
    [Header(" Camera follow player")]
    public bool followPlayer;
    public Transform target;
    public Vector3 cameraPos;
    public bool lookAtPlayer;
    public Vector3 cameraRotation;

    [Header("Camera smooth whin follow player")]
    public bool smooth;
    public float smoothSpeed = 0.123f;

    [Header("Camera scale betwen two players")]
    public bool scaleCamera;
    public Transform target1;
    public Transform target2;

    public void Update()
    {
        if(followPlayer || !smooth)
        {
            transform.position = target.position + cameraPos;
        }else if(followPlayer || smooth)
        {
            transform.position = Vector3.Lerp(transform.position, target.position + cameraPos, smoothSpeed);
        }

        if(scaleCamera)
        {
            transform.position = target1.transform.position - target2.transform.position;
        }

        if(lookAtPlayer)
        {
            transform.LookAt(target);
        }
    }
}
