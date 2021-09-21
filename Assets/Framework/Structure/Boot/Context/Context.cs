using System;
using Framework.Architecture.Pattern.DI;
using Framework.Architecture.Pattern.PubSub;

namespace Framework.Architecture.Base
{
    public class Context
    {
        private static Context _instance;
        public static Context Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new Context();
                }
                return _instance;
            }
        }

        protected PublishSubscribe _pubsub;
        protected DependencyInjection _inject;

        protected Context()
        {
            _pubsub = PublishSubscribe.Instance;
            _inject = DependencyInjection.Instance;
        }

        #region DI
        public void RegisterDependencies(Type type, object obj)
        {
            _inject.RegisterDependencies(type, obj);
        }

        public void UnregisterDependencies(Type type)
        {
            _inject.UnregisterDependencies(type);
        }

        public void InjectDependencies(object target)
        {
            _inject.InjectDependencies(target);
        }
        #endregion

        #region PubSub
        public void Publish<TMessage>(TMessage message)
        {
            _pubsub.Publish<TMessage>(message);
        }

        public void Subscribe<TMessage>(Action<TMessage> subscriber)
        {
            _pubsub.Subscribe(subscriber);
        }

        public void Unsubscribe<TMessage>(Action<TMessage> subscriber)
        {
            _pubsub.Unsubscribe(subscriber);
        }
        #endregion        
    }
}
