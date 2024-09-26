using System;
using System.Collections.Generic;

//membuat class hewan sebagai parental class (induknya)
public class Hewan
{
    //membuat properti nama dan umur (properti umum hewan)
    public string Nama { get; set; }
    public int Umur { get; set; }

    //konstruksi properti Hewan
    public Hewan(string nama, int umur)
    {
        Nama = nama;
        Umur = umur;
    }

    //menambahkan method Suara (hewan pasti punya suara)
    public virtual string Suara()
    {
        return "Hewan ini bersuara.";
    }

    //menambahkan method InfoHewan untuk mencetak informasi hewan
    public virtual string InfoHewan()
    {
        return $"Nama: {Nama}, Umur: {Umur} tahun";
    }
}

//membuat subclass Mamalia dari parental Hewan (inheritance pertama)
public class Mamalia : Hewan
{
    //membuat property khusus Mamalia
    public int JumlahKaki { get; set; }

    //konstruksi properti Mamalia
    public Mamalia(string nama, int umur, int jumlahKaki) : base(nama, umur)
    {
        JumlahKaki = jumlahKaki;
    }

    //menambahkan method InfoHewan untuk mencetak informasi mamalia dengan overriding
    public override string InfoHewan()
    {
        return base.InfoHewan() + $", Jumlah Kaki: {JumlahKaki}";
    }
}

//membuat subclass Reptil dari parental Hewan (inheritance pertama)
public class Reptil : Hewan
{
    //membuat property khusus Reptil
    public double PanjangTubuh { get; set; }

    //konsruksi properti Reptil
    public Reptil(string nama, int umur, double panjangTubuh) : base(nama, umur)
    {
        PanjangTubuh = panjangTubuh;
    }

    //menambahkan method InfoHewan untuk mencetak informasi reptil dengan overriding
    public override string InfoHewan()
    {
        return base.InfoHewan() + $", Panjang Tubuh: {PanjangTubuh} meter";
    }
}

//membuat subclass Singa dari subclass Mamalia  (inheritance kedua)
public class Singa : Mamalia
{
    //konstruksi properti Singa
    public Singa(string nama, int umur, int jumlahKaki) : base(nama, umur, jumlahKaki) { }

    //overriding Suara Hewan menjadi suara singa
    public override string Suara()
    {
        return "Singa mengaum! Roarrrrr!";
    }

    //menambah method khusus yaitu mengaum
    public void Mengaum()
    {
        Console.WriteLine($"Heboh suara {Nama} mengaum begitu keras! BonBin PBO geger!!");
    }
}

//membuat subclass Gajah dari subclass Mamalia  (inheritance kedua)
public class Gajah : Mamalia
{
    //konstruksi properti Gajah
    public Gajah(string nama, int umur, int jumlahKaki) : base(nama, umur, jumlahKaki) { }

    //overriding Suara Hewan menjadi suara gajah
    public override string Suara()
    {
        return "Gajah menderum! Fhwaummmmbrr!";
    }
}

//membuat subclass Ular dari subclass Reptil  (inheritance kedua)
public class Ular : Reptil
{
    //konstruksi properti Ular
    public Ular(string nama, int umur, double panjangTubuh) : base(nama, umur, panjangTubuh) { }

    //overriding suara Hewan menjadi suara ular
    public override string Suara()
    {
        return "Ular mendesis! Ssshhhhzh";
    }

    //menambah method khusus yaitu Merayap
    public void Merayap()
    {
        Console.WriteLine($"{Nama} tidak berkaki, {Nama} sedang melata ke luar kandang! Hati-hati!!");
    }
}

//membuat subclass Buaya dari subclass Reptil  (inheritance kedua)
public class Buaya : Reptil
{
    //konstruksi properti Buaya
    public Buaya(string nama, int umur, double panjangTubuh) : base(nama, umur, panjangTubuh) { }

    //overriding Suara Hewan menjadi suara buaya
    public override string Suara()
    {
        return "Buaya menderam! Drhammmm!";
    }
}

//membuat class KebunBinatang untuk mengelompokkan hewan ke dalam kebun binatang
public class KebunBinatang
{
    //membuat variabel dengan tipe list yang memuat data hewan ke koleksiHewan
    private List<Hewan> koleksiHewan = new List<Hewan>();

    //menambahkan hewan dari Hewan ke kebun binatang
    public void TambahHewan(Hewan hewan)
    {
        koleksiHewan.Add(hewan);
    }

    //mecetak informasi hewan yang ada di daftar hewan
    public void DaftarHewan()
    {
        foreach (var hewan in koleksiHewan)
        {
            Console.WriteLine(hewan.InfoHewan());
        }
    }
}


//membuat class program
class Program
{
    static void Main(string[] args)
    {
        //membuat objek kebun binatang
        KebunBinatang BonBinPBO = new KebunBinatang();

        //membuat beberapa objek dari berbagai jenis hewan
        Singa singa = new Singa("Singa Cape", 5, 4);
        Gajah gajah = new Gajah("Gajah Kalimantan", 10, 4);
        Ular ular = new Ular("Ular Piton", 3, 2.5);
        Buaya buaya = new Buaya("Buaya Muara", 7, 3.6);
        Reptil reptil = new Reptil("Tokek", 1, 0.5);

        //menambahkan hewan-hewan ke kebun binatang
        BonBinPBO.TambahHewan(singa);
        BonBinPBO.TambahHewan(gajah);
        BonBinPBO.TambahHewan(ular);
        BonBinPBO.TambahHewan(buaya);
        BonBinPBO.TambahHewan(reptil);

        //memanggil method DaftarHewan()
        Console.WriteLine("Daftar Hewan di Kebun Binatang BonBin PBO:");
        BonBinPBO.DaftarHewan();

        //mendemonstrasikan penggunaan polymorphism dengan memanggil method Suara()
        Console.WriteLine("\nHewan-hewan di kebun binatang berbunyi:");
        Console.WriteLine(singa.Suara());
        Console.WriteLine(gajah.Suara());
        Console.WriteLine(ular.Suara());
        Console.WriteLine(buaya.Suara());
        Console.WriteLine(reptil.Suara());

        //memanggil method khusus
        Console.WriteLine("\nSpecial ability (serba-serbi bonbin):");
        singa.Mengaum();
        ular.Merayap();
    }
}
