using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

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
            _warningText = transform.GetChild(1).GetComponent<TextMeshProUGUI>();
            _warningText.gameObject.SetActive(false);
        }

        private void Start()
        {
            GameManager.Instance.OnHPChanged += UpdateHPText;
            GameManager.Instance.OnLeafCollected += UpdateCountText;
            GameManager.Instance.OnPointNotEnough += DisplayWarningText;
        }

        private void OnDestory()
        {
            GameManager.Instance.OnHPChanged -= UpdateHPText;
            GameManager.Instance.OnLeafCollected -= UpdateCountText;
            GameManager.Instance.OnPointNotEnough -= DisplayWarningText;
        }

        private void DisplayWarningText()
        {
            _warningText.gameObject.SetActive(true);
            StartCoroutine(TextDisapear());
        }

        IEnumerator TextDisapear()
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

        private void UpdateCountText(int value)
        {
            _pointText.text = value.ToString();
        }
    }
}