using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using DatosLayer;
using System.Net;
using System.Reflection;


namespace ConexionEjemplo
{
    public partial class Form1 : Form
    {
        // Se crea una instancia del repositorio de clientes para interactuar con la base de datos.
        CustomerRepository customerRepository = new CustomerRepository();

        // Constructor del formulario.
        public Form1()
        {
            InitializeComponent(); // Inicializa los componentes del formulario.
        }

        // Evento asociado al botón "Cargar", que carga todos los clientes en el DataGridView.
        private void btnCargar_Click(object sender, EventArgs e)
        {
            var Customers = customerRepository.ObtenerTodos(); // Obtiene la lista de todos los clientes.
            dataGrid.DataSource = Customers; // Asigna la lista de clientes como fuente de datos del DataGridView.
        }

        // Evento asociado al cambio de texto en un TextBox. (Actualmente comentado y no se utiliza).
        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            // Este código permite filtrar la lista de clientes según el texto ingresado (comentado).
            // var filtro = Customers.FindAll(X => X.CompanyName.StartsWith(tbFiltro.Text));
            // dataGrid.DataSource = filtro;
        }

        // Evento que se ejecuta cuando el formulario se carga (inicialización adicional).
        private void Form1_Load(object sender, EventArgs e)
        {
            // Código comentado que establece valores para el nombre de la aplicación y el tiempo de espera en la conexión a la base de datos.
            /*
            DatosLayer.DataBase.ApplicationName = "Programacion 2 ejemplo";
            DatosLayer.DataBase.ConnectionTimeout = 30;

            string cadenaConexion = DatosLayer.DataBase.ConnectionString;
            var conxion = DatosLayer.DataBase.GetSqlConnection();
            */
        }

        // Evento asociado al botón "Buscar", que busca un cliente por su ID y llena los campos de texto con la información del cliente.
        private void btnBuscar_Click(object sender, EventArgs e)
        {
            var cliente = customerRepository.ObtenerPorID(txtBuscar.Text); // Busca un cliente por ID.
                                                                           // Llena los TextBox con los datos del cliente encontrado.
            tboxCustomerID.Text = cliente.CustomerID;
            tboxCompanyName.Text = cliente.CompanyName;
            tboxContacName.Text = cliente.ContactName;
            tboxContactTitle.Text = cliente.ContactTitle;
            tboxAddress.Text = cliente.Address;
            tboxCity.Text = cliente.City;
        }

        // Evento asociado a un clic en un label (no tiene funcionalidad, sólo está presente por compatibilidad con el diseñador de Windows Forms).
        private void label4_Click(object sender, EventArgs e)
        {
        }

        // Evento asociado al botón "Insertar", que inserta un nuevo cliente en la base de datos.
        private void btnInsertar_Click(object sender, EventArgs e)
        {
            var resultado = 0;

            var nuevoCliente = ObtenerNuevoCliente(); // Obtiene un nuevo cliente con los datos ingresados en el formulario.

            // Validación de campos comentada para asegurarse de que todos los campos necesarios estén llenos.

            // Si la validación de campos nulos pasa, inserta el cliente.
            if (validarCampoNull(nuevoCliente) == false)
            {
                resultado = customerRepository.InsertarCliente(nuevoCliente); // Inserta el cliente en la base de datos.
                MessageBox.Show("Guardado" + "Filas modificadas = " + resultado); // Muestra un mensaje indicando el éxito de la operación.
            }
            else
            {
                MessageBox.Show("Debe completar los campos por favor"); // Muestra un mensaje si faltan campos por completar.
            }
        }

        // Método para validar si algún campo del objeto cliente está vacío. Retorna true si hay un campo vacío, false si todos están llenos.
        public Boolean validarCampoNull(Object objeto)
        {
            foreach (PropertyInfo property in objeto.GetType().GetProperties())
            {
                object value = property.GetValue(objeto, null);
                if ((string)value == "")
                {
                    return true; // Si encuentra un campo vacío, retorna true.
                }
            }
            return false; // Si no encuentra campos vacíos, retorna false.
        }

        // Evento asociado a un clic en otro label (no tiene funcionalidad).
        private void label5_Click(object sender, EventArgs e)
        {
        }

        // Evento asociado al botón "Modificar", que actualiza la información de un cliente en la base de datos.
        private void btModificar_Click(object sender, EventArgs e)
        {
            var actualizarCliente = ObtenerNuevoCliente(); // Obtiene los datos actualizados del cliente.
            int actualizadas = customerRepository.ActualizarCliente(actualizarCliente); // Actualiza el cliente en la base de datos.
            MessageBox.Show($"Filas actualizadas = {actualizadas}"); // Muestra un mensaje con la cantidad de filas actualizadas.
        }

        // Método para crear un nuevo cliente utilizando los datos ingresados en los TextBox del formulario.
        private Customers ObtenerNuevoCliente()
        {
            var nuevoCliente = new Customers
            {
                CustomerID = tboxCustomerID.Text,
                CompanyName = tboxCompanyName.Text,
                ContactName = tboxContacName.Text,
                ContactTitle = tboxContactTitle.Text,
                Address = tboxAddress.Text,
                City = tboxCity.Text
            };

            return nuevoCliente; // Retorna el nuevo cliente creado.
        }

        // Evento asociado al botón "Eliminar", que elimina un cliente de la base de datos utilizando su ID.
        private void btnEliminar_Click(object sender, EventArgs e)
        {
            int elimindas = customerRepository.EliminarCliente(tboxCustomerID.Text); // Elimina el cliente de la base de datos.
            MessageBox.Show("Filas eliminadas = " + elimindas); // Muestra un mensaje indicando cuántas filas fueron eliminadas.
        }

    }
}