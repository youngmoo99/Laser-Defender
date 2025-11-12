# Laser Defender

Unity 2D 탄막 슈팅 게임

<p align="center">
  <a href="#demo">🎮 플레이 영상</a> •
  <a href="#features">✨ 주요 특징</a> •
  <a href="#tech-stack">🧰 기술 스택</a> •
  <a href="#setup">⚙️ 설치/실행</a> •
  <a href="#screenshots">🖼️ 스크린샷</a>
</p>
<p>
  <img alt="Unity" src="https://img.shields.io/badge/Unity-2021.3.45-black?logo=unity"/>
  <img alt="Platform" src="https://img.shields.io/badge/Platform-Windows%20%7C%20macOS-blue"/>
</p>

## TL;DR

* **장르**: 2D Space Shooter
* **엔진**: Unity 6.0
* **역할(Role)**: 기획 100%, 프로그래밍 100% (무료 리소스 일부 활용)
* **플레이 루프**: 기체 조종 → 마우스 조준/발사 → 적 격추 → 점수 획득 → 피격 시 연출 후 **즉시 재도전(씬 리로드)**

---

<h2 id="demo">🎮 플레이 영상</h2>

* ▶️ **Gameplay Video**: [게임 플레이 영상](https://youtu.be/WC9vJx0G150)

> 마우스 위치로 실시간 조준, 클릭 시 레이저 발사. 적은 파티클 충돌 판정을 통해 파괴되고 점수가 누적됩니다.

---

<h2 id="features">✨ 주요 특징 / Features</h2>

* 👾 **우주선 이동** - 적 우주선과 탄막 회피, 타격 메커니즘
* 💥 **탄막 공격** - 스페이스바로 연속 발사되는 탄막 시스템
* 🛰️ **플레이어 조작** - 좌우 방향키로 플레이어 우주선 조작
* 🌌 **배경** - 우주 배경 속 몰입감 있는 전투 연출
* 🔊 **BGM** - 박진감 넘치는 배경음악과 타격 사운드

---

<h2 id="tech-stack">🧰 기술 스택 / Tech Stack</h2>

**엔진**: Unity 2021.3.45
**언어**: C#
**패키지/툴**: Input System, TextMeshPro, Particle System, Git, VS Code/Rider

**핵심 시스템 구성**

| 시스템                  | 설명                                          |
| -------------------- | ------------------------------------------- |
| **PlayerMovement**   | WASD 이동, Pitch/Roll 회전 보간, 화면 경계 클램프        |
| **PlayerWeapon**     | 마우스 조준점 변환(Screen→World), 레이저 파티클 발사 On/Off |
| **Enemy**            | 파티클 충돌 → HP 감소 → 폭발 VFX → 점수 반영             |
| **Scoreboard**       | 점수 누적 및 TMP HUD 갱신                          |
| **CollisionHandler** | 플레이어 트리거 충돌 시 폭발 연출 + 레벨 리로드                |
| **GameSceneManager** | 1초 지연 후 현재 씬 재시작(빠른 재도전)                    |
| **MusicPlayer**      | 씬 간 **DontDestroyOnLoad**, 중복 인스턴스 제거       |
| **DialogueLines**    | 문자열 배열 기반 대사 진행(타임라인 이벤트 연동)                |

---

<h2 id="architecture">🏗️ 프로젝트 구조 / Architecture</h2>

```
Assets/
  GalaxyStrike/
    Player/
      PlayerMovement.cs
      PlayerWeapon.cs
      CollisionHandler.cs
    Gameplay/
      Enemy.cs
      Scoreboard.cs
    Systems/
      GameSceneManager.cs
      MusicPlayer.cs
      DialogueLines.cs
    UI/
      (TMP Texts, Crosshair)
    VFX/
      (Explosion / Laser Particles)
    Sprites_Models/
      (Ship, Enemies, Environment)
```

**설계 포인트**:

* 입력, 이동, 무기, 점수, 씬 관리 **관심사 분리**
* 파티클 충돌(OnParticleCollision)로 **저비용 피격 판정**
* `DontDestroyOnLoad`로 BGM 유지, **중복 인스턴스 가드**
* 마우스/월드 변환을 통한 **정확한 조준 피드백**

---

<h2 id="setup">⚙️ 설치 및 실행 / Setup</h2>

저장소 클론

```bash
git clone https://github.com/<YOUR_ID>/GalaxyStrike.git
```

Unity Hub에서 프로젝트 열기 → 패키지 자동 복구 → `Assets/Scenes/Demo.unity` 실행 → ▶️ **Play**

> 에셋 의존성이 있는 경우 Readme/팝업 안내에 따라 추가 패키지를 설치하세요.

---

<h2 id="controls">🎮 조작법 / Controls</h2>

| 동작       | 입력(Keyboard)      |
| -------- | ---------------- |
| 이동       | **↑ / ↓ / ← / →**|
| 발사       | **Space** |


---

<h2 id="screenshots">🖼️ 스크린샷 / Screenshots</h2>

<p align="center">
  <img src="Galaxy Strike Main.png" width="720" alt="Galaxy Strike Gameplay"/>
</p>

> 적 편대가 진입하는 행성 지형 위에서의 전투 장면.

---

<h2 id="roadmap">🚀 향후 계획 / Roadmap</h2>

* [ ] 웨이브/스폰 매니저 도입(난이도 커브, 패턴)
* [ ] 보스전 및 탄막 패턴 추가
* [ ] 업그레이드/파워업(연사, 산탄, 실드)
* [ ] 모바일/패드 입력 최적화, 진동/피드백 강화
* [ ] 리더보드 및 기록 저장

---

<h2 id="credits">👤 제작자 / Credits</h2>

* **기획·개발**: 김영무 (Kim YoungMoo)
* **아트/환경**: 강의 무료 리소스 
* **사운드**: 강의 무료 라이브러리 활용
* **참고 강의**: [강의 링크](https://www.udemy.com/course/best-3d-c-unity/?kw=C%23%EA%B3%BC+UNITY%EB%A1%9C+3&src=sac&couponCode=KEEPLEARNING)

---

<h2 id="contact">📬 연락처 / Contact</h2>

* **이메일**: [rladuan612@gmail.com](mailto:rladuan612@gmail.com)
* **포트폴리오**: [https://www.naver.com](https://www.naver.com)



# 🚀 Laser-Defender
<img src="LaserDefenderMain.PNG"/>
Unity 2D 탄막 슈팅 게임

## 🎮 게임 특징
- 👾 적 우주선과 탄막 회피, 타격 메커니즘
- 💥 스페이스바로 연속 발사되는 탄막 시스템
- 🛰️ 좌우 방향키로 플레이어 우주선 조작
- 🌌 우주 배경 속 몰입감 있는 전투 연출
- 🔊 박진감 넘치는 배경음악과 타격 사운드

## 📸 플레이 영상
https://youtu.be/WC9vJx0G150

## 🎮 조작법
- **← / → 방향키**: 플레이어 우주선 좌우 이동
- **Spacebar**: 탄막(총알) 발사

## 🛠️ 개발 도구
- **Engine**: Unity 2D
- **Language**: C#
- **Tools**: Unity Animator, Rigidbody2D, Tilemap, AudioSource
