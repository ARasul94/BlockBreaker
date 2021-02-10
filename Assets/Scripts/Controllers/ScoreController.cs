using TMPro;
using UnityEngine;

namespace Controllers
{
    public class ScoreController : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI scoreTextfield;

        private void Start()
        {
            UpdateDisplayedScore(0);
        }

        public void UpdateDisplayedScore(int score)
        {
            scoreTextfield.text = score.ToString();
        }
    }
}
