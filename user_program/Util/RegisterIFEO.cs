using Microsoft.Win32;
using System;
using System.IO;
using System.Text;
using System.Windows.Forms;

namespace user_program.Util
{
    //애매한 파일 레지스트리 변경시키는 코드
    public static class RegisterIFEO
    {
        public static void RegisterWarnListToIFEO()
        {
            string baseDir = AppDomain.CurrentDomain.BaseDirectory;
            string warnlistPath = Path.Combine(baseDir, "warnlist.csv");
            string wrapperPath = Path.Combine(baseDir, "wrapper.exe");

            if (!File.Exists(warnlistPath))
            {
                MessageBox.Show("warnlist.csv를 찾을 수 없습니다.");
                return;
            }

            if (!File.Exists(wrapperPath))
            {
                MessageBox.Show("wrapper.exe를 찾을 수 없습니다.");
                return;
            }

            var lines = File.ReadAllLines(warnlistPath, Encoding.UTF8);
            if (lines.Length <= 1)
            {
                MessageBox.Show("warnlist.csv에 등록된 항목이 없습니다.");
                return;
            }

            foreach (var line in lines[1..])
            {
                var parts = line.Split(',');
                if (parts.Length < 2) continue;

                string exeName = parts[0].Trim('"').Trim();
                string fullPath = parts[1].Trim('"').Trim();

                if (string.IsNullOrWhiteSpace(exeName) || string.IsNullOrWhiteSpace(fullPath))
                    continue;

                try
                {
                    // 기존 등록 제거 (중복 방지)
                    Registry.LocalMachine.OpenSubKey(
                        @"SOFTWARE\Microsoft\Windows NT\CurrentVersion\Image File Execution Options",
                        writable: true
                    )?.DeleteSubKeyTree(exeName, false);

                    // 새로 등록
                    using (var key = Registry.LocalMachine.CreateSubKey(
                        $@"SOFTWARE\Microsoft\Windows NT\CurrentVersion\Image File Execution Options\{exeName}",
                        true))
                    {
                        if (key != null)
                        {
                            string debuggerValue = $"\"{wrapperPath}\" \"{fullPath}\"";
                            key.SetValue("Debugger", debuggerValue);

                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"❌ {exeName} 등록 실패:\n{ex.Message}");
                }
            }

        }
    }
}
