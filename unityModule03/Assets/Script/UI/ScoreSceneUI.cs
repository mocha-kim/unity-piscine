using System;
using System.Collections;
using System.Collections.Generic;
using Module02;
using TMPro;
using UnityEngine;

public class ScoreSceneUI : MonoBehaviour
{
    private string[] _rankString = { "F", "B", "A", "S" };
    private GameObject _killedSection;
    private GameObject _hpSection;
    private GameObject _rankSection;
    
    private GameObject _retryButton;
    private GameObject _nextButton;

    private void Awake()
    {
        var scoreSection = transform.GetChild(0);
        _killedSection = scoreSection.GetChild(0).gameObject;
        _hpSection = scoreSection.GetChild(1).gameObject;
        _rankSection = scoreSection.GetChild(2).gameObject;
        
        _retryButton = transform.GetChild(1).gameObject;
        _nextButton = transform.GetChild(2).gameObject;
    }

    private void Start()
    {
        var killCount = 0;
        var remainedHp = 0f;
        _killedSection.transform.GetChild(1).GetComponent<TextMeshProUGUI>().text = killCount.ToString("N0");
        _hpSection.transform.GetChild(1).GetComponent<TextMeshProUGUI>().text = remainedHp.ToString("F0");
        
        _rankSection.transform.GetChild(1).GetComponent<TextMeshProUGUI>().text = GetRank(killCount, remainedHp);
    }

    private string GetRank(int killCount, float hp)
    {
        var rankIndex = 0;
        rankIndex += killCount > GameManager.Instance.KillCount ? 1 : 0;
        rankIndex += hp >= 5 ? 1 : 0;
        rankIndex += hp >= 3 ? 1 : 0;
        return _rankString[rankIndex];
    }

    public void OnClickRetry()
    {
        
    }

    public void OnClickNext()
    {
        
    }
}
