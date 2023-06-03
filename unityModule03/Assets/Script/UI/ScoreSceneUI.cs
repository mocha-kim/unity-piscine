using System;
using System.Collections;
using System.Collections.Generic;
using Module02;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ScoreSceneUI : MonoBehaviour
{
    private readonly string[] _rankString = { "F", "B", "A", "S" };
    [SerializeField] private Sprite[] titles;
    
    private GameObject _killedSection;
    private GameObject _hpSection;
    private GameObject _rankSection;
    
    private GameObject _retryButton;
    private GameObject _nextButton;

    private GameObject _title;

    private void Awake()
    {
        var scoreSection = transform.GetChild(0);
        _killedSection = scoreSection.GetChild(0).gameObject;
        _hpSection = scoreSection.GetChild(1).gameObject;
        _rankSection = scoreSection.GetChild(2).gameObject;
        
        _retryButton = transform.GetChild(1).gameObject;
        _nextButton = transform.GetChild(2).gameObject;
        _title = transform.GetChild(3).gameObject;
    }

    private void Start()
    {
        _title.GetComponent<Image>().sprite = GameManager.Instance.IsMapClear ? titles[0] : titles[1];
        
        if (GameManager.Instance.IsMapClear)
        {
            _retryButton.SetActive(false);
            _nextButton.SetActive(true);
        }
        else
        {
            _retryButton.SetActive(true);
            _nextButton.SetActive(false);
        }
        
        var killCount = GameManager.Instance.KillCount;
        var remainedHp = GameManager.Instance.HP;
        _killedSection.transform.GetChild(1).GetComponent<TextMeshProUGUI>().text = killCount.ToString("N0");
        _hpSection.transform.GetChild(1).GetComponent<TextMeshProUGUI>().text = remainedHp.ToString("F0");
        
        _rankSection.transform.GetChild(1).GetComponent<TextMeshProUGUI>().text = GetRank(killCount, remainedHp);
    }

    private string GetRank(int killCount, float hp)
    {
        var rankIndex = 0;
        rankIndex += killCount >= GameManager.Instance.KillCount ? 1 : 0;
        rankIndex += hp >= 5 ? 1 : 0;
        rankIndex += hp >= 3 ? 1 : 0;
        return _rankString[rankIndex];
    }

    public void OnClickRetry()
    {
        GameManager.Instance.Init();
        SceneManager.LoadScene("map0" + GameManager.Instance.MapIndex);
    }

    public void OnClickNext()
    {
        if (GameManager.Instance.MapIndex == 0)
        {
            SceneManager.LoadScene("Ending");
            return;
        }
        GameManager.Instance.Init();
        SceneManager.LoadScene("map0" + GameManager.Instance.MapIndex);
    }
}
