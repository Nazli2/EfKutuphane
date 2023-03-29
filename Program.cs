// See https://aka.ms/new-console-template for more information
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

Console.WriteLine("Hello, World!");

public class Ogrenci
{
    [Key]
    public int Id { get; set; }
    public string Adi { get; set; }
    public string Soyadi { get; set; }
    public char Cinsiyet { get; set; }
    public string Sinif { get; set; }
    public DateTime DogumTarihi { get; set; }
    public Boolean AktifMi { get; set; }
    public DateTime KayitTarihi { get; set; }
    public İslem islem { get; set; }
    
}

public class Tur
{
    [Key]
    public int Id { get; set; }
    public string TurAdi { get; set; }
    public Kitap kitap { get; set; }
}

public class YayınEvi
{
    [Key]
    public int Id { get; set; }
    public string YayinEviAdi { get; set; }
    public string Telefon { get; set; }
    public ICollection<Kitap> kitap { get; set; }
    
}

public class Yazar
{
    [Key]
    public int Id { get; set; }
    public string YazarAdi { get; set; }
    public Kitap kitap { get; set; }
}

public class Kitap
{
    [Key]
    public int Id { get; set; }
    public string KitapAdi { get;set; }
    public int SayfaSayisi { get; set; }
    public Boolean SilindiMi { get; set; }
    public DateTime KayitTarihi { get; set; }
    [ForeignKey("Yazar")]
    public int YazarId { get; set; }
    public DateTime BasimTarihi { get; set; }
    [ForeignKey("YayınEvi")]
    public int YayinEviId { get; set; }
    [ForeignKey("Tur")]
    public int TurId { get; set; }
    public string Dil { get; set; }
    public int KitapSayisi { get; set; }
    public string Cevirmen { get; set; }
    public İslem islem { get; set; }
    
}

public class İslem
{
    [Key]
    public int Id { get; set; }
    [ForeignKey("Ogrenci")]
    public int OgrenciId { get; set; }
    [ForeignKey("Kitap")]
    public int KitapId { get; set; }
    public DateTime OduncAldigiTarih { get; set; }
    public DateTime IadeTarihi { get; set; }
    public Boolean IadeEdildiMi { get; set; }
    public Kitap kitap { get; set; }
}



public class Context : DbContext
{
    public DbSet<Ogrenci> Ogrenciler { get; set; }
    public DbSet<Tur> Turler { get; set; }
    public DbSet<YayınEvi> YayinEvleri { get; set; }
    public DbSet<Yazar> Yazarlar { get; set; }
    public DbSet<Kitap> Kitaplar { get; set; }
    public DbSet<İslem> İslemler { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer("Server=DESKTOP-KIK63H8;Database=EfKutuphane;Integrated Security=true");
    }
}