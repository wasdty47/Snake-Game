using UnityEngine;

public class Food : MonoBehaviour
{

    private Rigidbody2D rb;

    private void Start(){

        rb = GetComponent<Rigidbody2D>();
        RandomizePos();

    }

    private void RandomizePos(){

        float x = Random.Range(-13f, 13f);
        float y = Random.Range(-7f, 7f);

        rb.position = new Vector2(Mathf.Round(x), Mathf.Round(y));
    }

    private void OnTriggerEnter2D(){
        RandomizePos();
    }

}
