using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameSession : MonoBehaviour
{
    // Start is called before the first frame update
    [Range(0, 10f)] [SerializeField] float gameSpeed = 1f;
    [SerializeField] TextMeshProUGUI scoreText;
    //state vars
    [SerializeField] int currentScore = 0;
    [SerializeField] int scorePerBlockDestroyed = 10; 
    [SerializeField] bool isAutoPlayEnabled;



    private void Awake(){

            int gameStatusCount = FindObjectsOfType<GameSession>().Length;

            if (gameStatusCount > 1){

                gameObject.SetActive(false);
                Destroy(gameObject);
            }else{
                DontDestroyOnLoad(gameObject);
                
            }

    }

    void Start()
    {
        scoreText.text = currentScore.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        Time.timeScale = gameSpeed;
    }


    public void AddToScore(){
        currentScore += scorePerBlockDestroyed;
        scoreText.text = currentScore.ToString();
    }

    public void ResetScore(){
        //currentScore = 0;
        Destroy(gameObject);
    }

    public bool IsAutoPlayEnabled(){
        return isAutoPlayEnabled;
    }

}
