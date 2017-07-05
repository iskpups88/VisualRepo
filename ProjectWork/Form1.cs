using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using System.Xml.Linq;
using NHibernate;
using NHibernate.Criterion;
using NLog;
using System.Xml;
using System.Data.SqlClient;

namespace ProjectWork
{
    public partial class Form1 : Form
    {
        
        private List<Student> StudentList;
        private Logger logger;
        private ISession session;

        public Form1()
        {
            InitializeComponent();
            logger = LogManager.GetCurrentClassLogger();
            StudentList = new List<Student>();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFile = new OpenFileDialog();
            try
            {                
                openFile.Filter = "Text files(*.xml)|*.xml|All files(*.*)|*.*";
                if (openFile.ShowDialog() == DialogResult.Cancel)
                    return;
                textBox1.Text = openFile.FileName;
                logger.Debug("Open file '" + openFile.FileName + "'");
                var doc = XDocument.Parse(File.ReadAllText(openFile.FileName));
                StudentList = doc.Descendants("Student").Select(d => new Student
                {
                    FirstName = d.Element("FirstName").Value,
                    MiddleName = d.Element("MiddleName").Value,
                    LastName = d.Element("LastName").Value,
                    GroupNumber = d.Element("GroupNumber").Value,
                    Email = d.Element("Email").Value
                }).ToList();
            }catch(XmlException)
            {
                MessageBox.Show("Incorrect file format", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                logger.Error("Incorrect file'" + openFile.FileName + "'");
            }
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                session = NHibertnateSession.OpenSession();
                foreach (Student st in StudentList)
                {
                    session.Save(st);
                }

                logger.Debug("insert to database '" + StudentList.Count + "' rows");

                var query = session.QueryOver<Student>()
                     .SelectList(list => list.Select(Projections.Distinct(Projections.Property<Student>(p => p.GroupNumber)))
                     )
                     .List<object>();

                //NHibernate.ICriteria criteria = session.CreateCriteria(typeof(Student));
                //criteria.SetProjection(
                //        Projections.Distinct(Projections.ProjectionList()
                //            .Add(Projections.Alias(Projections.Property("GroupNumber"), "GroupNumber"))
                //               )).SetResultTransformer(
                //        new NHibernate.Transform.AliasToBeanResultTransformer(typeof(Student)));       
                //IList<Student> listgr = criteria.List<Student>();

                comboBox1.DataSource = query;
                session.Close();
            }
            catch (SqlException)
            {
                MessageBox.Show("Connection to database failed", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                logger.Fatal("Connection to database failed when user tried to fill db");
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                session = NHibertnateSession.OpenSession();
                var query = session.QueryOver<Student>()
                     .Where(p => p.GroupNumber == (string)comboBox1.SelectedValue)
                     .SelectList(list => list.Select(Projections.Distinct(Projections.Property<Student>(p => p.Email)))
                     )
                     .List<object>();
                listBox1.DataSource = query;
                session.Close();
            }
            catch (SqlException)
            {
                MessageBox.Show("Connection to database failed", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                logger.Fatal("Connection to database failed when user tried to get group");
            }
        }
    }
}
