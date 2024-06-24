using ABC_Traders.ApplicationClass;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlTypes;
using System.Diagnostics.CodeAnalysis;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ABC_Traders
{
    public partial class manageCarParts : Form
    {
        public manageCarParts()
        {
            InitializeComponent();
        }

        private void manageCarParts_Load(object sender, EventArgs e)
        {
            ManageCarDetailClass.dataGridView = cardatagridview;

            ManageCarDetailClass.dataGridView = carpartDataGridview;

            ManageCarDetailClass.LoadforeignkeyFuelType(fuelComboBox);
            ManageCarDetailClass.LoadforeignkeyGyearType(gyearComboBox);
            ManageCarDetailClass.LoadforeignkeyModel(modelComboBox);
            ManageCarDetailClass.LoadforeignkeyBrand(brandComboBox);
            ManageCarDetailClass.LoadforeignkeyCarType(typeComboBox);
            ManageCarDetailClass.LoadforeignkeyCondition(conditionCombo);

            ManageCarDetailClass.LoadforeignkeyModel(cpmodelCombo);
            ManageCarDetailClass.LoadforeignkeyBrand(cpbrandCombo);
            ManageCarDetailClass.LoadforeignkeyCondition(cpconditionCombo);
            ManageCarDetailClass.LoadforeignkeyCarpartType(carpartsComboBox);

            ManageCarDetailClass.view(cardatagridview);
            ManageCarDetailClass.viewCarPart(carpartDataGridview);

        }

        private void label37_Click(object sender, EventArgs e)
        {

        }

        private void warrantyTextBox_TextChanged(object sender, EventArgs e)
        {
            ManageCarDetailClass.warranty = cpwarrantyTextBox.Text;
        }

        private void wifiTextBox_TextChanged(object sender, EventArgs e)
        {
            if (bool.TryParse(wifiTextBox.Text, out bool wifiAccess))
            {
                ManageCarDetailClass.wifiAccess = wifiAccess;
            }
            else
            {
                // Handle the case where the text is not a valid boolean.
                // You might want to show an error message or set a default value.
            }
        }

        private void savebtn_Click(object sender, EventArgs e)
        {
            ManageCarDetailClass.Save();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            adminDashboardLoad admin_dashboard = new adminDashboardLoad();
            this.Hide();
            admin_dashboard.Show();
        }

        private void gyearComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            ManageCarDetailClass.gyear_id_fk = gyearComboBox.SelectedIndex;
        }

        private void wheelTextBox_TextChanged(object sender, EventArgs e)
        {
            ManageCarDetailClass.wheel = int.Parse(wheelTextBox.Text);
        }

        private void babyseatTextBox_TextChanged(object sender, EventArgs e)
        {
            ManageCarDetailClass.babyseat = int.Parse(babyseatTextBox.Text);
        }

        private void colorTextBox_TextChanged(object sender, EventArgs e)
        {
            ManageCarDetailClass.colorFamily = colorTextBox.Text;
        }

        private void yearTextBox_TextChanged(object sender, EventArgs e)
        {
            ManageCarDetailClass.year = int.Parse(yearTextBox.Text);
        }

        private void carNoTextBox_TextChanged(object sender, EventArgs e)
        {
            ManageCarDetailClass.carNumber = carNoTextBox.Text;
        }

        private void modelComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            ManageCarDetailClass.model_id_fk = modelComboBox.SelectedIndex;
        }

        private void brandComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            ManageCarDetailClass.brand_id_fk = brandComboBox.SelectedIndex;
        }

        private void typeComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            ManageCarDetailClass.cartype_id_fk = typeComboBox.SelectedIndex;
        }

        private void conditionCombo_SelectedIndexChanged(object sender, EventArgs e)
        {
            ManageCarDetailClass.condition_id_fk = conditionCombo.SelectedIndex;
        }

        private void seatTextBox_TextChanged(object sender, EventArgs e)
        {
            ManageCarDetailClass.seat = int.Parse(seatTextBox.Text);
        }

        private void fuelComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            ManageCarDetailClass.fuel_id_fk = fuelComboBox.SelectedIndex;
        }

        private void carpartsComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            ManageCarDetailClass.part_id_fk = carpartsComboBox.SelectedIndex;
        }

        private void cpmodelCombo_SelectedIndexChanged(object sender, EventArgs e)
        {
            ManageCarDetailClass.model_id_fk = cpmodelCombo.SelectedIndex;
        }

        private void cpbrandCombo_SelectedIndexChanged(object sender, EventArgs e)
        {
            ManageCarDetailClass.brand_id_fk = cpbrandCombo.SelectedIndex;
        }

        private void cpyearTextBox_TextChanged(object sender, EventArgs e)
        {
            ManageCarDetailClass.year = int.Parse(cpyearTextBox.Text);
        }

        private void cpconditionCombo_SelectedIndexChanged(object sender, EventArgs e)
        {
            ManageCarDetailClass.condition_id_fk = cpconditionCombo.SelectedIndex;
        }

        private void cpquantityTextBox_TextChanged(object sender, EventArgs e)
        {
            ManageCarDetailClass.stock = int.Parse(cpquantityTextBox.Text);
        }

        private void cpinstallmentTextBox_TextChanged(object sender, EventArgs e)
        {
            ManageCarDetailClass.installment = cpinstallmentTextBox.Text;
        }

        private void cpwarrantyTextBox_TextChanged(object sender, EventArgs e)
        {
            ManageCarDetailClass.warranty = cpwarrantyTextBox.Text;
        }

        private void cpcolorTextBox_TextChanged(object sender, EventArgs e)
        {
            ManageCarDetailClass.colorFamily = cpcolorTextBox.Text;
        }

        private void saveBtnCarPart_Click(object sender, EventArgs e)
        {
            ManageCarDetailClass.CarPartSave();
        }

        private void searchcarIdcarpartIdTextBox_TextChanged(object sender, EventArgs e)
        {
            ManageCarDetailClass.car_id = int.Parse(searchcarIdcarIdTextBox.Text);
        }

        private void searchcarBtn_Click(object sender, EventArgs e)
        {
            manageCarParts manageCarPartsInstance = this;
            ManageCarDetailClass.SearchCar(manageCarPartsInstance, int.Parse(searchcarIdcarIdTextBox.Text));
        }

        private void searchcarpartTextBox_TextChanged(object sender, EventArgs e)
        {
            ManageCarDetailClass.carpart_id = int.Parse(searchcarpartTextBox.Text);
        }

        private void searchCarPartBtn_Click(object sender, EventArgs e)
        {
            manageCarParts manageCarPartsInstance = this;
            ManageCarDetailClass.SearchCarPart(manageCarPartsInstance, int.Parse(searchcarpartTextBox.Text));
        }

        private void carUpdateBtn_Click(object sender, EventArgs e)
        {
            manageCarParts manaCarPartsInstance = this;
            ManageCarDetailClass.CarUpdate(manaCarPartsInstance, int.Parse(searchcarIdcarIdTextBox.Text));
        }

        private void carpartUpdateBtn_Click(object sender, EventArgs e)
        {
            manageCarParts manageCarPartsInstance = this;
            ManageCarDetailClass.CarPartsUpdate(manageCarPartsInstance, int.Parse(searchcarpartTextBox.Text));
        }

        private void carDeleteBtn_Click(object sender, EventArgs e)
        {
            ManageCarDetailClass.DeleteCar(int.Parse(searchcarIdcarIdTextBox.Text));
        }

        private void carpartDeleteBtn_Click(object sender, EventArgs e)
        {
            ManageCarDetailClass.DeleteCarPart(int.Parse(searchcarpartTextBox.Text));
        }

        private void dashboardBtn_Click(object sender, EventArgs e)
        {
            adminDashboardLoad admin = new adminDashboardLoad();
            this.Hide();
            admin.Show();
        }
    }
}
