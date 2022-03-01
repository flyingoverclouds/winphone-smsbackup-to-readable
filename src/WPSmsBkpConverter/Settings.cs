using System;
using System.Collections.Generic;
using System.Text;

namespace WPSmsBkpConverter
{
    enum ExportFormatType {
        /// <summary>
        /// One exported file per backup file
        /// file format is : 
        ///    SenderInltPhonNumber: MESSAGE received
        ///    SenderInltPhonNumber*: MESSAGE sent by phone owner
        /// </summary>
        TextPerBackup,

        /// <summary>
        /// One exported file per conversation file (finale name is [00externalInltPhoneNum.txt] ) 
        /// file format is : 
        ///    dd-mm-yy hh:mm:ss InltPhonNumber: MESSAGE received
        ///    dd-mm-yy hh:mm:ss InltPhonNumber*: MESSAGE sent
        /// </summary>
        TextPerConversation,


        /// <summary>
        /// One exported templated file per backup file
        /// </summary>
        TemplatePerBackup,

        /// <summary>
        /// One exported file per conversation file (finale name is [00externalInltPhoneNum.EXT] ) 
        /// </summary>
        TemplatePerConversartion
    }




    class Settings
    {
        public ExportFormatType ExportFormat { get; set; } = ExportFormatType.TextPerBackup;

        public string TemplateFolder { get; set; } = "./template";

        public int MyProperty { get; set; }
    }
}
