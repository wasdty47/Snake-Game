using UnityEngine;
using UnityEngine.Events;

public class Food : MonoBehaviour
{

    public UnityEvent OnSnakeEat;

    private Rigidbody2D _rb;

    private void Start(){

        _rb = GetComponent<Rigidbody2D>();
        RandomizePos();

    }

    private void RandomizePos(){

        float x = Random.Range(-13f, 13f);
        float y = Random.Range(-7f, 7f);

        _rb.position = new Vector2(Mathf.Round(x), Mathf.Round(y));
    }

    private void OnTriggerEnter2D(){
        OnSnakeEat?.Invoke();
        RandomizePos();
    }

}
