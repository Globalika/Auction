using Auction.DAL.Models.Entities.Impl;
using Auction.DAL.Models.Filters.Impl;
using Auction.DAL.Repositories.Impl;
using System;
using System.Windows.Forms;

namespace Auction.FormsApp
{
    public partial class BidsEditForm : Form
    {
        BidsRepository rep;
        ItemsRepository itemRep;
        BuyersRepository buyRep;
        Bids bids;
        public BidsEditForm(int ID)
        {
            InitializeComponent();
            rep = new BidsRepository();
            itemRep = new ItemsRepository();
            buyRep = new BuyersRepository();
            BidsFilter filter = new BidsFilter
            {
                Id = (ulong?)(ID + 1)
            };
            bids = rep.Get(filter);
        }

        private void BidsEditForm_Load(object sender, EventArgs e)
        {
            comboBox1.DataSource = itemRep.GetAll();
            comboBox1.SelectedIndex = (int)(bids.Bid_Item_ID);
            comboBox2.DataSource = buyRep.GetAll();
            comboBox2.SelectedIndex = (int)(bids.Bid_Buyer_ID);
            textBox1.Text = Convert.ToString(bids.BidAmount);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Bids bid = new Bids
            {
                BidAmount = Convert.ToInt32(textBox1.Text),
                Bid_Item_ID = ((Items)comboBox1.SelectedItem).Id,
                Bid_Buyer_ID = ((Buyers)comboBox2.SelectedItem).Id
            };
            var filter = new BidsFilter
            {
                Id = bid.Id + 1
            };
            rep.Update(bid, filter);
        }
    }
}
