using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace EPCat.ViewModel
{
    public partial class CustomResources : ResourceDictionary
    {
        EpCatViewModel ViewModel
        {
            get
            {
                return (EpCatViewModel.Instance);
            }
        }
        private void UpdateEpItem(object sender, RoutedEventArgs e)
        {
            if (ViewModel != null)
            {
                ViewModel.UpdateCurrentItem();
            }
        }

        private void UpdateEpItemChecked(object sender, RoutedEventArgs e)
        {
            //var d = sender;
            //rgType05.
        }
    }
}
