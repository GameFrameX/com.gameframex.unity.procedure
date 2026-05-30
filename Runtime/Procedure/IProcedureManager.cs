//------------------------------------------------------------
// Game Framework
// Copyright © 2013-2021 Jiang Yin. All rights reserved.
// Homepage: https://gameframework.cn/
// Feedback: mailto:ellan@gameframework.cn
//------------------------------------------------------------

using System;
using GameFrameX.Fsm.Runtime;
using UnityEngine.Scripting;

namespace GameFrameX.Procedure.Runtime
{
    /// <summary>
    /// 流程管理器接口。
    /// </summary>
    public interface IProcedureManager
    {
        /// <summary>
        /// 获取当前流程。
        /// </summary>
        [Preserve]
        ProcedureBase CurrentProcedure { get; }

        /// <summary>
        /// 获取当前流程持续时间。
        /// </summary>
        [Preserve]
        float CurrentProcedureTime { get; }

        /// <summary>
        /// 初始化流程管理器。
        /// </summary>
        /// <param name="fsmManager">有限状态机管理器。</param>
        /// <param name="procedures">流程管理器包含的流程。</param>
        [Preserve]
        void Initialize(IFsmManager fsmManager, params ProcedureBase[] procedures);

        /// <summary>
        /// 开始流程。
        /// </summary>
        /// <typeparam name="T">要开始的流程类型。</typeparam>
        [Preserve]
        void StartProcedure<T>() where T : ProcedureBase;

        /// <summary>
        /// 开始流程。
        /// </summary>
        /// <param name="procedureType">要开始的流程类型。</param>
        [Preserve]
        void StartProcedure(Type procedureType);

        /// <summary>
        /// 是否存在流程。
        /// </summary>
        /// <typeparam name="T">要检查的流程类型。</typeparam>
        /// <returns>是否存在流程。</returns>
        [Preserve]
        bool HasProcedure<T>() where T : ProcedureBase;

        /// <summary>
        /// 是否存在流程。
        /// </summary>
        /// <param name="procedureType">要检查的流程类型。</param>
        /// <returns>是否存在流程。</returns>
        [Preserve]
        bool HasProcedure(Type procedureType);

        /// <summary>
        /// 获取流程。
        /// </summary>
        /// <typeparam name="T">要获取的流程类型。</typeparam>
        /// <returns>要获取的流程。</returns>
        [Preserve]
        ProcedureBase GetProcedure<T>() where T : ProcedureBase;

        /// <summary>
        /// 获取流程。
        /// </summary>
        /// <param name="procedureType">要获取的流程类型。</param>
        /// <returns>要获取的流程。</returns>
        [Preserve]
        ProcedureBase GetProcedure(Type procedureType);

        /// <summary>
        /// 销毁当前流程状态机，清空所有已注册的流程。
        /// </summary>
        [Preserve]
        void DestroyProcedures();

        /// <summary>
        /// 销毁当前流程状态机，并使用新的流程重新初始化。
        /// </summary>
        /// <param name="procedures">新注册的流程。</param>
        [Preserve]
        void ReinitializeProcedures(params ProcedureBase[] procedures);
    }
}