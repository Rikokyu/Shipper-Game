using UnityEngine;

public class PlayerBikeExit : MonoBehaviour
{
    public GameObject player;
    public GameObject bike;
    public GameObject playerWithBike;

    public GameObject enterButton;

    public ButtonFollower buttonFollower;
    public CameraSwitcher cameraSwitcher;

    private Animator animator;

    void Start()
    {
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        bool isRidingAnim = animator.GetBool("isRiding");

        // Button follow PlayerWithBike
        enterButton.transform.position =
            Camera.main.WorldToScreenPoint(
                playerWithBike.transform.position + new Vector3(0, 1.2f, 0)
            );

        if (isRidingAnim)
        {
            enterButton.SetActive(false);
        }
        else
        {
            enterButton.SetActive(true);

            if (Input.GetKeyDown(KeyCode.F))
            {
                ExitBike();
            }
        }
    }

    void ExitBike()
    {
        Vector3 exitPos = playerWithBike.transform.position;

        player.transform.position = exitPos;
        bike.transform.position = exitPos;

        player.SetActive(true);
        bike.SetActive(true);

        playerWithBike.SetActive(false);

        buttonFollower.SetTarget(bike.transform);

        cameraSwitcher.FollowPlayer();

        enterButton.SetActive(false);
    }
}