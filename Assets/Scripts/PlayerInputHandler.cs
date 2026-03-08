using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInputHandler : MonoBehaviour
{
    public Player Player;
    public FirstPersonCamera PlayerCamera;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 direction = new Vector3(0,0,0);
        if (Keyboard.current.wKey.isPressed)
        {
            direction.z += 1;
        }
        if (Keyboard.current.sKey.isPressed)
        {
            direction.z -= 1;
        }
        if (Keyboard.current.aKey.isPressed)
        {
            direction.x -= 1;
        }
        if (Keyboard.current.dKey.isPressed)
        {
            direction.x += 1;
        }
        if (Keyboard.current.leftArrowKey.isPressed)
        {
            PlayerCamera.AdjustRotation(-1);
            Player.RotateCreatureForCamera(PlayerCamera.cameraTransform);
        }
        if (Keyboard.current.rightArrowKey.isPressed)
        {
            PlayerCamera.AdjustRotation(1);
            Player.RotateCreatureForCamera(PlayerCamera.cameraTransform);
        }
        direction = PlayerCamera.cameraTransform.TransformDirection(direction);

        direction.y = 0;
        Player.Move(direction);

    }
}
