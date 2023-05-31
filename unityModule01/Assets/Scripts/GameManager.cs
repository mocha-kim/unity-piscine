using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Color = Module01.Interaction.Color;

public class GameManager : MonoBehaviour
{
    #region Variables & Properties

    private static GameManager _instance;
    public static GameManager Instance => _instance;

    private readonly int _maxIndex = 4;
    private int _stageIndex = 4;

    private GameObject _playerGroup;
    private int _totalCount;
    private int _exitCount;

    private bool IsAllExited => _exitCount >= _totalCount;
    public GameObject PlayerGroup => _playerGroup;

    #endregion

    #region MonoBehaviour Methods

    private void Awake()
    {
        if (_instance == null)
        {
            _instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
        
        InitExitState();
    }

    #endregion

    #region Public Methods

    public void AlignPlayerExit(string name)
    {
        _exitCount++;
        if (IsAllExited)
        {
            Debug.Log("Stage " + _stageIndex + " Clear!");

            LoadNextStage();
            InitExitState();
        }
    }

    public void BreakPlayerExit(string name)
    {
        _exitCount--;
    }

    #endregion

    #region Private Methods

    private void InitExitState()
    {
        _playerGroup = GameObject.FindWithTag("PlayerGroup");
        _exitCount = 0;
        _totalCount = _playerGroup.transform.childCount;
    }

    private void LoadNextStage()
    {
        _stageIndex++;
        _stageIndex = _stageIndex % (_maxIndex - 1) + 1;
        SceneManager.LoadScene("Stage" + _stageIndex);
    }

    #endregion
}
