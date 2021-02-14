using System;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace RegexTester
{
    public partial class Form1 : Form
    {

        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            richTextBox3.Clear();
            Regex reg = new Regex(richTextBox1.Text);
            if (reg.IsMatch(richTextBox2.Text))
            {
                MatchCollection mc = reg.Matches(richTextBox2.Text);
                for (int i = 0; i < mc.Count; i++)
                {
                    richTextBox3.Text += mc[i].Value + "\r\n";
                    //GroupCollection gc = mc[i].Groups;
                    //for (int j = 0; j < gc.Count; j++)
                    //{
                    //    richTextBox3.Text += "\t\t" + gc[j].Value + "\r\n";
                    //}
                }

            }
        }
        public static string ReplaceUpper(Match match)
        {
            return match.Value.ToUpper();
        }
        private void button2_Click(object sender, EventArgs e)
        {
            richTextBox3.Clear();
            //Regex reg = new Regex(richTextBox1.Text);
            //richTextBox3.Text = reg.Replace(richTextBox2.Text, new MatchEvaluator(ReplaceUpper));
            //richTextBox3.Text = reg.Replace(richTextBox2.Text, (Match m) => { return m.Value.ToUpper; });

        }

        public static string ReplaceNoSpace(Match match)
        {
            return match.Value.ToUpper();
        }
        private void button3_Click(object sender, EventArgs e)
        {

            Regex reg = new Regex(richTextBox1.Text);
            if (reg.IsMatch(richTextBox2.Text))
            {
                MatchCollection mc = reg.Matches(richTextBox2.Text);
                for (int i = 0; i < mc.Count; i++)
                {
                    richTextBox3.Text += mc[i].Value + "\r\n";
                }
            }
            richTextBox3.Clear();
            Regex reg1 = new Regex(@"(?<=[a-zA-Z]\s{" + richTextBox5.Text + @"})[A-Z]{2,3}(?=\b\s{" + richTextBox5.Text + "}[0-9])");
            Regex reg2 = new Regex(@"(?<=\s{" + richTextBox5.Text + @"})[A-Z\sa-z]+(?=\s{" + richTextBox5.Text + "}[A-Z])");
            if (reg1.IsMatch(richTextBox2.Text) && reg2.IsMatch(richTextBox2.Text))
            {
                MatchCollection mcTypes = reg1.Matches(richTextBox2.Text);
                MatchCollection mcComponent = reg2.Matches(richTextBox2.Text);
                
                string str1="", str2="", str3="";
                //str1 前面的字符
                str1 = "public class " + richTextBox4.Text + " : compositeSegment\n{" + 
                    "\n    public " + richTextBox4.Text + "(compositeType parent, string name) : base(parent, name)\n    {\n" + 
                    "\tdata = new abstractType[" + mcTypes.Count + "];\n";  

                //str2 匹配个数的data[i]实例化
                for (int i = 0; i < mcTypes.Count; i++)
                {
                    str2 += "\tdata["+i+"] = new "+ mcTypes[i].Value + "(\"" + mcComponent[i].Value + "\");\n";
                }
                str2 += "    }\n";

                //str3 字段声明
                for (int i = 0; i < mcTypes.Count; i++)
                {
                    str3 += "    public " + mcTypes[i].Value + " " + mcComponent[i].Value.Replace(" ", "") + "\n    {\n" +
                        "\tget { return data[" + i + "] as " + mcTypes[i].Value + ";}\n" +
                        "\tset { data[" + i + "] = value;}\n    }\n";
                }
                str3 += "}\n";
                richTextBox3.Text = str1 + str2 + str3;
            }
        }
    }
}

