using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Work4
{
    static class Program
    {
        public static ArrayList product = new ArrayList();

        /// <summary>
        /// 应用程序的主入口点。
        /// </summary>
        [STAThread]

        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            product.Add(new Product("无", 0f, 0));
            product.Add(new Product("Computer", 6199.00f, 20));
            product.Add(new Product("Phone", 4688.00f, 30));
            Application.Run(new Form1());
        }
    }
}
