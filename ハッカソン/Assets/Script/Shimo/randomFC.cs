using System.Collections;
using UnityEngine;

public class randomFC : MonoBehaviour
{
    public GameObject prefab;        // 生成するPrefab
    public float minInterval = 3f;    // 最小生成間隔
    public float maxInterval = 10f;    // 最大生成間隔

    void Start()
    {
        StartCoroutine(SpawnRoutine());
    }

    IEnumerator SpawnRoutine()
    {
        while (true)
        {
            // ランダムな待ち時間
            float waitTime = Random.Range(minInterval, maxInterval);
            yield return new WaitForSeconds(waitTime);

            // ランダムな方向（単位ベクトル）
            Vector3 randomDirection = new Vector3(Random.Range(-1f, 1f),    0f,    Random.Range(-1f, 1f)).normalized;

            Vector3 position = this.gameObject.transform.position;
            position.y = ShimoDB.Instance.getkoudo();

            // 回転（向きもランダムにしたい場合）
            Quaternion rotation = Quaternion.LookRotation(randomDirection);

            Instantiate(prefab, position, rotation);
        }
    }
}
