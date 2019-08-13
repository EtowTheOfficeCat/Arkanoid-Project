using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ScoreCounter : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI scoreText;
    [SerializeField] private TextMeshProUGUI numShipText;
    private void Start()
    {
        Game.ScoreChanged += OnScoreChanged;
        Game.NumShipChanged += OnNumShipChanged;
    }

    private void OnScoreChanged(int score)
    {
        scoreText.text = score.ToString();
    }

    private void OnNumShipChanged(int numShip)
    {
        numShipText.text = numShip.ToString();
    }
}
