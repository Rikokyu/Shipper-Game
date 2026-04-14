using UnityEngine;

public class UIFollow : MonoBehaviour
{
    public Transform target;
    public Camera cam;
    public Vector3 offset;

    void Update()
    {
        Vector3 pos = cam.WorldToScreenPoint(target.position + offset);
        transform.position = pos;
    }
}