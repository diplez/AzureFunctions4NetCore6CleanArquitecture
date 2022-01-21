using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bit.Domain.Utils
{
    public class PaginatorUtils
    {
        public static int fromSkipToPage(int page, int limit){
            return page>0?((page-1)*limit):page* limit;
        }

        public int pageTotal(double resultPerPage, double resultTotal) {
            int total = (int)Math.Round((resultTotal / resultPerPage), MidpointRounding.AwayFromZero);
            double totalAux = ((double)resultTotal / (double)resultPerPage);
            return totalAux > total ? total + 1 : total;
        }
    }
}
