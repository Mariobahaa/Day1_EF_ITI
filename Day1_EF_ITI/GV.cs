using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Day1_EF_ITI.Context;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace Day1_EF_ITI
{
    public partial class GV : Form
    {
        public GV()
        {
            InitializeComponent();
            this.FormClosed += (sender, e) => Context.Dispose();

            //this.FormClosing+= (sender, e) => Context.Dispose();

        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        
        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        PubsContext Context = new PubsContext();
       
        private void GV_Load(object sender, EventArgs e)
        {

           
                //load all data in datagridview
                Context.Titles.Load();
                dataGridView1.DataSource = Context.Titles.Local.ToBindingList();


                Context.Publishers.Load();
                DataGridViewComboBoxColumn ck = new DataGridViewComboBoxColumn();
                ck.DataSource = Context.Publishers.Local.ToBindingList();
                ck.HeaderText = "Publisher";
                ck.ValueMember = "PubId";
                ck.DisplayMember = "PubName";
                ck.DataPropertyName = "PubId";
                dataGridView1.Columns.Add(ck);

                dataGridView1.Columns["PubId"].Visible = false;
                dataGridView1.Columns["Pub"].Visible = false;

        }

        private void btnDGVSave_Click(object sender, EventArgs e)
        {
            dataGridView1.EndEdit();
            Context.SaveChanges();
        }
    }
}
//dataGridView1.UserDeletingRow += (args, e) =>
//{
//    var idToDelete = (String)e.Row.Cells["TitleId"].Value;
//    //try
//    //{

//    //    Context.Titles.Remove((Entities.Title)(from T in Context.Titles
//    //                                           where T.TitleId == idToDelete
//    //                                           select T).FirstOrDefault());
//    //    Context.SaveChanges();
//    //}
//    //catch (Exception ex)
//    //{
//    //    Trace.WriteLine(ex.Message);
//    //}


//};