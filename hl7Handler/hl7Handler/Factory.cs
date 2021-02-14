using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace hl7Handler
{
    public enum enumMessage { ACK, A01, A02, A03, A04, MSA, EVN, MSH, PID, ERR, PV1, OBR, ORC, HD, XCN, VID, PT, CE, DR, PN, FN, CM, ID, TS, IS, NM, ST, SI, DT, TM, TX, TN, FT, CWE, MSG};
    
    public abstract class abstractFactory
    {
        public abstract abstractType Create(compositeType parent, enumMessage product, string name);
    }

    public class messageFactory : abstractFactory
    {
        public override abstractType Create(compositeType parent, enumMessage product, string name)
        {
            if (product == enumMessage.ACK)
                return new ACK();
            else if (product == enumMessage.A01)
                return new A01();
            else if (product == enumMessage.A02)
                return new A02();
            else if (product == enumMessage.A03)
                return new A03();
            else if (product == enumMessage.A04)
                return new A04();
            else
                return null;
        }
    }
    public class segmentFactory : abstractFactory
    {
        public override abstractType Create(compositeType parent, enumMessage product, string name)
        {
            if (product == enumMessage.MSA)
                return new MSA(parent);
            else if (product == enumMessage.EVN)
                return new EVN(parent);
            else if (product == enumMessage.MSH)
                return new MSH(parent);
            else if (product == enumMessage.PID)
                return new PID(parent);
            else if (product == enumMessage.ERR)
                return new ERR(parent);
            else if (product == enumMessage.PV1)
                return new PV1(parent);
            else if (product == enumMessage.OBR)
                return new OBR(parent);
            else if (product == enumMessage.ORC)
                return new ORC(parent);
            else
                return null;
        }
    }
    public class fieldFactory : abstractFactory
    {
        private primitiveFactory factory;

        public override abstractType Create(compositeType parent, enumMessage product, string name)
        {
            if (product == enumMessage.HD)
                return new HD(parent, name);
            else if (product == enumMessage.XCN)
                return new XCN(parent, name);
            else if (product == enumMessage.VID)
                return new VID(parent, name);
            else if (product == enumMessage.PT)
                return new PT(parent, name);
            else if (product == enumMessage.CE)
                return new CE(parent, name);
            else if (product == enumMessage.DR)
                return new DR(parent, name);
            else if (product == enumMessage.PN)
                return new PN(parent, name);
            else if (product == enumMessage.FN)
                return new FN(parent, name);
            else if (product == enumMessage.CM)
                return new CM(parent, name);
            else if (product == enumMessage.MSG)
                return new MSG(parent, name);
            else
                return null;
        }
        
    }
    public class primitiveFactory : abstractFactory
    {
        public override abstractType Create(compositeType parent, enumMessage product, string name)
        {
            if (product == enumMessage.ID)
                return new ID(name);
            else if (product == enumMessage.TS)
                return new TS(name);
            else if (product == enumMessage.IS)
                return new IS(name);
            else if (product == enumMessage.NM)
                return new NM(name);
            else if (product == enumMessage.ST)
                return new ST(name);
            else if (product == enumMessage.SI)
                return new SI(name);
            else if (product == enumMessage.DT)
                return new DT(name);
            else if (product == enumMessage.TM)
                return new TM(name);
            else if (product == enumMessage.TX)
                return new TX(name);
            else if (product == enumMessage.TN)
                return new TN(name);
            else if (product == enumMessage.FT)
                return new FT(name);
            else if (product == enumMessage.CWE)
                return new CWE(name);
            else
                return null;
        }
    }
}
