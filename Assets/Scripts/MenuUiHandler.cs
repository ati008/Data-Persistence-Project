using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuUiHandler : MonoBehaviour
{
  public Text highScore;
  private int score;
  public Text playerName;
  // Start is called before the first frame update
  void Start()
  {
    if (GameManager.Instance != null)
    {
      score = GameManager.Instance.highScore;
      playerName.text = GameManager.Instance.playerName;
    }
    highScore.text = $"HighScore: {score}";
  }

  public void StartNew()
  {
    GameManager.Instance.playerName = playerName.text;
    SceneManager.LoadScene(1);
  }

  public void Exit()
  {
    GameManager.Instance.Save();
#if UNITY_EDITOR
    EditorApplication.ExitPlaymode();
#else
    Application.Quit(); // original code to quit Unity player
#endif
  }
}
