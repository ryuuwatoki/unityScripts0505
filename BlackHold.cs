using UnityEngine;

public class BlackHold : MonoBehaviour
{
    // 旋轉速度（每秒幾圈），可在Inspector調整
    [SerializeField]
    private float rotationSpeed = 1f; // 預設每秒1圈

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // 每秒360度 * 旋轉速度
        transform.Rotate(0, 0, 360f * rotationSpeed * Time.deltaTime);
    }
}
