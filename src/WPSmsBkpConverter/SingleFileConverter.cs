using System;
using System.Collections.Generic;
using System.Text;
using System.Xml;

namespace WPSmsBkpConverter
{
    class SingleFileConverter
    {
        HashSet<string> phoneNumbers = null;
        public SingleFileConverter(HashSet<string> phoneNumbers=null)
        {
            this.phoneNumbers = phoneNumbers;
        }

        public void Convert(XmlDocument doc,string localPhoneNumber)
        {
            foreach(XmlElement m in doc.GetElementsByTagName("Message"))
            {
                var sms = new SMS();
                foreach(XmlElement cn in m.ChildNodes)
                {
                    switch(cn.Name)
                    {
                        case "IsIncoming":
                            if (cn.InnerText == "false")
                            {
                                sms.Incoming = false;
                                sms.From = localPhoneNumber;
                            }
                            else
                                sms.Incoming = true;
                            break;
                        case "Body":
                            sms.Body = cn.InnerText;
                            break;
                        case "LocalTimestamp":
                            sms.SendDate= DateTime.FromFileTime(System.Convert.ToInt64(cn.InnerText));
                            break;
                        case "Sender":
                            if (!string.IsNullOrEmpty(cn.InnerText))
                            {
                                sms.From = cn.InnerText;
                                sms.To = localPhoneNumber;
                            }
                            break;
                        case "Recepients":
                            var to = string.Empty;
                            foreach(XmlElement rcpt in cn.ChildNodes)
                            {
                                if (to.Length > 0)
                                    to += ",";
                                to += rcpt.InnerText;
                            }
                            if (to.Length > 0)
                                sms.To=to;
                            //sms.From = localPhoneNumber;
                            break;
                    }
                }
                
                if (phoneNumbers==null || phoneNumbers.Contains(sms.To) || phoneNumbers.Contains(sms.From))
                    Console.WriteLine(sms.ToString());
                
            }



        }
    }
}

