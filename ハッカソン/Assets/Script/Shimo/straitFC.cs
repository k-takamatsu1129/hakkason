using System.Collections;
using UnityEngine;

public class straitFC : MonoBehaviour
{
    public GameObject prefab;        // ¶¬‚·‚éPrefab
    public float minInterval = 3f;    // Å¬¶¬ŠÔŠu
    public float maxInterval = 10f;    // Å‘å¶¬ŠÔŠu

    void Start()
    {
        StartCoroutine(SpawnRoutine());
    }

    IEnumerator SpawnRoutine()
    {
        while (true)
        {
            // ƒ‰ƒ“ƒ_ƒ€‚È‘Ò‚¿ŠÔ
            float waitTime = Random.Range(minInterval, maxInterval);
            yield return new WaitForSeconds(waitTime);


            Vector3 position = this.gameObject.transform.position;
            position.y = ShimoDB.Instance.getkoudo();

            Instantiate(prefab, position, Quaternion.identity);
        }
    }
}
