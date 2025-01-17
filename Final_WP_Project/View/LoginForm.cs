﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Final_WP_Project.View
{
    public partial class LoginForm : Form
    {
        public LoginForm()
        {
            InitializeComponent();
            Style();
        }
        public void NoBorderButton(Button a)
        {
            a.TabStop = false;
            a.FlatStyle = FlatStyle.Flat;
            a.FlatAppearance.BorderSize = 0;
        }
        private void userName_txt_Enter(object sender, EventArgs e)
        {
            if(userName_txt.Text== "Username")
            {
                userName_txt.Text = "";
            }    
        }

        private void userName_txt_Leave(object sender, EventArgs e)
        {
            if(userName_txt.Text == "")
            {
                userName_txt.Text = "Username";
                userName_txt.ForeColor = Color.FromArgb(48, 182, 251);
            }
        }

        private void password_txt_Enter(object sender, EventArgs e)
        {
            if (password_txt.Text == "Password")
            {
                password_txt.Text = "";
            }
        }
        private void password_txt_Leave(object sender, EventArgs e)
        {
            if (password_txt.Text == "")
            {
                password_txt.Text = "Password";
                password_txt.ForeColor = Color.FromArgb(48, 182, 251);
            }
        }

        public void Style()
        {
            label8.ForeColor = Color.FromArgb(48, 182, 251);
            this.yourAre_lb.ForeColor = Color.FromArgb(48, 182, 251);
            this.userName_txt.ForeColor = Color.FromArgb(48, 182, 251);
            this.password_txt.ForeColor = Color.FromArgb(48, 182, 251);
            this.submit_btn.BackColor = Color.FromArgb(48, 182, 251);
            submit_btn.TabStop = false;
            submit_btn.FlatStyle = FlatStyle.Flat;
            submit_btn.FlatAppearance.BorderSize = 0;
            NoBorderButton(submit_btn);
        }

        private void LoginForm_Load(object sender, EventArgs e)
        {

        }

        private void submit_btn_Click(object sender, EventArgs e)
        {
            Human log = new Human();
            SqlCommand command = new SqlCommand("SELECT * FROM login where Account = @Acc and Password = @Pass and UserType =@u");
            string u = "";
            if(radioButton1.Checked)
            {
                u = "Reception"; 
            }
            else if(manager_rbtn.Checked)
            {
                u = "Manager";
            }
            command.Parameters.Add("@u", SqlDbType.NVarChar).Value= u;
            command.Parameters.Add("@Acc", SqlDbType.NVarChar).Value = userName_txt.Text;
            command.Parameters.Add("@Pass", SqlDbType.NVarChar).Value = password_txt.Text;
            DataTable table = log.gethummans(command);
            if(table.Rows.Count>0)
            {
                MainForm_Manager_ f = new MainForm_Manager_();
                Global.SetID(userName_txt.Text);
                Global.SetMana(2);
                Global.SetRecep(4);
                Global.SetLabor(6);
                Global.SetLateSalary(20);
                Global.SetAbsentSalary(30);
                Global.s1a("Please wear a mask and wash your hands entering the company");
                Global.s2a("Come to work on time and be honest");
                Global.s3a("Friendly, sociable and helping each other");
                Global.s4a("Violating the law in the company will be severely punished");
                Global.s5a("Safety first");
                Global.s6a("Follow the rules");

                if (u == "Manager")
                {
                    Global.GetBoolManager(true);
                }
                else
                {
                    Global.GetBoolManager(false);
                }
                f.Show();
            }
            else
            {
                MessageBox.Show("Inavailable username or password", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            
        }

        private void submit_btn_MouseHover(object sender, EventArgs e)
        {
            submit_btn.BackColor = Color.FromArgb(48, 182, 251);
            panel3.BackColor = Color.FromArgb(48, 182, 251);
        }
    }
}
