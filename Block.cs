using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DialogueCreator3
{
    public partial class Block : Control
    {

        private bool _Hovering = false;
        private bool Hovering
        {
            get { return _Hovering; }
            set
            {
                if (value == _Hovering) return;
                _Hovering = value;
                Invalidate();
            }
        }

        private bool _Pressed = false;
        private bool Pressed
        {
            get { return _Pressed; }
            set
            {
                if (value == _Pressed) return;
                _Pressed = value;
                Invalidate();
            }
        }

        private bool Dragging_Output1 = false;
        private bool Dragging_Output2 = false;

        private bool Dragging_Input = false;

        private Point _startPoint = new Point(0,0);
        private Point startPoint
        {
            get { return _startPoint; }
            set
            {
                if (value == _startPoint) return;
                _startPoint = value;
                Invalidate();
            }
        }

        private Point _endPoint = new Point(0,0);
        private Point endPoint
        {
            get { return _endPoint; }
            set
            {
                if (value == _endPoint) return;
                _endPoint = value;
                Invalidate();
            }
        }

        private int _ID = 0;
        public int ID
        {
            get { return _ID; }
            set
            {
                if (_ID == value) return;
                _ID = value;
                Invalidate();
            }
        }

        private int _SetOutputs = 0; // With % (1 , 2 , 4 , 8 )
        private int SetOutputs
        {
            get { return _SetOutputs; }
            set
            {
                if (value == _SetOutputs) return;
                _SetOutputs = value;
                Invalidate();
            }
        }

        public Block()
        {
            InitializeComponent();
        }

        public new String Text
        {
            get { return base.Text; }
            set
            {
                if (value == base.Text) return;

                base.Text = value;
                Invalidate();
            }
        }

        public enum Shape
        {
            Oval,
            Rectangular
        }

        private Shape _ShapeType = Shape.Rectangular;

        /// <summary>
        /// Modifies the Shape style of the block
        /// </summary>
        [Description("Modifies the Shape style of the block"),
            Category("Appearance"),
            DefaultValue(typeof(Shape), "Rectangular"),
            Browsable(true)]

        public Shape ShapeType
        {
            get { return _ShapeType; }
            set
            {
                if (_ShapeType == value) return;
                _ShapeType = value;
                Invalidate();
            }
        }

        private bool _BlockType = false;
        [Description("Question or Answer"),
            Category("Functionality"),
            DefaultValue(typeof(bool), "false"),
            Browsable(true)]

        public bool BlockType
        {
            get { return _BlockType; }
            set
            {
                if (_BlockType == value) return;
                _BlockType = value;
                Invalidate();
            }
        }

        private bool _Begin = false;
        [Description("Begin Node"),
            Category("Functionality"),
            DefaultValue(typeof(bool), "false"),
            Browsable(true)]

        public bool Begin
        {
            get { return _Begin; }
            set
            {
                if (_Begin == value) return;
                _Begin = value;
                Invalidate();
            }
        }

        private int _nbAnswers = 1;
        [Description("Number of Answer"),
            Category("Functionality"),
            DefaultValue(typeof(int), "1"),
            Browsable(true)]

        public int nbAnswers
        {
            get { return _nbAnswers; }
            set
            {
                if (_nbAnswers == value) return;
                _nbAnswers = value;
                Invalidate();
            }
        }

        private int selectedTemp = -1;
        public int SelectedNode = -1;
        private int _selected = 0; // Add a selected input (maybe just -selected ?)
        public int selected
        {
            get { return _selected; }
            set
            {
                if (_selected == value) return;
                _selected = value;
                Invalidate();
            }
        }

        private bool moveable = false;

        public void Deselect(bool Answer, bool Linked)
        {
            if (Linked)
            {
                if(Answer) selected = -2;
                else selected = -3;
            }
            else selected = 0;
        }

        public event EventHandler SelectedAnswer; //Event of selected Answer
        public event EventHandler SelectedQuestion;
        public event EventHandler Delink;

        private int OverNode(MouseEventArgs e)
        {
            for (int i = 0; i < nbAnswers + 1; i++)
            {
                int X = 0;
                int Y = ClientRectangle.Height / 2 - 5;

                switch (i)
                {
                    case 0:
                        if (e.X > X - 0 && e.X < X + 9 && e.Y > Y - 10 && e.Y < Y + 10) return 0;

                        break;
                    case 1:
                        X = ClientRectangle.Width - 10;
                        Y = ClientRectangle.Height - 55 + ((nbAnswers - (i + (i - 1))) * 10);
                        if (e.X > X - 0 && e.X < X + 9 && e.Y > Y - 10 && e.Y < Y + 10) return 1;

                        break;
                    case 2:
                        Y = ClientRectangle.Height - 55 + ((nbAnswers - (i + (i - 1))) * 10);
                        if (e.X > X - 0 && e.X < X + 9 && e.Y > Y - 10 && e.Y < Y + 10) return 2;

                        break;
                    case 3:
                        Y = ClientRectangle.Height - 55 + ((nbAnswers - (i + (i - 1))) * 10);
                        if (e.X > X - 0 && e.X < X + 9 && e.Y > Y - 10 && e.Y < Y + 10) return 3;

                        break;
                    case 4:
                        Y = ClientRectangle.Height - 55 + ((nbAnswers - (i + (i - 1))) * 10);
                        if (e.X > X - 0 && e.X < X + 9 && e.Y > Y - 10 && e.Y < Y + 10) return 4;

                        break;
                    case 5:
                        Y = ClientRectangle.Height - 55 + ((nbAnswers - (i + (i - 1))) * 10);
                        if (e.X > X - 0 && e.X < X + 9 && e.Y > Y - 10 && e.Y < Y + 10) return 5;

                        break;
                }
            }

            return -1;
        }

        protected override void OnMouseMove(MouseEventArgs e)
        {
            Hovering = true;
            /*Dragging_Output1 = ((e.X > ClientRectangle.Width - 10 && e.X < ClientRectangle.Width+10 && e.Y > ClientRectangle.Height/2-5 && e.Y < ClientRectangle.Height/2+5));
            if(ID != 0) Dragging_Input = (e.X > 0 && e.X < 10 && e.Y > ClientRectangle.Height / 2 - 5 && e.Y < ClientRectangle.Height / 2 + 5);
            if (Dragging_Output1 && Pressed) endPoint = e.Location;
            else endPoint = new Point(0, 0);*/

            int temp = OverNode(e);
            if (selectedTemp > -1)//On hover déjà un node
            {
                if(selectedTemp != temp) //Différent de celui d'avant
                {
                    if (temp < 1) selected -= (int)Math.Pow((double)2, (double)selectedTemp); // Remove the previous selection
                    else // Not same hovered as before
                    {
                        selected -= (int)Math.Pow(2.0, (double)selectedTemp); //Remove previous selection
                    }
                }
            }
            else // Nouveau hover
            {
                switch (temp)
                {
                    case 0: //Over Input
                        if (selected % 2 == 0) selected += 1;
                        break;
                    case 1: //Over Output1
                        if (selected % 4 < 2) selected += 2;
                        break;
                    case 2: //Over Output2
                        if (selected % 8 < 4) selected += 4;
                        break;
                    case 3: //Over Output3
                        if (selected % 16 < 8) selected += 8;
                        break;
                    case 4: //Over Output4
                        if (selected % 32 < 16) selected += 16;
                        break;
                    case 5: //Over Output5
                        if (selected % 64 < 32) selected += 32;
                        break;
                }
            }
            selectedTemp = temp;

            if (moveable) this.Location = new Point(Location.X + e.X-50, Location.Y + e.Y-50);
        }

        protected override void OnMouseLeave(EventArgs e)
        {
            Hovering = false;
            if (!Pressed)
            {
                Dragging_Output1 = false;
                Dragging_Input = false;
            }
        }

        protected override void OnMouseDown(MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left) 
            {
                //Replace followinig by this

                if (selectedTemp > -1) // If a node is hovered
                {
                    selectedTemp = -1;
                    //SelectedNode = -1;
                    bool done = false;
                    for (int i = 0; i < nbAnswers + 1 && !done; i++)
                    {
                        switch (i)
                        {
                            case 0:
                                if (selected % 2 == 1) { SelectedNode = 0; done = true; }
                                break;
                            case 1:
                                if (selected % 4 > 1) { SelectedNode = 1; done = true; }
                                break;
                            case 2:
                                if (selected % 8 > 3) { SelectedNode = 2; done = true; }
                                break;
                            case 3:
                                if (selected % 16 > 7) { SelectedNode = 3; done = true; }
                                break;
                            case 4:
                                if (selected % 32 > 15) { SelectedNode = 4; done = true; }
                                break;
                            case 5:
                                if (selected % 64 > 31) { SelectedNode = 5; done = true; }
                                break;
                        }
                    }
                    if (Control.ModifierKeys == Keys.Alt) this.Delink(this, e);
                    else
                    {
                        this.SelectedAnswer(this, e);
                    }
                }
                else
                {
                    moveable = true;
                    Pressed = true;
                }
                /*if (Dragging_Output1)
                {
                    //if (startPoint == new Point(0, 0)) startPoint = e.Location;
                    selected = 1;
                    if (Control.ModifierKeys == Keys.Alt)
                    {
                        this.Delink(this, e);
                    }
                    else this.SelectedAnswer(this, e);
                }
                else if (Dragging_Input)
                {
                    selected = -1;
                    if (Control.ModifierKeys == Keys.Alt)
                    {
                        this.Delink(this, e);
                    }
                    else this.SelectedQuestion(this, e);
                }
                else moveable = true;*/
            }
        }

        protected override void OnMouseUp(MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left) Pressed = false;
            //startPoint = new Point(0, 0);
            moveable = false;
        }

        public void Delete()
        {
            Controls.Remove(this);
            this.Dispose();
        }

        protected override void OnPaint(PaintEventArgs pe)
        {
            Graphics gfx = pe.Graphics;
            Rectangle rc = ClientRectangle;
            rc.Width -= 1;
            rc.Height -= 1;
            
            //Node output drawing
            

            gfx.FillRectangle(new SolidBrush(Parent.BackColor), ClientRectangle);

            Color fill;
            if (Pressed) fill = Color.Orange;
            else if (Hovering) fill = Color.DarkRed;
            else fill = Color.Black;

            if(ShapeType == Shape.Oval)
            {
                gfx.FillEllipse(new SolidBrush(fill), rc);

                gfx.DrawEllipse(new Pen(Color.Blue, 1.0f), rc);
            }
            else
            {
                gfx.FillRectangle(new SolidBrush(fill), rc);

                gfx.DrawRectangle(new Pen(Color.Blue, 1.0f), rc);
            }

            for(int i=0;i<nbAnswers+1;i++)
            {
                Rectangle nodePoint = ClientRectangle;
                nodePoint.X = 0;
                nodePoint.Y += ClientRectangle.Height / 2 - 5;
                nodePoint.Size = new Size(10, 10);
                switch (i)
                {
                    case 0:
                        if(ID !=0) // Do you have to draw the input ?
                        {
                            if (selected % 2 == 1) // Is the input selected ?
                            {
                                if (selectedTemp == 0) gfx.FillRectangle(new SolidBrush(Color.Green), nodePoint); //Is it selected temporarily ?
                                else gfx.FillRectangle(new SolidBrush(Color.Yellow), nodePoint); // Is it selected yellow ?
                            }
                            else gfx.FillRectangle(new SolidBrush(Color.Red), nodePoint); // Not selected
                        }
                        break;
                    case 1:
                        nodePoint.X = ClientRectangle.Width - 10;
                        nodePoint.Y = ClientRectangle.Height - 55+((nbAnswers - (i + (i - 1))) * 10);
                        if(selected%4 > 1) // Is the input selected ?
                        {
                            if(selectedTemp == 1) gfx.FillRectangle(new SolidBrush(Color.Green), nodePoint); //Is it selected temporarily ?
                            else gfx.FillRectangle(new SolidBrush(Color.Yellow), nodePoint); // Is it selected yellow ?
                        }
                        else gfx.FillRectangle(new SolidBrush(Color.Red), nodePoint); // Not selected
                        break;
                    case 2:
                        nodePoint.Y = ClientRectangle.Height - 55 + ((nbAnswers - (i + (i - 1))) * 10);
                        if (selected % 8 > 3) // Is the input selected ?
                        {
                            if (selectedTemp == 2) gfx.FillRectangle(new SolidBrush(Color.Green), nodePoint); //Is it selected temporarily ?
                            else gfx.FillRectangle(new SolidBrush(Color.Yellow), nodePoint); // Is it selected yellow ?
                        }
                        else gfx.FillRectangle(new SolidBrush(Color.Red), nodePoint); // Not selected
                        break;
                    case 3:
                        nodePoint.Y = ClientRectangle.Height - 55 + ((nbAnswers - (i + (i - 1))) * 10);
                        if (selected % 16 > 7) // Is the input selected ?
                        {
                            if (selectedTemp == 3) gfx.FillRectangle(new SolidBrush(Color.Green), nodePoint); //Is it selected temporarily ?
                            else gfx.FillRectangle(new SolidBrush(Color.Yellow), nodePoint); // Is it selected yellow ?
                        }
                        else gfx.FillRectangle(new SolidBrush(Color.Red), nodePoint); // Not selected
                        break;
                    case 4:
                        nodePoint.Y = ClientRectangle.Height - 55 + ((nbAnswers - (i + (i - 1))) * 10);
                        if (selected % 32 > 15) // Is the input selected ?
                        {
                            if (selectedTemp == 4) gfx.FillRectangle(new SolidBrush(Color.Green), nodePoint); //Is it selected temporarily ?
                            else gfx.FillRectangle(new SolidBrush(Color.Yellow), nodePoint); // Is it selected yellow ?
                        }
                        else gfx.FillRectangle(new SolidBrush(Color.Red), nodePoint); // Not selected
                        break;
                    case 5:
                        nodePoint.Y = ClientRectangle.Height - 55 + ((nbAnswers - (i + (i - 1))) * 10);
                        if (selected % 64 > 31) // Is the input selected ?
                        {
                            if (selectedTemp == 5) gfx.FillRectangle(new SolidBrush(Color.Green), nodePoint); //Is it selected temporarily ?
                            else gfx.FillRectangle(new SolidBrush(Color.Yellow), nodePoint); // Is it selected yellow ?
                        }
                        else gfx.FillRectangle(new SolidBrush(Color.Red), nodePoint); // Not selected
                        break;
                }
            }

            /*if (nbAnswers > 0)
            {
                if (selected == 1) gfx.FillRectangle(new SolidBrush(Color.Green), nodePoint);
                else if(selected == -2) gfx.FillRectangle(new SolidBrush(Color.Yellow), nodePoint);
                else if (Dragging_Output1) gfx.FillRectangle(new SolidBrush(Color.Blue), nodePoint);
                else gfx.FillRectangle(new SolidBrush(Color.Red), nodePoint);

                nodePoint.X = 0;

                if (ID != 0)
                {
                    if (selected == -1) gfx.FillRectangle(new SolidBrush(Color.Green), nodePoint);
                    else if (selected == -3) gfx.FillRectangle(new SolidBrush(Color.Yellow), nodePoint);
                    else if (Dragging_Input) gfx.FillRectangle(new SolidBrush(Color.Blue), nodePoint);
                    else gfx.FillRectangle(new SolidBrush(Color.Red), nodePoint);
                }
            }*/

            //gfx.DrawEllipse(new Pen(Color.White, 1.0f), nodePoint);

            Font fnt = new Font("Verdana", (float)rc.Height * 0.125f, FontStyle.Bold, GraphicsUnit.Pixel);

            StringFormat sf = new StringFormat();

            sf.Alignment = StringAlignment.Center;
            sf.LineAlignment = StringAlignment.Center;
            gfx.DrawString(Text, fnt, new SolidBrush(Color.White), new RectangleF((float)rc.Left, (float)rc.Top, (float)rc.Width, (float)rc.Height), sf);

            gfx.DrawLine(new Pen(Color.Black), startPoint, endPoint);

        }

        protected override void OnPaintBackground(PaintEventArgs pevent)
        {
            
        }
    }
}
