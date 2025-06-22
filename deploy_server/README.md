# deploy_server
## 소개
  배포 서버입니다.
  프로그램의 업데이트 관리를 담당하는 서버입니다.
## 설치방법 및 사용법
### 사전 요구 사항
- Visual Studio Code
- Python 또는 Anaconda

### 설치 및 실행
  1. requirements.txt에서 라이브러리 확인
     
     ![image](https://github.com/user-attachments/assets/add3f113-8914-47e5-936b-e587b5499114)

  2. 라이브러리 설치
     ```cmd
     pip install -r requirements.txt
  
  3. 접속
     ```cmd
     python app.py

  4. 결과

     ![스크린샷 2025-06-17 205527](https://github.com/user-attachments/assets/dd31942a-e082-4571-a4e6-ed7165523e56)

### 업데이트 갱신
     
  1. deploy_server\static\files 폴더와 deploy_server\static\installers 폴더에 각각 업데이트할 파일과 설치파일을 옮긴다.
     ![image](https://github.com/user-attachments/assets/f5ec9e2e-ba75-4c93-9145-e7a85d5fdd01)
     ![image](https://github.com/user-attachments/assets/df2f2545-9a44-41d1-836d-40a32dca9e46)

  2. update_manifest.json 갱신
     ```cmd
     python generate_manifest.py
     
  3. 결과

     ![스크린샷 2025-06-17 205653](https://github.com/user-attachments/assets/c0a43002-c9d0-4824-ab35-5fc111978bf9)

     version.txt, update_manifest.json 파일 확인
