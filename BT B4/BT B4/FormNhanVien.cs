using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BT_B4
{
    public partial class FormNhanVien : Form
    {
        public NhanVien NhanVienData { get; private set; }

        public FormNhanVien()
        {
            InitializeComponent();
            this.Text = "Thêm nhân viên";
        }
        public FormNhanVien(NhanVien nv) : this()
        {
            this.Text = "Sửa nhân viên";
            NhanVienData = nv;

            txtMaNV.Text = nv.MaNV;
            txtTenNV.Text = nv.TenNV;
            txtLuongCB.Text = nv.LuongCB.ToString(CultureInfo.InvariantCulture);
        }

        private void SetNhanVienData(NhanVien nv)
        {
            throw new NotImplementedException();
        }

        private void btnDongY_Click(object sender, EventArgs e)
        {
            if (!KiemTraNhap()) return;

            if (NhanVienData == null)
            {
                NhanVienData = new NhanVien();
            }

            NhanVienData.MaNV = txtMaNV.Text.Trim();
            NhanVienData.TenNV = txtTenNV.Text.Trim();
            NhanVienData.LuongCB = decimal.Parse(txtLuongCB.Text.Trim(),
                CultureInfo.InvariantCulture);

            this.DialogResult = DialogResult.OK;
        }

        private bool KiemTraNhap()
        {
            if (string.IsNullOrWhiteSpace(txtMaNV.Text))
            {
                MessageBox.Show("Mã nhân viên không được trống");
                txtMaNV.Focus();
                return false;
            }

            if (string.IsNullOrWhiteSpace(txtTenNV.Text))
            {
                MessageBox.Show("Tên nhân viên không được trống");
                txtTenNV.Focus();
                return false;
            }
            if (!decimal.TryParse(txtLuongCB.Text.Trim(),
                NumberStyles.Any,
                CultureInfo.InvariantCulture,
                out _))
            {
                MessageBox.Show("Lương căn bản không hợp lệ");
                txtLuongCB.Focus();
                return false;
            }

            return true;
        }

        private void btnBoQua_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }
    }
}
