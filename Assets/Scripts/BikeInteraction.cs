using UnityEngine;

public class BikeInteraction : MonoBehaviour
{
    public GameObject player;
    public GameObject bike;
    public GameObject playerWithBike;

    public GameObject enterButton;

    public ButtonFollower buttonFollower;
    public CameraSwitcher cameraSwitcher;

    public float interactDistance = 1.5f;

    void Start()
    {
        enterButton.SetActive(false);
        buttonFollower.SetTarget(bike.transform);
    }

    void Update()
    {
        float distance =
            Vector2.Distance(player.transform.position, bike.transform.position);

        if (distance <= interactDistance)
        {
            enterButton.SetActive(true);

            if (Input.GetKeyDown(KeyCode.F))
            {
                EnterBike();
            }
        }
        else
        {
            enterButton.SetActive(false);
        }
    }

    void EnterBike()
    {
        player.SetActive(false);
        bike.SetActive(false);

        playerWithBike.transform.position = bike.transform.position;
        playerWithBike.SetActive(true);

        buttonFollower.SetTarget(playerWithBike.transform);

        cameraSwitcher.FollowBike();
    }
}