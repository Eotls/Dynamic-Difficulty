using UnityEditor.SceneManagement;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelStart : MonoBehaviour
{
    public void GameStart()
    {
        SceneManager.LoadScene(1);
    }
   
    
}
