using UnityEngine;

public class GenerateItem : MonoBehaviour
{
    [SerializeField] private GameObject[] itemVariables;
    [SerializeField] private GameObject[] generatePoints;

    private void OnEnable()
    {
        int generateCount = 0;
        foreach (var generatePoint in generatePoints)
        {
            if (Random.Range(0, 100) > 50 && generateCount != 2)
            {
                generateCount++;
                var item = Instantiate(itemVariables[Random.Range(0, itemVariables.Length)]);
                item.transform.position = generatePoint.transform.position;
                item.transform.parent = generatePoint.transform.parent;
            }            
        }

    }
}