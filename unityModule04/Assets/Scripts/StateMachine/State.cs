namespace Module04.StateMachine
{
    public abstract class State<T>
    {
        protected T _context;
        protected StateMachine<T> _stateMachine;

        internal void InitState(T context, StateMachine<T> stateMachine)
        {
            _context = context;
            _stateMachine = stateMachine;
        
            OnInit();
        }

        public virtual void OnInit()
        {}
    
        public virtual void OnEnter()
        {}
    
        public abstract void Update();

        public abstract void FixedUpdate();

        public virtual void OnExit()
        {}
    }
}
