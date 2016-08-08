﻿namespace DialogueCreator3
{
    partial class ExampleForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            Graph.Compatibility.AlwaysCompatible alwaysCompatible1 = new Graph.Compatibility.AlwaysCompatible();
            this.label1 = new System.Windows.Forms.Label();
            this.showLabelsCheckBox = new System.Windows.Forms.CheckBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.nodeMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.testMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.toDiskToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.onlineToolStripMenuItem2 = new System.Windows.Forms.ToolStripMenuItem();
            this.openToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.fromDiskToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.onlineToolStripMenuItem3 = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.graphControl = new Graph.GraphControl();
            this.nodeMenu.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 50);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(49, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Question";
            this.label1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.SomeNode_MouseDown);
            // 
            // showLabelsCheckBox
            // 
            this.showLabelsCheckBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.showLabelsCheckBox.AutoSize = true;
            this.showLabelsCheckBox.Location = new System.Drawing.Point(12, 547);
            this.showLabelsCheckBox.Name = "showLabelsCheckBox";
            this.showLabelsCheckBox.Size = new System.Drawing.Size(87, 17);
            this.showLabelsCheckBox.TabIndex = 2;
            this.showLabelsCheckBox.Text = "Show Labels";
            this.showLabelsCheckBox.UseVisualStyleBackColor = true;
            this.showLabelsCheckBox.CheckedChanged += new System.EventHandler(this.OnShowLabelsChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(9, 27);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(84, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "drag&drop nodes:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 73);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(35, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "Event";
            this.label3.MouseDown += new System.Windows.Forms.MouseEventHandler(this.TextureNode_MouseDown);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 96);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(13, 13);
            this.label4.TabIndex = 5;
            this.label4.Text = "If";
            this.label4.MouseDown += new System.Windows.Forms.MouseEventHandler(this.ColorNode_MouseDown);
            // 
            // nodeMenu
            // 
            this.nodeMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.testMenuItem});
            this.nodeMenu.Name = "NodeMenu";
            this.nodeMenu.Size = new System.Drawing.Size(96, 26);
            this.nodeMenu.ItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.nodeMenu_ItemClicked);
            // 
            // testMenuItem
            // 
            this.testMenuItem.Name = "testMenuItem";
            this.testMenuItem.Size = new System.Drawing.Size(95, 22);
            this.testMenuItem.Text = "Test";
            // 
            // button1
            // 
            this.button1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.button1.Location = new System.Drawing.Point(7, 503);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(92, 31);
            this.button1.TabIndex = 6;
            this.button1.Text = "Run";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.button2.Location = new System.Drawing.Point(7, 466);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(92, 31);
            this.button2.TabIndex = 7;
            this.button2.Text = "Preview";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // saveFileDialog1
            // 
            this.saveFileDialog1.Filter = "Text Files|*.txt";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.saveToolStripMenuItem1,
            this.openToolStripMenuItem1});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // saveToolStripMenuItem1
            // 
            this.saveToolStripMenuItem1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toDiskToolStripMenuItem1,
            this.onlineToolStripMenuItem2});
            this.saveToolStripMenuItem1.Name = "saveToolStripMenuItem1";
            this.saveToolStripMenuItem1.Size = new System.Drawing.Size(103, 22);
            this.saveToolStripMenuItem1.Text = "Save";
            // 
            // toDiskToolStripMenuItem1
            // 
            this.toDiskToolStripMenuItem1.Name = "toDiskToolStripMenuItem1";
            this.toDiskToolStripMenuItem1.Size = new System.Drawing.Size(111, 22);
            this.toDiskToolStripMenuItem1.Text = "To disk";
            this.toDiskToolStripMenuItem1.Click += new System.EventHandler(this.toDiskToolStripMenuItem1_Click);
            // 
            // onlineToolStripMenuItem2
            // 
            this.onlineToolStripMenuItem2.Name = "onlineToolStripMenuItem2";
            this.onlineToolStripMenuItem2.Size = new System.Drawing.Size(111, 22);
            this.onlineToolStripMenuItem2.Text = "Online";
            this.onlineToolStripMenuItem2.Click += new System.EventHandler(this.onlineToolStripMenuItem2_Click);
            // 
            // openToolStripMenuItem1
            // 
            this.openToolStripMenuItem1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fromDiskToolStripMenuItem1,
            this.onlineToolStripMenuItem3});
            this.openToolStripMenuItem1.Name = "openToolStripMenuItem1";
            this.openToolStripMenuItem1.Size = new System.Drawing.Size(103, 22);
            this.openToolStripMenuItem1.Text = "Open";
            // 
            // fromDiskToolStripMenuItem1
            // 
            this.fromDiskToolStripMenuItem1.Name = "fromDiskToolStripMenuItem1";
            this.fromDiskToolStripMenuItem1.Size = new System.Drawing.Size(126, 22);
            this.fromDiskToolStripMenuItem1.Text = "From disk";
            this.fromDiskToolStripMenuItem1.Click += new System.EventHandler(this.fromDiskToolStripMenuItem1_Click);
            // 
            // onlineToolStripMenuItem3
            // 
            this.onlineToolStripMenuItem3.Name = "onlineToolStripMenuItem3";
            this.onlineToolStripMenuItem3.Size = new System.Drawing.Size(126, 22);
            this.onlineToolStripMenuItem3.Text = "Online";
            this.onlineToolStripMenuItem3.Click += new System.EventHandler(this.onlineToolStripMenuItem3_Click);
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1115, 24);
            this.menuStrip1.TabIndex = 8;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // textBox1
            // 
            this.textBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox1.Location = new System.Drawing.Point(202, 9);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(129, 31);
            this.textBox1.TabIndex = 9;
            this.textBox1.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(103, 12);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(93, 25);
            this.label5.TabIndex = 10;
            this.label5.Text = "Name : ";
            // 
            // graphControl
            // 
            this.graphControl.AllowDrop = true;
            this.graphControl.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.graphControl.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(16)))), ((int)(((byte)(16)))), ((int)(((byte)(16)))));
            this.graphControl.CompatibilityStrategy = alwaysCompatible1;
            this.graphControl.FocusElement = null;
            this.graphControl.HighlightCompatible = true;
            this.graphControl.LargeGridStep = 128F;
            this.graphControl.LargeStepGridColor = System.Drawing.Color.FromArgb(((int)(((byte)(8)))), ((int)(((byte)(8)))), ((int)(((byte)(8)))));
            this.graphControl.Location = new System.Drawing.Point(108, 46);
            this.graphControl.Name = "graphControl";
            this.graphControl.ShowLabels = false;
            this.graphControl.Size = new System.Drawing.Size(995, 518);
            this.graphControl.SmallGridStep = 16F;
            this.graphControl.SmallStepGridColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(24)))), ((int)(((byte)(24)))));
            this.graphControl.TabIndex = 0;
            this.graphControl.Text = "graphControl";
            // 
            // ExampleForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1115, 576);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.menuStrip1);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.showLabelsCheckBox);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.graphControl);
            this.DoubleBuffered = true;
            this.KeyPreview = true;
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "ExampleForm";
            this.Text = "Form1";
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.ExampleForm_KeyDown);
            this.nodeMenu.ResumeLayout(false);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Graph.GraphControl graphControl;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.CheckBox showLabelsCheckBox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ContextMenuStrip nodeMenu;
        private System.Windows.Forms.ToolStripMenuItem testMenuItem;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem toDiskToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem onlineToolStripMenuItem2;
        private System.Windows.Forms.ToolStripMenuItem openToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem fromDiskToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem onlineToolStripMenuItem3;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label label5;
    }
}
