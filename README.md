# 개요


개인 PC에 설치되는 ‘사용자 프로그램’을 통해서 개인 PC 파일에 대한 정보를 수집한다. 수집된 데이터는 분석하기 위해 지능(AI) 서버로 전송되며, AI는 학습된 모델을 통해 각 파일의 위험성을 판단한다.  결과는 다시 사용자 프로그램으로 반환되며, 판단된 데이터에 따라 사용자 PC에서 특정 이벤트가 발생한다. 예를 들어, 악성 파일로 판단된 경우 경고 메시지를 출력하거나 삭제 등의 대응이 이루어진다. 이를 통해 제로 데이 공격과 같은 기존 방식으로 탐지하기 어려운 악성 프로그램도 효과적으로 감지하고 방지할 수 있도록 설계되었다.  프로젝트는 AI 기반 악성 코드 탐지 기술의 실용 가능성을 검증하고, 사용자 단위의 능동적인 보안 대응 시스템 구축에 기여하는 것을 목표로 한다.


<br/>

# 목표


디지털화가 가속화됨에 따라 사이버 공격의 빈도와 피해 규모가 지속적으로 증가하고 있다. 특히, 랜섬웨어와 같은 악성 프로그램은 사용자 시스템을 감염시켜 데이터를 암호화하고, 이를 인질로 삼아 금전을 요구하는 방식으로 막대한 피해를 초래하고 있다. 이러한 위협에 대응하기 위해 악성 프로그램을 탐지하고 차단하는 방어 시스템의 중요성이 점점 더 부각되고 있다.
기존 백신 프로그램은 주로 시그니처 기반 방식으로, 이미 알려진 악성 코드의 특징을 데이터베이스에 저장하고 이를 기반으로 탐지 및 차단을 수행한다. 그러나 이 방식은 새로운 형태의 악성 코드, 즉 제로 데이(Zero-day) 공격에 취약하다는 한계가 있다. 새롭게 등장한 악성 코드는 기존 데이터베이스에 정보가 없기 때문에 탐지가 어렵고, 그로 인해 피해가 확산될 가능성이 높다.
이에 따라 인공지능을 활용한 악성 코드 탐지 기술이 주목받고 있다. AI는 대량의 악성 코드 데이터를 학습하여 패턴을 분석하고, 이를 바탕으로 기존에 없던 새로운 악성 프로그램이라도 유사한 행위나 구조를 보이는 경우 이를 탐지할 수 있다. 이러한 기술은 제로 데이 공격에 대한 대응력을 높이고, 사이버 보안 체계 전반의 대응 효율성을 향상시킬 수 있다.
따라서 본 연구에서는 AI 기반 악성 코드 탐지 기술의 가능성과 효과를 분석하고, 이를 통해 보다 강력한 사이버 보안 체계 구축에 기여하고자 한다.


<br/>

# 팀원
<table>
  <tbody>
    <tr>
      <td align="center"><img src="https://github.com/user-attachments/assets/baaa9881-2803-4d49-b961-5f7f71e55d3e" width="100px;" alt=""/><br /><sub><b>팀장 : 이재원</b></sub></a><br /></td>
      <td align="center"><img src="https://github.com/user-attachments/assets/baaa9881-2803-4d49-b961-5f7f71e55d3e" width="100px;" alt=""/><br /><sub><b>팀원 : 박태현</b></sub></a><br /></td>
      <td align="center"><img src="https://github.com/user-attachments/assets/baaa9881-2803-4d49-b961-5f7f71e55d3e" width="100px;" alt=""/><br /><sub><b>팀원 : 윤대영</b></sub></a><br /></td>
      <td align="center"><img src="https://github.com/user-attachments/assets/baaa9881-2803-4d49-b961-5f7f71e55d3e" width="100px;" alt=""/><br /><sub><b>팀원 : 이재원</b></sub></a><br /></td>
     <tr/>
  </tbody>
</table>


<br/>

# 개발환경




|내용|설명|
|------|---|
|Program Language|Python, C#|
|Framework|.Net, Flask|
|Database|MySQL|
|Develop Tool|Visual Studio 2022, VS Code|


<br/>

# 흐름도


![Image](https://github.com/user-attachments/assets/26396b50-06a9-47bf-86cf-4f2fb84d7bb2)


<br/>

# 설치 방법


각 폴더 별 README 참고


*DB 데이터 셋은 타 기관에서 받아온 것으로 따로 첨부하지 않겠습니다.
