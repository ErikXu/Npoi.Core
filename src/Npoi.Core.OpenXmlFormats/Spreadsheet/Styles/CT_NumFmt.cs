﻿using Npoi.Core.OpenXml4Net.Util;
using System;
using System.IO;
using System.Xml;
using System.Xml.Linq;
using System.Xml.Serialization;

namespace Npoi.Core.OpenXmlFormats.Spreadsheet
{
    [Serializable]
    [XmlType(Namespace = "http://schemas.openxmlformats.org/spreadsheetml/2006/main")]
    public class CT_NumFmt
    {
        private uint numFmtIdField;

        private string formatCodeField;

        public static CT_NumFmt Parse(XElement node, XmlNamespaceManager namespaceManager)
        {
            if (node == null)
                return null;
            CT_NumFmt ctObj = new CT_NumFmt();
            ctObj.numFmtId = XmlHelper.ReadUInt(node.Attribute("numFmtId"));
            ctObj.formatCode = XmlHelper.ReadString(node.Attribute("formatCode"));
            return ctObj;
        }

        internal void Write(StreamWriter sw, string nodeName)
        {
            sw.Write(string.Format("<{0}", nodeName));
            XmlHelper.WriteAttribute(sw, "numFmtId", this.numFmtId, true);
            XmlHelper.WriteAttribute(sw, "formatCode", this.formatCode);
            sw.Write("/>");
        }

        [XmlAttribute]
        public uint numFmtId
        {
            get
            {
                return this.numFmtIdField;
            }
            set
            {
                this.numFmtIdField = value;
            }
        }

        [XmlAttribute]
        public string formatCode
        {
            get
            {
                return this.formatCodeField;
            }
            set
            {
                this.formatCodeField = value;
            }
        }
    }
}