<div align="center">

<img src="https://download.alianblank.com/gameframex/gameframex_logo_320.png" alt="Game Frame X Logo" width="160" />

# Game Frame X Procedure

[![License](https://img.shields.io/github/license/GameFrameX/com.gameframex.unity.procedure)](https://github.com/GameFrameX/com.gameframex.unity.procedure/blob/main/LICENSE.md)
[![Version](https://img.shields.io/github/v/release/GameFrameX/com.gameframex.unity.procedure)](https://github.com/GameFrameX/com.gameframex.unity.procedure/releases)
[![Documentation](https://img.shields.io/badge/Documentation-docs-blue)](https://gameframex.doc.alianblank.com)

> 인디 게임 개발자를 위한 올인원 솔루션 · 인디 개발자의 꿈을 실현

[문서](https://gameframex.doc.alianblank.com) · [빠른 시작](#빠른-시작) · [QQ 그룹](https://qm.qq.com/q/5U9Fvebw) · [언어](#언어)


</div>

---

## 언어

[English](README.md) | [简体中文](README.zh-CN.md) | [繁體中文](README.zh-TW.md) | [日本語](README.ja.md) | **한국어**

---

## 프로젝트 개요

GameFrameX의 Procedure 흐름 관리 컴포넌트.

**Procedure 흐름 관리 컴포넌트 (Procedure Component)** - 흐름 관리 컴포넌트 관련 인터페이스를 제공합니다.

**이 라이브러리는 주로 `https://github.com/AlianBlank/GameFrameX.Unity`의 하위 라이브러리로 사용됩니다.**

## 종속 컴포넌트

- 유한 상태 기계 (FSM): https://github.com/AlianBlank/com.alianblank.gameframex.unity.fsm

## 빠른 시작

### 설치 (선택)

1. `manifest.json` 파일의 `dependencies` 섹션에 다음 내용을 추가합니다:
   ```json
   {"com.gameframex.unity.procedure": "https://github.com/AlianBlank/com.gameframex.unity.procedure.git"}
   ```

2. Unity의 `Package Manager`에서 `Git URL`을 사용하여 추가: https://github.com/AlianBlank/com.gameframex.unity.procedure.git

3. 저장소를 직접 다운로드하여 Unity 프로젝트의 `Packages` 디렉토리에 배치합니다. 자동으로 로드됩니다.

## 사용 예시

### ProcedureComponent 개요

`ProcedureComponent`는 Unity와 Game Framework 기반 게임에서 게임 흐름을 관리하는 컴포넌트입니다. `FSMComponent`(유한 상태 기계 컴포넌트)에 의존하여 게임의 시작, 메뉴, 게임플레이, 일시 정지, 종료 등 다양한 단계나 상태를 관리합니다.

### 기능

- 프로시저 매니저(`IProcedureManager`)를 초기화하고, `GameFrameworkEntry`를 통해 관련 모듈을 등록 및 가져옵니다.
- 게임 시작 시 모든 사용 가능한 프로시저(`ProcedureBase` 타입 배열)를 생성하고 초기화합니다.
- 게임 시작 시 진입 프로시저(`m_EntranceProcedure`)로 자동 전환합니다.
- 현재 프로시저와 그 지속 시간을 쿼리하고 가져오는 메서드를 제공합니다.

### 종속성

`ProcedureComponent`는 다음 컴포넌트나 모듈이 필요합니다:

- `FSMComponent`: 프로시저의 유한 상태 기계 로직을 구현하는 데 사용.
- `IProcedureManager`: Game Framework에서 제공하는 게임 프로시저 상태 관리 인터페이스.
- `ProcedureBase`: 사용자 정의 프로시저를 확장하기 위한 기본 클래스.

### 설정

Unity Inspector에서 다음 속성을 설정할 수 있습니다:

- `m_AvailableProcedureTypeNames`: 사용 가능한 프로시저 타입 이름 배열. 게임 시작 시 프로시저를 생성하고 초기화하는 데 사용.
- `m_EntranceProcedureTypeName`: 게임 시작 시 처음으로 진입하는 프로시저의 타입 이름.

### 공개 메서드

- `HasProcedure<T>()`: 지정된 타입의 프로시저가 존재하는지 확인합니다.
- `GetProcedure<T>()`: 지정된 타입의 프로시저를 가져옵니다.

## 변경 로그

자세한 내용은 [CHANGELOG.md](CHANGELOG.md)를 참조하세요.

## 라이선스

이 프로젝트는 MIT 라이선스에 따라 배포됩니다. 자세한 내용은 [LICENSE.md](LICENSE.md) 파일을 참조하세요.
