using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLivesHandler : MonoBehaviour
{
    public int lives = 3;
    public GameObject lifeObj;
    
    // Start is called before the first frame update
    void Start()
    {
        EventHandler.ReducePlayerLives += OnReducePlayerLives;
        
        DrawLives();
    }

    private void OnReducePlayerLives()
    {
        lives--;
        DrawLives();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void DrawLives()
    {
        foreach (Transform child in gameObject.transform)
        {
            Destroy(child.gameObject);
        }
        
        for (int i = 0; i < lives; i++)
        {
            var obj = Instantiate(lifeObj, transform.position, Quaternion.identity);
            obj.transform.SetParent(gameObject.transform);
            obj.transform.position = i * 1.25f *  Vector3.right + obj.transform.parent.transform.position;
        }
    }
}
