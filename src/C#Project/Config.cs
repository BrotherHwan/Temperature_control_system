using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace C_Project
{
    public partial class Config : Form
    {
        public Config()
        {
            InitializeComponent();            
            string[] sarr = System.IO.Ports.SerialPort.GetPortNames();//Port이름 배열로 다 받고
            for (int i = 0; i < sarr.Length; i++) cbCom.Items.Add(sarr[i]); //COM 콤보박스에 하나씩 아이템스에 추가.
            cbCom.Text = "COM20";
            cbBaud.Text = "115200";
            cbParity.Text = "None";
            cbData.Text = "8";
            cbStop.Text = "1 - One";
        }
    }
}
