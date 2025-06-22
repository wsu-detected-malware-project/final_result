# tran_server
## 소개
  중계 서버입니다.
  클라이언트와 다른 서버들간의 통신을 통제하는 역할을 하는 서버입니다.
## 설치방법
### 사전 요구 사항
- Visual Studio Code
- Python 또는 Anaconda

### 설치 및 실행
  1. requirements.txt에서 라이브러리 확인
     
     ![image](https://github.com/user-attachments/assets/28f398ff-4172-4788-9a30-6098f1365895)

  2. 라이브러리 설치
     ```cmd
     pip install -r requirements.txt
  
  3. 실행
     ```cmd
     python app.py

  4. 결과

     ![image](https://github.com/user-attachments/assets/d8be2a87-c338-44eb-8cdd-b069227f4d20)

     * 로그인 후 중계 서버 트래픽 확인

     ![image](https://github.com/user-attachments/assets/224446ac-699f-414a-b577-f8622cd65918)

     * /download-page를 통해 외부에서 WSU_Malware_Installer.exe 다운로드

     ![image](https://github.com/user-attachments/assets/d3fc8ec7-af33-4251-b6b1-7b9de61501be)
