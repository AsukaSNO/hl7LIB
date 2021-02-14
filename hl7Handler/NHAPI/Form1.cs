using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using NHapi.Base;
using NHapi.Base.Parser;
using NHapi.Base.Model;
using NHapi.Model.V231;
using NHapi.Model.V231.Message;
using NHapi.Model.V231.Segment;
using NHapi.Model.V24;

namespace NHAPI
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string message = "MSH|^`\\&|HIS||DRAGONRIS||201206291130||ADT^A01|MSG00005|P|2.3.1|<cr>EVN|A01|201206291130|||0148^Addison^James|201206281130<cr>PID|||263656||Jhons^Dap||19770121|M|||121 Sunrise Street^First Hospital||(019)62256622<cr>";
            PipeParser parser = new PipeParser();
            IMessage m = parser.Parse(message);
            ADT_A01 adtA01 = m as ADT_A01;
            //richTextBox1.Text = adtA01.MSH.MessageControlID.Value;
            richTextBox1.Text = adtA01.PID.GetPatientName(0).FamilyLastName.FamilyName.Value;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            PipeParser parser = new PipeParser();
            Message.ADT_A04 a04 = new Message.ADT_A04();
            a04.MSH.MessageType.MessageType.Value = "ADT";
            a04.MSH.MessageType.TriggerEvent.Value = "A04";
            a04.MSH.MessageType.MessageStructure.Value = "ACK_A04";
        }
    }
}
