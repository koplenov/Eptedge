using System;
using DG.Tweening;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class CarController : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private float maxLeft;
    [SerializeField] private float maxRight;
    public Text HpText;
    private int durabiliti;
    private int cargo;
    private int havecargo;
    private void Start()
    {
        maxLeft = (transform.position += Vector3.left * 10).x;
        maxRight = (transform.position += Vector3.right * 10).x;
    }

    private void Awake()
    {  
        durabiliti = CartStats.Durability;
        cargo = CartStats.Cargo;
        havecargo = 0;
        HpText.text = "Durability: " + durabiliti;
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
            if (havecargo < cargo)
            {
                Debug.Log("Ежа поймав");
                havecargo++;
                Destroy(other.gameObject);
            }
            else
            {
                Debug.Log("To many Yodjiks");
            }
        }

        if (other.CompareTag("Wall"))
        {
            Debug.Log("Маслину.. поймав... пишов отмываться в гараж.....");
            durabiliti--;
            HpText.text = "Durability: " + durabiliti;
            if (durabiliti <= 0)
                Dead();
        }
    }

    public void Dead() => SceneManager.LoadScene("Garage");
}