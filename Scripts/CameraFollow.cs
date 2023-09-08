
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [SerializeField] Transform target;

    private void LateUpdate(){
        transform.position = target.position;
        transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z-10);
    }
}

