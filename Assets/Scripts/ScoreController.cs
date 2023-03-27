using UnityEngine;
using UnityEngine.UI;

public class ScoreController : MonoBehaviour
{

    private int _score = 0;
    [SerializeField] private Text _scoreText;

    public static ScoreController Instance;

    private void Awake(){

        if(Instance == null){
            Instance = this;
        }else{
            Destroy(this);
        }

    }

    private void Start(){

        _scoreText.text = _score.ToString();

    }
    
    public void IncrementScore(){

        _score++;
        _scoreText.text = _score.ToString();

    }

}
