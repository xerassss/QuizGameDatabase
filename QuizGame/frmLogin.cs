using System;
using System.IO;
using System.Windows.Forms;
using System.Drawing;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Driver;


namespace QuizGame
{
    public partial class frmLogin : Form
    {
        public static IMongoClient client = new MongoClient("mongodb+srv://Verf:12345@cluster0.rwlfhxl.mongodb.net/?appName=Cluster0");
        public static IMongoDatabase db = client.GetDatabase("QuizGameDB");
        public static IMongoCollection<Signup> coll = db.GetCollection<Signup>("firstquizDB");
        private Timer spinTimer;
        private float rotationAngle = 0;
        private Image originalImage;
        public frmLogin()
        {
            InitializeComponent();
            originalImage = Image.FromFile(@"C:\Users\admin\source\bsls\estin.jpg");
            funnyBox.Image = originalImage;
            funnyBox.SizeMode = PictureBoxSizeMode.StretchImage;

            spinTimer = new Timer();
            spinTimer.Interval = 50; // every 50 ms = 20 FPS
            spinTimer.Tick += SpinTimer_Tick;
            spinTimer.Start(); // start spinning automatically--

        }

        private void SpinTimer_Tick(object sender, EventArgs e)
        {
            rotationAngle += 5; 
            if (rotationAngle >= 360)
                rotationAngle = 0;

            funnyBox.Image = RotateImage(originalImage, rotationAngle);
        }
        private Image RotateImage(Image img, float rotationAngle)
        {
            Bitmap bmp = new Bitmap(img.Width, img.Height);
            using (Graphics g = Graphics.FromImage(bmp))
            {
                g.TranslateTransform((float)img.Width / 2, (float)img.Height / 2);
                g.RotateTransform(rotationAngle);
                g.TranslateTransform(-(float)img.Width / 2, -(float)img.Height / 2);
                g.DrawImage(img, new Point(0, 0));
            }
            return bmp;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string username = txtUser.Text;
            string password = txtPass.Text;

            var filter = Builders<Signup>.Filter.And(
            Builders<Signup>.Filter.Eq(u => u.Username, username),
            Builders<Signup>.Filter.Eq(u => u.Password, password)
        );

            var user = coll.Find(filter).FirstOrDefault();

            if (user != null)
            {
                MessageBox.Show("Login Successful!");
                using (diffWindow confirm = new diffWindow())
                {
                    var result = confirm.ShowDialog();
                }
            }
            else
            {
                MessageBox.Show("Invalid username or password.");
            }
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            using (frmRegister confirm = new frmRegister())
            {
                var result = confirm.ShowDialog();
            }
        }

        private void frmLogin_Load(object sender, EventArgs e)
        {

        }

        private void txtPass_TextChanged(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }
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





        //STREAM CODE (DONT TOUCH OR YESTIN WILL PLAY NEKOPARA VOL.69//
        /*+string username = txtUser.Text.Trim();
        string password = txtPass.Text.Trim();
        bool isAuthenticated = false;

        try
        {
            using (StreamReader sr = new StreamReader(@"C:\Users\admin\source\bsls\QuizGame\credentials.txt"))
            {
                string line;
                while ((line = sr.ReadLine()) != null)
                {
                    string[] parts = line.Split(',');
                    if (parts.Length == 2)
                    {
                        string fileUsername = parts[0].Trim();
                        string filePassword = parts[1].Trim();

                        if (username == fileUsername && password == filePassword)
                        {
                            using (diffWindow confirm = new diffWindow())
                            {
                                var result = confirm.ShowDialog();
                            }
                        }

                    }
                }
            }

            if (isAuthenticated)
            {
                MessageBox.Show("Login Successful!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
            else
            {
                MessageBox.Show("Invalid username or password!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        catch (Exception ex)
        {
            MessageBox.Show("Error reading credentials file: " + ex.Message);
        }*/

    }
    }