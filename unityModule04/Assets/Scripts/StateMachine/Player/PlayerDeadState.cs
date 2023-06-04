using UnityEngine;
using UnityEngine.UI;

namespace Module04.StateMachine.Player
{
    public class PlayerDeadState : State<Module04.Player>
    {
        private int _isDeadId;

        private float _elapsedTime = 0f;
        private readonly float _fadeTime = 1f;
        private readonly float _delayTime = 1f;
        
        private Image _blackPanel;
        private Color _color;
        
        public override void OnInit()
        {
            _isDeadId = Animator.StringToHash("isDead");
            _blackPanel = GameObject.FindWithTag("Canvas").transform.GetChild(0).GetComponent<Image>();
        }

        public override void OnEnter()
        {
            _context.PlayOneShot(EffectClip.Dead);
            _context.animator.SetBool(_isDeadId, true);
            GameManager.Instance.IsGameOver = true;

            _elapsedTime = 0f;
            _color = Color.clear;
            _blackPanel.color = _color;
            _blackPanel.gameObject.SetActive(true);
        }

        public override void Update()
        {
            _elapsedTime += Time.deltaTime;
            if (_elapsedTime < _delayTime) return;

            _color.a += _fadeTime * Time.deltaTime;
            _blackPanel.color = _color;
            if (_color.a >= 1f)
            {
                _stateMachine.ChangeState<PlayerRespawnState>();
            }
        }
    }
}