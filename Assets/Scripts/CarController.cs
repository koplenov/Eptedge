using DG.Tweening;
using UnityEngine;

public class CarController : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private float maxLeft;
    [SerializeField] private float maxRight;

    private void Start()
    {
        maxLeft = (transform.position += Vector3.left * 10).x;
        maxRight = (transform.position += Vector3.right * 10).x;
    }

    private void FixedUpdate()
    {
        transform.position += Vector3.forward * speed;

        speed += 0.0005f;
    }

    private bool _canMove = true;

    void Update()
    {
        if (!_canMove) return;
        
        if (Input.GetKeyDown(KeyCode.A) && transform.position.x > maxLeft)
        {
            transform.DOMoveX(transform.position.x - 10, 0.15f).onComplete = () => _canMove = true;
            _canMove = false;
        }

        if (Input.GetKeyDown(KeyCode.D) && transform.position.x <= maxRight)
        {
            transform.DOMoveX(transform.position.x + 10, 0.15f).onComplete = () => _canMove = true;
            _canMove = false;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("NewZone"))
            RoadManager.roadManager.GenerateNewRoad(other.transform);
    }
}