# ChichenRobotSimulation

로봇 기술의 의미가 변화하고 산업용 로봇과 협동로봇의 비중이 높아지는 추세가 되었습니다.
협동로봇이 일상생활에 근접해 있는 시장에 적용되고 있는 것을 게임을 통해 시뮬레이션 해보았습니다.

치킨 제조 협동로봇 시뮬레이션 게임을 설계하기 위해서 유니티 게임 엔진과 코드를 작성하여 이에 적용, 디버깅할 수 있는 비주얼 스튜디오 C#을 사용했습니다.

## 치킨 제조 협동로봇 시뮬레이션 게임 스토리
플레이어는 치킨 제조 협동로봇을 사용하여 목표치의 치킨을 제조합니다. 플레이어는 협동로봇을 사용하기 위해 도구와 재료를 갖고 있어야 합니다.
협동로봇을 사용할 수 있는 조건이 되면 협동로봇을 작동하여 치킨을 제조하고 목표치의 치킨을 제조하면 게임이 종료됩니다.


## 조작법
게임 객체 : 유저, 장갑(도구:검정), 생닭(분홍), 후라이드치킨(노랑), 양념치킨(빨강), 치킨로봇_A, 치킨로봇_B

방향키 : 유저 이동 조작
e : 장갑(도구:검정) 줍기
1 : 장갑 장착
q : 치킨로봇 조작

유저가 객체들을 줍기, 조작하려면 객체들의 히트박스 주변에 접촉해야하며,
생닭, 후라이드치킨, 양념치킨은 다른 조작없이 접촉만으로 습득한다.
생닭과 장갑을 습득후, 장갑을 장착하여 치킨로봇 히트박스에 q키를 이용해 치킨을 제조할 수 있다.
