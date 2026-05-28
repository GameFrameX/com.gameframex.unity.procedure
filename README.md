<div align="center">

<img src="https://download.alianblank.com/gameframex/gameframex_logo_320.png" alt="Game Frame X Logo" width="160" />

# Game Frame X Procedure

[![License](https://img.shields.io/github/license/GameFrameX/com.gameframex.unity.procedure)](https://github.com/GameFrameX/com.gameframex.unity.procedure/blob/main/LICENSE.md)
[![Version](https://img.shields.io/github/v/release/GameFrameX/com.gameframex.unity.procedure)](https://github.com/GameFrameX/com.gameframex.unity.procedure/releases)
[![Documentation](https://img.shields.io/badge/Documentation-docs-blue)](https://gameframex.doc.alianblank.com)

> All-in-One Solution for Indie Game Development · Empowering Indie Developers' Dreams

[Documentation](https://gameframex.doc.alianblank.com) · [Quick Start](#quick-start) · [QQ Group](https://qm.qq.com/q/5U9Fvebw) · [Language](#language)


</div>

---

## Language

**English** | [简体中文](README.zh-CN.md) | [繁體中文](README.zh-TW.md) | [日本語](README.ja.md) | [한국어](README.ko.md)

---

## Project Overview

GameFrameX Procedure Flow Management Component.

**Procedure Flow Management Component (Procedure Component)** - Provides interfaces related to the procedure management component.

**This library primarily serves as a sub-library for `https://github.com/AlianBlank/GameFrameX.Unity`.**

## Dependencies

- Finite State Machine (FSM): https://github.com/AlianBlank/com.alianblank.gameframex.unity.fsm

## Quick Start

### Installation (choose one)

1. Add the following to the `dependencies` section of `manifest.json`:
   ```json
   {"com.gameframex.unity.procedure": "https://github.com/AlianBlank/com.gameframex.unity.procedure.git"}
   ```

2. Add via Unity's `Package Manager` using `Git URL`: https://github.com/AlianBlank/com.gameframex.unity.procedure.git

3. Download the repository directly and place it in the Unity project's `Packages` directory. It will be auto-loaded.

## Usage Examples

### ProcedureComponent Overview

`ProcedureComponent` is a component for managing game procedures in Unity and Game Framework-based games. It depends on `FSMComponent` (Finite State Machine Component) to manage different stages or states in the game, such as startup, menu, gameplay, pause, and ending.

### Features

- Initializes the procedure manager (`IProcedureManager`), registers and retrieves related modules through `GameFrameworkEntry`.
- Creates and initializes all available procedures (`ProcedureBase` type array) when the game starts.
- Automatically switches to the entrance procedure (`m_EntranceProcedure`) when the game starts.
- Provides methods to query and get the current procedure and its duration.

### Dependencies

`ProcedureComponent` requires the following components or modules:

- `FSMComponent`: Used to implement the finite state machine logic for procedures.
- `IProcedureManager`: An interface provided by Game Framework to manage game procedure states.
- `ProcedureBase`: A base class for extending custom procedures.

### Configuration

In the Unity Inspector, you can set the following properties:

- `m_AvailableProcedureTypeNames`: Array of available procedure type names, used to create and initialize procedures when the game starts.
- `m_EntranceProcedureTypeName`: The type name of the procedure to enter first when the game starts.

### Public Methods

- `HasProcedure<T>()`: Checks if a procedure of the specified type exists.
- `GetProcedure<T>()`: Gets the procedure of the specified type.

## Changelog

See [CHANGELOG.md](CHANGELOG.md) for details.

## License

This project is licensed under the MIT License - see the [LICENSE.md](LICENSE.md) file for details.
