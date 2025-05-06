using UnityEngine;

public class MeteorPickup : MonoBehaviour
{
    public Collider2D MeteoriteArea;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        RandomMeteoritePosition();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        RandomMeteoritePosition();
    }



    // 隕石のランダムな出現位置を指定するための変数
    void RandomMeteoritePosition()
    {
        // テスト用のリスポーン範囲
        // var b = MeteoriteArea.bounds;
        // Debug.Log($"{b.min.x}, {b.max.x}, {b.min.y}, {b.max.y}");

        // 隕石のランダムな出現位置を指定する
        transform.position = new Vector2(
            Random.Range(MeteoriteArea.bounds.min.x, MeteoriteArea.bounds.max.x),
            Random.Range(MeteoriteArea.bounds.min.y, MeteoriteArea.bounds.max.y)
        );
    }

}
