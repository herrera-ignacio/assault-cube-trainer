using System;
using System.Windows.Forms;
using Memory;

namespace actrainer
{
    public partial class Form1 : Form
    {
        Mem meme = new Mem();

        // "ac_client.exe"+00109B74 + 13C
        string ammoAddress = "ac_client.exe+0x00109B74,13C";
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            int PID = meme.GetProcIdFromName("ac_client");

            if (PID > 0) // Game opened
            {
                meme.OpenProcess(PID);
                ammoTimer.Start();
            }
        }

        private void ammoTimer_Tick(object sender, EventArgs e)
        {
            if (ammoCheckbox.Checked)
            {
                meme.WriteMemory(ammoAddress, "int", "9999999");
            }
        }
    }
}
