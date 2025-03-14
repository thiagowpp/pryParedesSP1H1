﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace pryParedesSP1H1
{
    public partial class frmCultivos : Form
    {
        
        public frmCultivos()
        {
            InitializeComponent();
        }

        private void btnCrearLocalidad_Click(object sender, EventArgs e)
        {
            File.Create("./cultivos.txt");
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            //Abro el Agregado de datos, y uso StreamWriter (para salida de caracteres en una codificacion determinada)
            TextWriter Escribir = new StreamWriter("./cultivos.txt", true);

            //Uso la variable "Escribir" para escribir en el archivo ("./cultivos.txt)
            Escribir.WriteLine(Convert.ToString(txtIdentificador.Text + " " + txtCultivo.Text));
            Escribir.Close();

            MessageBox.Show("El cultivo se guardo correctamente", "Exito", MessageBoxButtons.OK, MessageBoxIcon.Information);

            txtCultivo.Text = "";
            txtIdentificador.Text = "";
            txtCultivo.Focus();
        }

        private void txtCultivo_TextChanged(object sender, EventArgs e)
        {
            //Si la textboxCultivo es diferente a vacio
            if (txtCultivo.Text != "")
            {
                btnAceptar.Enabled = true;

                btnEliminar.Enabled = true;
            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            //DialogResult, que se basa en el resultado que el usuario de cuando se muestre la MessageBox (Resultados de dialogo: Ok  - Cancelar)
            DialogResult r = MessageBox.Show("¿Esta seguro que desea eliminar el archivo?" + "\nAtencion: Si elimina el archivo todo el contenido se perdera" + "\n¿Aun desea continuar?", "Atencion", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);

            if (r == DialogResult.OK)
            {
                File.Delete("./cultivos.txt");


                MessageBox.Show("Archivo eliminado con exito", "Exito", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

            if (r == DialogResult.Cancel)
            {
                MessageBox.Show("Accion cancelada", "Cancelado", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void frmCultivos_Load(object sender, EventArgs e)
        {

        }
    }
}    
