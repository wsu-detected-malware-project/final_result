using System.ComponentModel;
using DotNetEnv;
using user_program.Controller;
using user_program.Invest;

namespace user_program.FormAll {
    public partial class Form2 : Form
    {
        private FormController F_controller = FormController.Singleton;
        private PEController PE_controller = PEController.Singleton;
        private NetController Net_controller = NetController.Singleton;
        private bool hasFReadExecuted = false;  // F_Read가 한 번 실행되었는지 확인하는 변수
        private string investType; // 문자열 인자를 저장할 변수
        private bool isFormClosing = false; //form2 X버튼 완전 종료 위한 코드
        public string InvestType => investType;
        private bool hasForm3Shown = false;

        public Form2(string _investType)
        {
            InitializeComponent();
            F_controller.form2 = this;

            investType = _investType;

            this.FormClosing += Form2_FormClosing;
        }

        // 기본 생성자 추가
        public Form2()
        {
            InitializeComponent();
            this.FormClosing += Form2_FormClosing;
        }

        private void Form2_FormClosing(object sender, FormClosingEventArgs e)
        {
            isFormClosing = true; 
        }

        #region 라벨 출력
        [NonSerialized]
        private string _updateVersion;
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]

        public string Update_Version
        {
            get { return _updateVersion; }
            set
            {
                _updateVersion = value.ToString();
                label2.Text = _updateVersion;
            }
        }
        #endregion

        #region 바 이벤트
        bool mouseDown;
        Point lastlocation;
        private void lbl_title_MouseDown(object sender, MouseEventArgs e)
        {
            mouseDown = true;
            lastlocation = e.Location;
        }
        private void lbl_title_MouseUp(object sender, MouseEventArgs e)
        {
            mouseDown = false;
        }

        private void lbl_title_MouseMove(object sender, MouseEventArgs e)
        {
            if (mouseDown)
            {
                this.Location = new Point(
                    (this.Location.X - lastlocation.X) + e.X,
                    (this.Location.Y - lastlocation.Y) + e.Y);

                this.Update();
            }
        }

        private void btn_min_Click(object sender, MouseEventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }
        private void btn_max_Click(object sender, MouseEventArgs e)
        {
            if (this.WindowState == FormWindowState.Normal)
            {
                this.WindowState = FormWindowState.Maximized;
            }
            else
            {
                this.WindowState = FormWindowState.Normal;
            }
        }

        private void btn_close_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btn_close_Click(object sender, MouseEventArgs e)
        {
            this.Close();
        }

        private void tableLayoutPanel2_Paint(object sender, PaintEventArgs e) { }
        #endregion

        private async Task WaitForFileAsync(string path, int maxWait = 60000)
        {
            int waited = 0;
            long previousLength = -1;

            while (waited < maxWait)
            {
                if (File.Exists(path))
                {
                    long length = new FileInfo(path).Length;
                    if (length > 0 && length == previousLength)
                        return;

                    previousLength = length;
                }
                await Task.Delay(500);
            }
            throw new TimeoutException("파일이 안정적으로 저장되지 않았습니다.");
        }

        private async void timer1_Tick(object sender, EventArgs e) 
        {
            if (isFormClosing)
            {
                timer1.Stop();
                return;
            }

            // p_invest는 진행바 값과 상관없이 항상 실행되도록 함
            if ((!hasFReadExecuted && investType == "p_invest") ||
                (progressBar1.Value < progressBar1.Maximum && !hasFReadExecuted))
            {
                if (listBox1.Items.Count == 0)
                {
                    hasFReadExecuted = true;

                    // 비동기로 전환
                    await Task.Run(() =>
                    {
                        if (investType == "f_invest")
                            PE_controller.get_f_invest();
                        else if (investType == "p_invest")
                            PE_controller.get_p_invest();
                        else if (investType == "d_invest")
                            PE_controller.get_d_invest();
                        
                    });


                }
            }

            // 로딩바 진행
            if (progressBar1.Value < progressBar1.Maximum)
            {
                // 진행 중이므로 타이머 유지
                return;
            }

            //로딩 완료 후 다음 단계
            timer1.Stop();  // 타이머 중단

            await Task.Delay(500);
            if (isFormClosing) return;

            bool success = await Net_controller.network();
            if (!success || isFormClosing) return;

            string filePath = Env.GetString("RESULT_PATH", Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "result.csv"));
            if (isFormClosing) return;

            await WaitForFileAsync(filePath, 10000);
            if (isFormClosing) return;

            string[] lines = File.ReadAllLines(filePath);
            string result = "";
            List<string> malwareNames = new List<string>();

            for (int i = 1; i < lines.Length; i++)
            {
                string[] columns = lines[i].Split(',');
                if (columns.Length > 0)
                    malwareNames.Add(columns[0]);
            }

            result = malwareNames.Count == 0 ? "protect" : "malware";

            if (hasForm3Shown) return;
            hasForm3Shown = true;

            this.Hide();
            Form3 form3 = new Form3(result, malwareNames);
            form3.ShowDialog();
        }



        private async void Form2_Load(object sender, EventArgs e)
        {
            string EnvPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, ".env");
            Env.Load(EnvPath);

            string version = Env.GetString("VERSION", "default_version");
            string resultPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "pe_info.csv");

            if (File.Exists(resultPath))
                File.Delete(resultPath);

            F_controller.Update_Version_2(version);

            if (investType == "f_invest")
            {
                // UI 스레드에서 프로그래스바 최대값 설정
                int max = await Task.Run(() => PE_controller.get_system_drive_totalfile());
                progressBar1.Maximum = max;

                //progressBar1.Maximum = PE_controller.get_system_drive_totalfile();
            }
            else if (investType == "d_invest")
            {
                progressBar1.Maximum = PE_controller.get_drive_totalfile();
            }
            else if (investType == "p_invest")
            {
                int max = await Task.Run(() => PE_controller.get_p_invest_totalfile());
                progressBar1.Maximum = Math.Max(max, 1);
            }

            progressBar1.Value = 1;

            // 타이머를 활성화하여 프로세스 시작
            timer1.Interval = 1;
            timer1.Start();

        }

        public ListBox Give_Listbox()
        {
            return listBox1;
        }

        public System.Windows.Forms.ProgressBar Give_progressBar()
        {
            return progressBar1;
        }
        public string GetInvestType()
        {
            return investType;
        }

    }
}