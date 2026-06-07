<div align="center">

<img src="https://download.alianblank.com/gameframex/gameframex_logo_320.png" alt="Game Frame X Logo" width="160" />

# Game Frame X Procedure

[![License](https://img.shields.io/github/license/GameFrameX/com.gameframex.unity.procedure)](https://github.com/GameFrameX/com.gameframex.unity.procedure/blob/main/LICENSE.md)
[![Version](https://img.shields.io/github/v/release/GameFrameX/com.gameframex.unity.procedure)](https://github.com/GameFrameX/com.gameframex.unity.procedure/releases)
[![Unity Version](https://img.shields.io/badge/Unity-2019.4-black?logo=unity)](https://unity.com/)
[![Documentation](https://img.shields.io/badge/Documentation-docs-blue)](https://gameframex.doc.alianblank.com)

独立游戏前后端一体化解决方案 · 独立游戏开发者的圆梦大使

<br />

[文档](https://gameframex.doc.alianblank.com) · [快速开始](#快速开始) · QQ群: 467608841 / 233840761

<br />

[English](README.md) | **简体中文** | [繁體中文](README.zh-TW.md) | [日本語](README.ja.md) | [한국어](README.ko.md)

</div>

## 语言

[English](README.md) | **简体中文** | [繁體中文](README.zh-TW.md) | [日本語](README.ja.md) | [한국어](README.ko.md)

---

## 项目简介

基于有限状态机（FSM）的 Unity 游戏流程管理包。通过可切换的流程状态驱动游戏生命周期阶段（闪屏、预加载、登录、主菜单等）。

## 架构概览

```
ProcedureComponent (MonoBehaviour)
  └─ IProcedureManager (接口)
       └─ ProcedureManager (管理 FSM)
            └─ ProcedureBase (抽象类，每个流程的逻辑)
```

- **ProcedureComponent** — Unity 组件，通过 Inspector 注册流程和入口流程，`Start()` 时自动启动。
- **ProcedureManager** — 核心管理器，通过 `IFsmManager` 创建内部 FSM 驱动流程状态切换。
- **ProcedureBase** — 抽象基类，提供生命周期回调：`OnInit`、`OnEnter`、`OnUpdate`、`OnFixedUpdate`、`OnLeave`、`OnDestroy`。

## 依赖

- [com.gameframex.unity.fsm](https://github.com/GameFrameX/com.gameframex.unity.fsm) — 有限状态机

## 快速开始

### 安装

编辑 Unity 项目的 `Packages/manifest.json`，添加 `scopedRegistries` 部分：

```json
{
  "scopedRegistries": [
    {
      "name": "GameFrameX",
      "url": "https://gameframex.upm.alianblank.uk",
      "scopes": [
        "com.gameframex"
      ]
    }
  ]
}
```

然后在 `dependencies` 中添加：

```json
{
  "dependencies": {
    "com.gameframex.unity.procedure": "1.1.1"
  }
}
```

`scopes` 控制哪些包通过此注册表解析。只有以 `com.gameframex` 开头的包才会从这个注册表获取。

## 使用示例

### 1. 定义流程类

```csharp
public class ProcedurePreload : ProcedureBase
{
    protected internal override void OnEnter(IFsm<IProcedureManager> procedureOwner)
    {
        // 加载资源、配置等
    }

    protected internal override void OnUpdate(IFsm<IProcedureManager> procedureOwner, float elapseSeconds, float realElapseSeconds)
    {
        // 检查加载进度，完成后切换到下一个流程
        ChangeToState<ProcedureMain>(procedureOwner);
    }
}

public class ProcedureMain : ProcedureBase
{
    protected internal override void OnEnter(IFsm<IProcedureManager> procedureOwner)
    {
        // 显示主菜单
    }
}
```

### 2. 通过 Inspector 配置

1. 将 `ProcedureComponent` 添加到游戏对象（通过 `GameFrameX > Procedure`）。
2. 在 Inspector 中勾选可用的流程。
3. 选择入口流程（如 `ProcedurePreload`）。

### 3. 运行时流程管理

```csharp
// 检查流程是否存在
bool has = procedureComponent.HasProcedure<ProcedureMain>();

// 获取流程实例
ProcedureMain main = procedureComponent.GetProcedure<ProcedureMain>();

// 获取当前流程信息
ProcedureBase current = procedureComponent.CurrentProcedure;
float time = procedureComponent.CurrentProcedureTime;

// 销毁所有流程并使用新流程重新初始化
procedureComponent.DestroyProcedures();
procedureComponent.ReinitializeProcedures(newProcedures, entranceProcedure);
```

## 更新日志

详见 [CHANGELOG.md](CHANGELOG.md)。

## 开源协议

详见 [LICENSE.md](LICENSE.md) 文件。
