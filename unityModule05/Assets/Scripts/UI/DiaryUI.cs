using System;
using System.Collections;
using System.Collections.Generic;
using Module04;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class DiaryUI : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _pointText;
    [SerializeField] private TextMeshProUGUI _deathText;
    
    [SerializeField] private GameObject _stageSection;
    [SerializeField] private Sprite _unlockedSprite;
    private List<GameObject> _stages = new ();

    private int _unlockIndex;

    private void Awake()
    {
        for (int i = 1; i < _stageSection.transform.childCount - 1; i++)
        {
            _stages.Add(_stageSection.transform.GetChild(i).gameObject);
        }
    }

    private void Start()
    {
        _pointText.text = PlayerPrefs.GetInt("Points", 0).ToString();
        _deathText.text = PlayerPrefs.GetInt("Death", 0).ToString();

        _unlockIndex = PlayerPrefs.GetInt("Unlock", 0);
        for (int i = 0; i <= _unlockIndex; i++)
        {
            var image = _stages[i].transform.GetChild(0).GetComponent<Image>();
            image.sprite = _unlockedSprite;
            image.color = Color.white;
        }
    }

    public void OnClickStage(int index)
    {
        if (index > _unlockIndex) return;
        GameManager.Instance.LoadStage(index);
    }

    public void OnClickBackToTitle()
    {
        SceneManager.LoadScene("MainMenu");
    }
}
