using UnityEngine;
#if ENABLE_INPUT_SYSTEM
using UnityEngine.InputSystem;
#endif

namespace StarterAssets
{
	public class StarterAssetsInputs : MonoBehaviour
	{
		private bool zoomedIn = false;
		private bool zoomedOut = false;
		
		[Header("Character Input Values")]
		public Vector2 move;
		public Vector2 look;
		public bool jump;
		public bool sprint;

		[Header("Movement Settings")]
		public bool analogMovement;

		[Header("Mouse Cursor Settings")]
		public bool cursorLocked = true;
		public bool cursorInputForLook = true;

#if ENABLE_INPUT_SYSTEM
		public void OnMove(InputValue value)
		{
			MoveInput(value.Get<Vector2>());
		}

		public void OnLook(InputValue value)
		{
			if(cursorInputForLook)
			{
				LookInput(value.Get<Vector2>());
			}
		}

		public void OnJump(InputValue value)
		{
			JumpInput(value.isPressed);
		}

		public void OnSprint(InputValue value)
		{
			SprintInput(value.isPressed);
		}

		public void OnZoomIn()
		{
			ZoomInInput();
		}

		public void OnZoomOut()
		{
			ZoomOutInput();
		}
#endif


		public void MoveInput(Vector2 newMoveDirection)
		{
			move = newMoveDirection;
		}

		public void LookInput(Vector2 newLookDirection)
		{
			look = newLookDirection;
		}

		public void JumpInput(bool newJumpState)
		{
			jump = newJumpState;
		}

		public void SprintInput(bool newSprintState)
		{
			sprint = newSprintState;
		}

		private void OnApplicationFocus(bool hasFocus)
		{
			SetCursorState(cursorLocked);
		}

		private void SetCursorState(bool newState)
		{
			Cursor.lockState = newState ? CursorLockMode.Locked : CursorLockMode.None;
		}

		public void ZoomInInput()
		{
			if (!zoomedIn)
			{
				GameObject playArea = GameObject.Find("PlayArea");
				if (playArea != null)
				{	
					GameObject playerArmature = GameObject.Find("PlayerArmature");
					var characterController = playerArmature.GetComponent<CharacterController>();
					characterController.enabled = false;
					playArea.transform.localScale += new Vector3(0.25f, 0.25f, 0.25f);
					if (playerArmature != null)
					{
						var controller = playerArmature.GetComponent<ThirdPersonController>();
						controller.SprintSpeed += 2f; //1.3f;
						controller.JumpHeight += 0.5f; //0.3f;
						controller.GroundedOffset -= 0.035f;
						controller.GroundedRadius += 0.07f;
						controller.Gravity -= 4f;//3.75f;
					}
					characterController.enabled = true;
				}
				zoomedIn = true;
			}
			else
			{
				zoomedIn = false;
			}
		}
		public void ZoomOutInput()
		{
			if (!zoomedOut)
			{
				GameObject playArea = GameObject.Find("PlayArea");
				if (playArea != null)
				{
					if (playArea.transform.localScale.x > 0.25f && playArea.transform.localScale.y > 0.25f && playArea.transform.localScale.z > 0.25f)
					{
						GameObject playerArmature = GameObject.Find("PlayerArmature");
						var characterController = playerArmature.GetComponent<CharacterController>();
						characterController.enabled = false;
						playArea.transform.localScale -= new Vector3(0.25f, 0.25f, 0.25f);
						if (playerArmature != null)
						{
							var controller = playerArmature.GetComponent<ThirdPersonController>();
							controller.SprintSpeed -= 2f; //1.3f;
							controller.JumpHeight -= 0.5f; //0.3f;
							controller.GroundedOffset += 0.035f;
							controller.GroundedRadius -= 0.07f;
							controller.Gravity += 4f;//3.75f;
						}
						characterController.enabled = true;
					}
				}
				zoomedOut = true;
			}
			else
			{
				zoomedOut = false;
			}
		}
	}
	
}