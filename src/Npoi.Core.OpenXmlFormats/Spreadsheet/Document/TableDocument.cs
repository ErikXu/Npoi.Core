﻿using System.IO;
using System.Xml;
using System.Xml.Linq;

namespace Npoi.Core.OpenXmlFormats.Spreadsheet
{
    public class TableDocument
    {
        private CT_Table ctTable = null;

        public TableDocument()
        {
        }

        public TableDocument(CT_Table table)
        {
            this.ctTable = table;
        }

        public static TableDocument Parse(XDocument xmldoc, XmlNamespaceManager namespaceMgr)
        {
            CT_Table obj = CT_Table.Parse(xmldoc.Document.Root, namespaceMgr);
            return new TableDocument(obj);
        }

        public CT_Table GetTable()
        {
            return ctTable;
        }

        public void SetTable(CT_Table table)
        {
            this.ctTable = table;
        }

        public void Save(Stream stream)
        {
            using (StreamWriter sw = new StreamWriter(stream))
            {
                ctTable.Write(sw);
            }
        }
    }
}