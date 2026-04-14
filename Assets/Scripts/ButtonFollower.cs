using UnityEngine;

public class ButtonFollower : MonoBehaviour
{
    public Transform target;

    void Update()
    {
        if (target == null) return;

        transform.position =
            Camera.main.WorldToScreenPoint(
                target.position + new Vector3(0, 1.2f, 0)
            );
    }

    public void SetTarget(Transform newTarget)
    {
        target = newTarget;
    }
}