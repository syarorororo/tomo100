using System.Diagnostics.Contracts;
using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(CharacterController))]
public class PlayerController : MonoBehaviour
{
    [SerializeField]
    private float P_speed;

    private Transform P_transform;
    private CharacterController CharacterController;

    private Vector2 inputMove;
    private float VerticalVelocity = 0;
    private float turnVelocity;

    public void OnMove(InputAction.CallbackContext context)
    {
        inputMove = context.ReadValue<Vector2>();
    }

    private void Awake()
    {
        CharacterController = GetComponent<CharacterController>();
        P_transform = GetComponent<Transform>();    
    }
    // Update is called once per frame
    void Update()
    {
        var moveVelocity = new Vector3(inputMove.x * P_speed, VerticalVelocity, inputMove.y * P_speed);
        var moveDelta =moveVelocity  *Time .deltaTime;  
        CharacterController.Move(moveDelta);

        if (inputMove != Vector2.zero)
        {
            var targetAngleY =-Mathf.Atan2(inputMove.y, inputMove.x)*Mathf.Rad2Deg+90;
            var angleY = Mathf.SmoothDampAngle(P_transform.eulerAngles.y, targetAngleY,ref turnVelocity,0.1f);

            P_transform.rotation = Quaternion.Euler(0,angleY,0);
        }
    }
}
