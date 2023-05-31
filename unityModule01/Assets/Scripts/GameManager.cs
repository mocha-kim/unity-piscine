using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    #region Variables & Properties

    private static GameManager _instance;
    public static GameManager Instance => _instance;

    private readonly int _maxIndex = 1;
    private int _stageIndex = 1;

    [SerializeField] private int _totalCount;
    private int _exitCount;

    private bool IsAllExited => _exitCount >= _totalCount;

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
        _exitCount = 0;
        _totalCount = GameObject.FindWithTag("PlayerGroup").transform.childCount;
    }

    private void LoadNextStage()
    {
        SceneManager.LoadScene("Stage" + (_stageIndex % _maxIndex + 1));
        _stageIndex++;
    }

    #endregion
}
