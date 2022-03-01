using System;
using System.Collections.Generic;
using System.Text;

namespace WPSmsBkpConverter
{
    class SMS
    {
        public bool Incoming { get; set; }
        public string From { get; set; } = "";
        public string To { get; set; } = "";
        public DateTime SendDate { get; set; }
        public string Body { get; set; } = "";


        public override string ToString()
        {
           return $"{SendDate.ToString("G")} {From} {((Incoming)?" ":"*")} : {Body}";
        }
    }
}
