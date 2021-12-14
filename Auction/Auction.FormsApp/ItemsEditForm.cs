using Auction.DAL.Models.Entities.Impl;
using Auction.DAL.Models.Filters.Impl;
using Auction.DAL.Repositories.Impl;
using System;
using System.Windows.Forms;

namespace Auction.FormsApp
{
    public partial class ItemsEditForm : Form
    {
        ItemsRepository rep;
        CategoriesRepository catRep;
        SellersRepository selRep;
        BuyersRepository buyRep;
        Items item;
        public ItemsEditForm(int ID)
        {
            InitializeComponent();
            rep = new ItemsRepository();
            catRep = new CategoriesRepository();
            selRep = new SellersRepository();
            buyRep = new BuyersRepository();
            ItemsFilter filter = new ItemsFilter
            {
                Id = (ulong?)(ID + 1)
            };
            item = rep.Get(filter);
        }

        private void ItemsEditForm_Load(object sender, EventArgs e)
        {
            comboBox1.DataSource = catRep.GetAll();
            comboBox1.SelectedItem = item.Category_ID;
            comboBox4.DataSource = selRep.GetAll();
            comboBox4.SelectedItem = item.Seller_ID;
            comboBox2.DataSource = buyRep.GetAll();
            comboBox2.SelectedItem = item.Buyer_ID;
            textBox1.Text = item.ItemName;
            textBox2.Text = Convert.ToString(item.Start_Bid);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Items item = new Items
            {
                ItemName = textBox1.Text,
                Category_ID = ((Categories)comboBox1.SelectedItem).Id,
                Seller_ID = ((Sellers)comboBox4.SelectedItem).Id,
                Buyer_ID = ((Buyers)comboBox2.SelectedItem).Id,
                Start_Bid = Convert.ToInt32(textBox2.Text)
            };
            var filter = new ItemsFilter
            {
                Id = item.Id + 1
            };
            rep.Update(item, filter);
        }
    }
}
