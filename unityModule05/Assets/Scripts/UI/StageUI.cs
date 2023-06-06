using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

namespace Module04
{
    public class StageUI : MonoBehaviour
    {
        private TextMeshProUGUI _warningText;
        private Color _textColor;
        private float _fadeTime = 1f;
        
        [SerializeField] private TextMeshProUGUI _hpText;
        [SerializeField] private TextMeshProUGUI _pointText;

        private void Awake()
        {
            _warningText = transform.GetChild(0).GetComponent<TextMeshProUGUI>();
            _warningText.gameObject.SetActive(false);
        }

        private void Start()
        {
            GameManager.Instance.OnHPChanged += UpdateHPText;
            GameManager.Instance.OnLeafCollected += UpdatePointText;
            GameManager.Instance.OnPointNotEnough += DisplayWarningText;
            
            UpdateHPText(GameManager.Instance.PlayerHP);
            UpdatePointText(GameManager.Instance.CurrentPoint);
        }

        private void OnDestroy()
        {
            GameManager.Instance.OnHPChanged -= UpdateHPText;
            GameManager.Instance.OnLeafCollected -= UpdatePointText;
            GameManager.Instance.OnPointNotEnough -= DisplayWarningText;
        }
        
        public void OnClickBackToTitle() => SceneManager.LoadScene("MainMenu");
        public void OnClickDiary() => SceneManager.LoadScene("Diary");

        private void DisplayWarningText()
        {
            _warningText.gameObject.SetActive(true);
            StartCoroutine(TextDisappear());
        }

        IEnumerator TextDisappear()
        {
            _textColor = Color.black;
            while (_textColor.a >= 0f)
            {
                _textColor.a -= _fadeTime * Time.deltaTime;
                _warningText.color = _textColor;
                yield return null;
            }

            _warningText.gameObject.SetActive(false);
        }

        private void UpdateHPText(int value)
        {
            _hpText.text = value.ToString();
        }

        private void UpdatePointText(int value)
        {
            _pointText.text = value.ToString();
        }
    }
}