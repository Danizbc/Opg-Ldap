using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LdapWin
{
    public partial class Form1 : Form
    {
        Logic l = new Logic();

        string firstname;

        string lastname;

        public Form1()
        {
            InitializeComponent();
            this.ActiveControl = textBox1;
            textBox1.Focus();


        }

        private void Form1_Load(object sender, EventArgs e)
        {
          
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (firstname != null && lastname != null)
            {
                firstname += (" " + lastname);
               MessageBox.Show(l.LdapConnect(firstname));

              
                foreach (var item in l.Information)
                {
                    listView1.Items.Add(item);
                }
            }
            else
            {
                
                MessageBox.Show("Enter a name or last name");
            }
            
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            firstname = textBox1.Text;

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            lastname = textBox2.Text;
        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {
       
        }
    }
}
