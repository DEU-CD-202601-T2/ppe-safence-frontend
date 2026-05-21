using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PPE_관제_시스템
{
    public partial class US_UsersSetting : UserControl
    {
        private List<WorkerControlDto> workerList = new List<WorkerControlDto>();
        public US_UsersSetting()
        {
            InitializeComponent();
            this.Load += US_UserSetting_Load;
        }

        private void InitGrid()
        {
            dgvUsersSetting.AutoGenerateColumns = false;
            dgvUsersSetting.AllowUserToAddRows = false;
            dgvUsersSetting.ReadOnly = true;
            dgvUsersSetting.SelectionMode = DataGridViewSelectionMode.FullRowSelect;

            if (dgvUsersSetting.Columns.Contains("user_name"))
                dgvUsersSetting.Columns["user_name"].DataPropertyName = "Name";

            if (dgvUsersSetting.Columns.Contains("user_id"))
                dgvUsersSetting.Columns["user_id"].DataPropertyName = "WorkerId";

            if (dgvUsersSetting.Columns.Contains("role"))
                dgvUsersSetting.Columns["role"].DataPropertyName = "LastViolation";

            if (dgvUsersSetting.Columns.Contains("location"))
                dgvUsersSetting.Columns["location"].DataPropertyName = "Zone";

            if (dgvUsersSetting.Columns.Contains("status"))
                dgvUsersSetting.Columns["status"].DataPropertyName = "Status";
            
            if (dgvUsersSetting.Columns.Contains("manage"))
                dgvUsersSetting.Columns["manage"].DataPropertyName = "Status";
        }

        private async Task LoadWorkerDataAsync()
        {
            try
            {
                var data = await ApiService.GetControlWorkerAsync();
                if(data != null)
                {
                    workerList = data;
                    dgvUsersSetting.DataSource = null;
                    dgvUsersSetting.DataSource = workerList;

                }
            }
            catch(Exception ex)
            {
                MessageBox.Show($"사용자 데이터 불러오는 중 오류가 발생");
            }
        }

        private async void US_UserSetting_Load(object sender, EventArgs e)
        {
            InitGrid();
            await LoadWorkerDataAsync();
        }

        protected override async void OnVisibleChanged(EventArgs e)
        {
            base.OnVisibleChanged(e);
            if (this.Visible)
            {
                await LoadWorkerDataAsync();
            }
        }
    }
}