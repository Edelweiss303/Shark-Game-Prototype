using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class SharkControls : MonoBehaviour
{
    [SerializeField] private PlayerParameters _sharkParameters;
    [SerializeField] private Camera _camera;
    [SerializeField] private Transform _looktarget;

    private Vector2 _controllerInput;
    private bool _isHeldDown;
    private float _boostMultiplier = 1.0f;

    private void Update()
    {
        if (_isHeldDown)
            MoveAndRotate();
    }
    public void Move(InputAction.CallbackContext context)
    {
        if (!context.canceled)
        {
            _isHeldDown = true;
            _controllerInput = context.ReadValue<Vector2>();
        }
        else
        {
            _isHeldDown = false;
        }
    }

    private void MoveAndRotate()
    {
        float factor = _controllerInput.y > 0 ? -1 : 1;

        transform.rotation = Quaternion.LookRotation(_camera.transform.forward) * Quaternion.FromToRotation(factor * Vector3.right, Vector3.forward);

        transform.Translate(_camera.transform.forward * _sharkParameters.movementSpeed * _controllerInput.y * _boostMultiplier * Time.deltaTime, Space.World);
    }

    public void Boost(InputAction.CallbackContext context)
    {
        if (!context.canceled)
            _boostMultiplier = _sharkParameters.boostMultiplier;
        else
            _boostMultiplier = 1.0f;
    }

}

