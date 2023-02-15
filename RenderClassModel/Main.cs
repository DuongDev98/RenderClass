using DuongNn.Db;
using DuongNn.Mapping;
using RenderClassModel.Utils;
using System;
using System.IO;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RenderClassModel
{
    public partial class Main : Form
    {
        public Main()
        {
            InitializeComponent();
            txtFolder.Text = "H:\\TOOLS\\RenderClassModel\\RenderClassModel\\code";

            //test
            //txtServer.Text = "server1.thuanvietsoft.com,1444";
            //txtUsername.Text = "erpdemo";
            //txtPassword.Text = "erpdemo123";
            //txtDatabase.Text = "thuanvietsoft.com_nppthuanphat";
        }

        private void Main_Load(object sender, EventArgs e)
        {
            txtFolder.Click += TxtFolder_Click;
            btnRender.Click += BtnRender_Click;
        }

        private void BtnRender_Click(object sender, EventArgs e)
        {
            string server = txtServer.Text.Trim();
            string username = txtUsername.Text.Trim();
            string password = txtPassword.Text.Trim();
            string database = txtDatabase.Text.Trim();
            string folder = txtFolder.Text.Trim();

            if (server.Length == 0 || username.Length == 0 || password.Length == 0 || database.Length == 0 || folder.Length == 0)
            {
                ShowWarnig("Tham số không hợp lệ");
                return;
            }

            Database db = new Database(server, username, password, database);

            bool test = true;
            if (test)
            {
                TDONHANGRow dhRow = new TDONHANGRow("5492e766-98a6-4d8c-8262-cf704e4da5bf");
                dhRow.NOTE = "123";
                dhRow.Update();
                return;
            }

            RenderDatabase render = new RenderDatabase(db, folder);

            Task task = new Task(() =>
            {
                this.Invoke(new MethodInvoker(delegate () { Enabled = false; }));
                bool error = false;
                try
                {
                    render.run();
                }
                catch (Exception ex)
                {
                    error = true;
                    ShowWarnig(ex.Message);
                }
                this.Invoke(new MethodInvoker(delegate () { Enabled = true; }));
                if (!error) ShowInfo("Done!");
            });
            task.Start();
        }

        private void TxtFolder_Click(object sender, EventArgs e)
        {
            OpenFileDialog opFolder = new OpenFileDialog();
            opFolder.CheckFileExists = false;
            opFolder.CheckPathExists = true;
            opFolder.ValidateNames = false;
            opFolder.FileName = "Folder Selection";
            opFolder.InitialDirectory = "H:\\";
            if (opFolder.ShowDialog() == DialogResult.OK)
            {
                txtFolder.Text = Path.GetDirectoryName(opFolder.FileName);
            }
        }

        void ShowInfo(string msg)
        {
            MessageBox.Show(msg, "", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        void ShowWarnig(string msg)
        {
            MessageBox.Show(msg, "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }
    }
}
