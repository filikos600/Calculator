using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Calculator.Data
{

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    [System.Xml.Serialization.XmlRootAttribute(Namespace = "", IsNullable = false)]
    public partial class ArrayOfExchangeRatesTable
    {

        private ArrayOfExchangeRatesTableExchangeRatesTable exchangeRatesTableField;

        /// <remarks/>
        public ArrayOfExchangeRatesTableExchangeRatesTable ExchangeRatesTable { get; set; }
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    public partial class ArrayOfExchangeRatesTableExchangeRatesTable
    {

        private string tableField;

        private string noField;

        private System.DateTime effectiveDateField;

        private ArrayOfExchangeRatesTableExchangeRatesTableRate[] ratesField;

        /// <remarks/>
        public string Table { get; set; }

        /// <remarks/>
        public string No { get; set; }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(DataType = "date")]
        public System.DateTime EffectiveDate { get; set; }
        /// <remarks/>
        [System.Xml.Serialization.XmlArrayItemAttribute("Rate", IsNullable = false)]
        public ArrayOfExchangeRatesTableExchangeRatesTableRate[] Rates { get; set; }
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    public partial class ArrayOfExchangeRatesTableExchangeRatesTableRate
    {

        private string currencyField;

        private string codeField;

        private decimal midField;

        /// <remarks/>
        public string Currency { get; set; }

        /// <remarks/>
        public string Code { get; set; }

        /// <remarks/>
        public decimal Mid { get; set; }
    }

}
