using UnityEngine;
using UnityEngine.UI;

public class RoadManager : MonoBehaviour
{
    [SerializeField] private Vector3 roadSize;
    [SerializeField] private GameObject road;
    public static RoadManager roadManager;
    public int maxTilesCount;
    public Button.ButtonClickedEvent finishAction;
    private int generatedRoads;
    
    private void Awake() => roadManager = this;

    public void GenerateNewRoad(Transform previousRoad)
    {
        Destroy(previousRoad.gameObject, 10);
        var newRoad = Instantiate(road);
        newRoad.transform.position = previousRoad.position + roadSize;
        generatedRoads++;
        
        if(generatedRoads >= maxTilesCount)
            finishAction?.Invoke();
    }
}