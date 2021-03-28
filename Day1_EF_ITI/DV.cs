using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Day1_EF_ITI.Context;
using Day1_EF_ITI.Entities;
using Microsoft.EntityFrameworkCore;

namespace Day1_EF_ITI
{
    public partial class DV : Form
    {
        public DV()
        {
            InitializeComponent();
            this.FormClosed += (sender, e) => Context.Dispose();

        }


        BindingNavigator bindingNavigator;
        BindingSource BSrc;
        BindingSource PS;
        PubsContext Context = new PubsContext();
        
        private void DV_Load(object sender, EventArgs e)
        {
            Context.Titles.Load();
            Context.Publishers.Load();
            BSrc = new BindingSource(Context.Titles.Local.ToBindingList(), ""); //if not try just the list
            PS = new BindingSource(Context.Publishers.Local.ToBindingList(), ""); //if not try just the list

            //Controls 
            BindingSource b = new BindingSource();

            title_id.DataBindings.Add("Text", BSrc, "TitleId", true);
            title.DataBindings.Add("Text", BSrc, "Title1", true);
            type.DataBindings.Add("Text", BSrc, "Type", true);
            price.DataBindings.Add("Value", BSrc, "Price", true);
            advance.DataBindings.Add("Value", BSrc, "Advance", true);
            royalty.DataBindings.Add("Value", BSrc, "Royalty", true);
            sales.DataBindings.Add("Value", BSrc, "YtdSales", true);
            notes.DataBindings.Add("Text", BSrc, "Notes", true);
            pubDate.DataBindings.Add("Value", BSrc, "Pubdate", true);


            b.AddingNew += (sender, e) => b.AddNew();
            ///Navigator
            bindingNavigator = new BindingNavigator(true);
            this.Controls.Add(bindingNavigator);
            bindingNavigator.Dock = DockStyle.Bottom;
            bindingNavigator.BindingSource = BSrc;

            comboBox1.DataSource = PS; //new Data Table
            comboBox1.DisplayMember = "PubName"; //pub name from the Binding Source from new Data Table
            comboBox1.ValueMember = "PubId";
            comboBox1.DataBindings.Add("SelectedValue", BSrc, "PubId", true);
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            BSrc.EndEdit();
            Context.SaveChanges();
        }
    }
}
