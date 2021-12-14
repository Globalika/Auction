using Auction.DAL.Models.Entities.Impl;
using Auction.DAL.Repositories.Impl;
using System;
using System.Linq;
using System.Windows.Forms;

namespace Auction.FormsApp
{
    public partial class BidsAddForm : Form
    {
        BidsRepository rep;
        ItemsRepository itemRep;
        BuyersRepository buyRep;

        public BidsAddForm()
        {
            InitializeComponent();
            rep = new BidsRepository();
            itemRep = new ItemsRepository();
            buyRep = new BuyersRepository();
        }

        private void BidsAddForm_Load(object sender, EventArgs e)
        {
            comboBox1.DataSource = itemRep.GetAll().ToList();
            comboBox1.SelectedIndex = -1;
            comboBox2.DataSource = buyRep.GetAll().ToList();
            comboBox2.SelectedIndex = -1;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Bids bid = new Bids
            {
                BidAmount = Convert.ToInt32(textBox1.Text),
                Bid_Item_ID = ((Items)comboBox1.SelectedItem).Id,
                Bid_Buyer_ID = ((Buyers)comboBox2.SelectedItem).Id
            };
            rep.Create(bid);
        }
    }
}
