using CRUD2.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace CRUD2
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        // Definer liste af Users
        public List<User> DatabaseUsers { get; private set; }

        public MainWindow()
        {
            InitializeComponent();
        }
        // Create
        public void Create()
        {
            // Brug DataContext
            using (DataContext context = new DataContext())
            {
                // Variabler med name og address fra tekstfelterne fra MainWindow
                var name = NameTextBox.Text;
                var address = AddressTextBox.Text;

                // Hvis name og address ikke er tomt
                if(name != null && address != null)
                {
                    // Tilføj name og address fra variablerne til Users
                    context.Users.Add(new User() { Name = name, Address = address });
                    // Gem ændringer i databasen
                    context.SaveChanges();
                }

            }

        }

        public void Read()
        {
            // Brug DataContext
            using (DataContext context = new DataContext())
            {
                // Query liste af data i databasen
                DatabaseUsers = context.Users.ToList();
                // Bind liste af data i ItemList i MainWindow
                ItemList.ItemsSource = DatabaseUsers;
            }

        }

        public void Update()
        {
            // Brug DataContext
            using (DataContext context = new DataContext())
            {
                // Får det første i ItemList som er id
                User? selectedUser = ItemList.SelectedItem as User;

                // Variabler med name og address fra tekstfelterne fra MainWindow
                var name = NameTextBox.Text;
                var address = AddressTextBox.Text;

                // Hvis name og address ikke er tomt
                if (name != null && address != null)
                {
                    // Find id fra den valgte bruger
                    User user = context.Users.Find(selectedUser.Id);
                    // Ændre name og address ud fra tekstfelterne
                    user.Name = name;
                    user.Address = address;
                    // Gem ændrignerne i databasen
                    context.SaveChanges();
                }

            }

        }

        public void Delete()
        {
            // Brug DataContext
            using (DataContext context = new DataContext())
            {
                // Får det første i ItemList som er id
                User? selectedUser = ItemList.SelectedItem as User;

                // Hvis selectedUser ikke er null
                if (selectedUser != null)
                {
                    // Tjekker om id er det samme som valgte bruger id
                    // Hvis true behold user for at slette
                    User user = context.Users.Single(x=> x.Id == selectedUser.Id);
                    // Slet bruger
                    context.Remove(user);
                    // Gem ændrignerne i databasen
                    context.SaveChanges();
                }
            }

        }

        // Create knap
        private void CreateButton1_Click(object sender, RoutedEventArgs e)
        {
            Create();
        }
        // Read knap
        private void ReadButton1_Click(object sender, RoutedEventArgs e)
        {
            Read();
        }
        // Update knap
        private void UpdateButton1_Click(object sender, RoutedEventArgs e)
        {
            Update();
        }
        // Delete knap
        private void DeleteButton1_Click(object sender, RoutedEventArgs e)
        {
            Delete();
        }
    }
}
