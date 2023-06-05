using UnityEngine;
using UnityEngine.UI;

namespace Module04.StateMachine.Player
{
    public class PlayerRespawnState : State<Module04.Player>
    {
        private int _isDeadId;

        private bool _isRevived;
        private float _elapsedTime = 0f;
        private readonly float _fadeTime = 1f;
        private readonly float _delayTime = 1f;
        
        private Image _blackPanel;
        private Color _color = new Color(0f, 0f, 0f, 0f);

        public override void OnInit()
        {
            _isDeadId = Animator.StringToHash("isDead");
            _blackPanel = GameObject.FindWithTag("Canvas").transform.GetChild(0).GetComponent<Image>();
        }

        public override void OnEnter()
        {
            _context.Init();
            _isRevived = false;
            
            _elapsedTime = 0f;
            _color = Color.black;
            _blackPanel.color = _color;
            _blackPanel.gameObject.SetActive(true);
        }

        public override void Update()
        {
            _elapsedTime += Time.deltaTime;
            if (_elapsedTime < _delayTime) return;

            if (!_isRevived)
            {
                _isRevived = true;
                _context.animator.SetBool(_isDeadId, false);
                _context.PlayOneShot(EffectClip.Respawn);
            }
            
            _color.a -= _fadeTime * Time.deltaTime;
            _blackPanel.color = _color;
            if (_color.a <= 0f)
            {
                _blackPanel.gameObject.SetActive(false);
                _stateMachine.ChangeState<PlayerIdleState>();
                GameManager.Instance.IsGameOver = false;
            }
        }
    }
}