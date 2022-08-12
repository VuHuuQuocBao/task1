using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task1.ViewModel.Pagination
{
    public class PagedRequest : PagedRequestBase
    {
        public string? Keyword { get; set; }
    }
}
