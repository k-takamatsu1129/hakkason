using System.Collections;
using UnityEngine;
using UnityEngine.AI;

public class MoveToTarget : MonoBehaviour
{
    public Transform target;  // 目標物
    private NavMeshAgent agent;

    void Start()
    {
        // NavMeshAgentコンポーネント取得
        agent = GetComponent<NavMeshAgent>();

        if (agent == null)
        {
            Debug.LogError("NavMeshAgentがアタッチされていません！");
        }
    }

    void Update()
    {
        if (target == null || agent == null) return;

        // 目標位置をNavMeshAgentにセット
        agent.SetDestination(target.position);
        // 到着判定
        if (!agent.pathPending) // 経路計算中でない
        {
            // remainingDistance が stoppingDistance 以下で速度がほぼゼロ
            if (agent.remainingDistance <= agent.stoppingDistance && !agent.hasPath)
            {
                // ここに到着時の処理を書く
                StartCoroutine(faive());
            }
        }
    }
    IEnumerator faive()
    {
        yield return new WaitForSeconds(3f);
        ShimoSceneManager.Instance.TitleSceneLoad();
    }
}
