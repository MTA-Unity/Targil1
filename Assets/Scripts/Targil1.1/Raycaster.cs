using UnityEngine;

namespace Targil1._1
{
    public class Raycaster : MonoBehaviour
    {
        [SerializeField] private Camera _camera;
        [SerializeField] private GameObject _prefab;

        void Update()
        {
            var pressingLeft = Input.GetMouseButtonDown(0);
            var pressingRight = Input.GetMouseButtonDown(1);
            
            if (pressingLeft || pressingRight)
            {
                var ray = _camera.ScreenPointToRay(Input.mousePosition);
                if (Physics.Raycast(ray, out var hit))
                {
                    if (hit.rigidbody != null && pressingLeft)
                    {
                        Destroy(hit.transform.gameObject);
                    }
                    
                    if (hit.rigidbody == null && pressingRight)
                    {
                        Instantiate(_prefab, hit.point + Vector3.up * 2, Quaternion.identity);
                    }
                }
            }
        }
    }
}
