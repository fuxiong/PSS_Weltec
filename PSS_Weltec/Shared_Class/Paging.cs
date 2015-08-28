using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PSS_Weltec.Shared_Class
{
    /// <summary>
    /// Paging
    /// </summary>
    public class Paging
    {
        private int currentPage;
        public static int DEFAULT_PAGE_SIZE=30;
        private int pageSize;
        private int recordCount;


        public Paging()
        {
            this.start = 0;
            this.end = 1;
            this.pageCount = 0;
            this.recordCount = 0;
            this.currentPage = 1;
            this.pageSize = DEFAULT_PAGE_SIZE;
        }

        public int GetCurrentPage()
        {
            return this.currentPage;
        }

        public int GetPageSize()
        {
            return this.pageSize;
        }

        public int GetRecordCount()
        {
            return this.recordCount;
        }

        public void SetCurrentPage(int currentPage)
        {
            if (currentPage < 1)
            {
                this.currentPage = 1;
            }
            else
            {
                this.currentPage = currentPage;
            }
            this.SetPage();

        }

        private void SetPage()
        {
            this.start = (this.currentPage - 1) * this.pageSize;
            if (this.start < 0)
            {
                this.start = 0;
            }
            this.end = this.start + this.pageSize;
        }


        public void SetPageSize(int pageSize)
        {
            if (pageSize < 1)
            {
                this.pageSize = DEFAULT_PAGE_SIZE;
            }
            else
            {
                this.pageSize = pageSize;
            }
            this.SetPage();
        }

        public void SetRecordCount(int recordCount)
        {
            this.recordCount = recordCount;
            this.pageCount = (recordCount / this.pageSize) + (((recordCount % this.pageSize) == 0) ? 0 : 1);
            this.currentPage = (this.currentPage <= this.pageCount) ? this.currentPage : this.pageCount;
            this.SetPage();
        }

        // Properties
        private int end { get; set; }
        private int pageCount { get; set; }
        public int start { get; set; }

    }
}