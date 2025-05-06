using UnityEngine;
using System;

public class BlackHold : MonoBehaviour
{
    [Header("旋轉速度")]
    [SerializeField] private float rotationSpeed = 1f;

    [Header("移動速度範圍")]
    public float minMoveSpeed = 1f;
    public float maxMoveSpeed = 5f;

    [Header("壽命範圍")]
    public float minLifeTime = 1f;
    public float maxLifeTime = 5f;

    [Header("重生區域（請指定遊戲區域的 Collider2D）")]
    public Collider2D respawnArea;

    [Header("重生區外圍距離")]
    [SerializeField] public float spawnOffset = 1.0f;

    private float moveSpeed;
    private Vector2 moveDir;
    private float lifeTime;
    private float timer;

    public Action OnDestroyed;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        ResetBlackHold();
    }

    void ResetBlackHold()
    {
        if (respawnArea == null)
        {
            Debug.LogWarning("請在 Inspector 指定 respawnArea！");
            return;
        }
        var bounds = respawnArea.bounds;
        float offset = spawnOffset;
        int side = UnityEngine.Random.Range(0, 4); // 0:上 1:下 2:左 3:右
        Vector2 pos = Vector2.zero;
        Vector2 dirToCenter = Vector2.zero;
        switch (side)
        {
            case 0: // 上
                pos = new Vector2(
                    UnityEngine.Random.Range(bounds.min.x, bounds.max.x),
                    bounds.max.y + offset
                );
                dirToCenter = Vector2.down;
                break;
            case 1: // 下
                pos = new Vector2(
                    UnityEngine.Random.Range(bounds.min.x, bounds.max.x),
                    bounds.min.y - offset
                );
                dirToCenter = Vector2.up;
                break;
            case 2: // 左
                pos = new Vector2(
                    bounds.min.x - offset,
                    UnityEngine.Random.Range(bounds.min.y, bounds.max.y)
                );
                dirToCenter = Vector2.right;
                break;
            case 3: // 右
                pos = new Vector2(
                    bounds.max.x + offset,
                    UnityEngine.Random.Range(bounds.min.y, bounds.max.y)
                );
                dirToCenter = Vector2.left;
                break;
        }
        transform.position = pos;
        // 方向稍微有點隨機性
        float angleOffset = UnityEngine.Random.Range(-30f, 30f);
        float angle = Mathf.Atan2(dirToCenter.y, dirToCenter.x) * Mathf.Rad2Deg + angleOffset;
        float rad = angle * Mathf.Deg2Rad;
        moveDir = new Vector2(Mathf.Cos(rad), Mathf.Sin(rad)).normalized;
        moveSpeed = UnityEngine.Random.Range(minMoveSpeed, maxMoveSpeed);
        lifeTime = UnityEngine.Random.Range(minLifeTime, maxLifeTime);
        timer = 0f;
    }

    // Update is called once per frame
    void Update()
    {
        if (!GameManager.playerHasMoved) return;
        transform.Rotate(0, 0, 360f * rotationSpeed * Time.deltaTime);
        transform.Translate(moveDir * moveSpeed * Time.deltaTime, Space.World);

        timer += Time.deltaTime;
        if (timer >= lifeTime)
        {
            OnDestroyed?.Invoke();
            ResetBlackHold();
        }
    }
}
