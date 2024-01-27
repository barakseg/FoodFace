using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FoodBehaviour : MonoBehaviour
{
    public float moveSpeed = 0f;
    public bool isDropped = false;
    public string keyCode = "";
    string[] sprites = { "cheese", "cucumber", "hamburger", "tomato"};

    public Vector3 initialPos;

    // Start is called before the first frame update
    void Start()
    {
        initialPos = transform.position;
    }

    private void drop() {
        Rigidbody2D rb = GetComponent<Rigidbody2D>();
        rb.gravityScale = 1f;
        isDropped = true;
        StartCoroutine(DelayedClone());
    }

    // Update is called once per frame
    void Update()
    {
        if (isDropped) {
            transform.Translate(Vector3.right * moveSpeed * Time.deltaTime);
            return;
        }
        if (keyCode == "Q" && Input.GetKeyDown(KeyCode.Q))
        {
            drop();    
        }
        if (keyCode == "W" && Input.GetKeyDown(KeyCode.W))
        {
            drop();    
        }
        if (keyCode == "E" && Input.GetKeyDown(KeyCode.E))
        {
            drop();    
        }
        if (keyCode == "R" && Input.GetKeyDown(KeyCode.R))
        {
            drop();    
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        moveSpeed = 2f;
    }

    IEnumerator DelayedClone()
    {
        yield return new WaitForSeconds(5f);
        GameObject clone = Instantiate(gameObject, initialPos, transform.rotation);
        clone.GetComponent<FoodBehaviour>().isDropped = false;
        clone.GetComponent<FoodBehaviour>().moveSpeed = 0f;
        clone.GetComponent<Rigidbody2D>().gravityScale = 0f;
        clone.GetComponent<SpriteRenderer>().sprite =  Resources.Load<Sprite>(sprites[Random.Range(0, sprites.Length)]);
    }
}