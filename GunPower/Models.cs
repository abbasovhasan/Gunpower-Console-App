using GunPower;
using System;
using System.Data;
using System.Diagnostics;
using System.Threading;

namespace GunPower
{
    public class Models
    {
        public int MaxCapacity { get; set; } = 30;
        public int Capacity { get; set; }

        public int MagazineCount { get; set; }

        public int mode, reload, option;
    }

    public class GunModel : Models
    {
        public GunModel()
        {
            Console.WriteLine("Please enter the number of the gun you want to select!\n1-Famas Gold, 2-AUG A3 ES, 3- Groza");

            option = Convert.ToInt32(Console.ReadLine());

            switch (option)
            {
                case 1:
                    Console.WriteLine("Your gun: 1-Famas Gold");
                    break;
                case 2:
                    Console.WriteLine("Your gun: 2-AUG A3 ES");
                    break;
                case 3:
                    Console.WriteLine("Your gun: 3-Groza");
                    break;
            }
        }
    }

    public class Mode : Models
    {
        public Mode()
        {
            Console.ReadKey();

        Start:

            Console.Clear();

            Console.WriteLine("Please select 1 for manual mode, 2 for automatic mode!");

            mode = Convert.ToInt32(Console.ReadLine());

            Stopwatch stopwatch = new Stopwatch();

            if (mode == 1)
            {
                Capacity = MaxCapacity;

                stopwatch.Start();

                for (int i = 1; i <= MaxCapacity; i++)
                {
                    MagazineCount = MaxCapacity - i;

                    Console.WriteLine($"Current Magazine Count: {MagazineCount}");

                    Console.ReadKey();

                    if (MagazineCount == 0)
                    {
                        stopwatch.Stop();

                        Console.WriteLine($"Well done! You emptied a magazine in {stopwatch.Elapsed.TotalSeconds} seconds!");

                        double oneBulletTime = stopwatch.Elapsed.TotalSeconds / 30;

                        Console.WriteLine($"\nFor one bullet shooting time: {oneBulletTime} seconds");

                        goto Reload;
                    }
                }
            }
            else if (mode == 2)
            {
                Capacity = MaxCapacity;

                stopwatch.Start();

                for (int i = 1; i <= MaxCapacity; i++)
                {
                    MagazineCount = MaxCapacity - i;

                    Console.WriteLine($"Current Magazine Count: {MagazineCount}");

                    Random random = new Random();

                    int delay = random.Next(10, 150);

                    Thread.Sleep(delay);

                    if (MagazineCount == 0)
                    {
                        stopwatch.Stop();

                        Console.WriteLine($"\nTotal shooting time: {stopwatch.Elapsed.TotalSeconds} seconds");

                        double oneBulletTime = stopwatch.Elapsed.TotalSeconds / 30;

                        Console.WriteLine($"\nFor one bullet shooting time: {oneBulletTime} seconds");

                        goto Reload;
                    }
                }
            }

        Reload:
            if (MagazineCount == 0)
            {
                Console.WriteLine("\nBullets are depleted, press 'r' or 'R' to reload!");

                char reloadInput = Console.ReadKey().KeyChar;

                if (reloadInput == 'r' || reloadInput == 'R')
                {
                    Capacity = MaxCapacity;

                    Console.WriteLine($"\nYour bullets are reloaded! \n\nCurrent bullet count: {Capacity}");
                }

                Console.WriteLine("\nDo you want to continue shooting? Press 1 for Yes, 0 for No!");

                int continueShooting = Convert.ToInt32(Console.ReadLine());

                if (continueShooting == 1)
                {
                    goto Start;
                }
                else
                {
                    Console.WriteLine("\nThank you for using our service! \n\nHope to see you again<3.");

                    Console.WriteLine($"\nTotal shooting time: {stopwatch.Elapsed.TotalSeconds} seconds");

                    return;
                }
            }
        }
    }
}
