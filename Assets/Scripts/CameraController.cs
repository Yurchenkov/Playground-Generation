using UnityEngine;

public class CameraController : MonoBehaviour {

    Transform target;
    Vector3 offset;
    float smoothTime = 0.3f;
    Vector3 velocity = Vector3.zero;

    void Start() {
        target = GameObject.FindGameObjectWithTag("Player").transform;
        offset = transform.position - target.position;
    }

    private void LateUpdate() {
        Vector3 targetPosition = target.position + offset;
        transform.position = Vector3.SmoothDamp(transform.position, targetPosition, ref velocity, smoothTime);
    }
}
