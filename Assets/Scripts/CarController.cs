using System;
using DG.Tweening;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Serialization;
using UnityEngine.UI;

public class CarController : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private float maxLeft;
    [SerializeField] private float maxRight;
    [SerializeField] private GameObject Loose;
    [SerializeField] private GameObject Victory;
    public Text Save;
    public Text PayDay;
    public Text Damage;
    public Text LooseDamage;
    public Text DurabilityText;
    public Text CargoText;
    private int durabiliti;
    private int cargo;
    private int havecargo;
    private int moneymodifier;

    private void Start()
    {
        Loose.SetActive(false);
        Victory.SetActive(false);
        maxLeft = (transform.position += Vector3.left * 10).x;
        maxRight = (transform.position += Vector3.right * 10).x;
    }

    private void Awake()
    {
        durabiliti = CartStats.Durability;
        cargo = CartStats.Cargo;
        moneymodifier = CartStats.JewishModifier;
        havecargo = 0;
        DurabilityText.text = "Durability: " + durabiliti;
        CargoText.text = havecargo + "/" + cargo;
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
                CargoText.text = havecargo + "/" + cargo;
            }
            if(havecargo == cargo)
            {
                Debug.Log("To many Yodjiks");
                Win();
            }
            
        }

        if (other.CompareTag("Wall"))
        {
            Debug.Log("Маслину.. поймав... пишов отмываться в гараж.....");
            durabiliti--;
            DurabilityText.text = "Durability: " + durabiliti;
            if (durabiliti <= 0)
                Dead();
        }
    }

    public void Dead()
    {
        Time.timeScale = 0;
        Cursor.visible = true;
        Loose.SetActive(true);
        LooseDamage.text = "Получено "+ CartStats.Durability+" урона";
    }

    public void Win()
    {
        Time.timeScale = 0;
        Cursor.visible = true;
        CartStats.TotalMoneyAmount += havecargo * moneymodifier;
        Victory.SetActive(true);
        Save.text = "Спасено: " + havecargo + " ежей";
        PayDay.text = "Заработано: "+ (havecargo * moneymodifier)+" $";
        Damage.text = "Получено "+ (CartStats.Durability - durabiliti)+" урона";
    }
}