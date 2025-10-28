using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;
using System.Text.RegularExpressions;
using System.Runtime.InteropServices;

namespace _03Radiograbber
{
    public partial class Form1 : Form
    {




        private CancellationTokenSource radioCts;
        private string lastTrack = "";
        DateTime delay1 = DateTime.Now;
        int count1 = 0;


        // словарь соответствий URL → файл
        private Dictionary<string, string> urlToFile = new();

        public Form1()
        {
            InitializeComponent();



            // добавляем путь Загрузок Windows в комбобокс
            comboBox7.Items.Add(GetDownloadsPath());

        }


        private string FormatSessionTime(TimeSpan ts)
        {
            return $"{(int)ts.TotalHours}:{ts.Minutes:D2}";
        }







        // ищем путь Загрузок Windows чтобы потом добавить в комбобокс
       
    [DllImport("shell32.dll")]
    private static extern int SHGetKnownFolderPath(
    [MarshalAs(UnmanagedType.LPStruct)] Guid rfid,
    uint dwFlags,
    IntPtr hToken,
    out IntPtr ppszPath);

    private static readonly Guid FolderDownloads =
        new Guid("374DE290-123F-4565-9164-39C4925E467B");

    public static string GetDownloadsPath()
    {
        SHGetKnownFolderPath(FolderDownloads, 0, IntPtr.Zero, out var outPath);
        string path = Marshal.PtrToStringUni(outPath);
        Marshal.FreeCoTaskMem(outPath);
        return path;
    }




















        private async Task MonitorRadioStream(string url, string saveFolder, ProgressBar progressBar, Control statusControl, CancellationToken token)
        {
            DateTime startTime = DateTime.Now;
            string filePath = Path.Combine(saveFolder, comboBox12.Text);
            await File.AppendAllTextAsync(filePath, $"-------  {DateTime.Now.ToString("dd.MM.yyyy HH:mm")}  ({comboBox11.Text}) {Environment.NewLine}");

            progressBar.Style = ProgressBarStyle.Marquee;
            comboBox11.Enabled = false;
            comboBox7.Enabled = false;
            button11.Enabled = false;
            comboBox12.Enabled = false;

            string lastTitle = "";

            while (!token.IsCancellationRequested)
            {
                try
                {
                    using var client = new HttpClient();
                    client.DefaultRequestHeaders.Add("Icy-MetaData", "1");
                    using var response = await client.GetAsync(url, HttpCompletionOption.ResponseHeadersRead, token);
                    response.EnsureSuccessStatusCode();


                    if (!response.Headers.TryGetValues("icy-metaint", out var metaintValues))
                    {
                        statusControl.Invoke(() => statusControl.Text = "Absent icy-metaint");
                    }
                    else
                    {
                        int metaInt = int.Parse(metaintValues.First());
                        using var stream = await response.Content.ReadAsStreamAsync(token);

                        // пропускаем блок аудио
                        byte[] audioBuffer = new byte[metaInt];
                        int totalRead = 0;
                        while (totalRead < metaInt)
                        {
                            int read = await stream.ReadAsync(audioBuffer, totalRead, metaInt - totalRead, token);
                            if (read <= 0) throw new Exception("Stream is closed");
                            totalRead += read;
                        }

                        // читаем метаданные
                        int metaLength = stream.ReadByte();
                        if (metaLength > 0)
                        {
                            int metaDataBytes = metaLength * 16;
                            byte[] metaBuffer = new byte[metaDataBytes];
                            int metaRead = 0;
                            while (metaRead < metaDataBytes)
                            {
                                int read = await stream.ReadAsync(metaBuffer, metaRead, metaDataBytes - metaRead, token);
                                if (read <= 0) throw new Exception("Error reading Metadata");
                                metaRead += read;
                            }

                            string metaString = Encoding.UTF8.GetString(metaBuffer);
                            var match = Regex.Match(metaString, "StreamTitle='(.*?)';");
                            if (match.Success)
                            {
                                string currentTitle = match.Groups[1].Value.Trim();

                                if (!string.IsNullOrEmpty(currentTitle) && currentTitle != lastTitle)
                                {
                                    lastTitle = currentTitle;
                                    await File.AppendAllTextAsync(filePath, currentTitle + Environment.NewLine);
                                    statusControl.Invoke(() => statusControl.Text = currentTitle);

                                    toolStripStatusLabel2.Text = "Last update: " + DateTime.Now.ToString("HH:mm");
                                    delay1 = DateTime.Now;
                                    toolStripStatusLabel2.ForeColor = Color.Gray; // меняем цвет текста на стандартный
                                    count1 = count1 + 1;
                                    toolStripStatusLabel5.Text = $"Titles saved: {count1}";

                                    this.Invoke(() =>
                                    {
                                        this.SelectNextControl(textBox15, true, true, true, true); // переаодим фокус обратно на кнопку
                                    });

                                }
                            }
                        }
                    }

                    // обновляем время сессии каждую минуту
                    TimeSpan sessionTime = DateTime.Now - startTime;
                    toolStripStatusLabel12.Text = "Session time: " + FormatSessionTime(sessionTime);

                    // ждем минуту
                    await Task.Delay(TimeSpan.FromMinutes(1), token);
                }
                catch (TaskCanceledException)
                {
                    statusControl.Invoke(() => statusControl.Text = "Stopped");
                    progressBar.Style = ProgressBarStyle.Blocks;
                    comboBox11.Enabled = true;
                    comboBox7.Enabled = true;
                    button11.Enabled = true;
                    comboBox12.Enabled = true;
                    return;
                }
                catch (Exception ex)
                {
                    statusControl.Invoke(() => statusControl.Text = "Error: " + ex.Message);
                    await Task.Delay(TimeSpan.FromMinutes(1), token);
                }

                if (DateTime.Now - delay1 > TimeSpan.FromMinutes(20))
                {
                    toolStripStatusLabel2.ForeColor = Color.Red; // меняем цвет текста если 20 мин нет нового тега
                }

            }
        }


        private async void button11_Click_1(object sender, EventArgs e)
        {

            using var folderDialog = new FolderBrowserDialog
            {
                Description = "Select the Folder for saving"
            };

            if (folderDialog.ShowDialog() == DialogResult.OK)
            {
                comboBox7.Text = folderDialog.SelectedPath;
            }
        }

        private async void button12_Click_1(object sender, EventArgs e)
        {
            if (radioCts == null)
            {
                if (string.IsNullOrWhiteSpace(comboBox11.Text))
                {
                    MessageBox.Show("Enter URL to radio stream");
                    return;
                }
                if (string.IsNullOrWhiteSpace(comboBox7.Text))
                {
                    MessageBox.Show("Enter the Folder for saving");
                    return;
                }
                if (string.IsNullOrWhiteSpace(comboBox12.Text))
                {
                    MessageBox.Show("Enter File Name to saving");
                    return;
                }



                button12.Text = "Stop";
                radioCts = new CancellationTokenSource();
                await MonitorRadioStream(comboBox11.Text, comboBox7.Text, progressBar11, textBox15, radioCts.Token);
            }
            else
            {
                radioCts.Cancel();
                radioCts = null;
                button12.Text = "Run";
            }



        }

        private async void button1_Click(object sender, EventArgs e)
        {
            string folderPath = comboBox7.Text;
            string fileName = comboBox12.Text;
            string filePath = Path.Combine(folderPath, fileName);

            if (File.Exists(filePath))
            {
                // открываем папку и выделяем файл
                System.Diagnostics.Process.Start("explorer.exe", $"/select,\"{filePath}\"");
            }
            else if (Directory.Exists(folderPath))
            {
                // если файла нет — просто открываем папку
                System.Diagnostics.Process.Start("explorer.exe", folderPath);
            }
            else
            {
                MessageBox.Show("Directory not found");
            }
        }

        // теперь только URL → файл
        private void comboBox11_SelectedIndexChanged(object sender, EventArgs e)
        {
            string url = comboBox11.Text;
            if (urlToFile.ContainsKey(url))
            {
                comboBox12.Text = urlToFile[url];
            }
        }

        private void ComboBox12_TextChanged(object sender, EventArgs e)
        {
            string iis = comboBox12.Text;
            switch (iis)
            {
                case "Radio_log_Svobodnoe.txt":
                    jrock.Visible = false;
                    svobodnoe.Visible = true;
                    break;

                case "Radio_log_JRock.txt":
                    jrock.Visible = true;
                    svobodnoe.Visible = false;
                    break;

                default:
                    jrock.Visible = false;
                    svobodnoe.Visible = false;
                    break;
            }
        }

        // загрузка Setup.ini
        private void Form1_Load(object sender, EventArgs e)
        {

            string iniPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Settings.ini");

            if (!File.Exists(iniPath))
            {
                MessageBox.Show("Settings.ini not found");
                return;
            }

            string currentSection = "";
            foreach (var rawLine in File.ReadAllLines(iniPath))
            {
                string trimmed = rawLine.Trim();

                // пропускаем пустые строки и комментарии (#, ;, //)
                if (string.IsNullOrWhiteSpace(trimmed) ||
                    trimmed.StartsWith("#") ||
                    trimmed.StartsWith(";") ||
                    trimmed.StartsWith("//"))
                    continue;

                // секция [ ... ]
                if (trimmed.StartsWith("[") && trimmed.EndsWith("]"))
                {
                    currentSection = trimmed.Trim('[', ']');

                    // если это файл .txt → добавляем в список файлов
                    if (currentSection.EndsWith(".txt", StringComparison.OrdinalIgnoreCase))
                    {
                        if (!comboBox12.Items.Contains(currentSection))
                            comboBox12.Items.Add(currentSection);
                    }
                    continue;
                }

                // обработка параметров внутри секций
                if (currentSection.Equals("destination", StringComparison.OrdinalIgnoreCase))
                {
                    if (trimmed.StartsWith("path=", StringComparison.OrdinalIgnoreCase))
                    {
                        // добавляем путь из Setup.ini в комбобокс текстом
                        comboBox7.Text = trimmed.Substring("path=".Length).Trim();
                        // добавляем путь из Setup.ini в список комбобокса
                        comboBox7.Items.Add(trimmed.Substring("path=".Length).Trim());
                    }
                }
                else if (currentSection.EndsWith(".txt", StringComparison.OrdinalIgnoreCase))
                {
                    if (trimmed.StartsWith("url=", StringComparison.OrdinalIgnoreCase))
                    {
                        string url = trimmed.Substring("url=".Length).Trim();

                        if (!comboBox11.Items.Contains(url))
                            comboBox11.Items.Add(url);

                        // сохраняем связь URL → файл
                        urlToFile[url] = currentSection;
                    }
                }
            }

            // выбираем первый элемент только один раз, если он есть
            if (comboBox12.Items.Count > 0)
                comboBox12.SelectedIndex = 0;
        }

        private void textBox15_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            textBox15.SelectAll();
        }

      
    }
}


















































