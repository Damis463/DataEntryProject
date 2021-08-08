using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DataEntryProject
{
    public partial class frmDataEntry : Form
    {

        TimeSpan elapsedTime;
        DateTime lastElapsed;


        public frmDataEntry()
        {
            InitializeComponent();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            txtName.Clear();
            txtAdress.Clear();
            txtCity.Clear();
            txtState.Clear();
            txtZip.Clear();
            txtName.Focus();
        }

        private void timTimer_Tick(object sender, EventArgs e)
        {
            elapsedTime += DateTime.Now  - lastElapsed;
            lastElapsed = DateTime.Now;

            txtTimer.Text = Convert.ToString(
                new TimeSpan(elapsedTime.Hours, elapsedTime.Minutes, elapsedTime.Seconds));
        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            btnStart.Enabled = false;
            btnPause.Enabled = true;
            timTimer.Enabled = true;
            grbDataEntry.Enabled = true;
            txtName.Focus();
            lastElapsed = DateTime.Now;
        }

        private void btnPause_Click(object sender, EventArgs e)
        {
            btnStart.Enabled = true;
            btnPause.Enabled = false;
            grbDataEntry.Enabled = false;
            timTimer.Enabled = false;
        }

        private void btnAccept_Click(object sender, EventArgs e)
        {
            string dataEntry;

            if (txtName.Text.Equals("") || txtAdress.Text.Equals("") ||
                txtCity.Text.Equals("") || txtState.Text.Equals("") || txtZip.Text.Equals(""))
            {
                MessageBox.Show("Each box must have an input", "Error Message",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtName.Focus();
                return;
            }

            dataEntry = txtName.Text + "\r\n" + txtAdress.Text + "\r\n" + txtCity.Text + "\r\n" +
                txtState.Text + "\r\n" + txtZip.Text + "\r\n";
            MessageBox.Show(dataEntry, "Data Entry", MessageBoxButtons.OK);
            btnClear.PerformClick();
        }

        private void txtInput_KeyPress(object sender, KeyPressEventArgs e)
        {
            string textBoxSender = ((TextBox)sender).Name;

            if (e.KeyChar == 13)
            { 
                switch(textBoxSender)
                {
                   case "txtName":
                       txtAdress.Focus();
                       break;
                   case "txtAdress":
                       txtCity.Focus();
                       break;
                    case "txtCity":
                        txtState.Focus();
                        break;
                    case "txtState":
                        txtZip.Focus();
                        break;
                    case "txtZip":
                        btnAccept.Focus();
                        break;
                 }
            }

            if (textBoxSender.Equals("txtZip"))
            {
                if (e.KeyChar >='0' && e.KeyChar <='9' || e.KeyChar == 8)
                {
                    e.Handled = false;
                }
                else
                {
                    e.Handled = true;
                }
            }
        }
    }        
}

