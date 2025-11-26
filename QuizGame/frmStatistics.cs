using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MongoDB.Driver;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

    namespace QuizGame
    {
        public partial class frmStatistics : Form
    {
        
    
        /*public static IMongoClient client = new MongoClient("mongodb+srv://Verf:12345@cluster0.rwlfhxl.mongodb.net/?appName=Cluster0");
        public static IMongoDatabase db = client.GetDatabase("QuizGameDB");
        public static IMongoCollection<Signup> coll = db.GetCollection<Signup>("firstquizDB");*/
        public frmStatistics()
        {
            InitializeComponent();
        }

        public static IMongoClient client = new MongoClient("mongodb+srv://Verf:12345@cluster0.rwlfhxl.mongodb.net/?appName=Cluster0");
        public static IMongoDatabase db = client.GetDatabase("QuizGameDB");
        private IMongoCollection<QuizResult> collection = db.GetCollection<QuizResult>("resultInfo");

        private void FormStatistics_Load(object sender, EventArgs e)
        {
            LoadResults();
        }

        private void LoadResults()
        {
            try
            {
                var results = collection.Find(new BsonDocument()).ToList();
                quizDataGrid.DataSource = results;

                quizDataGrid.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading results:\n" + ex.Message);
            }
        }
        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            quizDataGrid.ScrollBars = ScrollBars.Both;
            quizDataGrid.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            quizDataGrid.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.None;
            quizDataGrid.AllowUserToAddRows = false;
            quizDataGrid.AllowUserToResizeRows = false;
        }
    public class QuizResult
        {
            public ObjectId Id { get; set; }
           
            [BsonElement("playerName")]
            public string playerName { get; set; }
            
            [BsonElement("score")]
            public double score { get; set; }

            [BsonElement("percentage")]

            public double percentage { get; set; }

            [BsonElement("timeTaken")]

            public string timeTaken { get; set; }
        }
    }
    }

