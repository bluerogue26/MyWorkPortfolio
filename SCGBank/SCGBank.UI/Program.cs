﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SCGBank.UI.Workflows;

namespace SCGBank.UI
{
    class Program
    {
        static void Main(string[] args)
        {
            var menu = new MainMenu();
            menu.Execute();
        }
    }
}
