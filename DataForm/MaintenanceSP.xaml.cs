
using System.ComponentModel;
using System.Windows.Data;
using System.Collections.ObjectModel;
using DataForm;

namespace System.Windows.Controls
{
    /// <summary>
    /// Sample page that demonstrates using a DataGrid, DataForm, and DataPager
    /// to create a paged Master-Details view.
    /// </summary>
    
    public partial class MaintaenanceSP : UserControl
    {
        public ObservableCollection<User> lstPerson { get; set; }
        /// <summary>
        /// Initializes a DataGridMasterDetailsSample.
        /// </summary>
        public MaintaenanceSP()
        {
            InitializeComponent();
            
            lstPerson = new ObservableCollection<User>()
            {
            new User()
            {
            ID=1,
            FirstName="Turabek",
            LastName="Molodjanov",
            DateOfBirth = new DateTime(1981, 5, 5)
            },
            new User()
            {
            ID=2,
            FirstName="alex",
            LastName="chan",
            DateOfBirth = new DateTime(2009, 1, 1)
            },
            new User()
            {
            ID=3,
            FirstName="Terrance",
            LastName="Siang Peng",
            DateOfBirth = new DateTime(1922, 6, 10)
            }
            };
            PagedCollectionView pcv = new PagedCollectionView(lstPerson);
            DataContext = pcv;
        }

        private void btnEdit_Click(object sender, RoutedEventArgs e)
        {
            dataForm1.BeginEdit();
        }

        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            
            dataForm1.AddNewItem();

        }

        private void dataForm1_EditEnded(object sender, DataFormEditEndedEventArgs e)
        {
            System.Collections.IEnumerable temp = grd1.ItemsSource;
            grd1.ItemsSource = null;
            grd1.ItemsSource = temp;
        }
    }
}
