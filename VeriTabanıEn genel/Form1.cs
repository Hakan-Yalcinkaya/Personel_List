using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace VeriTabanıEn_genel
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        SqlConnection baglan = new SqlConnection("Data Source=desktop-521sbtj\\hakan;Initial Catalog=fabrika;Integrated Security=True");
        int id = 0;
        private void verilerigoster()
        {
            baglan.Open();
            SqlCommand komut = new SqlCommand("select *from fabrika", baglan);
            SqlDataReader oku = komut.ExecuteReader();
            while (oku.Read())
            {
                ListViewItem ekle = new ListViewItem();
                ekle.Text = oku["id"].ToString();
                ekle.SubItems.Add(oku["adsoyad"].ToString());
                ekle.SubItems.Add(oku["departman"].ToString());
                ekle.SubItems.Add(oku["telefon"].ToString());
                ekle.SubItems.Add(oku["adres"].ToString());
                ekle.SubItems.Add(oku["maas"].ToString());
                listView1.Items.Add(ekle);
            }
            baglan.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            verilerigoster();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            baglan.Open();
            SqlCommand komut = new SqlCommand("insert into fabrika(id,adsoyad,departman,telefon,adres,maas) values ('" + textBox1.Text.ToString() + "','" + textBox2.Text.ToString() + "','" + textBox3.Text.ToString() + "','" + textBox4.Text.ToString() + "','" + textBox5.Text.ToString() + "','" + textBox6.Text.ToString() + "')", baglan);
            komut.ExecuteNonQuery();
            baglan.Close();
            verilerigoster();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            baglan.Open();
            SqlCommand komut = new SqlCommand("Delete from fabrika where id=(" + id + ")", baglan);
            komut.ExecuteNonQuery();
            baglan.Close();
            

        }

        private void listView1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            id = int.Parse (listView1.SelectedItems[0].SubItems[0].Text);
            textBox1.Text = listView1.SelectedItems[0].SubItems[0].Text;
            textBox2.Text = listView1.SelectedItems[0].SubItems[1].Text;
            textBox3.Text = listView1.SelectedItems[0].SubItems[2].Text;
            textBox4.Text = listView1.SelectedItems[0].SubItems[3].Text;
            textBox5.Text = listView1.SelectedItems[0].SubItems[4].Text;
            textBox6.Text = listView1.SelectedItems[0].SubItems[5].Text;
            
            
        }

        private void button4_Click(object sender, EventArgs e)
        {
            listView1.Items.Clear();
            baglan.Open();
            SqlCommand komut = new SqlCommand("Select *From fabrika where adsoyad like '%" + textBox7.Text + "%'", baglan);
            SqlDataReader oku = komut.ExecuteReader();
            while (oku.Read())
            {
                ListViewItem ekle = new ListViewItem();
                ekle.Text = oku["id"].ToString();
                ekle.SubItems.Add(oku["adsoyad"].ToString());
                ekle.SubItems.Add(oku["departman"].ToString());
                ekle.SubItems.Add(oku["telefon"].ToString());
                ekle.SubItems.Add(oku["adres"].ToString());
                ekle.SubItems.Add(oku["maas"].ToString());
                listView1.Items.Add(ekle);
            }
            baglan.Close();
        }
        }
    }

