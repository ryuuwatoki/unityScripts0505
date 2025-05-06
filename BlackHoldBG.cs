using UnityEngine;

public class BlackHoldBG : MonoBehaviour
{
    // 幾秒轉一圈（可在Inspector調整）
    public float secondsPerRotation = 5f;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // 每秒旋轉的角度
        float rotationSpeed = 360f / secondsPerRotation;
        transform.Rotate(0, 0, rotationSpeed * Time.deltaTime);
    }
}
