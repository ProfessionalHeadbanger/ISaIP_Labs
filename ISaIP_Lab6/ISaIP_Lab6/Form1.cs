using System;

namespace ISaIP_Lab6
{
    public partial class Form1 : Form
    {
        private List<User> users;
        private List<AccessObject> accessObjects;
        private AccessMatrix accessMatrix;
        private Random random = new Random();

        public Form1()
        {
            InitializeComponent();
            loginLabel.Text = "You're: guest";
            InitializeData();
            PopulateAccessMatrix();
            InitializeContextMenu();
        }

        public void InitializeData()
        {
            users = new List<User>
            {
                new User("admin"),
                new User("guest"),
                new User("user1"),
                new User("user2"),
                new User("user3"),
                new User("user4")
            };

            accessObjects = new List<AccessObject>
            {
                new AccessObject("File 1"),
                new AccessObject("File 2"),
                new AccessObject("File 3"),
                new AccessObject("File 4"),
                new AccessObject("File 5")
            };

            accessMatrix = new AccessMatrix();
            var admin = users[0];
            foreach (var obj in accessObjects)
            {
                accessMatrix.SetAccess(admin, obj, AccessRights.Full);
            }

            foreach (var user in users)
            {
                if (user.Id == "admin") continue;

                foreach (var obj in accessObjects)
                {
                    AccessRights rights;
                    if (user.Id == "guest")
                    {
                        rights = (random.Next(2) == 0) ? AccessRights.None : AccessRights.Read;
                    }
                    else
                    {
                        rights = GetRandomAccessRights();
                    }

                    accessMatrix.SetAccess(user, obj, rights);
                }
            }
        }

        private AccessRights GetRandomAccessRights()
        {
            AccessRights rights = AccessRights.None;

            if (random.Next(2) == 1)
            {
                rights |= AccessRights.Read;
            }

            if (random.Next(2) == 1)
            {
                rights |= AccessRights.Write;
            }

            if (random.Next(10) == 1)
            {
                rights |= AccessRights.DelegateRights;
            }

            return rights;
        }

        private void InitializeContextMenu()
        {
            accessContextMenu = new ContextMenuStrip();

            var readMenuItem = new ToolStripMenuItem("Read", null, (s, e) => ExecuteAction(AccessRights.Read));
            var writeMenuItem = new ToolStripMenuItem("Write", null, (s, e) => ExecuteAction(AccessRights.Write));
            var delegateMenuItem = new ToolStripMenuItem("Delegate Rights", null, (s, e) => ExecuteAction(AccessRights.DelegateRights));

            accessContextMenu.Items.AddRange(new ToolStripItem[] { readMenuItem, writeMenuItem, delegateMenuItem });
        }

        private void ExecuteAction(AccessRights requiredRights)
        {
            var user = GetCurrentUser();
            var selectedRow = accessMatrixGridView.SelectedCells[0].RowIndex;
            var selectedColumn = accessMatrixGridView.SelectedCells[0].ColumnIndex;

            var accessObject = accessObjects[selectedColumn - 1];

            if (accessMatrix.HasAccess(user, accessObject, requiredRights))
            {
                MessageBox.Show($"User {user.Id} done: {requiredRights} on {accessObject.Name}", "Access allowed", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show($"User {user.Id} don't have rights to: {requiredRights} on {accessObject.Name}", "Access denied", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private User GetCurrentUser()
        {
            var userId = loginLabel.Text.Replace("You're: ", "").Trim();
            return users.FirstOrDefault(u => u.Id == userId);
        }

        private string FormatAccessRights(AccessRights rights)
        {
            var rightsList = new List<string>();

            if (rights.HasFlag(AccessRights.Read))
                rightsList.Add("Read");
            if (rights.HasFlag(AccessRights.Write))
                rightsList.Add("Write");
            if (rights.HasFlag(AccessRights.DelegateRights))
                rightsList.Add("DelegateRights");
            if (rights.HasFlag(AccessRights.Full))
                rightsList.Add("Full");

            return rightsList.Count > 0 ? string.Join(", ", rightsList) : "No Access";
        }

        private void PopulateAccessMatrix()
        {
            accessMatrixGridView.Columns.Add("User", "User");
            foreach (var obj in accessObjects)
            {
                accessMatrixGridView.Columns.Add(obj.Name, obj.Name);
            }

            foreach (var user in users)
            {
                var row = new DataGridViewRow();
                row.CreateCells(accessMatrixGridView);
                row.Cells[0].Value = user.Id;

                for (int i = 0; i < accessObjects.Count; i++)
                {
                    var obj = accessObjects[i];
                    var rights = accessMatrix.GetRights(user, obj);
                    row.Cells[i + 1].Value = FormatAccessRights(rights);
                }

                accessMatrixGridView.Rows.Add(row);
            }
        }

        private void loginButton_Click(object sender, EventArgs e)
        {
            using (var loginDialog = new LoginDialog())
            {
                if (loginDialog.ShowDialog() == DialogResult.OK)
                {
                    var userId = loginDialog.UserId;
                    var user = users.FirstOrDefault(u => u.Id == userId);

                    if (user != null)
                    {
                        loginLabel.Text = $"You're: {userId}";
                    }
                    else
                    {
                        MessageBox.Show("User not found. Please try again.", "Authentication Failed", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        loginLabel.Text = "You're: guest";
                    }
                }
            }
        }

        private void accessMatrixGridView_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right && e.RowIndex >= 0 && e.ColumnIndex > 0)
            {
                accessMatrixGridView.ClearSelection();
                accessMatrixGridView.Rows[e.RowIndex].Cells[e.ColumnIndex].Selected = true;
                accessContextMenu.Show(Cursor.Position);
            }
        }
    }
}
