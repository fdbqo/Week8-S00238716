using CsvHelper.Configuration.Attributes;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductModel
{
    public class GrnLine
    {
        [Key]
        public int LineID { get; set; }
        [ForeignKey("parentGRN")]

        public int GrnID { get; set; }
        [ForeignKey("associatedProduct")]

        public int StockID { get; set; }

        public int QtyDelivered { get; set; }

        public virtual GRN parentGRN { get; set; }

        public virtual Product associatedProduct { get; set; }


    }
}
