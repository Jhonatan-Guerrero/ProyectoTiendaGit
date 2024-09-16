using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Manejador;


namespace ProyectoTiendaGit
{
    public partial class frmAgregarProductos : Form
    {
        ManejadorProductos mp;
        public frmAgregarProductos()
        {

            InitializeComponent();
            mp= new ManejadorProductos();
            if (Form1.IdProductos > 0)
            {
                txtNombre.Text = Form1.Nombre;
                txtDescripcion.Text = Form1.Descripcion;
                txtPrecio.Text = Form1.precio.ToString();
            }
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (Form1.IdProductos > 0)
            {

            }
            else
                mp.Guardar(txtNombre, txtDescripcion, txtPrecio);
            Close();
        }
    }
}
