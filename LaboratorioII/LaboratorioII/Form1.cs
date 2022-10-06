using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LaboratorioII
{
    public partial class Form1 : Form
    {
        List<Calzado> calzados = new List<Calzado>();
        public string nomProd;
        int id = 0;
        
        public void LimpiarCampos()
        {
            txtId.Clear();
            txtMarca.Clear();
            txtDescrip.Clear();
            cbxCategoria.Text = "";
            txtTalla.Clear();
            txtCantidad.Clear();
            txtPrecioC.Clear();
        }

        public void idProducto()
        {
            txtId.Text = id.ToString();
            id = id + 1;
        }

        public void Registrar()
        {
            try
            {
                if(txtId.Text != "" && txtMarca.Text != "" && txtDescrip.Text != "" && cbxCategoria.Text != "" && 
                   txtTalla.Text != "" && txtCantidad.Text != "" && txtPrecioC.Text != "")
                {
                    double pVenta;
                    Calzado cls = new Calzado();
                    cls.idProducto = int.Parse(txtId.Text);
                    cls.Marca = txtMarca.Text;
                    cls.Descripcion = txtDescrip.Text;
                    cls.Categoria = cbxCategoria.Text;
                    cls.Talla = double.Parse(txtTalla.Text);
                    cls.Cantidad = int.Parse(txtCantidad.Text);
                    cls.PrecioCompra = double.Parse(txtPrecioC.Text);

                    pVenta = double.Parse(txtPrecioC.Text) + (double.Parse(txtPrecioC.Text) * 0.13);

                    cls.PrecioVenta = pVenta;
                    calzados.Add(cls);
                    LimpiarCampos();
                    idProducto();
                    Mostrar();

                }
            }
            catch (Exception e)
            {

                MessageBox.Show("Error al registrar", e.Message);
            }
        }

        public void Mostrar()
        {
            string Datos = "";
            foreach( Calzado cl in calzados)
            {
                Datos = Datos + "- " + cl.idProducto + "- " + cl.Marca + "- " + cl.Descripcion + "- " + cl.Categoria + "- " + cl.Talla + "- " + cl.Cantidad + "- " + cl.PrecioCompra + "- " + cl.PrecioVenta + "\n";
            }
            rtbMostrar.Text = Datos;
        }

        public void Buscar()
        {
            try
            {

                var busqueda = calzados.Where(cl => cl.idProducto == int.Parse(txtBuscar.Text));
                foreach( Calzado cl in busqueda)
                {
                    txtId.Text = Convert.ToString(cl.idProducto);
                    txtMarca.Text = cl.Marca;
                    txtDescrip.Text = cl.Descripcion;
                    cbxCategoria.Text = cl.Categoria;
                    txtTalla.Text = Convert.ToString(cl.Talla);
                    txtCantidad.Text = Convert.ToString(cl.Cantidad);
                    txtPrecioC.Text = Convert.ToString(cl.PrecioCompra);

                }
            }
            catch (Exception e)
            {

                MessageBox.Show("Error al buscar", e.Message);
            }
        }

        public void Filtrar()
        {
            try
            {
                string validacion = null;

                if( cbxFiltro.Text == "Categoria" )
                {   
                        string mostrar = "";
                        
                        string cat;
                        cat = txtDato.Text;
                        var consulta = from cate in calzados where cate.Categoria.Equals(txtDato.Text) select cate;

                        foreach( Calzado cls in consulta)
                        {
                            mostrar = mostrar + "_ " + cls.idProducto + " -" + cls.Marca + " -" + cls.Descripcion + " -" + cls.Categoria + " -" + cls.Talla + " -" + cls.Cantidad + " -" + cls.PrecioCompra + " -" + cls.PrecioVenta + "\n";
                        }

                        rtbFiltrar.Text = mostrar;
                }
                else
                {
                    string mostrar = "";
                    string marca;
                    marca = txtDato.Text;
                    var consulta = from marc in calzados where marc.Marca == txtDato.Text select marc;

                    foreach (Calzado cls in consulta)
                    {
                        mostrar = mostrar + "_ " + cls.idProducto + " -" + cls.Marca + " -" + cls.Descripcion + " -" + cls.Categoria + " -" + cls.Talla + " -" + cls.Cantidad + " -" + cls.PrecioCompra + " -" + cls.PrecioVenta + "\n";
                    }

                    rtbFiltrar.Text = mostrar;
                }
            }
            catch (Exception e)
            {

                MessageBox.Show("Error al filrar", e.Message);
            }
        }

        public void Editar()
        {
            try
            {
                foreach (Calzado cls in calzados)
                {
                    if (cls.idProducto == Convert.ToInt32(txtId.Text)) ;
                    {
                        double pVenta;
                        cls.idProducto = Convert.ToInt32(txtId.Text);
                        cls.Marca = txtMarca.Text;
                        cls.Descripcion = txtDescrip.Text;
                        cls.Categoria = cbxCategoria.Text;
                        cls.Talla = Convert.ToDouble(txtTalla.Text);
                        cls.Cantidad = Convert.ToInt32(txtCantidad.Text);
                        cls.PrecioCompra = Convert.ToDouble(txtPrecioC.Text);
                        pVenta = double.Parse(txtPrecioC.Text) + (double.Parse(txtPrecioC.Text) * 0.13);

                        cls.PrecioVenta = pVenta;
                    }
                }
            }
            catch (Exception e)
            {

                throw;
            }
        }

        public void Eliminar()
        {
            try
            {   
                
                int idBusqueda = Convert.ToInt32(txtId.Text);
                int indice = calzados.FindIndex( cl => cl.idProducto == idBusqueda );

                foreach( Calzado cls in calzados)
                {
                    calzados.RemoveAt(indice);
                    break;
                }

                
                /*
                if( txtId.Text != "")
                {
                    foreach( Calzado cls in calzados)
                    {
                        if( cls.idProducto == Convert.ToInt32(txtId.Text))
                        {
                            DialogResult respuesta = MessageBox.Show("Eliminaras el registro?", "Eliminar", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                            if( respuesta == DialogResult.Yes)
                            {
                                calzados.Remove(cls);

                            }
                        }
                    }
                }*/
            }
            catch (Exception e)
            {

                MessageBox.Show("Error al eliminar", e.Message);
            }
        }

        public Form1()
        {
            InitializeComponent();
            idProducto();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void btnRegistrar_Click(object sender, EventArgs e)
        {
            Registrar();
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            Buscar();
        }

        private void btnFiltrar_Click(object sender, EventArgs e)
        {
            Filtrar();
            txtDato.Clear();
            cbxFiltro.Text = "";
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            Editar();
            Mostrar();
            LimpiarCampos();
            idProducto();
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            Eliminar();
            LimpiarCampos();
            idProducto();
            Mostrar();
        }
    }
}
