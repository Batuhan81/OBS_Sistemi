﻿using DönemlikStajProje.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.EntityFramework;
using MySql.Data.MySqlClient;
using System.Configuration;

namespace DönemlikStajProje
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        private void timer1_Tick(object sender, EventArgs e)
        {
            label1.Text = label1.Text.Substring(1) + label1.Text.Substring(0, 1);
        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            timer1.Stop();
            timer2.Stop();
            this.Hide();
            Giriş git=new Giriş();
            git.ShowDialog();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
         Context c=new Context();
        private void Form1_Load(object sender, EventArgs e)
        {
        }
    }
}
