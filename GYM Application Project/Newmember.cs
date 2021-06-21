using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Windows.Forms;
using System.Data.Sql;
using System.Data.SqlClient;

namespace GYM_Application_Project
{
    public partial class Newmember : Form
       
    {
        SqlCommand cmd;
        SqlConnection con;
        SqlDataAdapter da;

        public Newmember()
        {
            InitializeComponent();
        }

        private void HomeButton_Click(object sender, EventArgs e)
        {
            Form1 home = new Form1();
            home.Show();
            this.Hide();
        }

        private void NewmemberButton_Click(object sender, EventArgs e)
        {
            this.Show();
        }

        private void ProfileButton_Click(object sender, EventArgs e)
        {
            Profile profile = new Profile();
            profile.Show();
            this.Hide();
        }

        private void TrainersButton_Click(object sender, EventArgs e)
        {
            Trainer trainer = new Trainer();
            trainer.Show();
            this.Hide();
        }

        private void PaymentButton_Click(object sender, EventArgs e)
        {
            Payments payments = new Payments();
            payments.Show();
            this.Hide();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click_1(object sender, EventArgs e)
        {

        }

   
        private void NewmemberPanel_Paint(object sender, PaintEventArgs e)
        {
            timer1.Start();
            label10.Text = DateTime.Now.ToLongTimeString();
            label11.Text = DateTime.Now.ToLongDateString();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            label10.Text = DateTime.Now.ToLongTimeString();
            timer1.Start();
        }

        private void panel3_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            //ComboBox Section --------
            
        }

        private void richTextBox9_TextChanged(object sender, EventArgs e)
        {

        }
        private void btn_next_Click(object sender, EventArgs e)
        {
            //connecting to the database 
            con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\gym_addMemberDB.mdf;Integrated Security=True");
            con.Open();
            // submit button section 
            //gym data_set = new gym();

            //data_set.last_name = richTextBox2.Text;
            //data_set.address = richTextBox3.Text;
            //data_set.email = richTextBox4.Text;
            //data_set.age = richTextBox9.Text;
            //data_set.weight = richTextBox8.Text;
            //data_set.height = richTextBox7.Text;
            string first_name = richTextBox1.Text;
            string last_name = richTextBox2.Text;
            string address = richTextBox3.Text;
            string email = richTextBox4.Text;
            int age = Convert.ToInt32(richTextBox9.Text);
            int weight = Convert.ToInt32(richTextBox8.Text);
            int height = Convert.ToInt32(richTextBox7.Text);
            string combo1_activelvl = comboBox1.Text;
            string combo2_gender = comboBox2.Text;
            string combo3_target = comboBox3.Text;
            if (!string.IsNullOrEmpty(first_name) && !string.IsNullOrEmpty(last_name) && !string.IsNullOrEmpty(address) && !string.IsNullOrEmpty(address) && !string.IsNullOrEmpty(email))
            {
                if (combo2_gender == "Male")
                {
                    //MessageBox.Show("you are a male");
                    double bmr = Convert.ToDouble((weight* 6.23) + (height * 12.7) - (age * 6.8) + 66);
                    //MessageBox.Show(bmr.ToString());
                    double daily_calories;

                    // Activity level choosen Section
                    
                            if (combo1_activelvl == "sedentary ")
                            {
                               daily_calories = bmr * 1.2;
                            }
                            else if (combo1_activelvl == "Light")
                            {
                                daily_calories = bmr * 1.375; 
                            }
                            else if (combo1_activelvl == "Moderate ")
                            {
                                daily_calories = bmr * 1.55;
                            }
                            else if (combo1_activelvl == "Active")
                            {
                                daily_calories = bmr * 1.725;
                            }
                            else {
                                MessageBox.Show("Select your Activity Level");
                            }

                    // End of the activity level  
                    //Target Section 
                       string target_details;
                    if (combo3_target == "Fat Lost")
                    {
                        target_details = "take(250-500)Cal more than the daily calorie limit";
                    }
                    else if (combo3_target == "Gain weight")
                    {
                        target_details = "Take (250 -500)Cal More than the daily calorie limit ";
                    }
                    else {
                        MessageBox.Show("please choose your target");
                    }


                    // insert first_name . last_name , address & email data into the database 
                    cmd = new SqlCommand("INSERT INTO Table (first_name ,last_name , address , email,age,weight , height , A_level , gender,target,bmr) VALUES (@first_name,@last_name,@address,@email,@age,@weight,@height,@A_level,@gender,@target,@bmr)", con);
                    cmd.Parameters.AddWithValue("@first_name", first_name);
                    cmd.Parameters.AddWithValue("@last_name", last_name);
                    cmd.Parameters.AddWithValue("@address", address);
                    cmd.Parameters.AddWithValue("@email", email);
                    cmd.Parameters.AddWithValue("@age", age);
                    cmd.Parameters.AddWithValue("@weight", weight);
                    cmd.Parameters.AddWithValue("@height", height);
                    cmd.Parameters.AddWithValue("@A_level", combo1_activelvl);
                    cmd.Parameters.AddWithValue("@gender", combo2_gender);
                    cmd.Parameters.AddWithValue("@target", combo3_target);
                    cmd.Parameters.AddWithValue("@bmr", bmr.ToString());
                    cmd.ExecuteNonQuery();



                }
                else if (combo2_gender == "Female")
                {
                    //MessageBox.Show("You are a Female");
                    double bmr = Convert.ToDouble((weight * 4.23) + (height * 4.7) - (age * 4.7) + 65);
                    //MessageBox.Show(bmr.ToString());
                    double daily_calories;

                            if (combo1_activelvl == "sedentary ")
                            {
                                daily_calories = bmr * 1.2;
                            }
                            else if (combo1_activelvl == "Light")
                            {
                                daily_calories = bmr * 1.375;
                            }
                            else if (combo1_activelvl == "Moderate ")
                            {
                                daily_calories = bmr * 1.55;
                            }
                            else if (combo1_activelvl == "Active")
                            {
                                daily_calories = bmr * 1.725;
                            }
                            else
                            {
                                MessageBox.Show("Select your Activity Level");
                            }

                    //Target Section 
                    string target_details;
                    if (combo3_target == "Fat Lost")
                    {
                        target_details = "take(250-500)Cal more than the daily calorie limit";
                    }
                    else if (combo3_target == "Gain weight")
                    {
                        target_details = "Take (250 -500)Cal More than the daily calorie limit ";
                    }
                    else
                    {
                        MessageBox.Show("please choose your target");
                    }


                }
                else {
                    MessageBox.Show("Please Select Your gender");
                }

            }
            else {
                MessageBox.Show("Please Fill the all Blanks", "ERROR");
            }
             
            

            
        }


        class gym {
            // declare a gym class
           
            public string first_name {
                get;
                set;
            }
            public string last_name {
                get;
                set;

            }
            public string address {
                get;
                set;
            }
            public string email {
                get;
                set;
            }
            public string age {
                get;
                set;
            }
            public string weight {
                get;
                set;
            }
            public string height {
                get;
                set;
            }
        }

        
    }
}
