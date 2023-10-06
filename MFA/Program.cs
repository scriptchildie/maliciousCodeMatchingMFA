using System;
using System.Drawing;
using System.IO;
using System.Reflection;
using System.Reflection.Emit;
using System.Resources;
using System.Windows.Forms;
using static System.Net.Mime.MediaTypeNames;
using Image = System.Drawing.Image;
using Label = System.Windows.Forms.Label;

namespace ConsoleDialog
{
    public class Program
    {
        public static void Main(string[] args)
        {
            if (args.Length != 2)
            {
                Console.WriteLine("Usage: MFA.exe <email> <Number>");
                return;
            }

            string resourceName = "MFA.Resource1";
            ResourceManager rm = new ResourceManager(resourceName, typeof(Program).Assembly);
            Image image = (Image)rm.GetObject("msft");
            Icon icon = (Icon)rm.GetObject("msfticon");

            string font = "Aldhabi";

            // Create a new dialog box.
            Form dialog = new Form();
            dialog.Text = "Sign in to your account";
            dialog.Size =  new Size(400, 400);
            dialog.FormBorderStyle = FormBorderStyle.FixedSingle;
            dialog.BackColor = Color.White;
            dialog.Icon = icon;
            dialog.TopMost = true;



            PictureBox pictureBox = new PictureBox();
            pictureBox.Image = image;
            pictureBox.Size = new Size(216, 46);
            pictureBox.Location = new System.Drawing.Point(20, 10);




            Label email = new Label();
            email.AutoSize = false;
            email.Text = args[0];
            email.Font = new Font(font, 12);
            SizeF textSize = TextRenderer.MeasureText(email.Text, email.Font);
            email.Size = new Size(400, (int)textSize.Height + 10);
            email.Location = new System.Drawing.Point(20, 80);

            Label approve = new Label() ;
            approve.AutoSize = false;
            approve.Text = "Approve sign in";
            approve.Font = new Font(font, 16, FontStyle.Bold);
            textSize = TextRenderer.MeasureText(approve.Text, approve.Font);
            approve.Size = new Size(400, (int)textSize.Height + 10);
            approve.Location = new System.Drawing.Point(20, 110);

            Label tap = new Label();
            tap.AutoSize = false;
            tap.Text = "Tap the number you see below in your\n" +
                       "Microsoft Authenticator app to sign in.";
            tap.Font = new Font(font, 12);
            textSize = TextRenderer.MeasureText(tap.Text, tap.Font);
            tap.Size = new Size(400, (int)textSize.Height + 10);


            tap.Location = new System.Drawing.Point(20, 164);

            Label number = new Label() ;
            number.AutoSize = false;
            number.Text = args[1]; ;
            number.Font = new Font(font, 25);
            textSize = TextRenderer.MeasureText(number.Text, number.Font);
            number.Size = new Size(350, (int)textSize.Height + 10);
            number.Location = new System.Drawing.Point(10, 220);
            number.TextAlign = ContentAlignment.MiddleCenter;

            // Add three paragraphs to the dialog box.
            dialog.Controls.Add(pictureBox);
            dialog.Controls.Add(email);
            dialog.Controls.Add(approve);
            dialog.Controls.Add(tap);
            dialog.Controls.Add(number);

            //dialog.Controls.Add(flowLayoutPanel1);

            //dialog.Controls.Add(new Label("Hello", Font.Size = 14));
            //dialog.Controls.Add(new Label("50", Font.Size = 20));

            // Add a close button to the dialog box.
            //Button closeButton = new Button("Close");
            //closeButton.Click += (sender, e) => dialog.Close();
            //dialog.Controls.Add(closeButton);

            // Display the dialog box.
            dialog.ShowDialog();
        }
    }
}
