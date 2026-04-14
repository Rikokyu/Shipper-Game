using UnityEngine;
using Unity.Cinemachine;

public class CameraSwitcher : MonoBehaviour
{
    public CinemachineCamera virtualCamera;

    public Transform player;
    public Transform playerWithBike;

    public void FollowPlayer()
    {
        virtualCamera.Follow = player;
    }

    public void FollowBike()
    {
        virtualCamera.Follow = playerWithBike;
    }
}