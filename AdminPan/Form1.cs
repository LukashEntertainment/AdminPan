using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AdminPan
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void uSER_PROFILEBindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {
            this.Validate();
            this.uSER_PROFILEBindingSource.EndEdit();
            this.tableAdapterManager.UpdateAll(this.egorcompanyDataSet1);

        }

        private void CreateCommand()
        {
            uSER_PROFILETableAdapter.Insert(userNameBox.Text, null, null, null, null, null);
            this.uSER_PROFILETableAdapter.Fill(this.egorcompanyDataSet1.USER_PROFILE);
        }

        private void userSearchButton_Click(object sender, EventArgs e)
        {
            CreateCommand();

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // TODO: данная строка кода позволяет загрузить данные в таблицу "egorcompanyDataSet1.USER_PROFILE". При необходимости она может быть перемещена или удалена.
            this.uSER_PROFILETableAdapter.Fill(this.egorcompanyDataSet1.USER_PROFILE);
            // TODO: данная строка кода позволяет загрузить данные в таблицу "egorcompanyDataSet1.COMPANYACCESS". При необходимости она может быть перемещена или удалена.
            this.cOMPANYACCESSTableAdapter.Fill(this.egorcompanyDataSet1.COMPANYACCESS);
            // TODO: данная строка кода позволяет загрузить данные в таблицу "egorcompanyDataSet1.BASEACCESS". При необходимости она может быть перемещена или удалена.
            this.bASEACCESSTableAdapter.Fill(this.egorcompanyDataSet1.BASEACCESS);
            // TODO: данная строка кода позволяет загрузить данные в таблицу "egorcompanyDataSet1.PROFILEACCESS". При необходимости она может быть перемещена или удалена.
            this.pROFILEACCESSTableAdapter.Fill(this.egorcompanyDataSet1.PROFILEACCESS);
            // TODO: данная строка кода позволяет загрузить данные в таблицу "egorcompanyDataSet.PROFILEACCESS". При необходимости она может быть перемещена или удалена.

        }

        private void userNameBox_TextChanged(object sender, EventArgs e)
        {
            uSER_PROFILEDataGridView.DataSource = uSER_PROFILETableAdapter.Search0('%' + userNameBox.Text + '%');
        }


        private void bindingNavigatorAddNewItem_Click(object sender, EventArgs e)
        {

        }

        private void cOMPANYACCESSDataGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void uSER_PROFILEBindingNavigator_RefreshItems(object sender, EventArgs e)
        {

        }
    }
}
