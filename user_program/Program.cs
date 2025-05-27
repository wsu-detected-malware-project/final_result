using user_program.Controller;
using user_program.Util;

namespace user_program.FormAll{
    static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            ApplicationConfiguration.Initialize();
            
            string[] args = Environment.GetCommandLineArgs();


            bool startedFromWindows = args.Any(arg => arg.Contains("/background")); // ← Windows 시작 시 배경 모드로 실행될 경우

            Form1 mainForm = new Form1();
            if (startedFromWindows)
            {
                mainForm.Hide(); // 백그라운드 실행일 경우 숨김
            }
            else
            {
                mainForm.Show(); // 직접 실행한 경우 보임
            }

            UtilController.CheckAndUpdate();

            Application.Run(mainForm);
        }    
    }
}


