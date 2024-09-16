using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using AccesoDatos;

namespace Manejador
{
    public class ManejadorProductos
    {
        Funciones f = new Funciones();
        public void Guardar(TextBox Nombre, TextBox Descripcion,TextBox Precio)
        {
            MessageBox.Show(f.Guardar($"Call p_InsertarProductos('{Nombre.Text}','{Descripcion.Text}','{Precio.Text}')"), "!ATENCIÓN!", MessageBoxButtons.OK, MessageBoxIcon.Information);

        }
        public void Borrar(int IdProductos, string dato)
        {
            DialogResult rs = MessageBox.Show($"¿Estas seguro de borrar el registro{dato}?", "!ATENCION", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (rs == DialogResult.Yes)
            {
                f.Borrar($"call p_EliminarProductos({IdProductos})");
                MessageBox.Show("Registro Eliminado", "!Atencion", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        DataGridViewButtonColumn Boton(string t, Color co)
        {
            DataGridViewButtonColumn bo = new DataGridViewButtonColumn();
            bo.Text = t;
            bo.UseColumnTextForButtonValue = true;
            bo.FlatStyle = FlatStyle.Popup;
            bo.DefaultCellStyle.BackColor = co;
            bo.DefaultCellStyle.ForeColor = Color.White;
            return bo;
        }
        public void Mostrar(DataGridView tabla, string filtro)
        {
            tabla.Columns.Clear();
            tabla.DataSource = f.Mostrar($"Select * from Productos where Nombre LIKE '%{filtro}%'", "Productos").Tables[0];
            tabla.Columns.Insert(4, Boton("Borrar", Color.Red));
            tabla.Columns.Insert(5, Boton("Modificar", Color.Green));
            tabla.AutoResizeColumns();
            tabla.AutoResizeRows();
        }
    }
}
