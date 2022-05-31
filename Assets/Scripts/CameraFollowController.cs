using UnityEngine;

public class CameraFollowController : MonoBehaviour
{
    [SerializeField] private Transform player;
    private Vector3 offset;

    private void Awake() => offset = transform.position - player.position;

    private void LateUpdate()
    {
        transform.LookAt(player.transform.position);
        var tempPos = player.position;
        tempPos.x = 0;
        transform.position = tempPos + offset;
    }
}
