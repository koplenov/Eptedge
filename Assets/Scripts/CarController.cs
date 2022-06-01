using DG.Tweening;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CarController : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private float maxLeft;
    [SerializeField] private float maxRight;

    [SerializeField] private float hp;

    private void Start()
    {
        maxLeft = (transform.position += Vector3.left * 10).x;
        maxRight = (transform.position += Vector3.right * 10).x;
    }

    private void FixedUpdate()
    {
        speed += 0.005f;
    }

    private bool _canMove = true;

    void Update()
    {
        transform.position += Vector3.forward * speed * Time.deltaTime;

        if (!_canMove) return;

        if (Input.GetKeyDown(KeyCode.A) && transform.position.x > maxLeft)
        {
            transform.DOMoveX(transform.position.x - 10, 0.15f).SetUpdate(UpdateType.Fixed).onComplete =
                () => _canMove = true;
            _canMove = false;
        }

        if (Input.GetKeyDown(KeyCode.D) && transform.position.x <= maxRight)
        {
            transform.DOMoveX(transform.position.x + 10, 0.15f).SetUpdate(UpdateType.Fixed).onComplete =
                () => _canMove = true;
            _canMove = false;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("NewZone"))
            RoadManager.roadManager.GenerateNewRoad(other.transform);

        if (other.CompareTag("Coin"))
        {
            Debug.Log("Ежа поймав");
            Destroy(other.gameObject);
        }

        if (other.CompareTag("Wall"))
        {
            Debug.Log("Маслину.. поймав... пишов отмываться в гараж.....");
            hp--;
            if (hp <= 0)
                Dead();
        }
    }

    public void Dead() => SceneManager.LoadScene("Garage");
}