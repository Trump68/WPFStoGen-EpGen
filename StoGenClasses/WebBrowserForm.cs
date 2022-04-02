using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace StoGen.Classes
{
    public partial class WebBrowserForm : Form
    {
        public WebBrowserForm()
        {
            InitializeComponent();
            Load += new EventHandler(Main_Load);  // Optional. Just an on Load event.
        }
        // The is the event on Form load. it is optional.
        private void Main_Load(object sender, EventArgs e)
        {
            //listener.start();
        }
    }
}
