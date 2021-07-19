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
        string userName;

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
            uSER_PROFILETableAdapter.Insert(userName, null, null, null, null, null);
            this.uSER_PROFILETableAdapter.Fill(this.egorcompanyDataSet1.USER_PROFILE);
        }

        private void FoundUser(string user_Name)
        {
            if(uSER_PROFILETableAdapter.CheckUserExist1(user_Name).Rows.Count == 0)
            {
                MessageBox.Show("Такого пользователя нет");
                userNameBox.Text = "";
                Application.Restart();
                return;
            }
            else
            {
                userName = user_Name;
                MessageBox.Show("Вы работаете с пользователем: " + userName);
                CurrentUserLabel.Text = user_Name;
                return;
            }
        }

        public void CheckCompanies() // отметка компаний пользователя
        {
            for (int i = 0; i < checkedListBox1.Items.Count; i++)
            {
                checkedListBox1.SetItemChecked(i, false);
            }

            for (int i = 0; i < cOMPANYACCESSDataGridView.RowCount - 1; i++)
            {
                int j = 0;
                string company = cOMPANYACCESSDataGridView[0, i].Value.ToString();
                string user = cOMPANYACCESSDataGridView[1, i].Value.ToString();
                for (j = 0; j < checkedListBox1.Items.Count; j++)
                {
                    if (user.Equals(userName))
                    {
                        if (checkedListBox1.Items[j].ToString().Equals(company) && !cOMPANYACCESSDataGridView[1, i].Value.Equals("") && cOMPANYACCESSDataGridView[1, i].Value.Equals(userName))
                        {
                            checkedListBox1.SetItemChecked(j, true);
                        }
                    }
                }
            }
        }

        public void CheckWarehouse() // отметка складов пользователя
        {
            for (int i = 0; i < checkedListBox2.Items.Count; i++)
            {
                checkedListBox2.SetItemChecked(i, false);
            }

            for (int i = 0; i < bASEACCESSDataGridView.RowCount - 1; i++)
            {
                int j = 0;
                string company = bASEACCESSDataGridView[0, i].Value.ToString();
                string user = bASEACCESSDataGridView[1, i].Value.ToString();
                for (j = 0; j < checkedListBox2.Items.Count; j++)
                {
                    if (user.Equals(userName))
                    {
                        if (checkedListBox2.Items[j].ToString().Equals(company) && !bASEACCESSDataGridView[1, i].Value.Equals("") && bASEACCESSDataGridView[1, i].Value.Equals(userName))
                        {
                            checkedListBox2.SetItemChecked(j, true);
                        }
                    }
                }
            }
        }

        public void CheckWorkProfile()
        {
            for (int i = 0; i < checkedListBox3.Items.Count; i++)
            {
                checkedListBox3.SetItemChecked(i, false);
            }

            for (int i = 0; i < pROFILEACCESSDataGridView.RowCount - 1; i++)
            {
                int j = 0;
                string company = pROFILEACCESSDataGridView[0, i].Value.ToString();
                string user = pROFILEACCESSDataGridView[1, i].Value.ToString();
                for (j = 0; j < checkedListBox3.Items.Count; j++)
                {
                    if (user.Equals(userName))
                    {
                        if (checkedListBox3.Items[j].ToString().Equals(company) && !pROFILEACCESSDataGridView[1, i].Value.Equals("") && pROFILEACCESSDataGridView[1, i].Value.Equals(userName))
                        {
                            checkedListBox3.SetItemChecked(j, true);
                        }
                    }
                }
            }
        }

        private void userSearchButton_Click(object sender, EventArgs e)
        {
            FoundUser(userNameBox.Text);
            CheckCompanies();
            CheckWarehouse();
            CheckWorkProfile();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // TODO: данная строка кода позволяет загрузить данные в таблицу "egorcompanyDataSet1.APPLICATION_USER_ACTIVITY_LOG". При необходимости она может быть перемещена или удалена.
            this.aPPLICATION_USER_ACTIVITY_LOGTableAdapter.Fill(this.egorcompanyDataSet1.APPLICATION_USER_ACTIVITY_LOG);
            this.bASETableAdapter.Fill(this.egorcompanyDataSet1.BASE);
            this.wORK_PROFILETableAdapter.Fill(this.egorcompanyDataSet1.WORK_PROFILE);
            this.cOMPANYTableAdapter.Fill(this.egorcompanyDataSet1.COMPANY);
            this.uSER_PROFILETableAdapter.Fill(this.egorcompanyDataSet1.USER_PROFILE);
            this.cOMPANYACCESSTableAdapter.Fill(this.egorcompanyDataSet1.COMPANYACCESS);
            this.bASEACCESSTableAdapter.Fill(this.egorcompanyDataSet1.BASEACCESS);
            this.pROFILEACCESSTableAdapter.Fill(this.egorcompanyDataSet1.PROFILEACCESS);

            for (int i = 0; i < cOMPANYDataGridView.RowCount - 1; i++)
            {
                string d = cOMPANYDataGridView[0, i].Value.ToString();
                this.checkedListBox1.Items.Add(d);
            }

            for (int i = 0; i < bASEDataGridView.RowCount - 1; i++)
            {
                string d = bASEDataGridView[0, i].Value.ToString();
                this.checkedListBox2.Items.Add(d);
            }

            for (int i = 0; i < wORK_PROFILEDataGridView.RowCount - 1; i++)
            {
                string d = wORK_PROFILEDataGridView[0, i].Value.ToString();
                this.checkedListBox3.Items.Add(d);
            }
        }

        private void userNameBox_TextChanged(object sender, EventArgs e)
        {
            uSER_PROFILEDataGridView.DataSource = uSER_PROFILETableAdapter.Search0('%' + userNameBox.Text + '%');
            aPPLICATION_USER_ACTIVITY_LOGDataGridView.DataSource = this.aPPLICATION_USER_ACTIVITY_LOGTableAdapter.Search0('%' + userNameBox.Text + '%');
            cOMPANYACCESSDataGridView.DataSource = this.cOMPANYACCESSTableAdapter.Search0('%' + userNameBox.Text + '%');
            bASEACCESSDataGridView.DataSource = this.bASEACCESSTableAdapter.Search0('%' + userNameBox.Text + '%');
            pROFILEACCESSDataGridView.DataSource = this.pROFILEACCESSTableAdapter.Search0('%' + userNameBox.Text + '%');
        }

        private void addCompanyAccButton_Click(object sender, EventArgs e)
        {

            for (int i = 0; i < checkedListBox1.CheckedItems.Count; i++)
            {
                if (cOMPANYACCESSTableAdapter.SelectAllWhere1(checkedListBox1.CheckedItems[i].ToString(), userName).Rows.Count == 0)
                {
                    cOMPANYACCESSDataGridView.DataSource = cOMPANYACCESSTableAdapter.InsertCompanyAcc(checkedListBox1.CheckedItems[i].ToString(), userName);
                    this.cOMPANYACCESSTableAdapter.Fill(this.egorcompanyDataSet1.COMPANYACCESS);
                    DateTime date = DateTime.Now;
                    byte[] byteValue = BitConverter.GetBytes(date.Ticks);
                    long longVar = BitConverter.ToInt64(byteValue, 0);
                    
                    aPPLICATION_USER_ACTIVITY_LOGTableAdapter.InsertActivityLog("Добавлен доступ к компании " + checkedListBox1.CheckedItems[i].ToString(), userName);
                }
            }

            Application.Restart();
        }

        private void deleteCompanyAccButton_Click(object sender, EventArgs e)
        {
            for (int j = 0; j < checkedListBox1.Items.Count; j++)
            {
                bool checkStat = checkedListBox1.GetItemChecked(j);
                if (checkStat == false)
                {
                    cOMPANYACCESSDataGridView.DataSource = cOMPANYACCESSTableAdapter.Delete(checkedListBox1.Items[j].ToString(), userName);
                    
                    aPPLICATION_USER_ACTIVITY_LOGTableAdapter.InsertActivityLog("Удален доступ к компании " + checkedListBox1.Items[j].ToString(), userName);
                }
            }

            Application.Restart();
        }

        private void addWarehouseAccButton_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < checkedListBox2.CheckedItems.Count; i++)
            {
                if (bASEACCESSTableAdapter.SelectAllWhereWH1(checkedListBox2.CheckedItems[i].ToString(), userName).Rows.Count == 0)
                {
                    bASEACCESSDataGridView.DataSource = bASEACCESSTableAdapter.InsertWHAcc(checkedListBox2.CheckedItems[i].ToString(), userName);
                    this.bASEACCESSTableAdapter.Fill(this.egorcompanyDataSet1.BASEACCESS);
                    
                    aPPLICATION_USER_ACTIVITY_LOGTableAdapter.InsertActivityLog("Добавлен доступ к складу " + checkedListBox2.CheckedItems[i].ToString(), userName);
                }
            }

            Application.Restart();
        }

        private void deleteWarehouseAccButton_Click(object sender, EventArgs e)
        {
            for (int j = 0; j < checkedListBox2.Items.Count; j++)
            {
                bool checkStat = checkedListBox2.GetItemChecked(j);
                if (checkStat == false)
                {
                    bASEACCESSDataGridView.DataSource = bASEACCESSTableAdapter.Delete(checkedListBox2.Items[j].ToString(), userName);
                    
                    aPPLICATION_USER_ACTIVITY_LOGTableAdapter.InsertActivityLog("Удален доступ к складу " + checkedListBox2.Items[j].ToString(), userName);
                }
            }

            Application.Restart();
        }

        private void checkedListBox2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void aPPLICATION_USER_ACTIVITY_LOGDataGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void addProfileButton_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < checkedListBox3.CheckedItems.Count; i++)
            {
                if (pROFILEACCESSTableAdapter.SelectAllWhereWorkProf1(checkedListBox3.CheckedItems[i].ToString(), userName).Rows.Count == 0)
                {
                   pROFILEACCESSDataGridView.DataSource = pROFILEACCESSTableAdapter.InsertWPROFAcc(checkedListBox3.CheckedItems[i].ToString(), userName);
                    this.pROFILEACCESSTableAdapter.Fill(this.egorcompanyDataSet1.PROFILEACCESS);

                    aPPLICATION_USER_ACTIVITY_LOGTableAdapter.InsertActivityLog("Добавлен доступ к рабочему профилю " + checkedListBox3.CheckedItems[i].ToString(), userName);
                }
            }

            Application.Restart();
        }

        private void delProfileButton_Click(object sender, EventArgs e)
        {
            for (int j = 0; j < checkedListBox3.Items.Count; j++)
            {
                bool checkStat = checkedListBox3.GetItemChecked(j);
                if (checkStat == false)
                {
                    pROFILEACCESSDataGridView.DataSource = pROFILEACCESSTableAdapter.Delete(checkedListBox3.Items[j].ToString(), userName);

                    aPPLICATION_USER_ACTIVITY_LOGTableAdapter.InsertActivityLog("Удален доступ к рабочему профилю " + checkedListBox3.Items[j].ToString(), userName);
                }
            }

            Application.Restart();
        }
    }
}
