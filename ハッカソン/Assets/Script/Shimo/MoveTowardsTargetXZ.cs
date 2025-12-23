using System.Collections;
using UnityEngine;

public class MoveTowardsTargetXZ : MonoBehaviour
{
    // Inspectorで設定する目標物
    public Transform target;

    // 移動速度
    public float speed = 7f;
    bool first = false;

    void Update()
    {
        if (target == null) return;
        if (!first && (transform.position.y < ShimoDB.Instance.getkoudo()))
        {
            Vector3 posi = transform.position;
            posi.y += speed * Time.deltaTime;
            transform.position = posi;
        }
        else
        {
            first = true;

            // 現在位置
            Vector3 currentPosition = transform.position;

            // 目標位置（y軸はそのまま保持）
            Vector3 targetPosition = new Vector3(target.position.x, currentPosition.y, target.position.z);

            // 移動方向を計算
            Vector3 direction = (targetPosition - currentPosition).normalized;

            // 移動量を計算
            Vector3 move = direction * speed * Time.deltaTime;

            // 目標を超えないようにClamp
            if (move.magnitude > Vector3.Distance(currentPosition, targetPosition))
            {
                move = targetPosition - currentPosition;
            }

            // 移動
            transform.position += move;

            // オプション：移動方向に向けて回転させる
            if (direction != Vector3.zero)
            {
                Quaternion targetRotation = Quaternion.LookRotation(direction);
                transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, 2 * Time.deltaTime);
            }

            if(move == Vector3.zero)
            {
                if (transform.position.y > -4.768372e-07)
                {
                    Vector3 posi = transform.position;
                    posi.y -= speed * Time.deltaTime;
                    transform.position = posi;
                }
                else
                {
                    StartCoroutine(faive());
                }
            }
        }
    }
    IEnumerator faive()
    {
        yield return new WaitForSeconds(3f);
        ShimoSceneManager.Instance.TitleSceneLoad();
    }
}
