using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class DifficultyTextUI : MonoBehaviour
{
    public Difficulty difficulty;
    TextMeshProUGUI text;
    private void Start()
    {
        text = GetComponent<TextMeshProUGUI>();
    }
    void Update()
    {
        if (difficulty.difficulty == 2) text.text = "Current difficulty is easy";
        if (difficulty.difficulty == 1) text.text = "Current difficulty is normal";
        if (difficulty.difficulty == 0) text.text = "Current difficulty is hard";
    }
}