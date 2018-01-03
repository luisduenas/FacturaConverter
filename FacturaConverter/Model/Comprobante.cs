using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace FacturaConverter.Model
{

    [XmlRootAttribute(Namespace = "http://www.sat.gob.mx/cfd/3")]
    public partial class Comprobante
    {
        private ComprobanteComplemento complementoField;


        [XmlAttributeAttribute()]
        public string version;

        [XmlAttributeAttribute()]
        public string folio;

        [XmlAttributeAttribute()]
        public string fecha;

        [XmlAttributeAttribute()]
        public string sello;

        [XmlAttributeAttribute()]
        public string formaDePago;

        [XmlAttributeAttribute()]
        public string noCertificado;

        [XmlAttributeAttribute()]
        public string certificado;

        [XmlAttributeAttribute()]
        public string subTotal;

        [XmlAttributeAttribute()]
        public string Moneda;

        [XmlAttributeAttribute()]
        public string total;

        [XmlAttributeAttribute()]
        public string tipoDeComprobante;

        [XmlAttributeAttribute()]
        public string metodoDePago;

        [XmlAttributeAttribute()]
        public string LugarExpedicion;

        [XmlElementAttribute()]
        public TEmisor Emisor;

        [XmlElementAttribute()]
        public TReceptor Receptor;

        [XmlArrayItemAttribute("Concepto")]
        public TConcepto[] Conceptos;

        [XmlElementAttribute()]
        public TImpuestos Impuestos;

        public ComprobanteComplemento Complemento
        {
            get
            {
                return this.complementoField;
            }
            set
            {
                this.complementoField = value;
            }
        }
    }

    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://www.sat.gob.mx/cfd/3")]
    public partial class ComprobanteComplemento
    {

        private TimbreFiscalDigital timbreFiscalDigitalField;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.sat.gob.mx/TimbreFiscalDigital")]
        public TimbreFiscalDigital TimbreFiscalDigital
        {
            get
            {
                return this.timbreFiscalDigitalField;
            }
            set
            {
                this.timbreFiscalDigitalField = value;
            }
        }
    }
    public partial class TEmisor
    {
        [XmlAttributeAttribute()]
        public string rfc;

        [XmlAttributeAttribute()]
        public string nombre;

        [XmlElementAttribute()]
        public TDomicilioFiscal DomicilioFiscal;

        [XmlElementAttribute()]
        public TRegimenFiscal[] RegimenFiscal;

    }

    public partial class TDomicilioFiscal
    {
        [XmlAttributeAttribute()]
        public string calle;

        [XmlAttributeAttribute()]
        public string municipio;

        [XmlAttributeAttribute()]
        public string estado;

        [XmlAttributeAttribute()]
        public string pais;

        [XmlAttributeAttribute()]
        public string codigoPostal;

    }

    public partial class TRegimenFiscal
    {
        [XmlAttributeAttribute()]
        public string Regimen;

    }

    public partial class TReceptor
    {
        [XmlAttributeAttribute()]
        public string rfc;

        [XmlAttributeAttribute()]
        public string nombre;

        [XmlElementAttribute()]
        public TDomicilio Domicilio;
    }

    public partial class TDomicilio
    {
        [XmlAttributeAttribute()]
        public string calle;

        [XmlAttributeAttribute()]
        public string noExterior;

        [XmlAttributeAttribute()]
        public string colonia;

        [XmlAttributeAttribute()]
        public string municipio;

        [XmlAttributeAttribute()]
        public string estado;

        [XmlAttributeAttribute()]
        public string pais;

        [XmlAttributeAttribute()]
        public string codigoPostal;
    }

    public partial class TConcepto
    {
        [XmlAttributeAttribute()]
        public string cantidad;

        [XmlAttributeAttribute()]
        public string unidad;

        [XmlAttributeAttribute()]
        public string descripcion;

        [XmlAttributeAttribute()]
        public string valorUnitario;

        [XmlAttributeAttribute()]
        public string importe;
    }

    public partial class TImpuestos
    {
        [XmlArrayItemAttribute("Traslado")]
        public TTraslado[] Traslados;
    }

    public partial class TTraslado
    {
        [XmlAttributeAttribute()]
        public string impuesto;

        [XmlAttributeAttribute()]
        public string tasa;

        [XmlAttributeAttribute()]
        public string importe;

    }






    /// <remarks/>
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    [System.Xml.Serialization.XmlRootAttribute(Namespace = "", IsNullable = false)]
    public partial class TimbreFiscalDigital
    {

        private string versionField;

        private string uUIDField;

        private string fechaTimbradoField;

        private string selloCFDField;

        private string noCertificadoSATField;

        private string selloSATField;

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string version
        {
            get
            {
                return this.versionField;
            }
            set
            {
                this.versionField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string UUID
        {
            get
            {
                return this.uUIDField;
            }
            set
            {
                this.uUIDField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string FechaTimbrado
        {
            get
            {
                return this.fechaTimbradoField;
            }
            set
            {
                this.fechaTimbradoField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string selloCFD
        {
            get
            {
                return this.selloCFDField;
            }
            set
            {
                this.selloCFDField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string noCertificadoSAT
        {
            get
            {
                return this.noCertificadoSATField;
            }
            set
            {
                this.noCertificadoSATField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string selloSAT
        {
            get
            {
                return this.selloSATField;
            }
            set
            {
                this.selloSATField = value;
            }
        }
    }



}
