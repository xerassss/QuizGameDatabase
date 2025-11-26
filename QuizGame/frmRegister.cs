using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Driver;

namespace QuizGame
{
    public partial class frmRegister : Form
    {
        public static IMongoClient client = new MongoClient("mongodb+srv://Verf:12345@cluster0.rwlfhxl.mongodb.net/?appName=Cluster0");
        public static IMongoDatabase db = client.GetDatabase("QuizGameDB");
        public static IMongoCollection<Signup> coll = db.GetCollection<Signup>("firstquizDB");
        public frmRegister()
        {
            InitializeComponent();
        }

        private void frmRegister_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Signup user = new Signup(txtUser.Text, txtPass.Text);
            coll.InsertOne(user);
            MessageBox.Show("Account Registered Successfully!");
        }
        public class Signup
        {
            public ObjectId Id { get; set; }

            [BsonElement("username")]
            public string Username { get; set; }

            [BsonElement("password")]
            public string Password { get; set; }

            public Signup(string username, string password)
            {
                Username = username;
                Password = password;
            }
        }
    }
}
