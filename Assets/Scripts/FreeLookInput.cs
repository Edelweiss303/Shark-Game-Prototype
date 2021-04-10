using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(CinemachineFreeLook))]
public class FreeLookInput : MonoBehaviour
{
    [Range(0f, 10f)] 
    [SerializeField] private float _lookSpeed;
    [SerializeField] private bool _invertY;

    private CinemachineFreeLook _freeLookComponent;

    public void Start()
    {
        _freeLookComponent = GetComponent<CinemachineFreeLook>();
    }

    public void OnLook(InputAction.CallbackContext context)
    {
        //Normalize vector 
        Vector2 lookMovement = context.ReadValue<Vector2>().normalized;
        lookMovement.y = _invertY ? -lookMovement.y : lookMovement.y;

        // X axis only contains between -180 and 180 instead of 0 and 1 like the Y axis
        lookMovement.x = lookMovement.x * 180f;


        _freeLookComponent.m_XAxis.Value += lookMovement.x * _lookSpeed * Time.deltaTime;
        _freeLookComponent.m_YAxis.Value += lookMovement.y * _lookSpeed * Time.deltaTime;
    }
}
