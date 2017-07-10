using System;
using System.Collections.Generic;
using System.Windows.Forms;
using NLog;
using System.Xml;
using System.Data.SqlClient;
using ProjectWork.RepositoriesImpl;
using ProjectWork.Utils;

namespace ProjectWork
{
    public partial class Form1 : Form
    {
        private List<Student> studentList;
        private Logger logger;
        private IStudentRepo studRepo;

        public Form1()
        {
            InitializeComponent();
            logger = LogManager.GetCurrentClassLogger();
            studRepo = new StudentRepo();
            load.Enabled = false;
        }

        private void browse_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFile = new OpenFileDialog();
            try
            {
                openFile.Filter = "Text files(*.xml)|*.xml|All files(*.*)|*.*";
                if (openFile.ShowDialog() == DialogResult.Cancel)
                    return;
                pathField.Text = openFile.FileName;
                logger.Info("Open file '" + pathField.Text + "'");
                studentList = XmlParser.parse(openFile.FileName);
                load.Enabled = true;
            }
            catch (XmlException)
            {
                MessageBox.Show("Incorrect file format", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                logger.Error("Incorrect file'" + pathField.Text + "'");
            }
            
        }

        private void load_Click(object sender, EventArgs e)
        {
            try
            {
                studRepo.save(studentList);
                groupNumberBox.DataSource = studRepo.getGroup();
                MessageBox.Show("Successful!", "Success!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                logger.Info("File downloaded");
            }
            catch (SqlException)
            {
                MessageBox.Show("Connection to database failed", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                logger.Fatal("Connection to database failed when user tried to fill db");
            }
        }

        private void getEmails_Click(object sender, EventArgs e)
        {
            try
            {
                emailsBox.DataSource = studRepo.getEmail((string)groupNumberBox.SelectedValue);
            }
            catch (SqlException)
            {
                MessageBox.Show("Connection to database failed", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                logger.Fatal("Connection to database failed when user tried to get group");
            }
        }
    }
}
