using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance {get; private set;}
    public float offsetX = 15f;
    public Vector2 offsetY = new Vector2(-2f, 1.5f);
    public float speedObstacle = 3.5f;
    public float intervalGenerationObstacle = 2.5f;
    public float delayRestart = 5f;
    [HideInInspector] public float offsetZ = -0.1f;
    [HideInInspector] public int score = 0;
    [HideInInspector] public bool gameEnded = false;
    void Awake(){
        if ( Instance != null && Instance != this) {
            Destroy(this);
        } else {
            Instance = this;
        }
    }

    public void EndGame() {
        Debug.Log("GAME OVER X.X ###### Your final Score: "+score);
        gameEnded = true;
        StartCoroutine(ReloadScene(delayRestart));
    }

    private IEnumerator ReloadScene(float delay){
        yield return new WaitForSeconds(delay);
        string sceneName = SceneManager.GetActiveScene().name;
        SceneManager.LoadScene(sceneName);
    }
}
