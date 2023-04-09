using System;
using System.Data;
using System.Data.SqlClient;

namespace kelompok_myklass
{
    internal class Program
    {
        public void koneksi()
        {
            
        }

        static void Main(string[] args)
        {
            new Program().koneksi();
            Program pr = new Program();
            while (true)
            {
                try
                {
                    Console.WriteLine("Koneksi ke Database\n");
                    Console.WriteLine("Masukkan UserID : ");
                    string user = Console.ReadLine();
                    Console.WriteLine("Masukkan Password : ");
                    string pass = Console.ReadLine();
                    Console.WriteLine("Masukkan Database Tujuan : ");
                    string db = Console.ReadLine();
                    Console.Write("\nKetik K untuk Terhubung ke Database: ");
                    char chr = Convert.ToChar(Console.ReadLine());
                    switch (chr)
                    {
                        case 'K':
                            {
                                using (
                //membuat koneksi
                SqlConnection conn = new SqlConnection("data source = LAPTOP-IH6NG1MN\\SITI_MARFUNGAH; database = Cafe; user ID=kesini;password=123"))

                                {
                                    conn.Open();

                                    Console.Clear();

                                    while (true)
                                    {
                                        try
                                        {
                                            Console.WriteLine("\nMenu");
                                            Console.WriteLine("1. Melihat Seluruh Data Makanan");
                                            Console.WriteLine("2. Melihat Seluruh Data Minuman");
                                            Console.WriteLine("3. Tambah Data Makanan");
                                            Console.WriteLine("4. Tambah Data Minuman");
                                            Console.WriteLine("5. Keluar");
                                            Console.Write("\nEnter your choice (1-5): ");
                                            char ch = Convert.ToChar(Console.ReadLine());
                                            switch (ch)
                                            {
                                                case '1':
                                                    {
                                                        Console.Clear();
                                                        Console.WriteLine("DATABASE CAFE\n");
                                                        Console.WriteLine();
                                                        pr.bacamk(conn);
                                                    }
                                                    break;
                                                case '2':
                                                    {
                                                        Console.Clear();
                                                        Console.WriteLine("DATABASE CAFE\n");
                                                        Console.WriteLine();
                                                        pr.bacamn(conn);
                                                    }
                                                    break;
                                                case '3':
                                                    {
                                                        Console.Clear();
                                                        Console.WriteLine("INPUT DATA MAKANAN\n");
                                                        Console.WriteLine("Masukkan Id Makanan : ");
                                                        string id_makanan = Console.ReadLine();
                                                        Console.WriteLine("Masukkan Nama Makanan : ");
                                                        string nm_makanan = Console.ReadLine();
                                                        Console.WriteLine("Masukkan Jenis Makanan : ");
                                                        string jenis_makanan = Console.ReadLine();
                                                        Console.WriteLine("Masukkan Harga Makanan : ");
                                                        string harga = Console.ReadLine();
                                                        Console.WriteLine("Masukkan Keterangan : ");
                                                        string keterangan = Console.ReadLine();
                                                        try
                                                        {
                                                            pr.insertmk(id_makanan, nm_makanan, jenis_makanan, harga, keterangan, conn);
                                                        }
                                                        catch
                                                        {
                                                            Console.WriteLine("\nAnda tidak memiliki " + "akses untuk menambah data");
                                                        }
                                                    }
                                                    break;
                                                 case '4':
                                                    {
                                                        Console.Clear();
                                                        Console.WriteLine("INPUT DATA MINUMAN\n");
                                                        Console.WriteLine("Masukkan Id Minuman : ");
                                                        string id_minuman = Console.ReadLine();
                                                        Console.WriteLine("Masukkan Nama Minuman : ");
                                                        string nm_minuman = Console.ReadLine();
                                                        Console.WriteLine("Masukkan Jenis Minuman : ");
                                                        string jenis_minuman = Console.ReadLine();
                                                        Console.WriteLine("Masukkan Harga Minuman : ");
                                                        string harga = Console.ReadLine();
                                                        Console.WriteLine("Masukkan Keterangan : ");
                                                        string keterangan = Console.ReadLine();
                                                        try
                                                        {
                                                            pr.insertmn(id_minuman, nm_minuman, jenis_minuman, harga, keterangan, conn);
                                                        }
                                                        catch
                                                        {
                                                            Console.WriteLine("\nAnda tidak memiliki " + "akses untuk menambah data");
                                                        }
                                                    }
                                                    break;
                                                case '5':
                                                    conn.Close();
                                                    return;
                                                default:
                                                    {
                                                        Console.Clear();
                                                        Console.WriteLine("\nInvalid Option");
                                                    }
                                                    break;
                                            }
                                        }
                                        catch
                                        {
                                            Console.WriteLine("\nCheck for the value entered.");
                                        }
                                    }
                                }

                            }
                    }
                }
                catch
                {
                    Console.Clear();
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Tidak Dapat Mengakses Database Menggunakan User Tersebut.\n");
                    Console.ResetColor();
                }
            }
        }
        public void bacamk(SqlConnection con)
        {
            SqlCommand cmd = new SqlCommand("Select * from tb_makanan", con);
            SqlDataReader r = cmd.ExecuteReader();
            while (r.Read())
            {
                for (int i = 0; i < r.FieldCount; i++)
                {
                    Console.WriteLine(r.GetValue(i));
                }
                Console.WriteLine();
            }
            r.Close();
        }
        public void bacamn(SqlConnection con)
        {
            SqlCommand cmd = new SqlCommand("Select * from tb_minuman", con);
            SqlDataReader r = cmd.ExecuteReader();
            while (r.Read())
            {
                for (int i = 0; i < r.FieldCount; i++)
                {
                    Console.WriteLine(r.GetValue(i));
                }
                Console.WriteLine();
            }
            r.Close();
        }
        public void insertmk(string id_makanan, string nm_makanan, string jenis_makanan, string harga, string keterangan, SqlConnection con)
        {
            string str = "";
            str = "insert into tb_makanan (id_makanan, nm_makanan, jenis_makanan, harga, keterangan)" + "values (@id, @nama, @jenis, @harganya, @ket)";
            SqlCommand cmd = new SqlCommand(str, con);
            cmd.CommandType = CommandType.Text;

            cmd.Parameters.Add(new SqlParameter("id", id_makanan));
            cmd.Parameters.Add(new SqlParameter("nama", nm_makanan));
            cmd.Parameters.Add(new SqlParameter("jenis", jenis_makanan));
            cmd.Parameters.Add(new SqlParameter("harganya", harga));
            cmd.Parameters.Add(new SqlParameter("ket", keterangan));
            cmd.ExecuteNonQuery();
            Console.WriteLine("Data Berhasil Ditambahkan");
        }

        public void insertmn(string id_minuman, string nm_minuman, string jenis_minuman, string harga, string keterangan, SqlConnection con)
        {
            string str = "";
            str = "insert into tb_minuman (id_minuman, nm_minuman, jenis_minuman, harga, keterangan)" + "values (@id, @nama, @jenis, @harganya, @ket)";
            SqlCommand cmd = new SqlCommand(str, con);
            cmd.CommandType = CommandType.Text;

            cmd.Parameters.Add(new SqlParameter("id", id_minuman));
            cmd.Parameters.Add(new SqlParameter("nama", nm_minuman));
            cmd.Parameters.Add(new SqlParameter("jenis", jenis_minuman));
            cmd.Parameters.Add(new SqlParameter("harganya", harga));
            cmd.Parameters.Add(new SqlParameter("ket", keterangan));
            cmd.ExecuteNonQuery();
            Console.WriteLine("Data Berhasil Ditambahkan ");
        }
    }
}
