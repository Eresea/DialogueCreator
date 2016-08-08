using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Graph;
using System.Drawing.Drawing2D;
using Graph.Compatibility;
using Graph.Items;
using System.Text.RegularExpressions;

namespace DialogueCreator3
{
	public partial class ExampleForm : Form
	{
        string[] Events = { "Close", "AcceptQuest", "AdvanceQuest", "FinishQuestion", "CustomEvent" };
        Node BeginNode;
        bool SaveOnline = false;
		public ExampleForm()
		{
			InitializeComponent();

			graphControl.CompatibilityStrategy = new TagTypeCompatibility();

			BeginNode = new Node("Begin");
            BeginNode.Location = new Point(0, 150);
            BeginNode.AddItem(new NodeTextBoxItem("BeginQuestion", false, false) { Tag = 31337 });
            BeginNode.AddItem(new NodeTextBoxItem("1", false, true) { Tag = 31337 });
            BeginNode.AddItem(new NodeTextBoxItem("2", false, true) { Tag = 31337 });
            BeginNode.AddItem(new NodeTextBoxItem("3", false, true) { Tag = 31337 });
            BeginNode.AddItem(new NodeTextBoxItem("4", false, true) { Tag = 31337 });
            BeginNode.AddItem(new NodeTextBoxItem("5", false, true) { Tag = 31337 });

            graphControl.AddNode(BeginNode);

			graphControl.ConnectionAdded	+= new EventHandler<AcceptNodeConnectionEventArgs>(OnConnectionAdded);
			graphControl.ConnectionAdding	+= new EventHandler<AcceptNodeConnectionEventArgs>(OnConnectionAdding);
			graphControl.ConnectionRemoving += new EventHandler<AcceptNodeConnectionEventArgs>(OnConnectionRemoved);
			graphControl.ShowElementMenu	+= new EventHandler<AcceptElementLocationEventArgs>(OnShowElementMenu);
		}

		void OnImgClicked(object sender, NodeItemEventArgs e)
		{
			MessageBox.Show("IMAGE");
		}

		void OnColClicked(object sender, NodeItemEventArgs e)
		{
			MessageBox.Show("Color");
		}

		void OnConnectionRemoved(object sender, AcceptNodeConnectionEventArgs e)
		{
			//e.Cancel = true;
		}

        private void SearchTextChanged_AddNode(object sender, EventArgs e)
        {
            foreach(ToolStripItem i in nodeMenu.Items)
            {
                i.Visible = i.Text.CaseInsensitiveContains(((ToolStripTextBox)sender).Text);
            }
        }

        private void Validate_AddNode(object sender, EventArgs e)
        {
            if(((KeyEventArgs)e).KeyCode == Keys.Enter)
            {
                foreach (ToolStripItem i in nodeMenu.Items)
                {
                    if (i.Visible == true && i != nodeMenu.Items[0]) { i.PerformClick(); return; }
                }
            }
        }


        void OnShowElementMenu(object sender, AcceptElementLocationEventArgs e)
		{
            nodeMenu.Items.Clear();
            if (e.Element == null)
			{
                List<string> Elements = new List<string>() { "Question", "Event", "If" };
                nodeMenu.Items.Add(new ToolStripTextBox() { BackColor = Color.LightGray });
                ((ToolStripTextBox)nodeMenu.Items[0]).TextChanged += SearchTextChanged_AddNode;
                ((ToolStripTextBox)nodeMenu.Items[0]).KeyDown += Validate_AddNode;
                // Show a test menu for when you click on nothing
                foreach (string s in Elements)
                {
                    nodeMenu.Items.Add(s);
                }
                nodeMenu.MaximumSize = new Size(1000000, 200);
                nodeMenu.Show(e.Position);
                ((ToolStripTextBox)nodeMenu.Items[0]).Focus(); //Focus

                //tb.MaximumSize = new Size(nodeMenu.Size.Width/10, tb.Height);

                e.Cancel = false;
			} else
			if (e.Element is Node)
			{
				// Show a test menu for a node
				nodeMenu.Items.Add(((Node)e.Element).Title);
				nodeMenu.Show(e.Position);
				e.Cancel = false;
			} else
			if (e.Element is NodeItem)
			{
                // Show a test menu for a nodeItem
                nodeMenu.Items.Add(e.Element.GetType().Name);
				nodeMenu.Show(e.Position);
				e.Cancel = false;
			} else
			{
				// if you don't want to show a menu for this item (but perhaps show a menu for something more higher up) 
				// then you can cancel the event
				e.Cancel = true;
			}
		}

		void OnConnectionAdding(object sender, AcceptNodeConnectionEventArgs e)
		{
			//e.Cancel = true;
		}

		static int counter = 1;
		void OnConnectionAdded(object sender, AcceptNodeConnectionEventArgs e)
		{
			//e.Cancel = true;
			e.Connection.Name = "Connection " + counter ++;
			e.Connection.DoubleClick += new EventHandler<NodeConnectionEventArgs>(OnConnectionDoubleClick);
		}

		void OnConnectionDoubleClick(object sender, NodeConnectionEventArgs e)
		{
			e.Connection.Name = "Connection " + counter++;
		}

		private void SomeNode_MouseDown(object sender, MouseEventArgs e)
		{
			var node = new Node("");
            node.AddItem(new NodeTextBoxItem("Question", true, false) { Tag = 31337 });
            node.AddItem(new NodeTextBoxItem("1", false, true) { Tag = 31337 });
            node.AddItem(new NodeTextBoxItem("2", false, true) { Tag = 31337 });
            node.AddItem(new NodeTextBoxItem("3", false, true) { Tag = 31337 });
            node.AddItem(new NodeTextBoxItem("4", false, true) { Tag = 31337 });
            node.AddItem(new NodeTextBoxItem("5", false, true) { Tag = 31337 });
			this.DoDragDrop(node, DragDropEffects.Copy);
		}

		private void TextureNode_MouseDown(object sender, MouseEventArgs e)
		{
            var node = new Node("Event");
            node.AddItem(new NodeDropDownItem(Events, 0, true, true) { Tag = 31337 });
            this.DoDragDrop(node, DragDropEffects.Copy);
        }

		private void ColorNode_MouseDown(object sender, MouseEventArgs e)
		{
            var node = new Node("If");
            node.AddItem(new NodeTextBoxItem("IsValid?", true, false) { Tag = 31337 });
            node.AddItem(new NodeTextBoxItem("True", false, true) { Tag = 31337 });
            node.AddItem(new NodeTextBoxItem("False", false, true) { Tag = 31337 });
            this.DoDragDrop(node, DragDropEffects.Copy);
        }

		private void OnShowLabelsChanged(object sender, EventArgs e)
		{
			graphControl.ShowLabels = showLabelsCheckBox.Checked;
		}

        private void button1_Click(object sender, EventArgs e)
        {
            Clipboard.SetText(Run(BeginNode));
        }

        private string Run(Node n)
        {
            string tmp = "";
            int close = 0;
            bool noConnections = true;
            switch(n.Title)
            {
                case "If":
                    tmp+="If(" + ((NodeTextBoxItem)n.Items.ElementAt(0).Node.Items.ElementAt(0)).Text + "){";
                    close = 1;
                    break;
                case "Event":
                    tmp += "[" + ((NodeDropDownItem)n.Items.ElementAt(0).Node.Items.ElementAt(0)).Items.ElementAt(((NodeDropDownItem)n.Items.ElementAt(0).Node.Items.ElementAt(0)).SelectedIndex) + "]";
                    break;
                default:
                    tmp += "{" + ((NodeTextBoxItem)n.Items.ElementAt(0).Node.Items.ElementAt(0)).Text + ":";
                        close = 1;
                    break;
            }

            foreach (NodeItem ni in n.Items)
            {
                foreach (var nc in ni.Output.Connectors)
                {
                    noConnections = false;
                    if (close == 1) tmp += ((NodeTextBoxItem)nc.From.Item).Text;
                    tmp += Run(nc.To.Node);
                    tmp += ",";
                }
            }

            /*for(int i=0;i<n.Connections.Count();i++)
            {
                var con = n.Connections.ElementAt(i);
                if (con.To.Node != n)
                {
                    noConnections = false;
                    if (close == 1) tmp += ((NodeTextBoxItem)con.From.Item).Text;
                    tmp += Run(con.To.Node);
                    tmp += ","; // N'est pas le dernier
                }
            }*/
            if (tmp.Substring(tmp.Length - 1) == ",") tmp = tmp.Substring(0, tmp.Length - 1);
            if (close == 1)
            {
                if (noConnections) tmp = tmp.Substring(0, tmp.Length - 1); // If it didn't have Elements inside, remove the last char
                tmp += "}";
            }
            return tmp;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Preview Prev = new Preview();
            Prev.Code = Run(BeginNode);
            Prev.Show();
        }

        private void OpenFile(string url)
        {
            graphControl.ClearBoard();
            string line;
            List<KeyValuePair<NodeConnector, KeyValuePair<int, int>>> Connections = new List<KeyValuePair<NodeConnector, KeyValuePair<int, int>>>();
            //CLEAR CURRENT BOARD
            if (System.IO.File.Exists(url))
            {
                System.IO.StreamReader file = new System.IO.StreamReader(url);
                while ((line = file.ReadLine()) != null)
                {
                    processLine(line, ref Connections);
                }
            }
            else
            {
                foreach(string s in url.Split('\n'))
                {
                    processLine(s, ref Connections);
                }
            }

            foreach(KeyValuePair<NodeConnector,KeyValuePair<int,int>> N in Connections)
            {
                graphControl.Connect(N.Key, graphControl.Nodes.ElementAt(N.Value.Key).Items.ElementAt(N.Value.Value).Input);
            }
        }

        private void processLine(string line, ref List<KeyValuePair<NodeConnector,KeyValuePair<int,int>>> Connections)
        {
            string nodeType = line.Substring(0, line.IndexOf(':'));

            PointF nodeLocation = new Point();

            line = line.Substring(line.IndexOf("{X=") + 3);
            nodeLocation.X = float.Parse(line.Substring(0, line.IndexOf(", ")));
            line = line.Substring(line.IndexOf("Y=") + 2);
            nodeLocation.Y = float.Parse(line.Substring(0, line.IndexOf('}')));

            Node NewNode = new Node(nodeType);
            if(nodeType == "Begin") BeginNode = NewNode;
            NewNode.Location = nodeLocation;

            line = line.Substring(line.IndexOf('|'));
            Regex regex = new Regex(@"\((?>[^()]+|\((?<P>)|(?<C-P>)\))*(?(P)(?!))\)", RegexOptions.IgnorePatternWhitespace);

            List<string> nodesInfo = regex.Matches(line).Cast<Match>().Select(p => p.Groups[0].Value).ToList();

            foreach (string s in nodesInfo) // Foreach items in the node
            {
                switch (s.Substring(1, s.IndexOf(':') - 1)) // Add the item
                {
                    case "Label":
                        NewNode.AddItem(new NodeTextBoxItem(s.Substring(s.IndexOf(':') + 1, (s.IndexOf(',') - s.IndexOf(':') - 1)), (s.Substring(s.IndexOf(',') + 1, 1) == "T"), (s.Substring(s.LastIndexOf(',') + 1, 1) == "T")) { Tag = 31337 });
                        break;
                    case "DropDown":
                        NewNode.AddItem(new NodeDropDownItem(Events, Events.ToList().IndexOf(s.Substring(s.IndexOf(':') + 1, (s.IndexOf(',') - s.IndexOf(':') - 1))), (s.Substring(s.IndexOf(',') + 1, 1) == "T"), (s.Substring(s.LastIndexOf(',') + 1, 1) == "T")) { Tag = 31337 });
                        break;
                }
                NodeConnector Nc;
                List<string> test = s.Split(',').ToList();
                if (test[1].Contains(":"))
                {
                    Nc = NewNode.Items.Last().Input;
                    //Connections.Add(new KeyValuePair<NodeConnector, KeyValuePair<int, int>>(Nc, new KeyValuePair<int, int>(Int32.Parse(test[1].Substring(test[1].IndexOf(':')+1,test[1].IndexOf('/')- test[1].IndexOf(':')-1)),Int32.Parse(test[1].Substring(test[1].IndexOf('/') + 1)))));
                }
                if (test[2].Contains(":"))
                {
                    Nc = NewNode.Items.Last().Output;
                    Connections.Add(new KeyValuePair<NodeConnector, KeyValuePair<int, int>>(Nc, new KeyValuePair<int, int>(Int32.Parse(test[2].Substring(test[2].IndexOf(':') + 1, test[2].IndexOf('/') - test[2].IndexOf(':') - 1)), Int32.Parse(test[2].Substring(test[2].IndexOf('/') + 1).Trim(')')))));
                }
            }

            graphControl.AddNode(NewNode);
        }

        private List<string> SaveProcess()
        {
            List<string> Lines = new List<string>();
            string tmp, tmp1;
            foreach (Node n in graphControl.Nodes)
            {
                tmp = tmp1 = "";
                foreach (NodeItem ni in n.Items)
                {
                    if (tmp != "") tmp += ","; // Si ce n'est pas le premier item, virgule
                    NodeTextBoxItem Label = ni as NodeTextBoxItem; // Type 0
                    NodeDropDownItem DropDown = ni as NodeDropDownItem;
                    if (Label != null) // If the item is a label
                    {
                        tmp += "(Label:" + Label.Text + "," + ni.Input.Enabled;
                        if (ni.Input.HasConnection)
                        {
                            tmp += ":" + graphControl.Nodes.ToList().IndexOf(ni.Input.Connectors.ElementAt(0).From.Node).ToString() + "/" + ni.Input.Connectors.ElementAt(0).From.Node.Items.ToList().IndexOf(ni.Input.Connectors.ElementAt(0).From.Item).ToString();
                        }
                        tmp += "," + ni.Output.Enabled;
                        if (ni.Output.HasConnection)
                        {
                            tmp += ":" + graphControl.Nodes.ToList().IndexOf(ni.Output.Connectors.ElementAt(0).To.Node).ToString() + "/" + ni.Output.Connectors.ElementAt(0).To.Node.Items.ToList().IndexOf(ni.Output.Connectors.ElementAt(0).To.Item).ToString();
                        }
                        tmp += ")";
                    }
                    if (DropDown != null)
                    {
                        tmp += "(DropDown:" + DropDown.Items[DropDown.SelectedIndex] + "," + ni.Input.Enabled;
                        if (ni.Input.HasConnection)
                        {
                            tmp += ":" + graphControl.Nodes.ToList().IndexOf(ni.Input.Connectors.ElementAt(0).From.Node).ToString() + "/" + ni.Input.Connectors.ElementAt(0).From.Node.Items.ToList().IndexOf(ni.Input.Connectors.ElementAt(0).From.Item).ToString();
                        }
                        tmp += "," + ni.Output.Enabled;
                        if (ni.Output.HasConnection)
                        {
                            tmp += ":" + graphControl.Nodes.ToList().IndexOf(ni.Output.Connectors.ElementAt(0).To.Node).ToString() + "/" + ni.Output.Connectors.ElementAt(0).To.Node.Items.ToList().IndexOf(ni.Output.Connectors.ElementAt(0).To.Item).ToString();
                        }
                        tmp += ")";
                    }


                    tmp1 = n.Title + ":" + n.Location;
                    foreach (NodeConnection con in n.Connections)
                    {
                        tmp1 += ",";
                        if (con.To != null) tmp1 += con.To.Node.ToString();
                        else tmp1 += con.To.Node.ToString();
                    }
                    tmp1 += "|";
                }
                Lines.Add(tmp1 + tmp);
            }
            return Lines;
        }

        private void toDiskToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            saveFileDialog1.ShowDialog();
            if (saveFileDialog1.FileName != "")
            {
                System.IO.StreamWriter file = new System.IO.StreamWriter(saveFileDialog1.FileName);
                List<string> Lines = SaveProcess();
                foreach(string s in Lines)
                {
                    file.WriteLine(s);
                }
                file.Close();
                SaveOnline = false;
            }
        }

        private void fromDiskToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            saveFileDialog1.ShowDialog();
            if (System.IO.File.Exists(saveFileDialog1.FileName))
            {
                OpenFile(saveFileDialog1.FileName);
                textBox1.Text = saveFileDialog1.FileName.Substring(saveFileDialog1.FileName.LastIndexOf('\\')+1);
                textBox1.Text = textBox1.Text.Remove(textBox1.Text.IndexOf('.'));
                SaveOnline = false;
            }
        }

        private void onlineToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            List<string> Lines = SaveProcess();
            string s = "";
            foreach(string line in Lines)
            {
                s += line + Environment.NewLine;
            }
            string DialogName = textBox1.Text;
            while (DialogName == "")
            {
                textBox1.Text = Prompt.ShowDialog("Dialog Name", "Enter a Dialog Name : ");
                DialogName = textBox1.Text;
            }
            if(OnlineFunction(DialogName, "Insert", s))
            {
                SaveOnline = true;
            }
        }

        private bool OnlineFunction(string DialogName, string Function, string Data)
        {
            string url = "http://saoproject.livehost.fr/SAOProject/Dialogs.php?Function=" + Function + "&Data=" + DialogName + "|" + Data;
            if (Data == "") url = url.Remove(url.Length - 1);
            using (var Client = new System.Net.WebClient())
            {
                var response = Client.DownloadString(url);
                if (response == "Failure") { MessageBox.Show("Failure !"); return false; } // Replace these messagebox by something like a notif later
                if (response == "Success") return true;
                if (response == "Name already taken !")
                {
                    DialogResult dr = MessageBox.Show("This name is already taken !" + Environment.NewLine + "Do you want to overwrite it ?", "Name taken", MessageBoxButtons.YesNo);
                    if (dr == DialogResult.Yes)
                    {
                        return OnlineFunction(DialogName, "Update", Data); // Recall this function but with Update function
                    }
                    return false;
                }
                if(response.Length>3)
                {
                    if (response.Substring(0, 4) == "Get:")
                    {
                        response = response.Substring(4);
                        OpenFile(response);
                    }
                }
                if(response.Length>4)
                {
                    if (response.Substring(0, 5) == "LIST:")
                    {
                        response = response.Substring(5);
                    }
                }
                return true;
            }
        }

        private void onlineToolStripMenuItem3_Click(object sender, EventArgs e)
        {
            OpenOnline f1 = new OpenOnline(this);
            f1.Show();
        }

        public void openFromOnline(string name)
        {
            if(name != "") OnlineFunction(name, "Get", "");
            textBox1.Text = name;
            SaveOnline = true;
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            SaveOnline = false;
            saveFileDialog1.FileName = textBox1.Text;
        }

        private void ExampleForm_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.Control && e.KeyCode == Keys.S)
            {
                if(SaveOnline)
                {
                    onlineToolStripMenuItem2.PerformClick();
                }
                else
                {
                    toDiskToolStripMenuItem1.PerformClick();
                }
            }
        }

        private void nodeMenu_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            switch(e.ClickedItem.Text)
            {
                case "Question":
                    var node = new Node("");
                    node.AddItem(new NodeTextBoxItem("Question", true, false) { Tag = 31337 });
                    node.AddItem(new NodeTextBoxItem("1", false, true) { Tag = 31337 });
                    node.AddItem(new NodeTextBoxItem("2", false, true) { Tag = 31337 });
                    node.AddItem(new NodeTextBoxItem("3", false, true) { Tag = 31337 });
                    node.AddItem(new NodeTextBoxItem("4", false, true) { Tag = 31337 });
                    node.AddItem(new NodeTextBoxItem("5", false, true) { Tag = 31337 });
                    graphControl.AddNode(node);
                    node.Location = graphControl.PointToClient(Cursor.Position);

                    var points = new PointF[] { node.Location };
                    graphControl.inverse_transformation.TransformPoints(points);
                    node.Location = points[0];

                    break;
                case "Event":
                    var node1 = new Node("Event");
                    node1.AddItem(new NodeDropDownItem(Events, 0, true, true) { Tag = 31337 });
                    graphControl.AddNode(node1);
                    node1.Location = graphControl.PointToClient(Cursor.Position);

                    var points1 = new PointF[] { node1.Location };
                    graphControl.inverse_transformation.TransformPoints(points1);
                    node1.Location = points1[0];
                    break;
                case "If":
                    var node2 = new Node("If");
                    node2.AddItem(new NodeTextBoxItem("IsValid?", true, false) { Tag = 31337 });
                    node2.AddItem(new NodeTextBoxItem("True", false, true) { Tag = 31337 });
                    node2.AddItem(new NodeTextBoxItem("False", false, true) { Tag = 31337 });
                    graphControl.AddNode(node2);
                    node2.Location = graphControl.PointToClient(Cursor.Position);

                    var points2 = new PointF[] { node2.Location };
                    graphControl.inverse_transformation.TransformPoints(points2);
                    node2.Location = points2[0];
                    break;
            }
        }
    }
}
