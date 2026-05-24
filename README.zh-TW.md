<div align="center">
  <img src="https://download.alianblank.com/gameframex/gameframex_logo_320.png" alt="Game Frame X Logo" width="160" />
</div>

# Game Frame X Procedure

[![License](https://img.shields.io/github/license/GameFrameX/com.gameframex.unity.procedure)](https://github.com/GameFrameX/com.gameframex.unity.procedure/blob/main/LICENSE.md)
[![Version](https://img.shields.io/github/v/release/GameFrameX/com.gameframex.unity.procedure)](https://github.com/GameFrameX/com.gameframex.unity.procedure/releases)
[![Documentation](https://img.shields.io/badge/Documentation-docs-blue)](https://gameframex.doc.alianblank.com)

> 獨立遊戲前後端一體化解決方案 · 獨立遊戲開發者的圓夢大使

[文檔](https://gameframex.doc.alianblank.com) · [快速開始](#快速開始) · [QQ群](https://qm.qq.com/q/5U9Fvebw) · [語言](#語言)

---

## 語言

[English](README.md) | [简体中文](README.zh-CN.md) | **繁體中文** | [日本語](README.ja.md) | [한국어](README.ko.md)

---

## 項目簡介

GameFrameX 的 Procedure 流程管理組件。

**Procedure 流程管理組件 (Procedure Component)** - 提供流程管理組件相關的介面。

**此套件主要服務於 `https://github.com/AlianBlank/GameFrameX.Unity` 作為子套件使用。**

## 依賴組件

- 有限狀態機：https://github.com/AlianBlank/com.alianblank.gameframex.unity.fsm

## 快速開始

### 使用方式（任選其一）

1. 直接在 `manifest.json` 的檔案中的 `dependencies` 節點下新增以下內容
   ```json
   {"com.gameframex.unity.procedure": "https://github.com/AlianBlank/com.gameframex.unity.procedure.git"}
   ```

2. 在 Unity 的 `Packages Manager` 中使用 `Git URL` 的方式新增套件，地址為：https://github.com/AlianBlank/com.gameframex.unity.procedure.git

3. 直接下載倉庫放置到 Unity 專案的 `Packages` 目錄下。會自動載入識別。

## 使用範例

### ProcedureComponent 簡介

`ProcedureComponent` 類是一款用於在基於 Unity 和 Game Framework 框架開發的遊戲中管理遊戲流程的組件。它依賴於 `FSMComponent`（有限狀態機組件）來管理遊戲中的不同階段或狀態，例如啟動、選單、遊戲、暫停和結束等。

### 功能

- 初始化流程管理器 (`IProcedureManager`)，透過 `GameFrameworkEntry` 註冊並取得相關模組。
- 在遊戲啟動時建立並初始化所有可用的流程 (`ProcedureBase` 類型陣列)。
- 啟動遊戲時，自動切換至入口流程 (`m_EntranceProcedure`)。
- 提供方法查詢、取得當前流程及其持續時間。

### 依賴關係

`ProcedureComponent` 需要以下組件或模組才能正常運作：

- `FSMComponent`：用於實作流程的有限狀態機邏輯。
- `IProcedureManager`：一個介面，由 Game Framework 提供，管理遊戲的流程狀態。
- `ProcedureBase`：用於擴充自訂具體流程的基礎類別。

### 設定

在 Unity Inspector 中，您可以設定以下屬性：

- `m_AvailableProcedureTypeNames`：可用流程的類型名稱陣列，用於在啟動遊戲時建立和初始化流程。
- `m_EntranceProcedureTypeName`：啟動遊戲時首先進入的流程的類型名稱。

### 公共方法

- `HasProcedure<T>()`：檢查是否存在指定類型的流程。
- `GetProcedure<T>()`：取得指定類型的流程。

## 更新日誌

詳見 [CHANGELOG.md](CHANGELOG.md)。

## 開源協議

本專案基於 MIT 協議開源，詳見 [LICENSE.md](LICENSE.md) 檔案。
