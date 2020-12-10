using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gaji
{
    class Karyawan
    {
        protected int ID;
        protected string Nama;
        protected long Rekening;

        public void setID(int A)
        {
            ID = A;
        }
        public void setNama(string B)
        {
            Nama = B;
        }
        public void setRekening(long C)
        {
            Rekening = C;
        }

        protected string Bulan;
        protected double Jumlahgaji;
        protected double Pajak;

        public void CekTunjangan()
        {
            Gaji _gaji = new Gaji();
            Bulan = _gaji.IdBulan;
            Jumlahgaji = _gaji.Tunjangan;
            Pajak = _gaji.Pajak;
        }      
    }

    class Dosen : Karyawan
    {
        int HonorPerJam = 200000;
        int JumlahMengajar = 5;
        string TotalGaji;

        public string LihatGaji()
        {
            Jumlahgaji = (Jumlahgaji + ((HonorPerJam * JumlahMengajar) * 30));
            Jumlahgaji = Jumlahgaji - (Jumlahgaji * Pajak);

            TotalGaji = "Total Gaji " + Nama + " pada bulan " + Bulan + " adalah = " + String.Format("{0:n0}", Math.Round(Jumlahgaji, 0));

            return TotalGaji;
        }
    }

    class KaryawanHarian : Karyawan
    {
        int UpahHarian = 300000;
        int JumlahHariKerja = 15;
        string TotalGaji;

        public string LihatGaji()
        {
            Jumlahgaji = (Jumlahgaji + (UpahHarian * JumlahHariKerja));
            Jumlahgaji = Jumlahgaji - (Jumlahgaji * Pajak);

            TotalGaji = "Total Gaji "+ Nama +" pada bulan " + Bulan + " adalah = " + String.Format("{0:n0}", Math.Round(Jumlahgaji, 0));

            return TotalGaji;
        }
    }

    class KaryawanTetap : Karyawan
    {
        int GajiBulanan = 4000000;
        string TotalGaji;

        public string LihatGaji()
        {
            Jumlahgaji = (Jumlahgaji + GajiBulanan);
            Jumlahgaji = Jumlahgaji - (Jumlahgaji * Pajak);

            TotalGaji = "Total Gaji " + Nama + " pada bulan " + Bulan + " adalah = " + String.Format("{0:n0}", Math.Round(Jumlahgaji, 0));

            return TotalGaji;
        }
    }

    class Gaji
    {
        public string IdBulan = "Januari";
        public int Tunjangan = 1000000;
        public double Pajak = 0.10;
    }

    class Program
    {
        static void Main(string[] args)
        {
            string nama, totalgaji = "";
            int id, status;
            long rekening;

            Console.WriteLine(" PROGRAM MELIHAT JUMLAH GAJI KARYAWAN PT. FESAMAJUSEJAHTERA");
            Console.WriteLine(".............................................................");
            Console.WriteLine();

            Console.Write("Masukan id anda : ");
            id = Convert.ToInt16(Console.ReadLine());
            Console.Write("Masukkan Nama Anda : ");
            nama = Console.ReadLine().ToUpper();
            Console.Write("Masukkan Rekening Anda : ");
            rekening = Convert.ToInt64(Console.ReadLine());
            Console.Write("Masukan Status Anda (1.Dosen) | (2.Karyawan Harian) | (3.Karyawan Tetap) : ");
            status = Convert.ToInt16(Console.ReadLine());

            if (status == 1)
            {
                Dosen _dosen = new Dosen();
                _dosen.CekTunjangan();
                _dosen.setID(id);
                _dosen.setNama(nama);
                _dosen.setRekening(rekening);
                totalgaji = _dosen.LihatGaji();
            }
            else if (status == 2)
            {
                KaryawanHarian _harian = new KaryawanHarian();
                _harian.CekTunjangan();
                _harian.setID(id);
                _harian.setNama(nama);
                _harian.setRekening(rekening);
                totalgaji = _harian.LihatGaji();
            }
            else if (status == 3)
            {
                KaryawanTetap _tetap = new KaryawanTetap();
                _tetap.CekTunjangan();
                _tetap.setID(id);
                _tetap.setNama(nama);
                _tetap.setRekening(rekening);
                totalgaji = _tetap.LihatGaji();
            }

            Console.WriteLine();
            Console.WriteLine(".............................................................");
            Console.WriteLine(totalgaji);
            Console.WriteLine(".............................................................");
            Console.ReadLine();
        }
    }
}
