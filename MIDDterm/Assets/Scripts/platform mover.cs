using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class platformmover : MonoBehaviour
{
    public enum PlatformType { PingPongMovement, MoveByPlayerTouch , ControllBySwitch};
    public PlatformType platformType; 
    public float moveTime;
    public Vector2 endPosition;
    private Vector2 startPos, endPos;
    public LayerMask layerMask;

    // Start is called before the first frame update
    void Start()
    {
        startPos = transform.position;
        endPos = new Vector2(transform.position.x + endPosition.x, transform.position.y + endPosition.y);
        
        if (platformType == PlatformType.PingPongMovement)
        {
            PingPongMovement();
        }
      
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(layerMask == (layerMask | (1 << collision.gameObject.layer)))
        {
            collision.transform.SetParent(transform);
        }

          if (collision.CompareTag("Player") && platformType == PlatformType.MoveByPlayerTouch)
        {
            MoveToEndPosition();
        }
    }

     private void OnTriggerExit2D(Collider2D collision)
    {
        if(layerMask == (layerMask | (1 << collision.gameObject.layer)))
        {
            collision.transform.SetParent(null);
        }
        
        if (collision.CompareTag("Player") && platformType == PlatformType.MoveByPlayerTouch)
        {
            MoveToStartPosition();
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void PingPongMovement()
    {
        transform.LeanMove(endPos, moveTime).setLoopPingPong();
    }

    public void MoveToStartPosition()
    {
        LeanTween.cancel(gameObject);
        float distance = Vector2.Distance(transform.position, startPos);
        float duration = distance / moveTime;
        transform.LeanMove(startPos, duration);
    }

    public void MoveToEndPosition()
    {
        LeanTween.cancel(gameObject);
        float distance = Vector2.Distance(transform.position, endPos);
        float duration = distance / moveTime;
        transform.LeanMove(endPos, duration);
    }

    private void OnDrawGizmosSelected()
    { 
        SpriteRenderer spr = GetComponent<SpriteRenderer>();
        Vector2 pos = new Vector2(transform.position.x + endPosition.x, transform.position.y + endPosition.y);
        Gizmos.DrawWireCube(pos,spr.bounds.size);
    }
}
