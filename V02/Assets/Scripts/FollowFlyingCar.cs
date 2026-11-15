using UnityEngine;

public class FollowFlyingCar : MonoBehaviour
{
    public Transform target;
    public Vector3 offset = new Vector3(0,6,-13);
    void LateUpdate()
    {
        if (target == null) return;
        Vector3 desired = target.position + target.rotation * offset;
        transform.position = Vector3.Lerp(transform.position,desired,Mathf.Clamp01(6*Time.deltaTime));
        transform.LookAt(target.position + Vector3.up*1.5f);
    }
}
