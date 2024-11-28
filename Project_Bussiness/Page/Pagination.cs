using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_Bussiness.Page
{
    public class Pagination
    {
        public int PageSize { get; set; }
        public int PageNumber { get; set; }
        public int TotalCount { get; set; }
        public int TotalPage
        {
            get
            {
                if (PageSize == 0) return 0;
                var total = TotalCount / PageSize;
                if (TotalCount % PageSize != 0)
                {
                    total++;
                }
                return total;
            }
        }
        public Pagination()
        {
            PageSize = -1;
            PageNumber = 1;
        }

    }
}
