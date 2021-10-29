using Dapper;
using OneToManyDupperExample.Entities;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Configuration;
using System.Data.SqlClient;
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

namespace OneToManyDupperExample
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            using (var connection = new SqlConnection(ConfigurationManager.ConnectionStrings["MyConnString"].ConnectionString))
            {
                var sql = @"select G.GroupId,G.Title,S.StudentId,S.Firstname,S.Age
from Groups as G
inner join Students as S
on S.GroupId=G.GroupId";
                var Groups = connection.Query<Group, Student, Group>(sql,
                    (group, student) =>
                    {
                        group.Students.Add(student);
                        return group;

                    }, splitOn: "StudentId").ToList();

                MyDataGrid.ItemsSource = Groups;



            }
        }
    }
}
