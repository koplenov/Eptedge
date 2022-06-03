using UnityEngine;

public class Finish : MonoBehaviour
{
    [SerializeField] private GameObject finishGameObject;
    private void Start() => finishGameObject.SetActive(RoadManager.roadManager.IsLastTile());

    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<CarController>() != null)
            RoadManager.roadManager.finishAction.Invoke();
    }
}