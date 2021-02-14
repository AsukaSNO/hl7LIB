using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace hl7Handler
{
    public static class common
    {
        public static string version = "2.4";
        public static string segmentDelimiter = "\r";
        public static string fieldDelimiter = "|";
        public static string componentDelimiter = "^";
        public static string subComponentDelimiter = "&";
        public static string repeatDelimiter = "~";
        public static string escapeDelimiter = "\\";
    }
    public abstract class abstractType
    {
        protected string name;
        protected string value;

        public abstractType(string name)
        {
            this.name = name;
        }

        public string Name
        {
            get {
                return name;
            }
        }

        public string Value
        {
            get
            {
                return value;
            }
            set
            {
                this.value = value;
            }
        }

        public string Version
        {
            get => ToString();
            set => Parse(value);
        }

        public abstract bool Parse(string text);

        public abstract string ToString();
    }
    public class primitiveType : abstractType
    {
        public primitiveType(string name) : base(name)
        {
            //;
        }

        public override bool Parse(string text)
        {
            value = text;
            return true;
        }

        public override string ToString()
        {
            return value;
        }
    }

    public class compositeType : abstractType
    {
        protected abstractType[] data;//子组件
        private string delimiter;

        public compositeType(compositeType parent,string name) : base(name)
        {
            if (parent == null)
                delimiter = common.segmentDelimiter;
            else if (parent.delimiter == common.segmentDelimiter)
                delimiter = common.fieldDelimiter;
            else if (parent.delimiter == common.fieldDelimiter)
                delimiter = common.componentDelimiter;
            else if (parent.delimiter == common.componentDelimiter)
                delimiter = common.subComponentDelimiter;
        }

        public override bool Parse(string text)
        {
            try
            {
                //text用本容器的分隔符分割
                //string[] childText = Regex.Split(text, delimiter, RegexOptions.IgnoreCase);

                //foreach (abstractType i in data)
                //{
                //    i.Parse(text);
                //}
                //return true;
                string[] subs = text.Split(delimiter[0]);
                //for (int i = 0; i < subs.Length; i++)
                //{
                //    if (subs[i] == null || subs[i].Length == 0) continue;
                //    data[i].Parse(subs[i]);
                //}
                value = text;
                value = "ABC\r123";
                return true;
            }
            catch
            {
                return false;
            }
        }

        public override string ToString()
         {
            string all = "";
            if(data != null) { 
                foreach (abstractType i in data)
                {
                    if (i == null)
                    {
                        Console.WriteLine("Stop");
                    }
                    all += i.ToString();
                }
            }
            all += delimiter;
            return all;
        }
    }

    

}
