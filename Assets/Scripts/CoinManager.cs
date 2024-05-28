using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinManager : MonoBehaviour
{

    Vector2 mindBounds;
    Vector2 maxBounds;
    // Start is called before the first frame update
    void Start()
    {
        InitBounds();
        Destroy(gameObject, 5f);
    }

    // Update is called once per frame
    void Update()
    {
        CoinInit();
    }

    void InitBounds()
    {
        Camera mainCamera = Camera.main;
        mindBounds = mainCamera.ViewportToWorldPoint(new Vector2(0, 0));
        maxBounds = mainCamera.ViewportToWorldPoint(new Vector2(1, 1));
    }

   void CoinInit()
    {
        Vector2 newPos = new Vector2();
        newPos.x = Mathf.Clamp(transform.position.x, mindBounds.x, maxBounds.x);
        newPos.y = Mathf.Clamp(transform.position.y,mindBounds.y + 2.5f, maxBounds.y);
        transform.position = newPos;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            Scorekeeper.instance.coin++;
            Destroy(gameObject);
        }
    }
}
