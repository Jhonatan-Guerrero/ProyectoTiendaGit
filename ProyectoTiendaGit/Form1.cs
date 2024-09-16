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
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace ProyectoTiendaGit
{
    public partial class Form1 : Form
    {
        ManejadorProductos mp;
        int fila = 0, columna = 0;
        public static string Nombre = "", Descripcion = "";
        public static double precio = 0.0;
        public static int IdProductos = 0;

        private void dtgvProductos_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            fila = e.RowIndex; columna = e.ColumnIndex;
            switch (columna)
            {
                case 4:
                    {
                        IdProductos = int.Parse(dtgvProductos.Rows[fila].Cells[0].Value.ToString());
                        mp.Borrar(IdProductos, dtgvProductos.Rows[fila].Cells[1].Value.ToString());
                        dtgvProductos.Visible = true;
                    }
                    break;
                case 5:
                    {
                        {
                            IdProductos = int.Parse(dtgvProductos.Rows[fila].Cells[0].Value.ToString());
                            Nombre = dtgvProductos.Rows[fila].Cells[1].Value.ToString();
                            Nombre = dtgvProductos.Rows[fila].Cells[2].Value.ToString();
                            precio = double.Parse(dtgvProductos.Rows[fila].Cells[3].Value.ToString());
                            
                            frmAgregarProductos ap = new frmAgregarProductos();
                            ap.ShowDialog();
                            ap.Visible = true;
                        }
                        break;
                    }
            }
        }

        private void txtProducto_TextChanged(object sender, EventArgs e)
        {
            dtgvProductos.Visible = true;
            mp.Mostrar(dtgvProductos,txtProducto.Text);
        }

        public Form1()
        {
            InitializeComponent();
            mp = new ManejadorProductos();
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            IdProductos = 0; Nombre = ""; Descripcion = ""; precio = 0.0;
            dtgvProductos.Visible = false;
            frmAgregarProductos ap = new frmAgregarProductos();
            ap.ShowDialog();
            txtProducto.Focus();
        }
    }
}
