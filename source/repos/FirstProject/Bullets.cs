using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FirstProject
{
    internal class Bullets
    {
        public static void Game()
        {
            int bullet_no = Convert.ToInt32(Console.ReadLine());
            Bullets bk = new Bullets(); 
            bk.Hero(bullet_no);
            bk.Villain(bullet_no);
        }

        public void Hero(int b)
        {
            int k = b / 3;
            Console.WriteLine("At the end, Maximum bullet shots got by hero "+k);
        }

        public void Villain(int b)
        {
            
            Console.WriteLine("Maximum bullet shots got by villain " + b);

        }
    }
}
