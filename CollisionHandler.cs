using UnityEngine;

public class CollisionHandler : MonoBehaviour
{
    public SoundManager soundManager;

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Food"))
        {
            soundManager.PlayGet();  // 播放獲得音效
        }
        else if (other.CompareTag("Obstacle"))
        {
            soundManager.StopGameBgm();  // 停止遊戲背景音
            soundManager.PlayBoom();     // 播放爆炸音效
        }
    }

    // 讓玩家重新開始播放背景音樂
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.LeftArrow) || Input.GetKeyDown(KeyCode.RightArrow) || Input.GetKeyDown(KeyCode.UpArrow) || Input.GetKeyDown(KeyCode.DownArrow))
        {
            soundManager.PlayGameBgm();
        }
    }
}
