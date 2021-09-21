using System.Collections;
using Framework.Architecture.Pattern.MVC;

namespace Framework.Architecture.Base
{
    public abstract class GroupController<TController> : BaseController<TController>
    where TController : GroupController<TController>
    {
        protected IController[] _subControllers;

        public override IEnumerator Initialize()
        {
            yield return InitializeSystem();
            Context.Instance.RegisterDependencies(typeof(TController), this);
            yield return InitSubControllers();
        }

        public override IEnumerator Finalize()
        {
            InjectDependencies(this);
            yield return FinalizeSubControllers();
            yield return FinalizeSystem();
        }

        protected virtual IEnumerator InitializeSystem()
        {
            yield return null;
        }

        protected virtual IEnumerator FinalizeSystem()
        {
            yield return null;
        }

        protected virtual IEnumerator InitSubControllers()
        {
            _subControllers = GetSubControllers();

            if (_subControllers != null)
            {
                int count = _subControllers.Length;
                for (int i = 0; i < count; i++)
                {
                    yield return _subControllers[i].Initialize();
                }
            }
            yield return null;
        }

        protected virtual IEnumerator FinalizeSubControllers()
        {
            if (_subControllers != null)
            {
                int count = _subControllers.Length;
                for (int i = 0; i < count; i++)
                {
                    yield return _subControllers[i].Finalize();
                }
            }
            yield return null;
        }

        #region Abstract
        protected abstract IController[] GetSubControllers();
        #endregion
    }
}
