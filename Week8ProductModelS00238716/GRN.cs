using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CsvHelper.Configuration.Attributes;

namespace ProductModel
{
    public class GRN
    {
        [Key]
        public int GrnID { get; set; }
        public DateTime  OrderDate { get; set; }

        [Optional]
        public DateTime? DeliveryDate { get; set; }

        public Boolean StockUpdated { get; set; }

        public virtual ICollection<GrnLine> GRNLines { get; set; }
    }
}
