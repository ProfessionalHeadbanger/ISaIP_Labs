using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ISaIP_Lab6
{
    public partial class LoginDialog : Form
    {
        public string UserId => userIdTextBox.Text;
        public LoginDialog()
        {
            InitializeComponent();
        }
    }
}
