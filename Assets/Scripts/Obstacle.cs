using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle : MonoBehaviour
{
    void FixedUpdate()
    {
        GameManager gm = GameManager.Instance;
        
        if (gm.gameEnded){
            return;
        }

        float mov = gm.speedObstacle * Time.fixedDeltaTime;
        transform.position -= new Vector3(mov,0,0);
        if(transform.position.x <= -gm.offsetX) {
            Destroy(gameObject);
        }
        
    }
}
