using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;

public class BirdController : MonoBehaviour
{
    public float jumpForce = 8f;
    private float coolDown = 0f;
    private float jumpInterval = 0.5f;
    private Rigidbody thisRigidBody;
    void Start()
    {
        thisRigidBody = GetComponent<Rigidbody>();
    }

    void Update()
    {
        coolDown -= Time.deltaTime;
        if (GameManager.Instance.gameEnded){
            thisRigidBody.isKinematic = true;
            return;
        }
        bool canJump = coolDown <= 0;
        if (canJump) {
            bool jumped = Input.GetKey(KeyCode.Space) | Input.GetKey(KeyCode.Mouse0);
            if (jumped) {
                coolDown = jumpInterval;
                Jump();
            }
        }
    }

    void OnCollisionEnter(Collision other){
        LogicGame(other.gameObject);
    }
    void OnTriggerEnter(Collider other){
        LogicGame(other.gameObject);
    }

    private void LogicGame (GameObject go_other) {
        bool isPoint = go_other.CompareTag("Point") && !GameManager.Instance.gameEnded;
        if (isPoint) {
            GameManager.Instance.score += 1;
            Debug.Log("Your score: "+GameManager.Instance.score);
        } else {
            GameManager.Instance.EndGame();
        }
    }

    void Jump(){
        thisRigidBody.velocity = Vector3.zero;
        thisRigidBody.AddForce(new Vector3(0,jumpForce,0), ForceMode.Impulse);
    }
}
