using HumanResourcesDesktop.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace HumanResourcesDesktop
{
    internal class AppConnect
    {
        public static Frame Main;
        public static Frame Hub;
        public static PersonEntity User;
        public static string Host = "https://localhost:5001/";
    }
}
