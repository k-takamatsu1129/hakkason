using UnityEngine;
using UnityEngine.InputSystem; // これが必要

public class TruckInputHandler : MonoBehaviour
{
    // インスペクターから操作を割り当てるための変数
    public InputActionProperty accelerateAction;
    public InputActionProperty brakeAction;

    [HideInInspector] public float accelerationValue;
    [HideInInspector] public float brakeValue;

    void Update()
    {
        // 右トリガーの押し込み具合を取得 (0.0 ～ 1.0)
        accelerationValue = accelerateAction.action.ReadValue<float>();

        // 左トリガーの押し込み具合を取得 (0.0 ～ 1.0)
        brakeValue = brakeAction.action.ReadValue<float>();
    }


}