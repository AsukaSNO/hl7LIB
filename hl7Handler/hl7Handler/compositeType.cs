using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace hl7Handler
{
    public class compositeMessage : compositeType
    {
        public compositeMessage(compositeType cT, string name) : base(cT, name)
        {

        }
        public override bool Parse(string text)
        {
            try
            {
                text = text.Replace(this.Name, "");
                base.Parse(text);
                return true;
            }
            catch
            {
                return false;
            }
        }
        public override string ToString()
        {
            return this.Name + base.ToString();
        }
    }
    public class compositeSegment : compositeType
    {
        public compositeSegment(compositeType cT, string name) : base(cT, name)
        {

        }
        public override bool Parse(string text)
        {
            try
            {
                text = text.Replace(this.Name, "");
                base.Parse(text);
                return true;
            }
            catch
            {
                return false;
            }
        }
        public override string ToString()
        {
            return this.Name + base.ToString();
        }
    }
    public class compositeField : compositeType
    {
        public compositeField(compositeType cT, string name) : base(cT, name)
        {

        }
    }

    //compositeField子类,参数(compositeType parent, string name)
    #region
    public class MSG : compositeField
    {
        public MSG(compositeType parent, string name) : base(parent, name)
        {
            data = new abstractType[3];
            data[0] = new ID("message type");
            data[1] = new ID("trigger event");
            data[2] = new ID("message structure");
        }
        public ID messagetype
        {
            get { return data[0] as ID; }
            set { data[0] = value; }
        }
        public ID triggerevent
        {
            get { return data[1] as ID; }
            set { data[1] = value; }
        }
        public ID messagestructure
        {
            get { return data[2] as ID; }
            set { data[2] = value; }
        }
    }

    public class HD : compositeField
    {
        public HD(compositeType parent, string name) : base(parent, name)
        {
            data = new abstractType[3];
            data[0] = new IS("namespace ID");
            data[1] = new ST("universak ID");
            data[2] = new ID("universal ID type");
        }
        public IS NamespaceID
        {
            get { return data[0] as IS; }
            set { data[0] = value; }
        }
        public ST UniversalID
        {
            get { return data[1] as ST; }
            set { data[1] = value; }
        }
        public ID UniversalIDType
        {
            get { return data[2] as ID; }
            set { data[2] = value; }
        }
    }

    public class XCN : compositeField
    {
        public XCN(compositeType parent, string name) : base(parent, name)
        {
            data = new abstractType[20];
            data[0] = new ST("ID numbee");
            data[1] = new FN(this, "family name");
            data[2] = new ST("given name");
            data[3] = new ST("second and further given names or initials thereof");
            data[4] = new IS("JR or");
            data[5] = new HD(this, "source table");
            data[6] = new ID("assigning authority");
            data[7] = new ST("name type code");
            data[8] = new ID("identifier check digit");
            data[9] = new ID("check digit scheme");
            data[10] = new HD(this, "identifier type code");
            data[11] = new ID("assigning facility");
            data[12] = new CE(this, "name representation code");
            data[13] = new DR(this, "name context");
            data[14] = new ID("name validity range");
            data[15] = new TS("name assembly order");
            data[16] = new TS("effective date");
            data[17] = new ST("expiration date");
            data[18] = new CWE("professional suffix");
            data[19] = new CWE("assigning jurisdiction");
        }
        public ST IDnumbee
        {
            get { return data[0] as ST; }
            set { data[0] = value; }
        }
        public FN familyname
        {
            get { return data[1] as FN; }
            set { data[1] = value; }
        }
        public ST givenname
        {
            get { return data[2] as ST; }
            set { data[2] = value; }
        }
        public ST secondandfurthergivennamesorinitialsthereof
        {
            get { return data[3] as ST; }
            set { data[3] = value; }
        }
        public IS JRor
        {
            get { return data[4] as IS; }
            set { data[4] = value; }
        }
        public HD sourcetable
        {
            get { return data[5] as HD; }
            set { data[5] = value; }
        }
        public ID assigningauthority
        {
            get { return data[6] as ID; }
            set { data[6] = value; }
        }
        public ST nametypecode
        {
            get { return data[7] as ST; }
            set { data[7] = value; }
        }
        public ID identifiercheckdigit
        {
            get { return data[8] as ID; }
            set { data[8] = value; }
        }
        public ID checkdigitscheme
        {
            get { return data[9] as ID; }
            set { data[9] = value; }
        }
        public HD identifiertypecode
        {
            get { return data[10] as HD; }
            set { data[10] = value; }
        }
        public ID assigningfacility
        {
            get { return data[11] as ID; }
            set { data[11] = value; }
        }
        public CE namerepresentationcode
        {
            get { return data[12] as CE; }
            set { data[12] = value; }
        }
        public DR namecontext
        {
            get { return data[13] as DR; }
            set { data[13] = value; }
        }
        public ID namevalidityrange
        {
            get { return data[14] as ID; }
            set { data[14] = value; }
        }
        public TS nameassemblyorder
        {
            get { return data[15] as TS; }
            set { data[15] = value; }
        }
        public TS effectivedate
        {
            get { return data[16] as TS; }
            set { data[16] = value; }
        }
        public ST expirationdate
        {
            get { return data[17] as ST; }
            set { data[17] = value; }
        }
        public CWE professionalsuffix
        {
            get { return data[18] as CWE; }
            set { data[18] = value; }
        }
        public CWE assigningjurisdiction
        {
            get { return data[19] as CWE; }
            set { data[19] = value; }
        }
    }

    public class VID : compositeField
    {
        public VID(compositeType parent, string name) : base(parent, name)
        {
            data = new abstractType[3];
            data[0] = new ID("version ID");
            data[1] = new CE(this, "internationalization code");
            data[2] = new CE(this, "international version ID");
        }
        public ID versionID
        {
            get { return data[0] as ID; }
            set { data[0] = value; }
        }
        public CE internationalizationcode
        {
            get { return data[1] as CE; }
            set { data[1] = value; }
        }
        public CE internationalversionID
        {
            get { return data[2] as CE; }
            set { data[2] = value; }
        }
    }

    public class PT : compositeField
    {
        public PT(compositeType parent, string name) : base(parent, name)
        {
            data = new abstractType[2];
            data[0] = new ID("processing ID");
            data[1] = new ID("processing mode");
        }
        public ID processingID
        {
            get { return data[0] as ID; }
            set { data[0] = value; }
        }
        public ID processingmode
        {
            get { return data[1] as ID; }
            set { data[1] = value; }
        }
    }

    public class CE : compositeField
    {
        public CE(compositeType parent, string name) : base(parent, name)
        {
            data = new abstractType[6];
            data[0] = new ST("identifier");
            data[1] = new ST("text");
            data[2] = new ID("name of coding system");
            data[3] = new ST("alternate identifier");
            data[4] = new ST("alternate text");
            data[5] = new ID("name of alternate coding system");
        }
        public ST identifier
        {
            get { return data[0] as ST; }
            set { data[0] = value; }
        }
        public ST text
        {
            get { return data[1] as ST; }
            set { data[1] = value; }
        }
        public ID nameofcodingsystem
        {
            get { return data[2] as ID; }
            set { data[2] = value; }
        }
        public ST alternateidentifier
        {
            get { return data[3] as ST; }
            set { data[3] = value; }
        }
        public ST alternatetext
        {
            get { return data[4] as ST; }
            set { data[4] = value; }
        }
        public ID nameofalternatecodingsystem
        {
            get { return data[5] as ID; }
            set { data[5] = value; }
        }
    }

    public class DR : compositeField
    {
        public DR(compositeType parent, string name) : base(parent, name)
        {
            data = new abstractType[2];
            data[0] = new ST("identifier");
            data[1] = new ST("text");
        }
        public ST identifier
        {
            get { return data[0] as ST; }
            set { data[0] = value; }
        }
        public ST text
        {
            get { return data[1] as ST; }
            set { data[1] = value; }
        }
    }

    public class PN : compositeField
    {
        public PN(compositeType parent, string name) : base(parent, name)
        {
            data = new abstractType[5];
            data[0] = new ST("given name");
            data[1] = new ST("second and further given names or initials thereof");
            data[2] = new ST("suffix");
            data[3] = new ST("prefix");
            data[4] = new IS("degree");
        }
        public ST givenname
        {
            get { return data[0] as ST; }
            set { data[0] = value; }
        }
        public ST secondandfurthergivennamesorinitialsthereof
        {
            get { return data[1] as ST; }
            set { data[1] = value; }
        }
        public ST suffix
        {
            get { return data[2] as ST; }
            set { data[2] = value; }
        }
        public ST prefix
        {
            get { return data[3] as ST; }
            set { data[3] = value; }
        }
        public IS degree
        {
            get { return data[4] as IS; }
            set { data[4] = value; }
        }
    }


    public class FN : compositeField
    {
        public FN(compositeType parent, string name) : base(parent, name)
        {
            data = new abstractType[5];
            data[0] = new ST("surname");
            data[1] = new ST("own surname prefix");
            data[2] = new ST("own surname");
            data[3] = new ST("surname prefix from partner spouse");
            data[4] = new ST("surname from partner spouse");
        }
        public ST surname
        {
            get { return data[0] as ST; }
            set { data[0] = value; }
        }
        public ST ownsurnameprefix
        {
            get { return data[1] as ST; }
            set { data[1] = value; }
        }
        public ST ownsurname
        {
            get { return data[2] as ST; }
            set { data[2] = value; }
        }
        public ST surnameprefixfrompartnerspouse
        {
            get { return data[3] as ST; }
            set { data[3] = value; }
        }
        public ST surnamefrompartnerspouse
        {
            get { return data[4] as ST; }
            set { data[4] = value; }
        }
    }

    public class CM : compositeField
    {
        public CM(compositeType parent, string name) : base(parent, name)
        {
            data = new abstractType[3];
            data[0] = new ID("message code");
            data[1] = new ID("trigger event");
            data[2] = new ID("message structure");
        }
        public ID messagecode
        {
            get { return data[0] as ID; }
            set { data[0] = value; }
        }
        public ID triggerevent
        {
            get { return data[1] as ID; }
            set { data[1] = value; }
        }
        public ID messagestructure
        {
            get { return data[2] as ID; }
            set { data[2] = value; }
        }
    }
    #endregion

    //compositeSegment子类,参数(compositeType parent)
    #region
    public class MSA : compositeSegment
    {
        public MSA(compositeType parent) : base(parent, "MSA")
        {
            data = new abstractType[6];
            data[0] = new ID("Acknowledgment Code");
            data[1] = new ST("Message Control ID");
            data[2] = new ST("Text Message");
            data[3] = new NM("Expected Sequence Number");
            data[4] = new ID("Delayed Acknowledgment Type");
            data[5] = new CE(this, "Error Condition");
        }
        public ID AcknowledgmentCode
        {
            get { return data[0] as ID; }
            set { data[0] = value; }
        }
        public ST MessageControlID
        {
            get { return data[1] as ST; }
            set { data[1] = value; }
        }
        public ST TextMessage
        {
            get { return data[2] as ST; }
            set { data[2] = value; }
        }
        public NM ExpectedSequenceNumber
        {
            get { return data[3] as NM; }
            set { data[3] = value; }
        }
        public ID DelayedAcknowledgmentType
        {
            get { return data[4] as ID; }
            set { data[4] = value; }
        }
        public CE ErrorCondition
        {
            get { return data[5] as CE; }
            set { data[5] = value; }
        }
        public override bool Parse(string text)
        {
            return true;
        }
    }

    public class EVN : compositeSegment
    {
        public EVN(compositeType parent) : base(parent, "EVN")
        {
            data = new abstractType[6];
            data[0] = new ID("Event Type Code");
            data[1] = new TS("Recorded");
            data[2] = new TS("Planned Event");
            data[3] = new IS("Event Reason Code");
            data[4] = new ID("Operator");
            data[5] = new TS("Event Occurred");
        }
        public ID EventTypeCode
        {
            get { return data[0] as ID; }
            set { data[0] = value; }
        }
        public TS Recorded
        {
            get { return data[1] as TS; }
            set { data[1] = value; }
        }
        public TS PlannedEvent
        {
            get { return data[2] as TS; }
            set { data[2] = value; }
        }
        public IS EventReasonCode
        {
            get { return data[3] as IS; }
            set { data[3] = value; }
        }
        public ID Operator
        {
            get { return data[4] as ID; }
            set { data[4] = value; }
        }
        public TS EventOccurred
        {
            get { return data[5] as TS; }
            set { data[5] = value; }
        }
        public override bool Parse(string text)
        {
            return true;
        }
    }

    public class MSH : compositeSegment
    {
        public MSH(compositeType parent) : base(parent, "MSH")
        {
            data = new abstractType[21];
            data[0] = new ST("Field Separator");
            data[1] = new ST("Encoding Characters");
            data[2] = new HD(this, "Sending Application");
            data[3] = new HD(this, "Sending Facility");
            data[4] = new HD(this, "Receiving Application");
            data[5] = new HD(this, "Receiving Facility");
            data[6] = new TS("Of Message");
            data[7] = new ST("Security");
            data[8] = new MSG(this, "Message Type");
            data[9] = new ST("Message Control ID");
            data[10] = new PT(this, "Processing ID");
            data[11] = new VID(this, "Version ID");
            data[12] = new NM("Sequence Number");
            data[13] = new ST("Continuation Pointer");
            data[14] = new ID("Accept Acknowledgment Type");
            data[15] = new ID("Application Acknowledgment Type");
            data[16] = new ID("Country Code");
            data[17] = new ID("Character Set");
            data[18] = new CE(this, "Principal Language Of Message");
            data[19] = new ID("Alternate Character Set Handling Scheme");
            data[20] = new TS("Date Time Of Message");
        }
        public ST FieldSeparator
        {
            get { return data[0] as ST; }
            set { data[0] = value; }
        }
        public ST EncodingCharacters
        {
            get { return data[1] as ST; }
            set { data[1] = value; }
        }
        public HD SendingApplication
        {
            get { return data[2] as HD; }
            set { data[2] = value; }
        }
        public HD SendingFacility
        {
            get { return data[3] as HD; }
            set { data[3] = value; }
        }
        public HD ReceivingApplication
        {
            get { return data[4] as HD; }
            set { data[4] = value; }
        }
        public HD ReceivingFacility
        {
            get { return data[5] as HD; }
            set { data[5] = value; }
        }
        public TS OfMessage
        {
            get { return data[6] as TS; }
            set { data[6] = value; }
        }
        public ST Security
        {
            get { return data[7] as ST; }
            set { data[7] = value; }
        }
        public MSG MessageType
        {
            get { return data[8] as MSG; }
            set { data[8] = value; }
        }
        public ST MessageControlID
        {
            get { return data[9] as ST; }
            set { data[9] = value; }
        }
        public PT ProcessingID
        {
            get { return data[10] as PT; }
            set { data[10] = value; }
        }
        public VID VersionID
        {
            get { return data[11] as VID; }
            set { data[11] = value; }
        }
        public NM SequenceNumber
        {
            get { return data[12] as NM; }
            set { data[12] = value; }
        }
        public ST ContinuationPointer
        {
            get { return data[13] as ST; }
            set { data[13] = value; }
        }
        public ID AcceptAcknowledgmentType
        {
            get { return data[14] as ID; }
            set { data[14] = value; }
        }
        public ID ApplicationAcknowledgmentType
        {
            get { return data[15] as ID; }
            set { data[15] = value; }
        }
        public ID CountryCode
        {
            get { return data[16] as ID; }
            set { data[16] = value; }
        }
        public ID CharacterSet
        {
            get { return data[17] as ID; }
            set { data[17] = value; }
        }
        public CE PrincipalLanguageOfMessage
        {
            get { return data[18] as CE; }
            set { data[18] = value; }
        }
        public ID AlternateCharacterSetHandlingScheme
        {
            get { return data[19] as ID; }
            set { data[19] = value; }
        }
        public TS DateTimeOfMessage
        {
            get { return data[20] as TS; }
            set { data[19] = value; }
        }
        public override bool Parse(string text)
        {
            return true;
        }
    }

    public class PID : compositeSegment
    {
        public PID(compositeType parent) : base(parent, "PID")
        {
            data = new abstractType[30];
            data[0] = new SI("Set");
            //data[1] = new CX("PID");
            //data[2] = new CX("Patient ID");
            //data[3] = new CX("Patient Identifier List");
            //data[4] = new XPN("Alternate Patient");
            //data[5] = new XPN("PID");
            data[6] = new TS("Patient Name");
            data[7] = new IS("Maiden Name");
            //data[8] = new XPN("Of Birth");
            data[9] = new CE(parent, "Sex");
            //data[10] = new XAD("Patient Alias");
            data[11] = new IS("Race");
            //data[12] = new XTN("Patient Address");
            //data[13] = new XTN("County Code");
            //data[14] = new CE(parent, "Phone");
            data[15] = new CE(parent, "Home");
            data[16] = new CE(parent, "Phone");
            //data[17] = new CX("Business");
            data[18] = new ST("Primary Language");
            //data[19] = new DLN("Marital Status");
            //data[20] = new CX("Religion");
            data[21] = new CE(parent, "Patient Account Number");
            data[22] = new ST("SSN");
            //data[23] = new ID("Patient");
            data[24] = new NM("License");
            data[25] = new CE(parent, "Patient");
            data[26] = new CE(parent, "Identifier");
            data[27] = new CE(parent, "Ethnic Group");
            data[28] = new TS("Birth Place");
            data[29] = new ID("Multiple Birth Indicator");
        }
        public CE Phone
        {
            get { return data[16] as CE; }
            set { data[16] = value; }
        }
        //public ID Patient
        //{
        //    get { return data[25] as CE; }
        //    set { data[25] = value; }
        //}
        public CE Patient
        {
            get { return data[25] as CE; }
            set { data[25] = value; }
        }
        public SI Set
        {
            get { return data[0] as SI; }
            set { data[0] = value; }
        }
        
        public TS PatientName
        {
            get { return data[6] as TS; }
            set { data[6] = value; }
        }
        public IS MaidenName
        {
            get { return data[7] as IS; }
            set { data[7] = value; }
        }
        
        public CE Sex
        {
            get { return data[9] as CE; }
            set { data[9] = value; }
        }
        
        public IS Race
        {
            get { return data[11] as IS; }
            set { data[11] = value; }
        }
        
        public CE Home
        {
            get { return data[15] as CE; }
            set { data[15] = value; }
        }
        

        public ST PrimaryLanguage
        {
            get { return data[18] as ST; }
            set { data[18] = value; }
        }
        
        public CE PatientAccountNumber
        {
            get { return data[21] as CE; }
            set { data[21] = value; }
        }
        public ST SSN
        {
            get { return data[22] as ST; }
            set { data[22] = value; }
        }
        public NM License
        {
            get { return data[24] as NM; }
            set { data[24] = value; }
        }
        public CE Identifier
        {
            get { return data[26] as CE; }
            set { data[26] = value; }
        }
        public CE EthnicGroup
        {
            get { return data[27] as CE; }
            set { data[27] = value; }
        }
        public TS BirthPlace
        {
            get { return data[28] as TS; }
            set { data[28] = value; }
        }
        public ID MultipleBirthIndicator
        {
            get { return data[29] as ID; }
            set { data[29] = value; }
        }
        //public CX PID
        //{
        //    get { return data[1] as CX; }
        //    set { data[1] = value; }
        //}
        //public DLN MaritalStatus
        //{
        //    get { return data[19] as DLN; }
        //    set { data[19] = value; }
        //}
        //public CX Religion
        //{
        //    get { return data[20] as CX; }
        //    set { data[20] = value; }
        //}
        //public CX PatientID
        //{
        //    get { return data[2] as CX; }
        //    set { data[2] = value; }
        //}
        //public CX PatientIdentifierList
        //{
        //    get { return data[3] as CX; }
        //    set { data[3] = value; }
        //}
        //public XPN AlternatePatient
        //{
        //    get { return data[4] as XPN; }
        //    set { data[4] = value; }
        //}
        //public XPN PID
        //{
        //    get { return data[5] as XPN; }
        //    set { data[5] = value; }
        //}
        //public XPN OfBirth
        //{
        //    get { return data[8] as XPN; }
        //    set { data[8] = value; }
        //}
        //public XAD PatientAlias
        //{
        //    get { return data[10] as XAD; }
        //    set { data[10] = value; }
        //}
        //public XTN PatientAddress
        //{
        //    get { return data[12] as XTN; }
        //    set { data[12] = value; }
        //}
        //public XTN CountyCode
        //{
        //    get { return data[13] as XTN; }
        //    set { data[13] = value; }
        //}
        //public CX Business
        //{
        //    get { return data[17] as CX; }
        //    set { data[17] = value; }
        //}
    }

    public class ERR : compositeSegment
    {
        public ERR(compositeType parent) : base(parent, "ERR")
        {

        }
    }
    public class PV1 : compositeSegment
    {
        public PV1(compositeType parent) : base(parent, "PV1")
        {
            data = new abstractType[51];
            data[0] = new SI("Setidpv1");
            data[1] = new IS("Patient Class");
            //data[2] = new PL("Assigned Patient Location");
            data[3] = new IS("Admission Type");
            //data[4] = new CX("Preadmit Number");
            //data[5] = new PL("Prior Patient Location");
            data[6] = new XCN(parent, "Attending Doctor");
            data[7] = new XCN(parent, "Referring Doctor");
            data[8] = new XCN(parent, "Consulting Doctor");
            data[9] = new IS("Hospital Service");
            //data[10] = new PL("Temporary Location");
            data[11] = new IS("Preadmit Test Indicator");
            data[12] = new IS("Indicator");
            data[13] = new IS("Admit Source");
            data[14] = new IS("Ambulatory Status");
            data[15] = new IS("VIP Indicator");
            data[16] = new XCN(parent, "Admitting Doctor");
            data[17] = new IS("Patient Type");
            //data[18] = new CX("Visit Number");
            //data[19] = new FC("Financial Class");
            data[20] = new IS("Charge Price Indicator");
            data[21] = new IS("Courtesy Code");
            data[22] = new IS("Credit Rating");
            data[23] = new IS("Contract Code");
            data[24] = new DT("Contract Effective Date");
            data[25] = new NM("Contract Amount");
            data[26] = new NM("Contract Period");
            data[27] = new IS("Interest Code");
            data[28] = new IS("Transfer to Bad Debt Code");
            data[29] = new DT("Transfer to Bad Debt Date");
            data[30] = new IS("Bad Debt Agency Code");
            data[31] = new NM("Bad Debt Transfer Amount");
            data[32] = new NM("Bad Debt Recovery Amount");
            data[33] = new IS("Delete Account Indicator");
            data[34] = new DT("Delete Account Date");
            data[35] = new IS("Discharge Disposition");
            data[36] = new CE(parent, "Diet Type");
            data[37] = new IS("Servicing Facility");
            data[38] = new IS("Bed Status");
            data[39] = new IS("Account Status");
            //data[40] = new PL("Pending Location");
            //data[41] = new PL("Prior Temporary Location");
            data[42] = new TS("Admit DateTime");
            data[43] = new TS("Discharge DateTime");
            data[44] = new NM("Current Patient Balance");
            data[45] = new NM("Total Charges");
            data[46] = new NM("Total Adjustments");
            data[47] = new NM("Total Payments");
            //data[48] = new CX("Alternate Visit ID");
            data[49] = new IS("Visit Indicator");
            data[50] = new XCN(parent, "Other Healthcare Provider");
        }
        public SI Setidpv1
        {
            get { return data[0] as SI; }
            set { data[0] = value; }
        }
        public IS PatientClass
        {
            get { return data[1] as IS; }
            set { data[1] = value; }
        }
        //public PL AssignedPatientLocation
        //{
        //    get { return data[2] as PL; }
        //    set { data[2] = value; }
        //}
        public IS AdmissionType
        {
            get { return data[3] as IS; }
            set { data[3] = value; }
        }
        //public CX PreadmitNumber
        //{
        //    get { return data[4] as CX; }
        //    set { data[4] = value; }
        //}
        //public PL PriorPatientLocation
        //{
        //    get { return data[5] as PL; }
        //    set { data[5] = value; }
        //}
        public XCN AttendingDoctor
        {
            get { return data[6] as XCN; }
            set { data[6] = value; }
        }
        public XCN ReferringDoctor
        {
            get { return data[7] as XCN; }
            set { data[7] = value; }
        }
        public XCN ConsultingDoctor
        {
            get { return data[8] as XCN; }
            set { data[8] = value; }
        }
        public IS HospitalService
        {
            get { return data[9] as IS; }
            set { data[9] = value; }
        }
        //public PL TemporaryLocation
        //{
        //    get { return data[10] as PL; }
        //    set { data[10] = value; }
        //}
        public IS PreadmitTestIndicator
        {
            get { return data[11] as IS; }
            set { data[11] = value; }
        }
        public IS Indicator
        {
            get { return data[12] as IS; }
            set { data[12] = value; }
        }
        public IS AdmitSource
        {
            get { return data[13] as IS; }
            set { data[13] = value; }
        }
        public IS AmbulatoryStatus
        {
            get { return data[14] as IS; }
            set { data[14] = value; }
        }
        public IS VIPIndicator
        {
            get { return data[15] as IS; }
            set { data[15] = value; }
        }
        public XCN AdmittingDoctor
        {
            get { return data[16] as XCN; }
            set { data[16] = value; }
        }
        public IS PatientType
        {
            get { return data[17] as IS; }
            set { data[17] = value; }
        }
        //public CX VisitNumber
        //{
        //    get { return data[18] as CX; }
        //    set { data[18] = value; }
        //}
        //public FC FinancialClass
        //{
        //    get { return data[19] as FC; }
        //    set { data[19] = value; }
        //}
        public IS ChargePriceIndicator
        {
            get { return data[20] as IS; }
            set { data[20] = value; }
        }
        public IS CourtesyCode
        {
            get { return data[21] as IS; }
            set { data[21] = value; }
        }
        public IS CreditRating
        {
            get { return data[22] as IS; }
            set { data[22] = value; }
        }
        public IS ContractCode
        {
            get { return data[23] as IS; }
            set { data[23] = value; }
        }
        public DT ContractEffectiveDate
        {
            get { return data[24] as DT; }
            set { data[24] = value; }
        }
        public NM ContractAmount
        {
            get { return data[25] as NM; }
            set { data[25] = value; }
        }
        public NM ContractPeriod
        {
            get { return data[26] as NM; }
            set { data[26] = value; }
        }
        public IS InterestCode
        {
            get { return data[27] as IS; }
            set { data[27] = value; }
        }
        public IS TransfertoBadDebtCode
        {
            get { return data[28] as IS; }
            set { data[28] = value; }
        }
        public DT TransfertoBadDebtDate
        {
            get { return data[29] as DT; }
            set { data[29] = value; }
        }
        public IS BadDebtAgencyCode
        {
            get { return data[30] as IS; }
            set { data[30] = value; }
        }
        public NM BadDebtTransferAmount
        {
            get { return data[31] as NM; }
            set { data[31] = value; }
        }
        public NM BadDebtRecoveryAmount
        {
            get { return data[32] as NM; }
            set { data[32] = value; }
        }
        public IS DeleteAccountIndicator
        {
            get { return data[33] as IS; }
            set { data[33] = value; }
        }
        public DT DeleteAccountDate
        {
            get { return data[34] as DT; }
            set { data[34] = value; }
        }
        public IS DischargeDisposition
        {
            get { return data[35] as IS; }
            set { data[35] = value; }
        }
        public CE DietType
        {
            get { return data[36] as CE; }
            set { data[36] = value; }
        }
        public IS ServicingFacility
        {
            get { return data[37] as IS; }
            set { data[37] = value; }
        }
        public IS BedStatus
        {
            get { return data[38] as IS; }
            set { data[38] = value; }
        }
        public IS AccountStatus
        {
            get { return data[39] as IS; }
            set { data[39] = value; }
        }
        //public PL PendingLocation
        //{
        //    get { return data[40] as PL; }
        //    set { data[40] = value; }
        //}
        //public PL PriorTemporaryLocation
        //{
        //    get { return data[41] as PL; }
        //    set { data[41] = value; }
        //}
        public TS AdmitDateTime
        {
            get { return data[42] as TS; }
            set { data[42] = value; }
        }
        public TS DischargeDateTime
        {
            get { return data[43] as TS; }
            set { data[43] = value; }
        }
        public NM CurrentPatientBalance
        {
            get { return data[44] as NM; }
            set { data[44] = value; }
        }
        public NM TotalCharges
        {
            get { return data[45] as NM; }
            set { data[45] = value; }
        }
        public NM TotalAdjustments
        {
            get { return data[46] as NM; }
            set { data[46] = value; }
        }
        public NM TotalPayments
        {
            get { return data[47] as NM; }
            set { data[47] = value; }
        }
        //public CX AlternateVisitID
        //{
        //    get { return data[48] as CX; }
        //    set { data[48] = value; }
        //}
        public IS VisitIndicator
        {
            get { return data[49] as IS; }
            set { data[49] = value; }
        }
        public XCN OtherHealthcareProvider
        {
            get { return data[50] as XCN; }
            set { data[50] = value; }
        }
    }

    public class OBR : compositeSegment
    {
        public OBR(compositeType parent) : base(parent, "OBR")
        {

        }
    }
    public class ORC : compositeSegment
    {
        public ORC(compositeType parent) : base(parent, "ORC")
        {

        }
    }
    #endregion

    //compositeMessage子类,无参数
    #region
    public class ACK : compositeMessage 
    {
        public ACK() : base(null, "ACK")
        {
            data = new abstractType[3];
            data[0] = new MSH(this);
            data[1] = new MSA(this);
            data[2] = new ERR(this);
        }
        public MSH msh
        {
            get { return data[0] as MSH; }
            set { data[0] = value; }
        }
        public MSA msa
        {
            get { return data[1] as MSA; }
            set { data[1] = value; }
        }
        public ERR err
        {
            get { return data[2] as ERR; }
            set { data[2] = value; }
        }
    }
    public class A01 : compositeMessage
    {
        public A01() : base(null, "A01")
        {
            data = new abstractType[4];
            data[0] = new EVN(this);
            data[1] = new MSH(this);
            data[2] = new PID(this);
            data[3] = new PV1(this);
        }
        public EVN evn
        {
            get { return data[0] as EVN; }
            set { data[0] = value; }
        }
        public MSH msh
        {
            get { return data[1] as MSH; }
            set { data[1] = value; }
        }
        public PID pid
        {
            get { return data[2] as PID; }
            set { data[2] = value; }
        }
        public PV1 pv1
        {
            get { return data[3] as PV1; }
            set { data[2] = value; }
        }
    }
    public class A02 : compositeMessage
    {
        public A02() : base(null, "A02")
        {
            data = new abstractType[4];
            data[0] = new EVN(this);
            data[1] = new MSH(this);
            data[2] = new PID(this);
            data[3] = new PV1(this);
        }
        public EVN evn
        {
            get { return data[0] as EVN; }
            set { data[0] = value; }
        }
        public MSH msh
        {
            get { return data[1] as MSH; }
            set { data[1] = value; }
        }
        public PID pid
        {
            get { return data[2] as PID; }
            set { data[2] = value; }
        }
        public PV1 pv1
        {
            get { return data[3] as PV1; }
            set { data[2] = value; }
        }
    }
    public class A03 : compositeMessage
    {
        public A03() : base(null, "A01")
        {
            data = new abstractType[4];
            data[0] = new EVN(this);
            data[1] = new MSH(this);
            data[2] = new PID(this);
            data[3] = new PV1(this);
        }
        public EVN evn
        {
            get { return data[0] as EVN; }
            set { data[0] = value; }
        }
        public MSH msh
        {
            get { return data[1] as MSH; }
            set { data[1] = value; }
        }
        public PID pid
        {
            get { return data[2] as PID; }
            set { data[2] = value; }
        }
        public PV1 pv1
        {
            get { return data[3] as PV1; }
            set { data[2] = value; }
        }
    }
    public class A04 : compositeMessage
    {
        public A04() : base(null, "A04")
        {
            data = new abstractType[4];
            data[0] = new EVN(this);
            data[1] = new MSH(this);
            data[2] = new PID(this);
            data[3] = new PV1(this);
        }
        public EVN evn
        {
            get { return data[0] as EVN; }
            set { data[0] = value; }
        }
        public MSH msh
        {
            get { return data[1] as MSH; }
            set { data[1] = value; }
        }
        public PID pid
        {
            get { return data[2] as PID; }
            set { data[2] = value; }
        }
        public PV1 pv1
        {
            get { return data[3] as PV1; }
            set { data[2] = value; }
        }
    }
    #endregion
}
