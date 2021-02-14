using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;

namespace XDS
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        
        private void button1_Click(object sender, EventArgs e)
        {
            XmlDocument doc = new XmlDocument();
            XmlElement Node = doc.CreateElement("patients");
            doc.AppendChild(Node);
            XmlElement Node0_1 = doc.CreateElement("patient");
            Node0_1.SetAttribute("ID", "1001");
            doc.DocumentElement.AppendChild(Node0_1);
            XmlElement Node0_2 = doc.CreateElement("Name");
            Node0_2.InnerText = "张三";
            Node0_1.AppendChild(Node0_2);
            XmlElement Node0_3 = doc.CreateElement("gender");
            Node0_3.InnerText = "男";
            Node0_1.AppendChild(Node0_3);
            XmlElement Node0_4 = doc.CreateElement("birthday");
            Node0_1.AppendChild(Node0_4);
            XmlElement Node0_5 = doc.CreateElement("year");
            Node0_5.InnerText = "2008";
            Node0_4.AppendChild(Node0_5);
            XmlElement Node0_6 = doc.CreateElement("month");
            Node0_6.InnerText = "8";
            Node0_4.AppendChild(Node0_6);
            XmlElement Node0_7 = doc.CreateElement("day");
            Node0_7.InnerText = "18";
            Node0_4.AppendChild(Node0_7);

            XmlElement Node1_1 = doc.CreateElement("patient");
            Node1_1.SetAttribute("ID", "1002");
            doc.DocumentElement.AppendChild(Node1_1);
            XmlElement Node1_2 = doc.CreateElement("Name");
            Node1_2.InnerText = "李四";
            Node1_1.AppendChild(Node1_2);
            XmlElement Node1_3 = doc.CreateElement("gender");
            Node1_3.InnerText = "男";
            Node1_1.AppendChild(Node1_3);
            XmlElement Node1_4 = doc.CreateElement("birthday");
            Node1_1.AppendChild(Node1_4);
            XmlElement Node1_5 = doc.CreateElement("year");
            Node1_5.InnerText = "2010";
            Node1_4.AppendChild(Node1_5);
            XmlElement Node1_6 = doc.CreateElement("month");
            Node1_6.InnerText = "5";
            Node1_4.AppendChild(Node1_6);
            XmlElement Node1_7 = doc.CreateElement("day");
            Node1_7.InnerText = "8";
            Node1_4.AppendChild(Node1_7);
            doc.Save("C:/Users/usst/Desktop/hl7Handler/test1.xml");

            richTextBox1.Text = doc.OuterXml;
        }
        

        private void button2_Click_1(object sender, EventArgs e)
        {
            XmlDocument doc = new XmlDocument();
            XmlNamespaceManager nsmgr = new XmlNamespaceManager(doc.NameTable);
            nsmgr.AddNamespace("query", "urn:oasis:names:tc:ebxml-regrep:xsd:query:3.0");

            XmlElement Node = doc.CreateElement("query", "AdhocQueryRequest", nsmgr.LookupNamespace("query"));
            Node.SetAttribute("xmlns:xsi", "http://www.w3.org/2001/XMLSchema-instance");
            Node.SetAttribute("xmlns:rim", "urn:oasis:names:tc:ebxml-regrep:xsd:rim:3.0");
            Node.SetAttribute("xmlns:rs", "urn:oasis:names:tc:ebxml-regrep:xsd:rs:3.0");
            doc.AppendChild(Node);

            XmlElement Node1 = doc.CreateElement("query", "ResponseOption", nsmgr.LookupNamespace("query"));
            Node1.SetAttribute("returnComposedObjets", "true");
            Node1.SetAttribute("returnType", "LeafClass");
            Node.AppendChild(Node1);

            XmlElement Node2 = doc.CreateElement("AdhocQuery");
            Node2.SetAttribute("id", "urn:uuid:5c4f972b-d56b-40ac-a5fc-c8ca9b40b9d4");
            Node.AppendChild(Node2);
            XmlElement Node3 = doc.CreateElement("Slot");
            Node3.SetAttribute("name", "$XDSDocumentEntryUniqueId");
            Node2.AppendChild(Node3);
            XmlElement Node4 = doc.CreateElement("ValueList");
            Node3.AppendChild(Node4);
            XmlElement Node5 = doc.CreateElement("Value");
            Node5.InnerText = "('$uniqueId07')";
            Node4.AppendChild(Node5);

            richTextBox1.Text = doc.OuterXml;
        }
    }
}
