using CsvHelper.Configuration;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductModel.CSVMapping
{
    public class GrnMap : ClassMap<GRN>
    {
        public GrnMap()
        {
            string format = "dd/MM/yyyy";
            var msMY = CultureInfo.GetCultureInfo("en-ie");

            Map(m => m.GrnID).Name("GrnID");
            Map(m => m.OrderDate).Name("OrderDate")
                .TypeConverterOption.Format(format)
                .TypeConverterOption.CultureInfo(msMY);
            Map(m => m.DeliveryDate).Name("DeliveryDate")
                .TypeConverterOption.Format(format)
                .TypeConverterOption.CultureInfo(msMY);
            Map(m => m.StockUpdated).Name("StockUpdated");
        }
    }
}
