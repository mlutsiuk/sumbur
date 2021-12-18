using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombPlant : MonoBehaviour
{
    public GameObject bombPrefab;
    private Rigidbody2D rb;
    private bool isPlanted = false;
    
    
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    
    void PlantBomb()
    {
        Instantiate(bombPrefab, rb.position, Quaternion.identity);
    }
    
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.B) && !isPlanted)
        {
            PlantBomb();
            isPlanted = true;
        } else if (Input.GetKeyUp(KeyCode.B))
        {
            isPlanted = false;
        }
    }
}
