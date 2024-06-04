using CsvHelper;
using CsvHelper.Configuration;
using CsvHelper.Configuration.Attributes;
using Microsoft.VisualBasic.Devices;
using Microsoft.WindowsAPICodePack.Dialogs;
using System.Diagnostics;
using System.Dynamic;
using System.Globalization;
using System.IO;
using System.Management;
using System.Runtime.InteropServices;
using static System.Windows.Forms.DataFormats;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Desktop_Resource_Monitor
{
    public partial class Form1 : Form
    {
        bool closing = false;

        public class Usage
        {
            // Name Attribute를 사용하여 매핑할 컬럼명 지정
            [Name("시간")]
            public string Time { get; set; }
            [Name("CPU")]
            public string CPU { get; set; }
            [Name("MEM")]
            public string MEM { get; set; }
        }

        public Form1()
        {
            InitializeComponent();
            CheckForIllegalCrossThreadCalls = false;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            ComboboxItem item0 = new ComboboxItem();
            item0.Text = "1초마다 저장";
            item0.Value = "1";
            comboBox1.Items.Add(item0);

            ComboboxItem item1 = new ComboboxItem();
            item1.Text = "10초마다 저장";
            item1.Value = "10";
            comboBox1.Items.Add(item1);

            ComboboxItem item2 = new ComboboxItem();
            item2.Text = "30초마다 저장";
            item2.Value = "30";
            comboBox1.Items.Add(item2);

            ComboboxItem item3 = new ComboboxItem();
            item3.Text = "1분마다 저장";
            item3.Value = "60";
            comboBox1.Items.Add(item3);

            ComboboxItem item4 = new ComboboxItem();
            item4.Text = "10분마다 저장";
            item4.Value = "600";
            comboBox1.Items.Add(item4);

            comboBox1.SelectedIndex = 1;

            DirectoryInfo di = new DirectoryInfo(Application.StartupPath + @"\Data");
            if (!di.Exists) { di.Create(); }
            textBox1.Text = di.FullName;

            Thread t1 = new Thread(() =>
            {
                while (!closing)
                {
                    string cpuUsage = String.Format("{0:0.##}", GetTotalCpuUsage()) + "%";
                    dynamic memUsage = GetMemUsage();
                    var memUsageText = string.Format("{0}/{1}", memUsage.usage, memUsage.total);
                    label4.Text = cpuUsage;
                    label6.Text = memUsageText;

                    if (checkBox1.Checked)
                    {
                        List<Usage> list = new List<Usage>
                        {
                            new Usage { Time = DateTime.Now.ToString("yyyy.MM.dd HH:mm:ss"), CPU = cpuUsage, MEM = memUsageText },
                        };

                        var config = new CsvConfiguration(CultureInfo.InvariantCulture);
                        config.HasHeaderRecord = false;

                        using (var streamWriter = new StreamWriter(di.FullName + "\\data.csv", append: true))
                        {
                            using (var csvWriter = new CsvWriter(streamWriter, config))
                            {
                                csvWriter.WriteRecords(list);
                            }
                        }
                    }

                    Thread.Sleep(int.Parse((comboBox1.SelectedItem as ComboboxItem).Value.ToString()) * 1000);
                }
            });

            t1.SetApartmentState(ApartmentState.STA);
            t1.Start();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            using (var dialog = new CommonOpenFileDialog())
            {
                dialog.IsFolderPicker = true;
                if (dialog.ShowDialog() == CommonFileDialogResult.Ok)
                {
                    textBox1.Text = dialog.FileName;
                }
            }
        }

        private double GetTotalCpuUsage()
        {
            try
            {
                var wmi = new ManagementObjectSearcher("select * from Win32_PerfFormattedData_PerfOS_Processor where Name != '_Total'");
                var cpuUsages = wmi.Get().Cast<ManagementObject>().Select(mo => (long)(ulong)mo["PercentProcessorTime"]);
                var totalUsage = cpuUsages.Average();

                return (double)totalUsage;
            }
            catch (Exception)
            {
                return 0;
            }
        }

        private dynamic GetMemUsage()
        {
            try
            {
                dynamic returndata = new ExpandoObject();

                var search = new ManagementObjectSearcher("root\\CIMV2", "Select TotalVisibleMemorySize, FreePhysicalMemory from Win32_OPeratingSystem");

                foreach (var x in search.Get())
                {

                    var totalMemory = (ulong)x["TotalVisibleMemorySize"];
                    var freeMemory = (ulong)x["FreePhysicalMemory"];

                    var totalmem = Convert.ToInt32((double)totalMemory / 1024);
                    var freemem = Convert.ToInt32(Math.Round(Convert.ToDecimal((((double)freeMemory / 1024)))));
                    var usedmem = Convert.ToInt32(Math.Round(Convert.ToDecimal((((totalmem - freemem))))));

                    returndata.total = totalmem;
                    returndata.usage = usedmem;
                    returndata.free = freemem;
                }

                return returndata;
            }
            catch (Exception)
            {
                return String.Empty;
            }
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            closing = true;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Process.Start(new ProcessStartInfo()
            {
                FileName = "Explorer.exe",
                Arguments = textBox1.Text
            });
        }
    }
    public class ComboboxItem
    {
        public string Text { get; set; }
        public object Value { get; set; }

        public override string ToString()
        {
            return Text;
        }
    }
}
