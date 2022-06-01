using UnityEngine;

public class GenerateCoins : MonoBehaviour
{
    [SerializeField] private GameObject itemVariable;
    [SerializeField] private GameObject[] generatePoints;

    private void OnEnable()
    {
        foreach (var generatePoint in generatePoints)
        {
            if (Random.Range(0, 100) > 50)
            {
                var item = Instantiate(itemVariable);
                item.transform.position = generatePoint.transform.position + Vector3.up * 2;
                item.transform.parent = generatePoint.transform.parent;
            }            
        }

    }
}