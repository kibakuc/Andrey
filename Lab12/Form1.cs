using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Serialization;

namespace Lab12 {
    public partial class Form1 : Form {
        ArrayList product;
        DataTable dt;
        DataRow dr;
        DataSet ds;
        int id;

        public Form1() {
            InitializeComponent();
            ds = new DataSet();
            dt = new DataTable();
            product = new ArrayList();
            FileInfo f = new FileInfo("product.xml");

            dt.Columns.Add(new DataColumn("ID", Type.GetType("System.Int32")));
            dt.Columns.Add(new DataColumn("Name", Type.GetType("System.String")));
            dt.Columns.Add(new DataColumn("Price", Type.GetType("System.Int32")));

            if (!f.Exists) {
                product.Add(new Product(product.Count, "name1", 20));
                product.Add(new Product(product.Count, "name2", 21));
                product.Add(new Product(product.Count, "name3", 22));


                for (int i = 0; i < product.Count; i++) {
                    dr = dt.NewRow();
                    dr["ID"] = ((Product)(product[i])).Id;
                    dr["Name"] = ((Product)(product[i])).Name;
                    dr["Price"] = ((Product)(product[i])).Price;
                    dt.Rows.Add(dr);
                }
            }
            ds.Tables.Add(dt);
            ds.Tables[0].TableName = "Product";

            if (!f.Exists) {
                Serializer.WriteXML("product.xml", ds);
            }
            ds = Serializer.ReadXML("product.xml");
            GridView1.DataSource = ds.Tables[0];
            Name1.Text = GridView1.Rows[0].Cells["Name"].Value.ToString();
            Price1.Text = GridView1.Rows[0].Cells["Price"].Value.ToString();

        }

        private void GridView1_CellClick(object sender, DataGridViewCellEventArgs e) {
            if (e.RowIndex >= 0) {
                id = GridView1.CurrentCell.RowIndex;
                Name1.Text = GridView1.Rows[e.RowIndex].Cells["Name"].Value.ToString();
                Price1.Text = GridView1.Rows[e.RowIndex].Cells["Price"].Value.ToString();
            }
        }

        private void GridView1_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e) {
            if (e.RowIndex < 0) {
                id = 0;
                Name1.Text = GridView1.Rows[0].Cells["Name"].Value.ToString();
                Price1.Text = GridView1.Rows[0].Cells["Price"].Value.ToString();
            }
        }

        //Add button
        private void Button1_Click(object sender, EventArgs e) {
            int number;
            DataRow dr = ds.Tables[0].NewRow();
            dr["ID"] = GridView1.Rows.Count - 1;
            dr["Name"] = Name1.Text;
            dr["Price"] = (int.TryParse(Price1.Text, out number) == true) ? Price1.Text : "0";
            ds.Tables[0].Rows.Add(dr);
            Serializer.WriteXML("product.xml", ds);
            Name1.Text = "";
            Price1.Text = "";
        }

        //Save button
        private void Button2_Click(object sender, EventArgs e) {
            int number;
            id = GridView1.CurrentCell.RowIndex;
            GridView1.Rows[id].Cells["ID"].Value = id;
            GridView1.Rows[id].Cells["Name"].Value = Name1.Text.Trim();
            GridView1.Rows[id].Cells["Price"].Value = Convert.ToInt32((int.TryParse(Price1.Text, out number) == true) ? Price1.Text : "0");
            Serializer.WriteXML("product.xml", ds);
        }

        //Del button
        private void Button3_Click(object sender, EventArgs e) {
            DataRow drCurrent = ds.Tables[0].Rows[GridView1.CurrentCell.RowIndex];
            drCurrent.Delete();
            Serializer.WriteXML("product.xml", ds);
        }
    }




}
