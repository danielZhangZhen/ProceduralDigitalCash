using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WFDigitalCash
{
    public partial class Form1 : Form
    {
        private EServerState serverState;

        public Form1()
        {
            InitializeComponent();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {


            textBox1.Text = comboBox1.Text;
            serverState = (EServerState)comboBox1.SelectedIndex;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string json = string.Empty;
            switch (serverState)
            {

                case EServerState.eHuobi:
                    HuoBiAPIMgr huobiApi = new HuoBiAPIMgr();
                    json = huobiApi.GetCommonSymbols();
                    break;
                case EServerState.eOKcoin:
                    break;
                case EServerState.eBian:
                    break;
                default:
                    break;
            }
            textBox1.Text = !string.IsNullOrEmpty(json) ? json : "null";
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            textBox1.Text = comboBox1.Text;
            serverState = (EServerState)comboBox1.SelectedIndex;
        }
    }


    public enum EServerState
    {
        eHuobi = 0,
        eOKcoin = 1,
        eBian = 2
    }
}
