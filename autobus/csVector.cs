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
    public partial class csVector : Form
    {
        List<String> values = new List<String>(); 
        public csVector()
        {
            InitializeComponent();
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
            int quantity = temp.Length;
            int available = 20 - this.values.Count() ;
            if (quantity <= 0 || quantity > 20 || (quantity > available))
            {
                MessageBox.Show("La cantidad de sillas que solicita no está disponible");
                return;
            }


            temp = temp.Distinct().ToArray();
            for (int i = 0; i < temp.Length; i ++ )
            {
                if (validateReserve(int.Parse(temp[i])))
                {
                    MessageBox.Show("Asiento " + temp[i] + " ya ha sido reservado");
                    return;
                } else if (int.Parse(temp[i]) < 1 || int.Parse(temp[i]) > 20)
                {
                    MessageBox.Show("Asiento fuera del rango");
                    return;
                } else 
                {
                    values.Add(temp[i]);    
                    setValues(int.Parse(temp[i]));
                }
            }

            this.cleanInput();  
        }


        private void setValues(int chair)
        {
            switch (chair)
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
                case 6:
                    chk6.Checked = true;
                    break;
                case 7:
                    chk7.Checked = true;
                    break;
                case 8:
                    chk8.Checked = true;
                    break;
                case 9:
                    chk9.Checked = true;
                    break;
                case 10:
                    chk10.Checked = true;
                    break;
                case 11:
                    chk11.Checked = true;
                    break;
                case 12:
                    chk12.Checked = true;
                    break;
                case 13:
                    chk13.Checked = true;
                    break;
                case 14:
                    chk14.Checked = true;
                    break;
                case 15:
                    chk15.Checked = true;
                    break;
                case 16:
                    chk16.Checked = true;
                    break;
                case 17:
                    chk17.Checked = true;
                    break;
                case 18:
                    chk18.Checked = true;
                    break;
                case 19:
                    chk19.Checked = true;
                    break;
                case 20:
                    chk20.Checked = true;
                    break;
                default:
                    break;

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

        private bool validateReserve(int chair)
        {
            bool result = false;
            foreach (String item in this.values)
            {
                if (int.Parse(item) == chair)
                {
                    result = true;  
                }
            }  

            return result;
        }
    }
}
