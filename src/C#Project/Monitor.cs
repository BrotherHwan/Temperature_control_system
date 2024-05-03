using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Net.Mime.MediaTypeNames;


namespace C_Project
{
    public partial class Monitor : Form
    {
        public Monitor()
        {
            InitializeComponent();
        }
     
        private void mnuSetup_Click_1(object sender, EventArgs e) //시리얼 연결 설정
        {
            Config frm = new Config();
            frm.ShowDialog();

            serialPort1.Parity = (Parity)frm.cbParity.SelectedIndex;
            serialPort1.DataBits = int.Parse(frm.cbData.Text);
            serialPort1.StopBits = (StopBits)frm.cbStop.SelectedIndex;
            serialPort1.BaudRate = int.Parse(frm.cbBaud.Text); 
            serialPort1.PortName = frm.cbCom.Text;             

            string strComm = $"{frm.cbCom.Text}:{frm.cbBaud.Text}{frm.cbParity.Text[0]}";
            strComm += $"{frm.cbData.Text}{frm.cbStop.SelectedIndex}";

            sbLabel1.Text = strComm ; //status창에 연결타입 표시
        }

        private void mnuRestart_Click_1(object sender, EventArgs e) //시리얼 오픈 및 타이머 스타트
        {
            if (serialPort1.IsOpen)
            {
                serialPort1.Close();
                sbLabel2.Text = $"{serialPort1.PortName} Port Closed.";                
            }
            serialPort1.Open();
            sbLabel2.Text = $"{serialPort1.PortName} Port open sucess!";            

            System.Windows.Forms.Timer timer = new System.Windows.Forms.Timer();
            timer.Interval = 2000; // 2초
            timer.Tick += new EventHandler(timer1_Tick);
            timer.Start();
        }


        string str;
        private void serialPort1_DataReceived(object sender, SerialDataReceivedEventArgs e) //데이터 수신 및 화면 출력
        {           
            try                                                                                                   
            {
                Thread.Sleep(100);
                str = serialPort1.ReadExisting();
                string[] words = str.Split('@'); //@를 기준으로 문자열 나누기

                if (words[0] == "TT" ) //STM32에서 보내주는 현재 온도 데이터를 화면에 출력 
                {                    
                    tbCTem.Text = words[1]; 
                }
                else if (words[0] == "HH") //STM32에서 보내주는 현재 습도 데이터를 화면에 출력
                {                   
                   tbCHum.Text = words[1];
                }
                else if (words[0] == "UU" || words[0] == "DD") //STM32에서 보내주는 희망온도 데이터를 화면에 출력
                {                   
                    tbDTem.Text = words[1];
                }                
           
            }
            catch { }
        }
        private void timer1_Tick(object sender, EventArgs e) //타이머를 이용한 현재 온도,습도 요청
        {
            if (count % 2 == 0)
            {              
                serialPort1.Write("tt");
            }
            else
            {               
                serialPort1.Write("hh");
            }
            count++;
        }
        private void btnTemUp_Click(object sender, EventArgs e) //Up버튼을 통해 희망온도 상승 요청
        {
            serialPort1.Write("uu");
        }

        private void btnTemDown_Click(object sender, EventArgs e) //Down버튼을 통해 희망온도 하강 요청
        {
            serialPort1.Write("dd");
        }
        int count = 0 ;
        

       
    }
}
