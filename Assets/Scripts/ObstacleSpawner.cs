using System.Collections;
using System.Collections.Generic;
using System.IO.Pipes;
using Unity.VisualScripting;
using UnityEngine;

public class ObstacleSpawner : MonoBehaviour
{
    public List<GameObject> obstacles;
    private float coolDown = 2f;
    void Update()
    {
        GameManager gm = GameManager.Instance;
        
        if (gm.gameEnded){
            return;
        }

        coolDown -= Time.deltaTime;
        if (coolDown <=0) {
            coolDown = gm.intervalGenerationObstacle;
            Generate();
        }
    }

    void Generate(){
        GameManager gm = GameManager.Instance;
        GameObject pipe = obstacles[0];
        float xPos = gm.offsetX;
        float yPos = Random.Range(gm.offsetY[0], gm.offsetY[1]);
        float zPos = gm.offsetZ;
        Vector3 pos = new Vector3(xPos, yPos, zPos);
        Quaternion q = new Quaternion(0,0,0,0);
        Instantiate(pipe, pos, q);
    }
}
