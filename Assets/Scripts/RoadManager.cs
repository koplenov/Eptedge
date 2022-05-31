using UnityEngine;

public class RoadManager : MonoBehaviour
{
    [SerializeField] private Vector3 roadSize;
    [SerializeField] private GameObject road;
    public static RoadManager roadManager;
    private void Awake() => roadManager = this;

    public void GenerateNewRoad(Transform previousRoad)
    {
        Destroy(previousRoad.gameObject, 2);
        var newRoad = Instantiate(road);
        newRoad.transform.position = previousRoad.position + roadSize;
    }
}