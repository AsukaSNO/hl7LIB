using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using hl7Handler;

namespace HL7Test
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            messageFactory factory = new messageFactory();
            ACK msg = factory.Create(null, enumMessage.ACK, "ACK") as ACK;
            
            msg.msh.FieldSeparator.Value = "|";
            msg.msh.EncodingCharacters.Value = "^~\\&";
            msg.msh.DateTimeOfMessage.Value = DateTime.Now.ToString("yyyyMMddhhmmss.fff");

            msg.msh.MessageType.messagetype.Value = "ACK";
            msg.msh.MessageType.triggerevent.Value = "A01";
            msg.msh.MessageType.messagestructure.Value = "ACK_A01";
            //msg.msh.MessageType.MessageStructure.Value = "ACK^A01^ACK_A01";

            msg.msh.MessageControlID.Value = "A00002";
            msg.msh.ProcessingID.processingID.Value = "P";
            msg.msh.VersionID.versionID.Value = "2.4";

            msg.msa.AcknowledgmentCode.Value = "AA";
            msg.msa.MessageControlID.Value = "MSG00001";
            msg.msa.TextMessage.Value = "Success";

            richTextBox1.Text = msg.ToString(); //i in data 是segment类，value为null。
        }

        private void button2_Click(object sender, EventArgs e)
        {
            messageFactory factory = new messageFactory();
            ACK msg = factory.Create(null, enumMessage.ACK, "ACK") as ACK;

            msg.Parse("MSH|^~\\&|HIS|00001|LIS|1234|2004112754000||ACK^A01^ACK_A01|0200002|P|2.4\rMSA|AE|0200001|type   error|||102\r");
            richTextBox1.Text = msg.ToString(); //txtMessage
            richTextBox2.Text = msg.msa.MessageControlID.Value; //txtMsgControllID
            richTextBox1.Text = msg.msa.TextMessage.Value;
        }
    }
}
