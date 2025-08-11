using UnityEngine;

public class ButtonPress : MonoBehaviour
{
    private GameObject Button;
    private GameObject door_L;
    private GameObject door_R;

    private void OnTriggerEnter(Collider collision)
    {
        if (collision.CompareTag("Player"))
        {
            Button = GameObject.Find("Button");
            door_L = GameObject.Find("door_L");
            door_R = GameObject.Find("door_R");
            if (Button != null && door_L != null && door_R != null)

            {
                Animator buttonAnimator = Button.GetComponent<Animator>();
                Animator leftDoorAnimator = door_L.GetComponent<Animator>();
                Animator rightDoorAnimator = door_R.GetComponent<Animator>();

                if (buttonAnimator != null)
                {
                    buttonAnimator.Play("buttonPushed");
                }

                if (leftDoorAnimator != null)
                {
                    leftDoorAnimator.Play("Lopening");
                }

                if (rightDoorAnimator != null)
                {
                    rightDoorAnimator.Play("Ropening");
                }
            }

            // Disable the button to prevent further presses
            gameObject.SetActive(false);
        }
    }
}
