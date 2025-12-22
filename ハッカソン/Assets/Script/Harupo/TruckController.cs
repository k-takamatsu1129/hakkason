using UnityEngine;

public class TruckController : MonoBehaviour {
    public WheelCollider[] driveWheels; // 駆動輪
    public WheelCollider[] steerWheels; // 前輪
    public Transform steeringWheelVisual; // VR内のハンドルモデル
    
    public float maxTorque = 1500f;
    public float maxSteerAngle = 45f;

    void Update() {
        // ハンドルの回転角からステアリング値を計算 (-1.0 ～ 1.0)
        float steerInput = steeringWheelVisual.localEulerAngles.z; 
        if (steerInput > 180) steerInput -= 360f;
        float steering = (steerInput / 180f); 

        // コントローラーのトリガー入力取得（簡易例）
        float acceleration = Input.GetAxis("XRI_RightTrigger"); 

        foreach (var wheel in steerWheels) {
            wheel.steerAngle = steering * maxSteerAngle;
        }
        foreach (var wheel in driveWheels) {
            wheel.motorTorque = acceleration * maxTorque;
        }
    }
}