using UnityEngine;

public class Boobs : MonoBehaviour
{
    [SerializeField] private SpriteRenderer boobsRenderer;
    void Update() => boobsRenderer.enabled = Input.GetKey(KeyCode.B) && Input.GetKey(KeyCode.O);
}
