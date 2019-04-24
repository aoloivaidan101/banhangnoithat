using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NoiThatNhuanHuong.UserControls.CongNo
{
    public partial class UCPhieuTraNo : UserControl
    {
        public UCPhieuTraNo()
        {
            InitializeComponent();
        }

        private void UCPhieuTraNo_Load(object sender, EventArgs e)
        {
            display();
        }

        void display()
        {
            gridControl1.DataSource = SQL_CongNo.Display_PhieuTraNo();
            fixHeaderName();
        }
        void fixHeaderName()
        {
            gridView1.Columns[0].Caption = "Mã trả nợ";
            gridView1.Columns[1].Caption = "Mã nợ";
            gridView1.Columns[2].Caption = "Ngày trả";
            gridView1.Columns[3].Caption = "Tổng tiền";
            gridView1.Columns[4].Caption = "Người trả";
        }

        private void gridView1_CustomRowCellEditForEditing(object sender, DevExpress.XtraGrid.Views.Grid.CustomRowCellEditEventArgs e)
        {
            /// load chi tiết phiếu nợ
   
            /// mã  stt nợ
            Temp.Temp_PhieuNoID = gridView1.GetRowCellValue(e.RowHandle, "STT_No").ToString();
            // lấy mã phiếu nhập
            DataTable bangno = SQL_CongNo.Display_PhieuNo();
            for(int i=0;i<bangno.Rows.Count;i++)
            {
                if (Temp.Temp_PhieuNoID == bangno.Rows[i][0].ToString())
                    Temp.Temp_PhieuNhapHangID = bangno.Rows[i][1].ToString();
            }
            Form_ChiTietPhieuNo dlg2 = new Form_ChiTietPhieuNo();
            dlg2.ShowDialog();
        }
    }
}
