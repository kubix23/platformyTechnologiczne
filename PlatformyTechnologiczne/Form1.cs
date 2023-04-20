using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace PlatformyTechnologiczne
{
    public partial class Form1 : Form
    {
        private List<Car> myCars;
        public Form1(object a)
        {
            InitializeComponent();
            myCars = (List<Car>)a;
            this.Load += new EventHandler(Form1_Load);
        }

        private void Form1_Load(System.Object sender, System.EventArgs e)
        {
            SetupdataGridView1();
            PopulatedataGridView1();
            this.delate.Click += buttonRemove_Click;
        }

        private void SetupdataGridView1()
        {

            dataGridView1.ColumnHeadersDefaultCellStyle.BackColor = Color.Navy;
            dataGridView1.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            dataGridView1.ColumnHeadersDefaultCellStyle.Font =
            new Font(dataGridView1.Font, FontStyle.Bold);
            dataGridView1.MultiSelect = false;
        }
        private void PopulatedataGridView1()
        {
            CarBindingList<Car> myCarsBindingList = new CarBindingList<Car>(myCars);
            BindingSource carBindingSource = new BindingSource { DataSource = myCarsBindingList };
            findBar1.Data = carBindingSource;
            findBar1.ItemFound += findStrip_ItemFound;
            dataGridView1.DataSource = carBindingSource;
            dataGridView1.CellParsing += CellParsing;
        }
        private void CellParsing(object sender, DataGridViewCellParsingEventArgs e)
        {
            if (typeof(Engine) == e.DesiredType)
            {
                string temp = e.Value.ToString();
                string[] temp2 = temp.Split(' ');
                if(temp2.Length == 3)
                {
                    e.Value = new Engine(double.Parse(temp2[1]), double.Parse(temp2[2]), temp2[0]);
                }
                else
                {
                    e.Value = new Engine();
                }
                e.ParsingApplied = true;
            }
        }

        private void findStrip_ItemFound(object sender, ItemFoundEventArgs e)
        {
            if (e.Index >= 0)
            {
                this.dataGridView1.ClearSelection();
                this.dataGridView1.Rows[e.Index].Selected = true;
            }
        }

        private void buttonRemove_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewCell oneCell in dataGridView1.SelectedCells)
            {
                if (oneCell.Selected && dataGridView1.RowCount > 1)
                    dataGridView1.Rows.RemoveAt(oneCell.RowIndex);
            }
        }
    }
}   
