# Temperature_control_system
## 프로젝트 소개
PC(C#)과 STM32를 통해 희망온도와 현재온도를 비교하여 에어컨 혹은 히터를 자동으로 제어
## 구성인원
2명
## 기술스택
![a](https://img.shields.io/badge/C-00599C?style=for-the-badge&logo=cpp&logoColor=white) ![b](https://img.shields.io/badge/STM32-03234B?style=for-the-badge&logo=stmicroelectronics&logoColor=white) ![c](https://img.shields.io/badge/C%23-03234B?style=for-the-badge&logo=C%23&logoColor=white) ![d](https://img.shields.io/badge/Visual_Studio-FF6F00?style=for-the-badge&logo=visual%20studio%20code&logoColor=white) ![e](https://img.shields.io/badge/.Net_framework-FF6F00?style=for-the-badge&logo=.Net_framework&logoColor=white)  
## 사용 디바이스
stm32f411, 온습도센서, Red LED(히터역할), DC motor&프로펠러(에어컨역할)
## 개발환경
STM32CubeIDE, Visual Studio(.NET framework)
## 흐름도
<img src="./image_video/temperature_flow.png" width=800 height=500>

## 수행역할
PC(C#)과 STM32간의 통신, GUI를 구성했습니다. 희망온도, 희망습도 데이터를 STM32에 넘겨줄 수 있게 했습니다.


## 시연영상
<img src="./image_video/Tem_Con_Sys.gif" width=500 height=400>
시연영상에 대한 설명<br/>
1. 통신설정 및 재시작 합니다. 하단 상태표시줄에 연결상태가 표시됩니다.<br/>
2. 현재온도보다 희망온도를 높아지게 설정합니다. |희망온도 - 현재온도|의 차이가 커질수록 Red LED가 더 밝아집니다.(PWM사용)<br/>
3. 현재온도보다 희망온도를 낮아지게 설정합니다. |희망온도 - 현재온도|의 차이가 커질수록 모터가 더 빨라집니다.(PWM사용)<br/>
<br/>

[원본영상](https://github.com/BrotherHwan/Temperature_control_system/blob/main/image_video/Tem_Con_Sys.mp4)(이 링크의 raw file 다운로드시 좀 더 크고 명확한 영상을 확인하실 수 있습니다. )

