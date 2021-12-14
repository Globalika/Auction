using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Auction.DAL.Repositories.Impl;
using Auction.DAL.Models.Entities.Impl;

namespace Auction.FormsApp
{
    public partial class ItemAddForm : Form
    {
        ItemsRepository rep;
        CategoriesRepository catRep;
        SellersRepository selRep;
        BuyersRepository buyRep;
        public ItemAddForm()
        {
            InitializeComponent();
            rep = new ItemsRepository();
            catRep = new CategoriesRepository();
            selRep = new SellersRepository();
            buyRep = new BuyersRepository();
        }

        private void ItemAddForm_Load(object sender, EventArgs e)
        {
            comboBox1.DataSource = catRep.GetAll();
            comboBox1.SelectedIndex = -1;
            comboBox4.DataSource = selRep.GetAll();
            comboBox4.SelectedIndex = -1;
            comboBox3.DataSource = buyRep.GetAll();
            comboBox3.SelectedIndex = -1;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Items item = new Items
            {
                Category_ID = ((Categories)comboBox1.SelectedItem).Id,
                Seller_ID = ((Sellers)comboBox4.SelectedItem).Id,
                Buyer_ID = ((Buyers)comboBox3.SelectedItem).Id,
                Start_Bid = Convert.ToInt32(textBox2.Text),
                ItemName = textBox1.Text
            };
            rep.Create(item);
        }
    }
}
