using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PSS_Weltec.Shared_Class
{
    public class JsonDataGridResult
    {
        public JsonDataGridResult()
        {
            this.total = 0;
            this.page = 1;
            this.result = true;
            this.message = "";
            rows = new ArrayList();
            select = new ArrayList();
            footer = new ArrayList();
        }

        public int total { get; set; }
        public string message { get; set; }
        public int page { get; set; }
        public bool result { get; set; }
        public ArrayList rows { get; set; }
        public ArrayList select { get; set; }
        public ArrayList footer { get; set; }
    }
}