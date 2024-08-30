using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatosLayer
{
    public class Customers
    {
        // Propiedades de la clase Customers, que corresponden a los campos de la tabla Customers en la base de datos

        // ID del cliente, usualmente una clave primaria en la base de datos
        public string CustomerID { get; set; }

        // Nombre de la compañía del cliente
        public string CompanyName { get; set; }

        // Nombre del contacto en la compañía del cliente
        public string ContactName { get; set; }

        // Título del contacto en la compañía del cliente (por ejemplo, Gerente de Ventas)
        public string ContactTitle { get; set; }

        // Dirección del cliente
        public string Address { get; set; }

        // Ciudad donde se encuentra el cliente
        public string City { get; set; }

        // Región o estado donde se encuentra el cliente
        public string Region { get; set; }

        // Código postal del cliente
        public string PostalCode { get; set; }

        // País donde se encuentra el cliente
        public string Country { get; set; }

        // Número de teléfono del cliente
        public string Phone { get; set; }

        // Número de fax del cliente
        public string Fax { get; set; }
    }

}
