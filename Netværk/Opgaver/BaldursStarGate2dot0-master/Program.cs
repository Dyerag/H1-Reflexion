namespace BaldursStarGate2dot0
{
    internal class Program
    {
        static void Main(string[] args)
        {
            RndSeed();
            //Console.ReadKey();
            Console.CursorVisible = false;
            //Console.SetWindowSize(20, 20);
            //Console.SetBufferSize(20, 20);
            Console.Clear();
            CreateSomeEquipment();
            new Menu();
        }

        static void CreateSomeEquipment()
        {
            AllEquipment ae = new AllEquipment();
            Equipment Sword = new() { Name = "Claymore", Damage = 10, Gold = 100 };
            Equipment Shield = new() { Name = "Hyrule Shield", Armor = 10, Gold = 150 };
            ae.EquipmentList = new() { Sword, Shield };
            Io.Save(ae);
        }


        private static void RndSeed()
        {
            for (int i = 0; i < 10; i++)
            {
                Console.WriteLine(Game.Rnd.Next(0, 10));
            }
        }
    }
}