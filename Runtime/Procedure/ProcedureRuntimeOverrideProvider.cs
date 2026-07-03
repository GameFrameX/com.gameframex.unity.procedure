using GameFrameX.Runtime;
using UnityEngine;
using UnityEngine.Scripting;

namespace GameFrameX.Procedure.Runtime
{
    /// <summary>
    /// Provides runtime overrides for automatically created procedure components.
    /// </summary>
    [Preserve]
    internal sealed class ProcedureRuntimeOverrideProvider : IGameFrameXRuntimeOverrideProvider
    {
        private static readonly ProcedureRuntimeOverrideProvider Instance = new ProcedureRuntimeOverrideProvider();

        [RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.SubsystemRegistration)]
        private static void Register()
        {
            GameFrameXRuntimeOverrideProvider.RegisterProvider(Instance);
        }

        public void CollectOverrides(GameFrameXRuntimeOverrideContext context)
        {
            if (context == null)
            {
                throw new GameFrameworkException("Runtime override context is invalid.");
            }

            context.SetComponentValue(typeof(ProcedureComponent), "m_UseStartupRunner", true);
        }
    }
}
