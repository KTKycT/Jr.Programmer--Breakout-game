using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;
#if UNITY_EDITOR
using UnityEditor;
#endif

[DefaultExecutionOrder(1000)]
public class MenuUI : MonoBehaviour
{
    public InputField nickPlaceHolder;
    public TextMeshProUGUI hightScoreText;

    private void Awake()
    {
        hightScoreText.SetText("CURRET HIGHT SCORE: \n" + GameManager.Instance.BestScoreNick + " - " + GameManager.Instance.BestScoreInt);
    }

    //Update NickName after input in place holder
    public void UpdateNickName()
    {
        GameManager.Instance.NickName = nickPlaceHolder.text;
    }
    //Start new game
    public void StartGame()
    {
        SceneManager.LoadScene(1);
    }
    // Quit from game
    public void QuitGame()
    {
#if UNITY_EDITOR
        EditorApplication.ExitPlaymode();
#else
        Application.Quit();
#endif
    }

}
