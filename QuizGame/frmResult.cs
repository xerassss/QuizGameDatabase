using System;
using System.Windows.Forms;
using static QuizGame.UserResult;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Rebar;
using MongoDB.Driver;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System.Collections.ObjectModel;


namespace QuizGame
{

    public partial class frmResult : Form
    {
        private IMongoCollection<QuizResult> collection;

        private MongoClient client = new MongoClient("mongodb+srv://Verf:12345@cluster0.rwlfhxl.mongodb.net/?appName=Cluster0");
        private IMongoDatabase database;


        private DelegateNumbers DelScore;
        private DelegateNumber DelPercentage;
        private DelegateText DelName, DelTime;

        public frmResult()          
        {
            InitializeComponent();
            DelName = new DelegateText(UserResult.getName);
            DelScore = new DelegateNumbers(UserResult.getScore);
            DelPercentage = new DelegateNumber(UserResult.getPercentage);
            DelTime = new DelegateText(UserResult.getTime);

            database = client.GetDatabase("QuizGameDB");
            collection = database.GetCollection<QuizResult>("resultInfo");

        }

        private void frmResult_Load(object sender, EventArgs e)
        {
            lblName.Text = DelName(UserResult.Name).ToString();   
            lblScore.Text = DelScore(UserResult.Score).ToString();
            lblPercentage.Text = DelPercentage(UserResult.Percentage).ToString() + "%";
            lblTotalTime.Text = DelTime(UserResult.Time).ToString();

        }


        private void btnFinish_Click(object sender, EventArgs e)
        {
            QuizResult result = new QuizResult
            {
                PlayerName = UserResult.Name,
                Score = UserResult.Score,
                Percentage = UserResult.Percentage,
                TimeTaken = UserResult.Time
            };

            collection.InsertOne(result); // Save to MongoDB

            Application.Exit();
        }

        private void btnRetry_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
    public class UserResult
    {
        public delegate long DelegateNumber(long number);
        public delegate double DelegateNumbers(double number);
        public delegate string DelegateText(string text);

        public static double Score = 0;
        public static long Percentage = 0;
        public static string Time = "0";
        public static string Name = "";

        public static double getScore(double Score) { return Score; }
        public static string getTime(string Time) { return Time; }
        public static long getPercentage(long Percentage) { return Percentage; }
        public static string getName(string Name) { return Name; }
    }

    public class QuizResult
    {
        [BsonId]
        public ObjectId Id { get; set; }

        [BsonElement("playerName")]
        public string PlayerName { get; set; }

        [BsonElement("score")]
        public double Score { get; set; }

        [BsonElement("percentage")]
        public long Percentage { get; set; }

        [BsonElement("timeTaken")]
        public string TimeTaken { get; set; }
    }   

}
