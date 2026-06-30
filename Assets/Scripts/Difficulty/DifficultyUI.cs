using UnityEngine;

public class DifficultyUI : MonoBehaviour
{
    public Difficulty difficulty;
    public int difficultyAmount;
    public void OnButtonPress()
    {
        difficulty.difficulty = difficultyAmount;
    }
}