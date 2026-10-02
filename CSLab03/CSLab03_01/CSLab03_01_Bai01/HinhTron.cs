using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSLab03_01_Bai01
{
    public class HinhTron : HinhHoc
    {
        private double mBanKinh;

        public double BanKinh
        {
            get { return mBanKinh; }
            set
            {
                if (value > 0) mBanKinh = value;
                else throw new ArgumentException("Bán kính phải > 0");
            }
        }

        public HinhTron(double r = 1.0)
        {
            BanKinh = r;
            tinhDienTichChuVi();
        }

        public override void tinhDienTichChuVi()
        {
            DienTich = Math.PI * mBanKinh * mBanKinh;
            ChuVi = 2 * Math.PI * mBanKinh;
        }

        public override string ToString()
        {
            return string.Format("R = {0}; {1}", mBanKinh, base.ToString());
        }
    }
}
