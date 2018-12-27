using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace ADOassignment
{
    public class ProductLine
    {
        private ProductLine()
        {

        }

        public string ProdLine { get; set; }
        public string TextDescription { get; set; }
        public string HtmlDescription { get; set; }
        public byte[] Image { get; set; }

        public static ProductLine ProductLineFactory(IDataReader reader)
        {
            return new ProductLine
            {
                ProdLine = reader.IsDBNull(0) ? null : reader.GetString(0),
                TextDescription = reader.IsDBNull(1) ? null : reader.GetString(1),
                HtmlDescription = reader.IsDBNull(2) ? null : reader.GetString(2),
                Image = reader.IsDBNull(3) ? null : (byte[]) reader["image"] 
            };
        }
    }
}
