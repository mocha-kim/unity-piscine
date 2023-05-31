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

    private readonly int _maxIndex = 5;
    private int _stageIndex = 1;

    private GameObject _camera;
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
        
        Initialize();
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
            Initialize();
        }
    }

    public void BreakPlayerExit(string name)
    {
        _exitCount--;
    }

    public void GameOver()
    {
        Debug.Log("Game Over");
        _camera.GetComponent<CameraMove>().StopMove();
        _playerGroup.SetActive(false);
    }

    public void StopCamera() => _camera.GetComponent<CameraMove>().StopMove();

    #endregion

    #region Private Methods

    private void Initialize()
    {
        _camera = GameObject.Find("Main Camera");
        _playerGroup = GameObject.FindWithTag("PlayerGroup");
        _exitCount = 0;
        _totalCount = _playerGroup.transform.childCount;
    }

    private void LoadNextStage()
    {
        _stageIndex++;
        _stageIndex = _stageIndex % (_maxIndex - 1) + 1;
        SceneManager.LoadScene("Stage" + _stageIndex);
        Initialize();
    }

    #endregion
}
