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
            //var categ = new List<String>();
            //foreach(var cat in catRep.GetAll())
            //{
            //    categ.Add(cat.Category);
            //}
            comboBox1.DataSource = catRep.GetAll();
            //var sellers = new List<String>();
            //foreach (var sel in selRep.GetAll())
            //{
            //    sellers.Add(sel.Sellers_Username);
            //}
            comboBox4.DataSource = selRep.GetAll();
            //var bayers = new List<String>();
            //foreach (var bay in buyRep.GetAll())
            //{
            //    bayers.Add(bay.Buyers_Username);
            //}
            comboBox3.DataSource = buyRep.GetAll();
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
