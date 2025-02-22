using UnityEngine;
using StarterAssets;

#if ENABLE_INPUT_SYSTEM
using UnityEngine.InputSystem;
#endif

namespace StarterAssets
{
    public class StarterAssetsInputs : MonoBehaviour
    {
        [Header("Joystick Reference")]
        public UIVirtualJoystick joystickMove;

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

        private bool isJoystickActive = false;
        private Vector2 lastMoveDirection = Vector2.zero;

        private void Start()
        {
            if (joystickMove != null)
            {
                joystickMove.joystickOutputEvent.AddListener(UpdateJoystickValue);
            }
        }

        private void UpdateJoystickValue(Vector2 joystickValue)
        {
            if (joystickValue.magnitude > 0.1f)
            {
                move = joystickValue * 0.5f;
                lastMoveDirection = move;
                isJoystickActive = true;
            }
            else
            {
                move = Vector2.zero;
                isJoystickActive = false;
            }
        }

        private void Update()
        {
            if (isJoystickActive)
            {
                MoveInput(lastMoveDirection);
            }

            if (Input.touchCount > 0)
            {
                Touch touch = Input.GetTouch(0);
                if (touch.phase == UnityEngine.TouchPhase.Began)  // FIXED TouchPhase ambiguity
                {
                    Vector2 touchPosition = touch.position;
                    MoveToPosition(touchPosition);
                }
            }
        }

        void MoveToPosition(Vector2 position)
        {
            Vector3 worldPosition = Camera.main.ScreenToWorldPoint(new Vector3(position.x, position.y, 10f));
            transform.position = Vector3.Lerp(transform.position, worldPosition, Time.deltaTime * 5);
        }

#if ENABLE_INPUT_SYSTEM
        public void OnMove(InputValue value)
        {
            MoveInput(value.Get<Vector2>());
        }

        public void OnLook(InputValue value)
        {
            if (cursorInputForLook)
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
#endif

        public void MoveInput(Vector2 newMoveDirection)
        {
            move = newMoveDirection * 0.5f;
            UnityEngine.Debug.Log("Joystick Movement: " + move);

            if (newMoveDirection.magnitude < 0.1f)
            {
                move = Vector2.zero;
                isJoystickActive = false;
            }
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
    }
}
