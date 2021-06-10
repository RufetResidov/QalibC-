using PharmacyApp.Helpers;
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
    public partial class MedicineAddForm : Form
    {
        PharmacyK209DBContext _context = new PharmacyK209DBContext();

        public object Utilities { get; private set; }

        public MedicineAddForm()
        {
            InitializeComponent();
        }
        public void FillComboBox( )
        {
            cmbFirms.Items.AddRange(_context.Firms.Select(x => x.Name).ToArray());
        }
        public void FillTagComboBox()
        {
            cmbTags.Items.AddRange(_context.Tags.Select(x => x.Name).ToArray());
        }
        private void MedicineAddForm_Load(object sender, EventArgs e)
        {
            FillComboBox();
            FillTagComboBox();
        }

        public int  FindFirm(string FirmName) {
            Firm SelectedFirm = _context.Firms.FirstOrDefault(x => x.Name == FirmName);
            if (SelectedFirm == null)
            {
                Firm newFirm = new Firm();
                newFirm = FirmName;
                _context.Firms.Add(newFirm);
                _context.SaveChanges();
                return newFirm.Id;
            }
            return SelectedFirm.Id;
        }
        private void button1_Click(object sender, EventArgs e)
        {
            string MedicineName = txtMedicineName.Text;
            string FirmName = cmbFirms.Text;
            int count = (int)nudQuantity.Value;
            decimal Price = nudPrice.Value;
            int barcode = (int)numericUpDown1.Value;
            string description = richTextBox1.Text;
            DateTime prodate = dateTimePicker1.Value;
            DateTime expDate = dateTimePicker2.Value;
            bool isReceipt = checkBox1.Checked;

            string[] ar = { MedicineName, FirmName, description };
            if (utilities.IsEmpty(ar) && barcode !=0)
            {
                int firmId = FindFirm(FirmName);
                Medicine medicine = new Medicine
                {
                    Name = MedicineName,
                    FirmId = firmId,
                    Count = count,
                    Price = Price,
                    ProductionDate = prodate,
                    ExpireDate = expDate,
                    Description = description,
                    IsReceipt = isReceipt ? true : false
                };
                _context.Medicines.Add(medicine);
                _context.SaveChanges();
                MessageBox.Show("Medicine Added Succesfully");
            }
            else
            {
                MessageBox.Show("Please Fill all");
            }
        }

        private void cmbTags_SelectedIndexChanged(object sender, EventArgs e)
        {
            string tagName = cmbTags.Text;
            
            if (!checkedListBox1.Items.Contains(tagName))
            {
                checkedListBox1.Items.Add(tagName);
            }
        }

        private void cmbTags_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode== Keys.Enter)
            {
                string tagName = cmbTags.Text;
                if (!checkedListBox1.Items.Contains(tagName))
                {
                    checkedListBox1.Items.Add(tagName);
                }
            }
        }
    }
}
