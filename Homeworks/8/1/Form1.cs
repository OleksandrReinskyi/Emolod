using _1.Properties;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


/*
Pseudocode:

class User
- Id
- Static IdIncrement
- Name
- ImageColor (chosen randomly)

class Comment
- Id
- Static IdDecrement
- Text
- User
- Likes
- Dislikes 

class CommentBox
- Comment 
- DrawComment 
-- Set margin, width values
-- Insert code from form 
-- 




class static HelperGenerator
- private list colors 
- private string loremIpsum 
- random Random
- User GenerateUser(name)
- Comment GenerateComment(user)
-- Generate comment
- DrawComments(CommentsList)
-- Bind comment with CommentBox
-- Call draw Function 
-- Return commentBoxList



Main
- CommentsList
- UsersList
- NamesList 
- HelperGenerator call
- 

 */

namespace _1
{
    public partial class Form1 : Form
    {
        private List<Comment> comments = new List<Comment>();
        private List<User> users = new List<User>();
        private List<CommentBox> commentsBox = new List<CommentBox>();
        public Form1()
        {
            InitializeComponent();



            for(int i = 0; i < 5; i++)
            {
                User user = HelperGenerator.GenerateUser();
                users.Add(user);


                Comment comment = HelperGenerator.GenerateComment(user);
                comments.Add(comment);


                CommentBox commentBox;
                if (commentsBox.Count == 0) {
                    commentBox = new CommentBox(comment,30);
                }
                else
                {
                    commentBox = new CommentBox(comment, commentsBox[i-1].YEndLocation);
                }
                commentsBox.Add(commentBox);
                this.Controls.Add(commentBox.VisualBox);



            }
           
        }

        private void RefreshButton_Click(object sender, EventArgs e)
        {
            foreach(CommentBox control in commentsBox)
            {
                control.VisualBox.Refresh();
            }
        }
    }

    class User
    {
        public int id;
        public string name = string.Empty;
        public List<int> imageColor;

        static int idIncrement = 0;
        public User(string name, List<int> imageColor)
        {
            this.name = name;
            this.imageColor = imageColor;
            this.id = idIncrement++;
        }
    }

    class Comment
    {
        public int id;
        public string text = string.Empty;
        public int dislikes = 0;
        public int likes = 0;
        public User user;

        static int idDecrement = 0;

        public Comment(string text, User user)
        {
            this.user = user;
            this.id = idDecrement--;
            this.text = text;

        }

    }

    class CommentBox
    {
        public Comment comment;
        public GroupBox VisualBox = new System.Windows.Forms.GroupBox();
        public GroupBox UserBox = new System.Windows.Forms.GroupBox();
        public GroupBox LikeDislikeBox = new System.Windows.Forms.GroupBox();
        public Label DislikesNumber = new System.Windows.Forms.Label();
        public Label LikesNumber = new System.Windows.Forms.Label();
        public Button LikeButton = new System.Windows.Forms.Button();
        public Button DislikeButton = new System.Windows.Forms.Button();

        bool disliked = false;
        bool liked = false;

        public int YEndLocation;


        public int BoxPadding = 3;
        public int BoxMargin = 40;
        public int TextBottomMargin = 50;
        public int TextWidth = 500;
        public int ImageSize = 25;

        public CommentBox(Comment comment,int previousYEndLocation)
        {
            this.comment = comment;
            this.CreateComment(previousYEndLocation);

        }

        public void CreateComment(int previousYEndLocation)
        {

            Label UserImage = new System.Windows.Forms.Label();
            Label UserName = new System.Windows.Forms.Label();


            Label CommentLabel = new System.Windows.Forms.Label();
            VisualBox.SuspendLayout();
            UserBox.SuspendLayout();
            LikeDislikeBox.SuspendLayout();

            // 
            // CommentLabel
            // 
            CommentLabel.AccessibleRole = System.Windows.Forms.AccessibleRole.None;
            CommentLabel.AutoEllipsis = true;
            CommentLabel.AutoSize = true;
            CommentLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            CommentLabel.Location = new System.Drawing.Point(9, 64);
            CommentLabel.Margin = new System.Windows.Forms.Padding(3, 0, 3, TextBottomMargin);

            CommentLabel.MaximumSize = new System.Drawing.Size(TextWidth, 0);
            CommentLabel.MinimumSize = new System.Drawing.Size(TextWidth, 0);
            CommentLabel.Name = "CommentLabel";
            CommentLabel.TabIndex = 3;
            CommentLabel.Text = this.comment.text;

            Size textSize = TextRenderer.MeasureText(CommentLabel.Text, CommentLabel.Font, new Size(TextWidth, 0), TextFormatFlags.WordBreak);

            CommentLabel.Size = new System.Drawing.Size(TextWidth, textSize.Height);



            // 
            // UserBox
            // 
            UserBox.Controls.Add(UserImage);
            UserBox.Controls.Add(UserName);
            UserBox.Dock = System.Windows.Forms.DockStyle.Top;
            UserBox.Location = new System.Drawing.Point(3, 16);
            UserBox.Name = "UserBox";
            UserBox.Size = new System.Drawing.Size(509, 45);
            UserBox.TabIndex = 9;
            UserBox.TabStop = false;
            UserBox.Text = "User Box";
            // 
            // UserImage
            // 
            UserImage.BackColor = System.Drawing.Color.FromArgb(this.comment.user.imageColor[0], this.comment.user.imageColor[1], this.comment.user.imageColor[2]);
            UserImage.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            UserImage.Location = new System.Drawing.Point(6, 16);
            UserImage.Name = "UserImage";
            UserImage.Size = new System.Drawing.Size(ImageSize, ImageSize);
            UserImage.TabIndex = 1;
            UserImage.Text = $"{this.comment.user.name[0]}";
            UserImage.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // UserName
            // 
            UserName.AutoSize = true;
            UserName.BackColor = System.Drawing.SystemColors.Control;
            UserName.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            UserName.Location = new System.Drawing.Point(36, 16);
            UserName.Name = "UserName";
            UserName.Size = new System.Drawing.Size(58, 24);
            UserName.TabIndex = 4;
            UserName.Text = this.comment.user.name;
            // 
            // LikeDislikeBox
            // 
            LikeDislikeBox.Controls.Add(LikeButton);
            LikeDislikeBox.Controls.Add(DislikesNumber);
            LikeDislikeBox.Controls.Add(LikesNumber);
            LikeDislikeBox.Controls.Add(DislikeButton);
            LikeDislikeBox.Dock = System.Windows.Forms.DockStyle.Bottom;
            LikeDislikeBox.Location = new System.Drawing.Point(3, 167);
            LikeDislikeBox.Name = "LikeDislikeBox";
            LikeDislikeBox.Size = new System.Drawing.Size(509, 60);
            LikeDislikeBox.TabIndex = 8;
            LikeDislikeBox.TabStop = false;
            LikeDislikeBox.Text = "Like/Dislike Box";
            // 
            // LikeButton
            // 
            LikeButton.BackColor = System.Drawing.Color.Gray;
            LikeButton.Cursor = System.Windows.Forms.Cursors.Hand;
            LikeButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            LikeButton.ForeColor = System.Drawing.SystemColors.ControlText;
            LikeButton.Location = new System.Drawing.Point(6, 19);
            LikeButton.Name = "LikeButton";
            LikeButton.Size = new System.Drawing.Size(75, 23);
            LikeButton.TabIndex = 0;
            LikeButton.Text = "Like";
            LikeButton.UseVisualStyleBackColor = false;
            LikeButton.Click += new System.EventHandler(LikeButton_Click);
            // 
            // DislikesNumber
            // 
            DislikesNumber.AutoSize = true;
            DislikesNumber.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            DislikesNumber.Location = new System.Drawing.Point(435, 22);
            DislikesNumber.Name = "DislikesNumber";
            DislikesNumber.Size = new System.Drawing.Size(42, 16);
            DislikesNumber.TabIndex = 7;
            DislikesNumber.Text = Convert.ToString(this.comment.dislikes);
            // 
            // LikesNumber
            // 
            LikesNumber.AutoSize = true;
            LikesNumber.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            LikesNumber.Location = new System.Drawing.Point(86, 22);
            LikesNumber.Name = "LikesNumber";
            LikesNumber.Size = new System.Drawing.Size(49, 16);
            LikesNumber.TabIndex = 5;
            LikesNumber.Text = Convert.ToString(this.comment.likes);
            // 
            // DislikeButton
            // 
            DislikeButton.BackColor = System.Drawing.Color.Gray;
            DislikeButton.Cursor = System.Windows.Forms.Cursors.Hand;
            DislikeButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            DislikeButton.Location = new System.Drawing.Point(354, 19);
            DislikeButton.Name = "DislikeButton";
            DislikeButton.Size = new System.Drawing.Size(75, 23);
            DislikeButton.TabIndex = 2;
            DislikeButton.Text = "Dislike";
            DislikeButton.UseVisualStyleBackColor = false;
            DislikeButton.Click += new System.EventHandler(DislikeButton_Click);

            // 
            // CommentBox
            // 

            int commentBoxHeight = CommentLabel.Height + LikeDislikeBox.Height + UserBox.Height + BoxPadding*2;

            VisualBox.Anchor = System.Windows.Forms.AnchorStyles.Top;
            VisualBox.AutoSize = true;
            VisualBox.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            VisualBox.Controls.Add(UserBox);
            VisualBox.Controls.Add(LikeDislikeBox);
            VisualBox.Controls.Add(CommentLabel);
            VisualBox.Location = new System.Drawing.Point(160, previousYEndLocation + BoxMargin);
            VisualBox.Name = "CommentBox";
            VisualBox.Size = new System.Drawing.Size(515, commentBoxHeight);
            VisualBox.TabIndex = 0;
            VisualBox.TabStop = false;
            VisualBox.Text = "Comment Box";

            this.YEndLocation = VisualBox.Location.Y + commentBoxHeight;
            VisualBox.ResumeLayout(false);
            UserBox.ResumeLayout(false);
            UserBox.PerformLayout();
            LikeDislikeBox.ResumeLayout(false);
            LikeDislikeBox.PerformLayout();
            VisualBox.PerformLayout();
        }



        private void DislikeButton_Click(object sender, EventArgs e) {

            if (!disliked)
            {
                if (liked)
                {
                    LikesNumber.Text = Convert.ToString(--comment.likes);
                    liked = false;
                    LikeButton.BackColor = Color.Gray;
                }
                DislikesNumber.Text = Convert.ToString(++comment.dislikes);
                disliked = true;
                DislikeButton.BackColor = Color.Red;
                LikeDislikeBox.Refresh();
            }
            else
            {
                MessageBox.Show("Error: The comment was already disliked by you!","Error",MessageBoxButtons.OK);
            }

        }
        private void LikeButton_Click(object sender, EventArgs e) {

            if (!liked)
            {
                if (disliked)
                {
                    DislikesNumber.Text = Convert.ToString(--comment.dislikes);
                    disliked = false;
                    DislikeButton.BackColor = Color.Gray;
                }
                LikesNumber.Text = Convert.ToString(++comment.likes);
                liked = true;
                LikeButton.BackColor = Color.Green;
                LikeDislikeBox.Refresh();
            }
            else
            {
                MessageBox.Show("Error: The comment was already liked by you!", "Error", MessageBoxButtons.OK);
            }

        }
    }

    static class HelperGenerator
    {
        static private List<List<int>> Colors = new List<List<int>>()
            {
                new List<int> { 255, 235, 59 },   // #FFEB3B (Bright Yellow)
                new List<int> { 0, 230, 118 },    // #00E676 (Bright Green)
                new List<int> { 255, 87, 34 },    // #FF5722 (Bright Orange)
                new List<int> { 41, 182, 246 },   // #29B6F6 (Sky Blue)
                new List<int> { 255, 215, 0 },    // #FFD700 (Gold)
                new List<int> { 255, 64, 129 },   // #FF4081 (Hot Pink)
                new List<int> { 139, 195, 74 },   // #8BC34A (Lime Green)
                new List<int> { 255, 152, 0 },    // #FF9800 (Bright Amber)
                new List<int> { 64, 196, 255 },   // #40C4FF (Bright Cyan)
                new List<int> { 253, 216, 53 }    // #FDD835 (Sunny Yellow)
            };
        static private string LoremIpsum = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Ut ac efficitur ligula. Donec suscipit mi dui, ac ullamcorper velit euismod at. Curabitur ullamcorper dapibus viverra. Cras eu orci a massa vehicula placerat. Mauris gravida dui id viverra volutpat. Curabitur venenatis interdum turpis, in commodo ex tincidunt vitae. Mauris sit amet rhoncus massa, a rhoncus metus. Sed eu consectetur lacus. Pellentesque vehicula, nibh vitae tristique efficitur, orci urna aliquam dolor, id aliquam orci orci eget ex. Suspendisse potenti. Nam sit amet metus condimentum velit semper sollicitudin. Vivamus euismod volutpat lorem, vitae luctus odio egestas eget. Fusce dignissim varius fringilla. Curabitur magna leo, feugiat ac ullamcorper ullamcorper, maximus quis mauris.\r\n\r\nNunc viverra, metus et sodales malesuada, velit nisl euismod dolor, at aliquam sem ligula at erat. Suspendisse potenti. Nam egestas, metus sed fringilla volutpat, quam turpis fermentum lacus, eget euismod ligula diam ac sapien. Quisque pharetra fringilla ex, sit amet mattis eros posuere sit amet. Aliquam tempus accumsan lorem, at tincidunt augue vehicula a. Suspendisse euismod rutrum ex, vitae porta enim molestie ac. Aliquam ultrices mauris metus, ut euismod elit lacinia vel. Donec elementum nisl vitae dolor placerat sagittis. Morbi id interdum orci. In nec volutpat mauris. ";
        static private Random Rand = new Random();
        static private List<string> Names = new List<string>
            {
                "Oliver Smith",
                "Amelia Johnson",
                "Jack Williams",
                "Isla Brown",
                "Harry Taylor",
                "Ava Davies",
                "George Evans",
                "Sophie Wilson",
                "Charlie Thomas",
                "Emily Roberts"
            }; 
        static public User GenerateUser()
        {
            return new User(Names[Rand.Next(0, Names.Count)], Colors[Rand.Next(0, Colors.Count)]);
        }

        static public Comment GenerateComment(User user)
        {
            return new Comment(LoremIpsum.Substring(0, Rand.Next(0, LoremIpsum.Length)),user);
        }


    }

}
