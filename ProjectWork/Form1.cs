using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using System.Xml.Linq;
using NLog;
using System.Xml;
using System.Data.SqlClient;
using ProjectWork.RepositoriesImpl;

namespace ProjectWork
{
    public partial class Form1 : Form
    {
        
        private List<Student> StudentList;
        private Logger logger;
        private IStudentRepo studRepo;

        public Form1()
        {
            InitializeComponent();
            logger = LogManager.GetCurrentClassLogger();
            StudentList = new List<Student>();
            studRepo = new StudentRepo();
        }

        private void browse_Click(object sender, EventArgs e)
        {

            OpenFileDialog openFile = new OpenFileDialog();
            try
            {
                openFile.Filter = "Text files(*.xml)|*.xml|All files(*.*)|*.*";
                if (openFile.ShowDialog() == DialogResult.Cancel)
                    return;
                textBox1.Text = openFile.FileName;
                logger.Info("Open file '" + textBox1.Text + "'");
                var doc = XDocument.Parse(File.ReadAllText(textBox1.Text));
                StudentList = doc.Descendants("Student").Select(d => new Student
                {
                    FirstName = d.Element("FirstName").Value,
                    MiddleName = d.Element("MiddleName").Value,
                    LastName = d.Element("LastName").Value,
                    GroupNumber = d.Element("GroupNumber").Value,
                    Email = d.Element("Email").Value
                }).ToList();
            }
            catch (XmlException)
            {
                MessageBox.Show("Incorrect file format", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                logger.Error("Incorrect file'" + textBox1.Text + "'");
            }
        }

        private void load_Click(object sender, EventArgs e)
        {
            try
            {
                studRepo.save(StudentList);
                logger.Info("insert to database '" + StudentList.Count + "' rows");
                comboBox1.DataSource = studRepo.getGroup();
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
                listBox1.DataSource = studRepo.getEmail((string)comboBox1.SelectedValue);
            }
            catch (SqlException)
            {
                MessageBox.Show("Connection to database failed", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                logger.Fatal("Connection to database failed when user tried to get group");
            }
        }
    }
}
