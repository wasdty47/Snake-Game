using UnityEngine;
using System.Collections.Generic;
using UnityEngine.SceneManagement;

public class Snake : MonoBehaviour
{

    [SerializeField] private Transform segmentPrefab;

    private float timeForStart = .3f;
    [SerializeField] private float timeForMove = .3f;

    private Rigidbody2D rb; 
    private Vector2 snakeDir = Vector2.left; // move left by deafult

    private List<Transform> segments = new List<Transform>();

    private void Start(){
        
        rb = GetComponent<Rigidbody2D>();
        
        segments.Add(this.transform);
    
    }

    private void Update(){
    
        GetInput();
        Move();
    
    }

    private void GetInput(){

        if(Input.GetKeyDown(KeyCode.W)){
            snakeDir = Vector2.up;
        }else if(Input.GetKeyDown(KeyCode.A)){
            snakeDir = Vector2.left;
        }else if(Input.GetKeyDown(KeyCode.D)){
            snakeDir = Vector2.right;
        }else if(Input.GetKeyDown(KeyCode.S)){
            snakeDir = Vector2.down;
        }

    }

    private void Move(){

        if(Time.timeSinceLevelLoad >= timeForStart){

            for(int i = segments.Count - 1; i > 0; i--){
                segments[i].position = segments[i-1].position;
            }

            this.transform.position = new Vector3(Mathf.Round(this.transform.position.x) + snakeDir.x,
                                                  Mathf.Round(this.transform.position.y) + snakeDir.y, 
                                                  0.0f);

            timeForStart = Time.timeSinceLevelLoad + timeForMove;
        }
        
    }

    private void OnTriggerEnter2D(Collider2D col){

        if(col.name == "food"){

            Vector3 spawnPoint = new Vector3(segments[segments.Count-1].position.x, 
                                             segments[segments.Count-1].position.y, 
                                             transform.position.z) - (Vector3)snakeDir;

            Transform segment = Instantiate(segmentPrefab, 
                                            spawnPoint, 
                                            Quaternion.identity);
            
            segments.Add(segment);
            
        }else{

            SceneManager.LoadScene(0);

        }
    }


}
