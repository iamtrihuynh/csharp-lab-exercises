using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSLab03_01_Bai01
{
    public class HinhHoc
    {
        public double DienTich { get; set; }
        public double ChuVi { get; set; }

        public virtual void tinhDienTichChuVi()
        {
            // Được ghi đè ở các lớp con
        }

        public override string ToString()
        {
            return string.Format("S = {0:F2}; P = {1:F2}", DienTich, ChuVi);
        }
    }
}
