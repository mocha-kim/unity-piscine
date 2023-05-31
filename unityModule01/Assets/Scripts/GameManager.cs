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

    private readonly int _maxIndex = 3;
    private int _stageIndex = 3;

    private GameObject _playerGroup;
    private int _totalCount;
    private int _exitCount;

    [SerializeField] private Material blue;
    [SerializeField] private Material yellow;
    [SerializeField] private Material red;
    private Dictionary<Color, Material> _colorDictionary = new ();

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
        _colorDictionary[Color.Blue] = blue;
        _colorDictionary[Color.Yellow] = yellow;
        _colorDictionary[Color.Red] = red;
    }

    #endregion

    #region Public Methods

    public Material GetMaterial(Color color) => _colorDictionary[color];

    public int GetLayer(Color color)
    {
        switch (color)
        {
            case Color.Blue:
                return 7;
            case Color.Yellow:
                return 9;
            case Color.Red:
                return 11;
            case Color.Default:
            default:
                return 0;
        }
    }
    
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
