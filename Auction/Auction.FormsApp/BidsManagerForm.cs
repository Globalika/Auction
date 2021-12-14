using Auction.DAL.Models.Filters.Impl;
using Auction.DAL.Repositories.Impl;
using System;
using System.Linq;
using System.Windows.Forms;

namespace Auction.FormsApp
{
    public partial class BidsManagerForm : Form
    {
        BidsRepository rep;
        public BidsManagerForm()
        {
            InitializeComponent();
            rep = new BidsRepository();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //add
            BidsAddForm addForm = new BidsAddForm();
            addForm.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            //edit
            if (dataGridView1.SelectedRows.Count == 1)
            {
                BidsEditForm form = new BidsEditForm(dataGridView1.SelectedRows[0].Index);
                form.Show();
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            //delete

            if (dataGridView1.SelectedRows.Count == 1)
            {
                var filter = new BidsFilter
                {
                    Id = (ulong?)dataGridView1.SelectedRows[0].Index + 1
                };
                rep.Delete(filter);
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            //refresh
            dataGridView1.DataSource = rep.GetAll().ToList();
        }

        private void BidsManagerForm_Load(object sender, EventArgs e)
        {
            dataGridView1.DataSource = rep.GetAll().ToList();
        }
    }
}
