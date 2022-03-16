using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using CRUD2.Data;
using Microsoft.EntityFrameworkCore.Infrastructure;

namespace CRUD2
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        // Kør når programmet starter
        protected override void OnStartup(StartupEventArgs e)
        {
            // Opret database hvis den ikke findes med DataContext
            DatabaseFacade facade = new DatabaseFacade(new DataContext());
            // Sikre at databasen er oprettet
            facade.EnsureCreated();

        }
    }
}
