<div align="center">

<img src="https://download.alianblank.com/gameframex/gameframex_logo_320.png" alt="Game Frame X Logo" width="160" />

# Game Frame X Procedure

[![License](https://img.shields.io/github/license/GameFrameX/com.gameframex.unity.procedure)](https://github.com/GameFrameX/com.gameframex.unity.procedure/blob/main/LICENSE.md)
[![Version](https://img.shields.io/github/v/release/GameFrameX/com.gameframex.unity.procedure)](https://github.com/GameFrameX/com.gameframex.unity.procedure/releases)
[![Documentation](https://img.shields.io/badge/Documentation-docs-blue)](https://gameframex.doc.alianblank.com)

> 独立游戏前后端一体化解决方案 · 独立游戏开发者的圆梦大使

[文档](https://gameframex.doc.alianblank.com) · [快速开始](#快速开始) · [QQ群](https://qm.qq.com/q/5U9Fvebw) · [语言](#语言)


</div>

---

## 语言

[English](README.md) | **简体中文** | [繁體中文](README.zh-TW.md) | [日本語](README.ja.md) | [한국어](README.ko.md)

---

## 项目简介

GameFrameX 的 Procedure 流程管理组件。

**Procedure 流程管理组件 (Procedure Component)** - 提供流程管理组件相关的接口。

**该库主要服务于 `https://github.com/AlianBlank/GameFrameX.Unity` 作为子库使用。**

## 依赖组件

- 有限状态机：https://github.com/AlianBlank/com.alianblank.gameframex.unity.fsm

## 快速开始

### 使用方式（任选其一）

1. 直接在 `manifest.json` 的文件中的 `dependencies` 节点下添加以下内容
   ```json
   {"com.gameframex.unity.procedure": "https://github.com/AlianBlank/com.gameframex.unity.procedure.git"}
   ```

2. 在 Unity 的 `Packages Manager` 中使用 `Git URL` 的方式添加库，地址为：https://github.com/AlianBlank/com.gameframex.unity.procedure.git

3. 直接下载仓库放置到 Unity 项目的 `Packages` 目录下。会自动加载识别。

## 使用示例

### ProcedureComponent 简介

`ProcedureComponent` 类是一款用于在基于 Unity 和 Game Framework 框架开发的游戏中管理游戏流程的组件。它依赖于 `FSMComponent`（有限状态机组件）来管理游戏中的不同阶段或状态，例如启动、菜单、游戏、暂停和结束等。

### 功能

- 初始化流程管理器 (`IProcedureManager`)，通过 `GameFrameworkEntry` 注册并获取相关模块。
- 在游戏启动时创建并初始化所有可用的流程 (`ProcedureBase` 类型数组)。
- 启动游戏时，自动切换至入口流程 (`m_EntranceProcedure`)。
- 提供方法查询、获取当前流程及其持续时间。

### 依赖关系

`ProcedureComponent` 需要以下组件或模块来正常工作：

- `FSMComponent`：用于实现流程的有限状态机的逻辑。
- `IProcedureManager`：一个接口，由 Game Framework 提供，管理游戏的流程状态。
- `ProcedureBase`：用于扩展自定义具体流程的基类。

### 配置

在 Unity Inspector 中，您可以设置以下属性：

- `m_AvailableProcedureTypeNames`：可用流程的类型名称数组，用于在启动游戏时创建和初始化流程。
- `m_EntranceProcedureTypeName`：启动游戏时首先进入的流程的类型名称。

### 公共方法

- `HasProcedure<T>()`：检查是否存在指定类型的流程。
- `GetProcedure<T>()`：获取指定类型的流程。

## 更新日志

详见 [CHANGELOG.md](CHANGELOG.md)。

## 开源协议

本项目基于 MIT 协议开源，详见 [LICENSE.md](LICENSE.md) 文件。
