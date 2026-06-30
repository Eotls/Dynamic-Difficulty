using TMPro;
using UnityEngine;

public class RoundText : MonoBehaviour
{
    TextMeshProUGUI text;

    [SerializeField]

    Rounds rounds;

    private void Start()
    {
        text = GetComponent<TextMeshProUGUI>();
    }

    private void Update()
    {
        text.text = rounds.roundCounter.ToString();
    }
}
