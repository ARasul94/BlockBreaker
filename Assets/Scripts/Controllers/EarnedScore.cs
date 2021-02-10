using TMPro;
using UnityEngine;

namespace Controllers
{
    public class EarnedScore : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI earnedField;

        public void SetValue(int value)
        {
            earnedField.text = "+" + value;
        
            Destroy(gameObject, 1);
        }
    }
}
