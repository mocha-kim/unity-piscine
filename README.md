# unity-piscine
2023-05-29 ~

42 piscine project for member

0. The basics Unity tools
1. 3D physics, Tags, Layers and Scene
2. 2D environment, tiles and sprites
3. Advanced inputs and 2D GUI
4. Animations and Sound
5. Singleton, playerPrefs and coroutines
6. Navmesh, light, sound and camera

You can find each projects in thier branch

## 6. Navmesh, light, sound and camera
### Nightmare House

유령의 추적을 피해 3개의 열쇠를 모아 탈출하는 어드벤쳐 게임

#### 주요 게임 기능
1. 캐릭터 이동

   3인칭 시점일 때에는 방향키 또는 WASD로 이동한다.

   1인칭 시점일 때에는 마우스로 방향을 조절하고 Z로 직진, X로 후진한다.
   
2. 카메라 시점 전환

   키보드의 C를 누르면 3인칭과 1인칭 시점으로 전환된다.
   
3. 유령과 해골 파수꾼

   - 유령
   
     유령은 정해진 경로를 순찰한다.
  
     플레이어가 시야에 걸리면 플레이어를 추격한다.
  
     플레이어는 유령에게 붙잡히면 게임 오버 된다.
  
     일정 시간이 지나면 유령은 다시 정해진 경로로 돌아간다.

   - 해골 파수꾼
   
     해골 파수꾼은 빨간 빛이 나는 횃불을 들고 서있다.
  
     플레이어가 빨간 불빛에 닿으면 일정 시간 동안 씬의 모든 유령이 플레이어를 추격한다.

4. 문과 방

   방에는 문이 달려있다.

   대부분의 문은 플레이어가 가까이 가면 열린다.

   열리지 않는 문은 열쇠 3개를 모아야 열 수 있다.

   열쇠를 모아 연 문을 통과해 들어간 방에만 탈출구가 있다.
   
   
<img width="640" alt="스크린샷 2023-07-12 오후 4 27 38" src="https://github.com/mocha-kim/unity-piscine/assets/49827929/d601ef1e-980b-43f1-93b5-3fa9374193de">
<img width="640" alt="스크린샷 2023-07-12 오후 4 27 52" src="https://github.com/mocha-kim/unity-piscine/assets/49827929/40e36d2e-e21f-46be-a7f9-4475c23a7c19">
