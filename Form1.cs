namespace C__project
{
    using System.Data.SqlClient;
    using static System.Windows.Forms.VisualStyles.VisualStyleElement.TaskbarClock;
    using System.Drawing;

    public partial class LoginForm : Form
    {
        private string connectionString = "Data Source=(localdb)\\ProjectModels;Initial Catalog=master;Integrated Security=True;Connect Timeout=30;Encrypt=False";
        public LoginForm()
        {
            InitializeComponent();

            // Login Button
            Login_Button.Padding = new Padding(6, 0, 5, 0);
        }

        // Connecting with DataBase and checking Username and Password
        public string? Check(String username, String password)
        {
            string? role = null;

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string upit = "SELECT Role FROM Users WHERE Username=@Username AND Password=@Password";

                using (SqlCommand command = new SqlCommand(upit, connection))
                {
                    command.Parameters.AddWithValue("@Username", username);
                    command.Parameters.AddWithValue("@Password", password);

                    // Opening connection
                    connection.Open();

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())  // Ako postoji bar jedan red
                        {
                            role = reader["Role"].ToString();  // Dobijamo ulogu
                        }
                    }

                }

                // Zatvaranje konekcije
                connection.Close();

                return role;
            }
        }




        // Zatvaranje Forme sa X
        private void LoginForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            // Prikazivanje MessageBox-a sa pitanjem
            DialogResult result = MessageBox.Show("Are you sure you want to close the application?",
                                                  "",
                                                  MessageBoxButtons.YesNo,
                                                  MessageBoxIcon.Question);
            if (result == DialogResult.No)
            {
                // Ako korisnik izabere "No", sprečavamo zatvaranje forme
                e.Cancel = true;
            }
        }



        // Hiding/Showing the Password
        private void icon_Click(object sender, EventArgs e)
        {
            if (PasswordTB.PasswordChar == '*')
                PasswordTB.PasswordChar = '\0';
            else
                PasswordTB.PasswordChar = '*';
        }
        // Login Button
        private void Login_Button_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(UsernameTB.Text))
            {
                MessageBox.Show("Enter Username !!!", "Error...", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                if (String.IsNullOrEmpty(PasswordTB.Text))
                {
                    MessageBox.Show("Enter Password !!!", "Error...", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else
                {
                    string? role = Check(UsernameTB.Text, PasswordTB.Text);

                    if (role == null)
                    {
                        MessageBox.Show("Incorrect username and/or password !!!", "Error...", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                    else if (role == "W")
                    {
                        this.UsernameTB.Text = "";
                        this.PasswordTB.Text = "";

                        this.Hide();
                        WorkerForm rf = new WorkerForm(this);

                        rf.Show();
                    }
                    else if (role == "A")
                    {
                        this.UsernameTB.Text = "";
                        this.PasswordTB.Text = "";

                        this.Hide();

                        AdminForm af = new AdminForm(this);

                        af.Show();

                    }
                }

            }
        }

        private void LoginForm_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                Login_Button_Click(sender, e);

                e.Handled = true;
                e.SuppressKeyPress = true;
            }
        }

        private void Login_Button_MouseEnter(object sender, EventArgs e)
        {
            Login_Button.BackColor = Color.SteelBlue;
        }

        private void Login_Button_MouseLeave(object sender, EventArgs e)
        {
            Login_Button.BackColor = Color.LightSkyBlue;
        }

        private void UsernameTB_Enter(object sender, EventArgs e)
        {
            UsernameTB.ForeColor = Color.DarkSlateGray;
        }
        private void UsernameTB_Leave(object sender, EventArgs e)
        {
            UsernameTB.ForeColor = Color.Black;
        }
        private void PasswordTB_Enter(object sender, EventArgs e)
        {
            PasswordTB.ForeColor = Color.DarkSlateGray;
        }
        private void PasswordTB_Leave(object sender, EventArgs e)
        {
            PasswordTB.ForeColor = Color.Black;
        }

    }
}