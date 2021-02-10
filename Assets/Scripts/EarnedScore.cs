using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class EarnedScore : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI earnedField;

    public void SetValue(int value)
    {
        earnedField.text = "+" + value;
        
        Destroy(gameObject, 1);
    }
}
