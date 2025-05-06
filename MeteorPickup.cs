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
        Debug.Log( MeteoriteArea.bounds.min.x );
        Debug.Log( MeteoriteArea.bounds.max.x );
        Debug.Log( MeteoriteArea.bounds.min.y );
        Debug.Log( MeteoriteArea.bounds.max.y );
    }
}
