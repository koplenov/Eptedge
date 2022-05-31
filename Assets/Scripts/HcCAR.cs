using UnityEngine;

public class HcCAR : MonoBehaviour
{
    [SerializeField] private Transform wheelsFront;
    [SerializeField] private Transform wheelsBack;
    void FixedUpdate()
    {
        wheelsFront.Rotate(Vector3.back, 5f);
        wheelsBack.Rotate(Vector3.back, 5f);
    }
}
