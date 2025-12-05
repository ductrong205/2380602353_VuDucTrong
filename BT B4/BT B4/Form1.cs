using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BT_B4
{
    public partial class Form1 : Form
    {
        private BindingList<NhanVien> danhSach;
        public Form1()
        {
            InitializeComponent();
            danhSach = new BindingList<NhanVien>();
            SetupGrid();
            dgvNhanVien.AutoGenerateColumns = true;
            dgvNhanVien.DataSource = danhSach;
        }

        private void SetupGrid()
        {
            dgvNhanVien.AutoGenerateColumns = false;

            dgvNhanVien.Columns.Clear();

            var colMa = new DataGridViewTextBoxColumn();
            colMa.DataPropertyName = "MaNV";
            colMa.HeaderText = "MSNV";
            colMa.Width = 80;
            dgvNhanVien.Columns.Add(colMa);

            var colTen = new DataGridViewTextBoxColumn();
            colTen.DataPropertyName = "TenNV";
            colTen.HeaderText = "Tên nhân viên";
            colTen.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dgvNhanVien.Columns.Add(colTen);

            var colLuong = new DataGridViewTextBoxColumn();
            colLuong.DataPropertyName = "LuongCB";
            colLuong.HeaderText = "Lương căn bản";
            colLuong.DefaultCellStyle.Format = "N0"; 
            colLuong.Width = 120;
            dgvNhanVien.Columns.Add(colLuong);

            dgvNhanVien.RowHeadersVisible = false;
            dgvNhanVien.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvNhanVien.MultiSelect = false;
            dgvNhanVien.AllowUserToAddRows = false;
            dgvNhanVien.ReadOnly = true;
            dgvNhanVien.BackgroundColor = SystemColors.Window;
            dgvNhanVien.BorderStyle = BorderStyle.FixedSingle;
            dgvNhanVien.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            danhSach.Add(new NhanVien
            {
                MaNV = "NV001",
                TenNV = "Nguyễn Thị Thu Hiền",
                LuongCB = 8500000
            });
        }


        private void btnThem_Click(object sender, EventArgs e)
        {
            using (var f = new FormNhanVien())
            {
                if (f.ShowDialog() == DialogResult.OK)
                {
                    danhSach.Add(f.NhanVienData);
                }
            }
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            if (dgvNhanVien.CurrentRow == null)
            {
                MessageBox.Show("Hãy chọn nhân viên cần sửa");
                return;
            }

            var nv = dgvNhanVien.CurrentRow.DataBoundItem as NhanVien;
            if (nv == null) return;

            using (var f = new FormNhanVien(nv))
            {
                if (f.ShowDialog() == DialogResult.OK)
                {
                    dgvNhanVien.Refresh(); 
                }
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (dgvNhanVien.CurrentRow == null)
            {
                MessageBox.Show("Hãy chọn nhân viên cần xóa");
                return;
            }

            var nv = dgvNhanVien.CurrentRow.DataBoundItem as NhanVien;
            if (nv == null) return;

            var r = MessageBox.Show(
                "Bạn có chắc muốn xóa nhân viên này?",
                "Xác nhận",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (r == DialogResult.Yes)
            {
                danhSach.Remove(nv);
            } 
        }

        private void btnDong_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
