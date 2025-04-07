using CsvHelper.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductModel
{
    public class GrnLineMap : ClassMap<GrnLine>
    {
        public GrnLineMap()
        {
            Map(m => m.LineID).Name("LineID");
            Map(m => m.QtyDelivered).Name("QtyDelivered");
            Map(m => m.StockID).Name("StockID");
            Map(m => m.GrnID).Name("GrnId");

        }
    }
}
