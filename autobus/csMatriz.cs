using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace autobus
{
    public partial class csMatriz : Form
    {

        string[,] values = new string[4,5];
        public csMatriz()
        {
            InitializeComponent();
            var values = new List<Valor>();
            values.Add(new Valor() { Name = "Fila 1", Value = "F1" });
            values.Add(new Valor() { Name = "Fila 2", Value = "F2" });
            values.Add(new Valor() { Name = "Fila 3", Value = "F3" });
            values.Add(new Valor() { Name = "Fila 4", Value = "F4" });
            cmbFila.DataSource = values;
            cmbFila.DisplayMember = "Name"; 
            cmbFila.ValueMember = "Value";  
            cmbFila.SelectedIndex = 0;  
        }

        private void btnSubmit_Click(object sender, EventArgs e)
        {
            if (validateEmpty())
            {
                MessageBox.Show("Debes ingresar datos");
                return;
            }

            string[] temp = txtChairs.Text.Trim().Split(',');
            temp = temp.Distinct().ToArray();
            if (temp.Length > 5)
            {
                MessageBox.Show("La cantidad de sillas que solicita no está disponible");
                return;
            }

            for (int i = 0; i < temp.Length; i++)
            {
                int filaIndex = fila(cmbFila.SelectedValue.ToString());
                int columnIndex = int.Parse(temp[i]);
                if (validateReserve(int.Parse(temp[i]), filaIndex - 1, columnIndex -1))
                {
                    MessageBox.Show("Asiento " + temp[i] + " ya ha sido reservado");
                    return;
                }
                else if (int.Parse(temp[i]) < 1 || int.Parse(temp[i]) > 5)
                {
                    MessageBox.Show("Asiento fuera del rango");
                    return;
                }
                {
                    values[filaIndex - 1, columnIndex - 1] = temp[i]; 
                    setValues(filaIndex, columnIndex);
                    cleanInput();
                }
            }
        }


        private void cleanInput()
        {
            txtChairs.Text = "";
        }

        private bool validateEmpty()
        {
            return (txtChairs.Text.Trim() == "" || txtChairs.Text.Trim().Length <= 0);
        }

        private bool validateReserve(int chair, int i, int j)
        {
            bool result = false;
            if (values[i, j] != null)
            {
                if (int.Parse(values[i, j]) == chair)
                {
                    result = true;
                }
            }

            return result;  
        }

        private int fila(string value)
        {
            switch (value)
            {
                case "F1":
                    return 1;
                case "F2":
                    return 2;
                case "F3":
                    return 3;
                case "F4":
                    return 4;
                    default: 
                    return 0;
            }
        }

        private void setValues(int fila, int column)
        {
            if (fila == 1)
            {
                switch(column)
                {
                    case 1:
                        chk1.Checked = true;    
                        break;
                   case 2:
                        chk2.Checked = true;
                        break;
                    case 3:
                        chk3.Checked = true;
                        break;
                    case 4:
                        chk4.Checked = true;
                        break;
                    case 5:
                        chk5.Checked = true;
                        break;
                    default:
                        return;
                }
            }

            if (fila == 2)
            {
                switch (column)
                {
                    case 1:
                        chk1_2.Checked = true;
                        break;
                    case 2:
                        chk2_2.Checked = true;
                        break;
                    case 3:
                        chk3_2.Checked = true;
                        break;
                    case 4:
                        chk4_2.Checked = true;
                        break;
                    case 5:
                        chk5_2.Checked = true;
                        break;
                    default:
                        return;
                }
            }


            if (fila == 3)
            {
                switch (column)
                {
                    case 1:
                        chk1_3.Checked = true;
                        break;
                    case 2:
                        chk2_3.Checked = true;
                        break;
                    case 3:
                        chk3_3.Checked = true;
                        break;
                    case 4:
                        chk4_3.Checked = true;
                        break;
                    case 5:
                        chk5_3.Checked = true;
                        break;
                    default:
                        return;
                }
            }


            if (fila == 4)
            {
                switch (column)
                {
                    case 1:
                        chk1_4.Checked = true;
                        break;
                    case 2:
                        chk2_4.Checked = true;
                        break;
                    case 3:
                        chk3_4.Checked = true;
                        break;
                    case 4:
                        chk4_4.Checked = true;
                        break;
                    case 5:
                        chk5_4.Checked = true;
                        break;
                    default:
                        return;
                }
            }
        }

    }

    public class Valor
    {
        public string Value { get; set; }
        public string Name { get; set; }    
    }
}
