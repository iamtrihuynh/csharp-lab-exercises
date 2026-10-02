using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSLab03_01_Bai01
{
    public class HinhChuNhat : HinhHoc
    {
        private double mChieuDai;
        private double mChieuRong;

        public double ChieuDai
        {
            get { return mChieuDai; }
            set
            {
                if (value > 0) mChieuDai = value;
                else throw new ArgumentException("Chiều dài phải > 0");
            }
        }

        public double ChieuRong
        {
            get { return mChieuRong; }
            set
            {
                if (value > 0) mChieuRong = value;
                else throw new ArgumentException("Chiều rộng phải > 0");
            }
        }

        public HinhChuNhat(double d = 1, double r = 0.5)
        {
            ChieuDai = d;
            ChieuRong = r;
            tinhDienTichChuVi();
        }

        public override void tinhDienTichChuVi()
        {
            DienTich = mChieuDai * mChieuRong;
            ChuVi = (mChieuDai + mChieuRong) * 2;
        }

        public override string ToString()
        {
            return string.Format("L = {0}, W = {1}; {2}", mChieuDai, mChieuRong, base.ToString());
        }
    }
}
