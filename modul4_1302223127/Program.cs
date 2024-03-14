using modul4_1302223127;
using static modul4_1302223127.KodeBuah;


internal class Program
{
    private static void Main(string[] args)
    {
        Console.WriteLine("===== 1). Table-Driven : Kode Buah");
        KodeBuah objBuah = new KodeBuah();
        Console.WriteLine("Kode buah " + EnumBuah.Blackberry + " adalah : " + objBuah.getKodeBuah(EnumBuah.Blackberry));
        Console.WriteLine("Kode buah " + EnumBuah.Kelapa + " adalah : " + objBuah.getKodeBuah(EnumBuah.Kelapa));
        Console.WriteLine("Kode buah " + EnumBuah.Semangka + " adalah : " + objBuah.getKodeBuah(EnumBuah.Semangka));

        Console.WriteLine("\n===== 2). State-Based : Posisi Karakter Game");
        PosisiKarakterGame objGame = new PosisiKarakterGame();
        Console.WriteLine("Posisi Awal : " + objGame.currentState);
        objGame.ActionGame(EnumTriggerGame.TombolW);
        objGame.ActionGame(EnumTriggerGame.TombolW);
        objGame.ActionGame(EnumTriggerGame.TombolX);
        objGame.ActionGame(EnumTriggerGame.TombolS);
    }
}