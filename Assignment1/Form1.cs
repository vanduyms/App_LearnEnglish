using System.Media;
using System.Text.RegularExpressions;

namespace Assignment1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        public int countQues = 1;
        public string rightAns;
        public string topic;

        private void Form1_Load(object sender, EventArgs e)
        {
            scoreLabel.Visible = false;
            scoreText.Visible = false;
            backBtn.Visible = false;

            pictureAns.Visible = false;
            boxAns.Visible = false;
            submitBtn.Visible = false;

            boxAlertExit.Visible = false;

            wrongAnsBox.Visible = false;
            rightAnsBox.Visible = false;

            animalBtn.Visible = false;
            fruitBtn.Visible = false;
            occupationBtn.Visible = false;
            vehicleBtn.Visible = false;

            animalLabel.Visible = false;
            fruitLabel.Visible = false;
            occupationLabel.Visible = false;
            vehicleLabel.Visible = false;

            label2.Visible = false;
            label3.Visible = false;
            label4.Visible = false;
            label5.Visible = false;

            btnBackWelCome.Visible = false;

            winnerBox.Visible = false;

        }

        public void welcomeScreen()
        {
            playBtn.Visible = true;
            creditBtn.Visible = true;
            exitBtn.Visible = true;

            animalBtn.Visible = false;
            fruitBtn.Visible = false;
            occupationBtn.Visible = false;
            vehicleBtn.Visible = false;

            animalLabel.Visible = false;
            fruitLabel.Visible = false;
            occupationLabel.Visible = false;
            vehicleLabel.Visible = false;

            label2.Visible = false;
            label3.Visible = false;
            label4.Visible = false;
            label5.Visible = false;

            Form1.ActiveForm.BackgroundImage = Properties.Resources.background;
        }

        public void switchScreen()
        {
            animalBtn.Visible = false;
            fruitBtn.Visible = false;
            occupationBtn.Visible = false;
            vehicleBtn.Visible = false;

            animalLabel.Visible = false;
            fruitLabel.Visible = false;
            occupationLabel.Visible = false;
            vehicleLabel.Visible = false;

            scoreLabel.Visible = true;
            scoreText.Text = countScore(countQues).ToString();
            scoreText.Visible = true;
            backBtn.Visible = true;

            pictureAns.Visible = true;
            boxAns.Visible = true;
            submitBtn.Visible = true;

            btnBackWelCome.Visible = false;

            Enabled();

            Form1.ActiveForm.BackgroundImage = Properties.Resources.english_bg;

            displayQues(countQues);
        }

        public void mainScreen()
        {
            btnBackWelCome.Visible = true;
            animalBtn.Visible = true;
            fruitBtn.Visible = true;
            occupationBtn.Visible = true;
            vehicleBtn.Visible = true;

            animalLabel.Visible = true;
            fruitLabel.Visible = true;
            occupationLabel.Visible = true;
            vehicleLabel.Visible = true;

            scoreLabel.Visible = false;
            scoreText.Visible = false;
            backBtn.Visible = false;

            pictureAns.Visible = false;
            boxAns.Visible = false;
            submitBtn.Visible = false;

            Form1.ActiveForm.BackgroundImage = Properties.Resources.background;
        }

        public void unEnabled()
        {
            boxAns.Enabled = false;
            submitBtn.Enabled = false;
            backBtn.Enabled = false;
        }

        public void Enabled()
        {
            boxAns.Enabled = true;
            submitBtn.Enabled = true;
            backBtn.Enabled = true;
        }

        public void showPointBox()
        {
            SoundPlayer sound = new SoundPlayer(@Application.StartupPath + @"\Music\win.wav");
            sound.Play();
            winnerLabel.Text = "Congratulation! You got " + countScore(countQues).ToString() + " points";
            winnerBox.Visible = true;
        }

        int countScore(int x)
        {
            if (x == 1)
                return 0;
            if (x == 2)
                return 10;
            if (x == 3)
                return 20;
            if (x == 4)
                return 30;
            if (x == 5)
                return 40;
            if (x == 6)
                return 50;
            if (x == 7)
                return 60;
            if (x == 8)
                return 70;
            if (x == 9)
                return 80;
            if (x == 10)
                return 90;
            if (x == 11)
                return 100;
            else return 0;
        }

        private void animalBtn_Click(object sender, EventArgs e)
        {
            topic = "animal";
            countQues = 1;

            switchScreen();
        }

        private void fruitBtn_Click(object sender, EventArgs e)
        {
            topic = "fruit";
            countQues = 1;
            switchScreen();
        }

        private void occupationBtn_Click(object sender, EventArgs e)
        {
            topic = "occupation";
            countQues = 1;
            switchScreen();
        }

        private void vehicleBtn_Click(object sender, EventArgs e)
        {
            topic = "vehicle";
            countQues = 1;
            switchScreen();
        }

        private void label1_Click_1(object sender, EventArgs e)
        {

        }

        private void animalLabel_Click(object sender, EventArgs e)
        {

        }

        private void fruitLabel_Click(object sender, EventArgs e)
        {

        }

        private void vehicleLabel_Click(object sender, EventArgs e)
        {

        }

        private void occupationLabel_Click(object sender, EventArgs e)
        {

        }

        private void scoreLabel_Click(object sender, EventArgs e)
        {

        }

        private void backBtn_Click(object sender, EventArgs e)
        {
            boxAlertExit.Visible = true;
            unEnabled();
        }

        private void btnHideWrongBox_Click(object sender, EventArgs e)
        {
            wrongAnsBox.Visible = false;
            backBtn.Visible = true;
            Enabled();
        }

        public int countLine(string pathFile)
        {
            int keywordCount = 0;
            string s = File.ReadAllText(pathFile);
            Regex r = new Regex("\n", RegexOptions.Multiline);
            MatchCollection mc = r.Matches(s);
            keywordCount = mc.Count + 1;
            return keywordCount;
        }

        public question getQuestion(int x)
        {
            boxAns.Text = "";
            string path = @Application.StartupPath + "\\QS\\" + topic + "\\question\\" + x.ToString() + ".txt";
            question qs = new question();
            StreamReader caumot = new StreamReader(path);
            Random rd = new Random();
            int rand = rd.Next(1, (countLine(path) / 2) + 1);
            int dk;
            dk = 1;
            while (dk != rand && !caumot.EndOfStream)
            {
                caumot.ReadLine();
                caumot.ReadLine();
                dk++;
            }
            qs.pathImage = caumot.ReadLine();
            qs.rightAns = caumot.ReadLine();
            return qs;
        }

        private void displayQues(int x)
        {
            if (x == 11)
            {
                showPointBox();

                unEnabled();
            } 
            else
            {
                question qs = new question();
                qs = getQuestion(x);

                Image img = Image.FromFile(qs.pathImage);
                pictureAns.Image = img;
                rightAns = qs.rightAns;
            }   
        }

        public void mesageSubmit()
        {
            string yourAns = boxAns.Text;
            if (yourAns.ToLower() == rightAns)
            {
                countQues += 1;
                scoreText.Text = countScore(countQues).ToString();

                SoundPlayer sound = new SoundPlayer(@Application.StartupPath + @"\Music\correct.wav");
                sound.Play();

                rightAnsBox.Visible = true;
                backBtn.Visible = false;
                unEnabled();
            }
            else
            {
                wrongAnsBox.Visible = true;
                backBtn.Visible = false;

                SoundPlayer sound = new SoundPlayer(@Application.StartupPath + @"\Music\wrong.wav");
                sound.Play();

                unEnabled();
            }  
        }

        private void submitBtn_Click(object sender, EventArgs e)
        {
            mesageSubmit();
        }

        private void btnYesExit_Click(object sender, EventArgs e)
        {
            boxAlertExit.Visible = false;
            showPointBox();
        }

        private void btnNoExit_Click(object sender, EventArgs e)
        {
            boxAlertExit.Visible = false;
            backBtn.Visible = true;
            Enabled();
        }

        private void btnNextQues_Click(object sender, EventArgs e)
        {
            rightAnsBox.Visible = false;
            backBtn.Visible = true;
            displayQues(countQues);
            Enabled();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            rightAnsBox.Visible = false;
            showPointBox();
        }

        private void okBtn_Click(object sender, EventArgs e)
        {
            winnerBox.Visible = false;
            mainScreen();
        }


        private void playBtn_Click(object sender, EventArgs e)
        {
            playBtn.Visible = false;
            creditBtn.Visible = false;
            exitBtn.Visible = false;
            mainScreen();
        }

        private void creditBtn_Click(object sender, EventArgs e)
        {
            playBtn.Visible = false;
            creditBtn.Visible = false;
            exitBtn.Visible = false;

            Form1.ActiveForm.BackgroundImage = Properties.Resources.english_bg;

            label2.Visible = true;
            label3.Visible = true;
            label4.Visible = true;
            label5.Visible = true;

            btnBackWelCome.Visible = true;
        }

        private void exitBtn_Click(object sender, EventArgs e)
        {
            System.Windows.Forms.Application.Exit();
        }

        private void btnBackWelCome_Click(object sender, EventArgs e)
        {
            welcomeScreen();
            btnBackWelCome.Visible = false ;

        }
    }
}