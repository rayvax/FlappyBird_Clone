using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColumnGenerator : ObjectPool
{
    [SerializeField] private GameObject _column;
    [SerializeField] private float _spawnCooldown;
    [SerializeField] private float _maxSpawnPositionY;
    [SerializeField] private float _minSpawnPositionY;

    private float _elapsedTime;

    private void Start()
    {
        Initialize(_column);
    }

    private void Update()
    {
        _elapsedTime += Time.deltaTime;

        if(_elapsedTime >= _spawnCooldown)
        {
            if(TryGetObject(out GameObject column))
            {
                _elapsedTime = 0;
                column.SetActive(true);
                float positionY = Random.Range(_minSpawnPositionY, _maxSpawnPositionY);
                column.transform.position = new Vector3(transform.position.x, positionY, transform.position.z);
            }

            DisableObjectsAbroadCamera();
        }
    }

    public override void ResetPool()
    {
        base.ResetPool();
        _elapsedTime = 0;
    }
}
