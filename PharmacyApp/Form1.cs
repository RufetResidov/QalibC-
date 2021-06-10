using PharmacyApp.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PharmacyApp
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void addmedicine_Click(object sender, EventArgs e)
        {
            MedicineAddForm db = new MedicineAddForm();
            db.ShowDialog();
        }
        PharmacyK209DBContext _context = new PharmacyK209DBContext();

        private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }
        public void FillComboBox()
        {
            cmbFMedicineOpen.Items.AddRange(_context.Firms.Select(x => x.Name).ToArray());
        }
        public void FillFirmsomboBox()
        {
            cmbFirmsOpen.Items.AddRange(_context.Firms.Select(x => x.Name).ToArray());
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            FillComboBox();
            FillFirmsomboBox();
        }
    }
}
