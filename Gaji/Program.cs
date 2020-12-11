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
        
        public virtual string LihatGaji()
        {
            return ("Berikut Hasil Perhitungan Gaji Anda : ");
        }    
    }

    class Dosen : Karyawan
    {
        int HonorPerJam = 200000;
        int JumlahMengajar = 5;
        string TotalGaji;

        public override string LihatGaji()
        {
            Jumlahgaji = (Jumlahgaji + ((HonorPerJam * JumlahMengajar) * 30));
            Jumlahgaji = Jumlahgaji - (Jumlahgaji * Pajak);

            TotalGaji = "Total Gaji " + Nama + " Sebagai Dosen, pada bulan " + Bulan + " adalah = " + String.Format("{0:n0}", Math.Round(Jumlahgaji, 0));

            return TotalGaji;
        }
    }

    class KaryawanHarian : Karyawan
    {
        int UpahHarian = 300000;
        int JumlahHariKerja = 15;
        string TotalGaji;

        public override string LihatGaji()
        {
            Jumlahgaji = (Jumlahgaji + (UpahHarian * JumlahHariKerja));
            Jumlahgaji = Jumlahgaji - (Jumlahgaji * Pajak);

            TotalGaji = "Total Gaji "+ Nama + " Sebagai Karyawan Harian, pada bulan " + Bulan + " adalah = " + String.Format("{0:n0}", Math.Round(Jumlahgaji, 0));

            return TotalGaji;
        }
    }

    class KaryawanTetap : Karyawan
    {
        int GajiBulanan = 4000000;
        string TotalGaji;

        public override string LihatGaji()
        {
            Jumlahgaji = (Jumlahgaji + GajiBulanan);
            Jumlahgaji = Jumlahgaji - (Jumlahgaji * Pajak);

            TotalGaji = "Total Gaji " + Nama + " Sebagai Karyawan Tetap, pada bulan " + Bulan + " adalah = " + String.Format("{0:n0}", Math.Round(Jumlahgaji, 0));

            return TotalGaji;
        }
    }

    class Gaji
    {
        public string IdBulan = "Januari";
        public int Tunjangan = 1000000;
        public double Pajak = 0.10;
    }

    class InputOutput
    {
        string nama, totalgajitunjangan = "", totalgaji = "";

        public void input()
        {
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
            Console.Write("Masukan Status Anda (1.Dosen) | (2.Karyawan Harian) | (3.Karyawan Tetap) | (4.Bandingkan Gaji) : ");
            status = Convert.ToInt16(Console.ReadLine());

            if (status == 1)
            {
                Karyawan _karyawan = new Karyawan();
                totalgaji = _karyawan.LihatGaji();

                Dosen _dosen = new Dosen();
                _dosen.setID(id);
                _dosen.setNama(nama);
                _dosen.setRekening(rekening);
                _dosen.CekTunjangan();
                totalgajitunjangan = _dosen.LihatGaji();
                display();
            }
            else if (status == 2)
            {
                Karyawan _karyawan = new Karyawan();
                totalgaji = _karyawan.LihatGaji();

                KaryawanHarian _harian = new KaryawanHarian();
                _harian.CekTunjangan();
                _harian.setID(id);
                _harian.setNama(nama);
                _harian.setRekening(rekening);
                totalgajitunjangan = _harian.LihatGaji();
                display();
            }
            else if (status == 3)
            {
                Karyawan _karyawan = new Karyawan();
                totalgaji = _karyawan.LihatGaji();

                KaryawanTetap _tetap = new KaryawanTetap();
                _tetap.CekTunjangan();
                _tetap.setID(id);
                _tetap.setNama(nama);
                _tetap.setRekening(rekening);
                totalgajitunjangan = _tetap.LihatGaji();
                display();
            }
            else if (status == 4)
            {
                for (int a = 0; a < 3; a++)
                {
                    Karyawan _karyawan = new Karyawan();
                    totalgaji = _karyawan.LihatGaji();

                    if (a == 0)
                    {
                        Dosen _dosen = new Dosen();
                        _dosen.setID(id);
                        _dosen.setNama(nama);
                        _dosen.setRekening(rekening);
                        _dosen.CekTunjangan();
                        totalgajitunjangan = _dosen.LihatGaji();
                    }
                    else if (a == 1)
                    {
                        KaryawanHarian _harian = new KaryawanHarian();
                        _harian.CekTunjangan();
                        _harian.setID(id);
                        _harian.setNama(nama);
                        _harian.setRekening(rekening);
                        totalgajitunjangan = _harian.LihatGaji();
                    }
                    else if (a == 2)
                    {
                        KaryawanTetap _tetap = new KaryawanTetap();
                        _tetap.CekTunjangan();
                        _tetap.setID(id);
                        _tetap.setNama(nama);
                        _tetap.setRekening(rekening);
                        totalgajitunjangan = _tetap.LihatGaji();
                    }
                    display();
                }
            }
            else
            {
                Console.WriteLine("Input Salah!!");
            }
        }

        public void display()
        {
            Console.WriteLine();
            Console.WriteLine(".............................................................");
            Console.WriteLine(totalgaji);
            Console.WriteLine(totalgajitunjangan);
            Console.WriteLine(".............................................................");
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            string ulang = "";

            do
            {
                Console.Clear();
                InputOutput tampil = new InputOutput();
                tampil.input();

                Console.WriteLine();
                Console.WriteLine("Apakah anda ingin mengecek ulang ??? y/n");
                ulang = Console.ReadKey().KeyChar.ToString();
            } while (ulang.ToUpper() == "Y");
        }
    }
}
