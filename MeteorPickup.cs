using UnityEngine;

public class MeteorPickup : MonoBehaviour
{
    public Collider2D MeteoriteArea;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        // テスト用のリスポーン範囲
        // var b = MeteoriteArea.bounds;
        // Debug.Log($"{b.min.x}, {b.max.x}, {b.min.y}, {b.max.y}");
    }
}
