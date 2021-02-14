using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace hl7Handler
{
    public class ID : primitiveType
    {
        public ID(string name) : base(name)
        {

        }
        public override bool Parse(string text)
        {
            value = text;
            Regex reg = new Regex(@"[\u4e00-\u9fa5]");
            this.Value = reg.Replace(value, "");
            return true;
        }
        public override string ToString()
        {
            return this.Value;
        }
    }
    public class TS : primitiveType
    {
        public TS(string name) : base(name)
        {

        }
        public override bool Parse(string text)
        {
            value = text;
            Regex reg = new Regex(@"[\u4e00-\u9fa5]");
            this.Value = reg.Replace(value, "");
            return true;
        }
    }
    public class IS : primitiveType
    {
        public IS(string name) : base(name)
        {

        }
        public override bool Parse(string text)
        {
            value = text;
            Regex reg = new Regex(@"[\u4e00-\u9fa5]");
            this.Value = reg.Replace(value, "");
            return true;
        }

    }
    public class NM : primitiveType
    {
        public NM(string name) : base(name)
        {

        }
        public override bool Parse(string text)
        {
            value = text;
            Regex reg = new Regex(@"[\u4e00-\u9fa5]");
            this.Value = reg.Replace(value, "");
            return true;
        }

    }
    public class ST : primitiveType
    {
        public ST(string name) : base(name)
        {

        }
        public override bool Parse(string text)
        {
            value = text;
            Regex reg = new Regex(@"[\u4e00-\u9fa5]");
            this.Value = reg.Replace(value, "");
            return true;
        }
        public override string ToString()
        {
            return this.value;
            //Regex reg = new Regex(@"[\u4e00-\u9fa5]");
            //if (this.Value==null)
            //return reg.Replace(this.value, "");
        }
    }
    public class SI : primitiveType
    {
        public SI(string name) : base(name)
        {

        }
        public override bool Parse(string text)
        {
            value = text;
            Regex reg = new Regex(@"[\u4e00-\u9fa5]");
            this.Value = reg.Replace(value, "");
            return true;
        }

    }
    public class DT : primitiveType
    {
        public DT(string name) : base(name)
        {

        }
        public override bool Parse(string text)
        {
            value = text;
            Regex reg = new Regex(@"[\u4e00-\u9fa5]");
            this.Value = reg.Replace(value, "");
            return true;
        }

    }
    public class TM : primitiveType
    {
        public TM(string name) : base(name)
        {

        }
        public override bool Parse(string text)
        {
            value = text;
            Regex reg = new Regex(@"[\u4e00-\u9fa5]");
            this.Value = reg.Replace(value, "");
            return true;
        }

    }  
    public class TX : primitiveType
    {
        public TX(string name) : base(name)
        {

        }
        public override bool Parse(string text)
        {
            value = text;
            Regex reg = new Regex(@"[\u4e00-\u9fa5]");
            this.Value = reg.Replace(value, "");
            return true;
        }

    }
    public class TN : primitiveType
    {
        public TN(string name) : base(name)
        {

        }
        public override bool Parse(string text)
        {
            value = text;
            Regex reg = new Regex(@"[\u4e00-\u9fa5]");
            this.Value = reg.Replace(value, "");
            return true;
        }

    }
    public class FT : primitiveType
    {
        public FT(string name) : base(name)
        {

        }
        public override bool Parse(string text)
        {
            value = text;
            Regex reg = new Regex(@"[\u4e00-\u9fa5]");
            this.Value = reg.Replace(value, "");
            return true;
        }

    }
    public class CWE : primitiveType
    {
        public CWE(string name) : base(name)
        {

        }
        public override bool Parse(string text)
        {
            value = text;
            Regex reg = new Regex(@"[\u4e00-\u9fa5]");
            this.Value = reg.Replace(value, "");
            return true;
        }

    }
    //public class MSG : primitiveType
    //{
    //    public MSG(string name) : base(name)
    //    {

    //    }
    //    public override bool Parse(string text)
    //    {
    //        value = text;
    //        Regex reg = new Regex(@"[\u4e00-\u9fa5]");
    //        this.Value = reg.Replace(value, "");
    //        return true;
    //    }

    //}

}
