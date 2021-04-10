using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FishController : MonoBehaviour
{
    [SerializeField] private int _scoreValue;

    [SerializeField] private int _movementSpeed;

    [SerializeField] private float _randomPointRadius;

    [SerializeField] private Animator _fsm;

    [SerializeField] bool _isGoodFish;

    private Vector3 destination;

    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<SharkControls>())
        {
            Die();
        }
        else
        {
            FindRandomPoint();
        }
    }

    private void Die()
    {
        UIManager.Instance.UpdateScore(_scoreValue);
        
        if (_isGoodFish)
            UIManager.Instance.goodFishes++;

        Destroy(gameObject);
    }

    public void FindRandomPoint()
    {
        destination = Random.insideUnitSphere * _randomPointRadius;
    }

    public void Move()
    {
        Vector3 direction = (destination - transform.position).normalized;
        transform.rotation = Quaternion.LookRotation(direction);
        transform.Translate(direction * _movementSpeed * Time.deltaTime, Space.World);
    }
}
