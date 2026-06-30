using UnityEngine;

public class FollowTarget : MonoBehaviour
{
    [SerializeField]
    Transform target;
    [SerializeField]
    DynamicDifficulty DD;
    float smoothTime => DD.dodgeSpeed;
    Vector3 smoothingVelocity;

    void Update()
    {
        transform.position = Vector3.SmoothDamp(transform.position, target.position, ref smoothingVelocity, smoothTime);
    }
}
