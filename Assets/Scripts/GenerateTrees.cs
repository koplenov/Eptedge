using System.Collections;
using UnityEngine;

public class GenerateTrees : MonoBehaviour
{
    [SerializeField] private GameObject[] itemVariables;
    [SerializeField] private GameObject[] generatePoints;

    private void OnEnable() => StartCoroutine(GenTree());
    IEnumerator GenTree()
    {
        foreach (var generatePoint in generatePoints)
        {
            yield return new WaitForFixedUpdate();
            var item = Instantiate(itemVariables[Random.Range(0, itemVariables.Length)]);
            item.transform.position = generatePoint.transform.position;
            item.transform.parent = generatePoint.transform.parent;
            item.transform.rotation = Quaternion.Euler(
                new Vector3
                {
                    x = 0,
                    y = Random.Range(0, 360),
                    z = 0,
                }
            );
        }

        yield return null;
    }
}