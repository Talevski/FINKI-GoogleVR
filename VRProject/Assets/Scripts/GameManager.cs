using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance = null;
    private int score;

    // Start is called before the first frame update
    void Start()
    {
        if(instance == null){
            instance = this;
        }
        else if(instance != this){
            Destroy(gameObject);
        }
        DontDestroyOnLoad(gameObject);

        score = 0;
    }

    public void incrementScore(){
        score++;
    }

    public int getScore(){
        return score;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
