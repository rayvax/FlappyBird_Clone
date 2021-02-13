using System.Linq;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPool : MonoBehaviour
{
    [SerializeField] private Transform _container;
    [SerializeField] private int _capacity;

    private List<GameObject> _pool;
    private Camera _camera;

    public void Initialize(GameObject prefab)
    {
        _camera = Camera.main;
        _pool = new List<GameObject>(_capacity);

        for (int i = 0; i < _capacity; i++)
        {
            GameObject spawned = Instantiate(prefab, _container);
            spawned.SetActive(false);

            _pool.Add(spawned);
        }
    }

    public bool TryGetObject(out GameObject result)
    {
        result = _pool.FirstOrDefault(obj => obj.activeSelf == false);

        return result != null;
    }

    public void DisableObjectsAbroadCamera()
    {
        Vector2 disablePoint = _camera.ViewportToWorldPoint(new Vector2(0, 0.5f));

        foreach (var item in _pool)
        {
            if(item.activeSelf && item.transform.position.x < disablePoint.x)
            {
                item.SetActive(false);
            }
        }
    }

    public virtual void ResetPool()
    {
        foreach (var item in _pool)
        {
            item.SetActive(false);
        }
    }
}
