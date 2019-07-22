using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Lab11 {
    public partial class Form1 : Form {

        ArrayList clients;
        int oldagr, oldid;

        public Form1() {
            InitializeComponent();
            clients = new ArrayList();
            clients.Add(new Person(clients.Count, "clientname1", 20));
            clients.Add(new Person(clients.Count, "clientname2", 21));
            clients.Add(new Person(clients.Count, "clientname3", 22));
            Grid1.DataSource = clients;
        }

        private void Grid1_CellEndEdit(object sender, DataGridViewCellEventArgs e) {
            if (Grid1.Columns[e.ColumnIndex].HeaderText == "Id") {
                Grid1.CurrentCell.Value = oldid;
            }
            textBox1.Text = ((Person)(clients[e.RowIndex])).Clientname;
            textBox2.Text = ((Person)(clients[e.RowIndex])).Age.ToString();
        }

        private void Button1_Click(object sender, EventArgs e) {
            clients.Add(new Person(clients.Count, textBox1.Text, Convert.ToInt32(textBox2.Text)));
            Grid1.DataSource = null;
            Grid1.DataSource = clients;
            textBox1.Text = "";
            textBox2.Text = "";
        }

        private void Grid1_DataError(object sender, DataGridViewDataErrorEventArgs e) {
            e.ThrowException = false;
            //MessageBox.Show(Grid1.Columns[e.ColumnIndex].HeaderText);
            if (Grid1.Columns[e.ColumnIndex].HeaderText == "Age") {
                Grid1.CurrentCell.Value = oldagr;
            }
            e.Cancel = false;
        }

        private void Grid1_CellBeginEdit(object sender, DataGridViewCellCancelEventArgs e) {

            switch (Grid1.Columns[e.ColumnIndex].HeaderText) {
                case "Age":
                    oldagr = (int)Grid1.CurrentCell.Value;
                    break;
                case "Id":
                    oldid = (int)Grid1.CurrentCell.Value;
                    break;
                default:
                    break;
            }

        }

    }




}
