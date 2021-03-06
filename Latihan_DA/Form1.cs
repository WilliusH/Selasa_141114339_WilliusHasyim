﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace Latihan_DA
{
    public partial class Form1 : Form
    {
        MySqlConnection conn;
        MySqlDataAdapter customerDA;
        // DataSet ds;
        DataTable datatable;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            string myConnectionString = "Server=localhost;Database=testing;Uid=root;Pwd=;";
            conn = new MySqlConnection(myConnectionString);
            conn.Open();
            // ds = new DataSet();
            datatable = new DataTable();
            initializeDA();
            customerDA.SelectCommand.ExecuteScalar();
            // customerDA.Fill(ds, "customer");
            customerDA.Fill(datatable);
            dgvDaftar.ReadOnly = true;
            dgvDaftar.AllowUserToAddRows = false;
            dgvDaftar.AllowUserToDeleteRows = false;
            dgvDaftar.SelectionMode = DataGridViewSelectionMode.FullRowSelect;

            BindingSource bindingsource = new BindingSource();
            // bs.DataSource = ds.Tables["customer"];
            bindingsource.DataSource = datatable;
            dgvDaftar.DataSource = bindingsource;
            // dgvDaftar.DataSource = ds.Tables["customer"];
        }

        private void initializeDA()
        {
            customerDA = new MySqlDataAdapter();

            // SELECT
            string customerSelectSql = String.Concat("SELECT * FROM customer");
            customerDA.SelectCommand = new MySqlCommand(customerSelectSql, conn);

            // INSERT
            string customerInsertSql = String.Concat("INSERT INTO customer (name, address, zip_code, phone_number, email,created_at) VALUES (@name, @address, @zip_code, @phone_number, @email,@created_at)");
            /*string sql = "INSERT into customer (name,address,zip_code,phone_number,email,create_at,update_at)";
            sql += "VALUES(@name,@address,@zip_code,@phone_number,@email)";*/
            MySqlCommand customerInsertCommand = new MySqlCommand(customerInsertSql, conn);

            customerInsertCommand.Parameters.AddWithValue("@name", txName.Text);
            customerInsertCommand.Parameters.AddWithValue("@address", txAddress.Text);
            customerInsertCommand.Parameters.AddWithValue("@zip_code", txZipCode.Text);
            customerInsertCommand.Parameters.AddWithValue("@phone_number", txPhoneNumber.Text);
            customerInsertCommand.Parameters.AddWithValue("@email", txEmail.Text);
            customerInsertCommand.Parameters.AddWithValue("@created_at", DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss"));
            // customerInsertCommand.Parameters.AddWithValue("@updated_at", DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss"));
            customerDA.InsertCommand = customerInsertCommand;
            //MessageBox.Show(sql);


            // UPDATE
            string customerUpdateSql = String.Concat("UPDATE customer SET name = @name, address = @address, zip_code = @zip_code, phone_number = @phone_number, email = @email, updated_at = @updated_at WHERE id = @id");
            MySqlCommand customerUpdateCommand = new MySqlCommand(customerUpdateSql, conn);
            customerUpdateCommand.Parameters.AddWithValue("@id", txId.Text);
            customerUpdateCommand.Parameters.AddWithValue("@name", txName.Text);
            customerUpdateCommand.Parameters.AddWithValue("@address", txAddress.Text);
            customerUpdateCommand.Parameters.AddWithValue("@zip_code", txZipCode.Text);
            customerUpdateCommand.Parameters.AddWithValue("@phone_number", txPhoneNumber.Text);
            customerUpdateCommand.Parameters.AddWithValue("@email", txEmail.Text);
            customerUpdateCommand.Parameters.AddWithValue("@updated_at", DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss"));
            customerDA.UpdateCommand = customerUpdateCommand;

            // delete


        }

        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            conn.Close();
            conn.Dispose();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // INSERT
            initializeDA();
            string psn = "";
            if (txId.Text == "")
            {
                psn = String.Concat(customerDA.InsertCommand.ExecuteNonQuery(), " Record succesfully saved.");

                // MessageBox.Show(psn);
            }
            MessageBox.Show(psn, "Save Information");
            customerDA.SelectCommand.ExecuteScalar();
            datatable.Clear();
            customerDA.Fill(datatable);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            // UPDATE
            initializeDA();
            string psn = "";
            if (txId.Text != "")
            {
                psn = String.Concat(customerDA.UpdateCommand.ExecuteNonQuery(), " Record succesfully updated.");
            }
            MessageBox.Show(psn, "Save Information");
            customerDA.SelectCommand.ExecuteScalar();
            datatable.Clear();
            customerDA.Fill(datatable);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (dgvDaftar.SelectedRows.Count > 0)
            {
                string customerDeleteSql = String.Concat("DELETE FROM customer WHERE ID= @id");
                MySqlCommand customerDeleteCommand = new MySqlCommand(customerDeleteSql, conn);
                customerDeleteCommand.Parameters.AddWithValue("@id", Convert.ToString(dgvDaftar.SelectedCells[0].Value));
                customerDeleteCommand.ExecuteNonQuery();
                customerDA.SelectCommand.ExecuteScalar();
                datatable.Clear();
                customerDA.Fill(datatable);
            }
            else
            {
                MessageBox.Show("Nothing to Delete !");
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void dgvDaftar_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            txId.Text = dgvDaftar.Rows[e.RowIndex].Cells[0].Value.ToString();
            txName.Text = dgvDaftar.Rows[e.RowIndex].Cells[1].Value.ToString();
            txAddress.Text = dgvDaftar.Rows[e.RowIndex].Cells[2].Value.ToString();
            txZipCode.Text = dgvDaftar.Rows[e.RowIndex].Cells[3].Value.ToString();
            txPhoneNumber.Text = dgvDaftar.Rows[e.RowIndex].Cells[4].Value.ToString();
            txEmail.Text = dgvDaftar.Rows[e.RowIndex].Cells[5].Value.ToString();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            foreach(Control i in Controls)
            {
                if(i is TextBox)
                {
                    (i as TextBox).Clear();
                    txName.Focus();
                }
            }
        }

        private void txId_TextChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void txName_TextChanged(object sender, EventArgs e)
        {

        }

        private void txAddress_TextChanged(object sender, EventArgs e)
        {

        }

        private void txZipCode_TextChanged(object sender, EventArgs e)
        {

        }

        private void txPhoneNumber_TextChanged(object sender, EventArgs e)
        {

        }

        private void txEmail_TextChanged(object sender, EventArgs e)
        {

        }

        private void dgvDaftar_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
