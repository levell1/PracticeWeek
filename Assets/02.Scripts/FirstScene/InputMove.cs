
using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;

public class InputMove : MonoBehaviour
{
    [Header("Movement")]
    public float MoveSpeed;
    private Vector2 _curMovementInput;
    public float JumpForce;
    public LayerMask GroundLayerMask;
    private Vector2 _mouseDelta;
    private int _JumpCount = 1;

    [HideInInspector]
    public bool canLook = true;

    private Rigidbody _rigidbody;

    public TextMeshProUGUI textMeshPro;

    public static InputMove instance;
    private void Awake()
    {
        instance = this;
        _rigidbody = GetComponent<Rigidbody>();
    }
    private void Update()
    {
        if (IsGrounded() && _JumpCount != 1)
        {
            _JumpCount = 1;
        }
    }
    private void FixedUpdate()
    {
        Move();
        
    }

    private void Move()
    {
        Vector3 dir = transform.forward * _curMovementInput.y + transform.right * _curMovementInput.x;
        dir *= MoveSpeed;
        dir.y = _rigidbody.velocity.y;

        _rigidbody.velocity = dir;
    }

    private void LateUpdate()
    {
    }

    public void OnMoveInput(InputAction.CallbackContext context)
    {
        if (context.phase == InputActionPhase.Performed)
        {
            _curMovementInput = context.ReadValue<Vector2>();
        }
        else if (context.phase == InputActionPhase.Canceled)
        {
            _curMovementInput = Vector2.zero;
        }
    }

    public void OnJumpInput(InputAction.CallbackContext context)
    {
        if (context.phase == InputActionPhase.Started)
        {
            if (_JumpCount != 0)
            {
                _JumpCount--;
                _rigidbody.AddForce(Vector2.up * JumpForce, ForceMode.Impulse);
            }
        }
    }

    public void OnInteractInput(InputAction.CallbackContext context)
    {
        if (context.phase == InputActionPhase.Started)
        {
            textMeshPro.gameObject.SetActive(true);
        }
    }
    private bool IsGrounded()
    {
        Ray[] rays = new Ray[4]
        {
            new Ray(transform.position + (transform.forward * 0.2f) + (Vector3.up * 0.01f) , Vector3.down),
            new Ray(transform.position + (-transform.forward * 0.2f)+ (Vector3.up * 0.01f), Vector3.down),
            new Ray(transform.position + (transform.right * 0.2f) + (Vector3.up * 0.01f), Vector3.down),
            new Ray(transform.position + (-transform.right * 0.2f) + (Vector3.up * 0.01f), Vector3.down),
        };


        for (int i = 0; i < rays.Length; i++)
        {
            if (Physics.Raycast(rays[i], 0.2f, GroundLayerMask))
            {
                return true;
            }
        }

        return false;
    }
}
