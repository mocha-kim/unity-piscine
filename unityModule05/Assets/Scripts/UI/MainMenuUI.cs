using System.Collections;
using System.Collections.Generic;
using Module04;
using UnityEngine;

public class MainMenuUI : MonoBehaviour
{
    public void OnClickResume()
    {
        GameManager.Instance.LoadGame();
        GameManager.Instance.LoadStage(PlayerPrefs.GetInt("Played", 0));
    }
    
    public void OnClickNewGame()
    {
        GameManager.Instance.NewGame();
        GameManager.Instance.LoadStage(0);
    }

    public void OnClickDiary()
    {
        
    }
}
