using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;

public class SnakeController : MonoBehaviour
{

    [SerializeField] private Transform _segmentPrefab;
    private float _timeForStart = .3f;
    [SerializeField] private float _timeForMove = .15f;

    private Rigidbody2D _rb; 
    private Vector3 _snakeDir = Vector2.left; // move left by deafult

    private List<Transform> _segments = new List<Transform>();

    private void Start(){
        
        _rb = GetComponent<Rigidbody2D>();
        
        _segments.Add(this.transform);
    
    }

    private void Update(){
    
        GetInput();
        Move();
    
    }

    private void GetInput(){

        if(Input.GetKeyDown(KeyCode.W)){
            _snakeDir = Vector2.up;
        }else if(Input.GetKeyDown(KeyCode.A)){
            _snakeDir = Vector2.left;
        }else if(Input.GetKeyDown(KeyCode.D)){
            _snakeDir = Vector2.right;
        }else if(Input.GetKeyDown(KeyCode.S)){
            _snakeDir = Vector2.down;
        }

    }

    private void Move(){

        if(Time.timeSinceLevelLoad >= _timeForStart){

            for(int i = _segments.Count - 1; i > 0; i--){
                _segments[i].position = _segments[i-1].position;
            }

            Vector3 targetPos = new Vector3(Mathf.Round(this.transform.position.x) + _snakeDir.x,
                                            Mathf.Round(this.transform.position.y) + _snakeDir.y, 
                                            0.0f);
            
            this.transform.position = targetPos;

            _timeForStart = Time.timeSinceLevelLoad + _timeForMove;
        }
        
    }

    private void OnTriggerEnter2D(Collider2D col){

        if(col.name == "food"){

            Vector3 spawnPoint;

            if(_segments.Count >= 2){
                spawnPoint = _segments[_segments.Count-1].position - (_segments[_segments.Count-2].position - _segments[_segments.Count-1].position);
            }else{
                spawnPoint = transform.position-_snakeDir;
            }

            Transform segment = Instantiate(_segmentPrefab, 
                                            spawnPoint, 
                                            Quaternion.identity);
            
            _segments.Add(segment);
            
        }else{

            SceneManager.LoadScene(0);
        }
    }
}