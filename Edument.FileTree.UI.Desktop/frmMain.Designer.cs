namespace Edument.FileTree.UI.Desktop
{
    partial class frmMain
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabTreeView = new System.Windows.Forms.TabPage();
            this.trViewFile = new System.Windows.Forms.TreeView();
            this.tabListView = new System.Windows.Forms.TabPage();
            this.listViewFile = new System.Windows.Forms.ListView();
            this.btnBack = new System.Windows.Forms.Button();
            this.tabControl1.SuspendLayout();
            this.tabTreeView.SuspendLayout();
            this.tabListView.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabTreeView);
            this.tabControl1.Controls.Add(this.tabListView);
            this.tabControl1.Location = new System.Drawing.Point(12, 12);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(776, 426);
            this.tabControl1.TabIndex = 1;
            // 
            // tabTreeView
            // 
            this.tabTreeView.Controls.Add(this.trViewFile);
            this.tabTreeView.Location = new System.Drawing.Point(4, 24);
            this.tabTreeView.Name = "tabTreeView";
            this.tabTreeView.Padding = new System.Windows.Forms.Padding(3);
            this.tabTreeView.Size = new System.Drawing.Size(768, 398);
            this.tabTreeView.TabIndex = 0;
            this.tabTreeView.Text = "TreeView UI";
            this.tabTreeView.UseVisualStyleBackColor = true;
            // 
            // trViewFile
            // 
            this.trViewFile.Location = new System.Drawing.Point(0, 3);
            this.trViewFile.Name = "trViewFile";
            this.trViewFile.Size = new System.Drawing.Size(765, 392);
            this.trViewFile.TabIndex = 0;
            // 
            // tabListView
            // 
            this.tabListView.Controls.Add(this.listViewFile);
            this.tabListView.Controls.Add(this.btnBack);
            this.tabListView.Location = new System.Drawing.Point(4, 24);
            this.tabListView.Name = "tabListView";
            this.tabListView.Padding = new System.Windows.Forms.Padding(3);
            this.tabListView.Size = new System.Drawing.Size(768, 398);
            this.tabListView.TabIndex = 1;
            this.tabListView.Text = "ListView UI";
            this.tabListView.UseVisualStyleBackColor = true;
            // 
            // listViewFile
            // 
            this.listViewFile.Alignment = System.Windows.Forms.ListViewAlignment.SnapToGrid;
            this.listViewFile.HideSelection = false;
            this.listViewFile.LabelWrap = false;
            this.listViewFile.Location = new System.Drawing.Point(4, 33);
            this.listViewFile.MultiSelect = false;
            this.listViewFile.Name = "listViewFile";
            this.listViewFile.Size = new System.Drawing.Size(761, 362);
            this.listViewFile.TabIndex = 1;
            this.listViewFile.UseCompatibleStateImageBehavior = false;
            this.listViewFile.View = System.Windows.Forms.View.Tile;
            // 
            // btnBack
            // 
            this.btnBack.Location = new System.Drawing.Point(4, 4);
            this.btnBack.Name = "btnBack";
            this.btnBack.Size = new System.Drawing.Size(75, 23);
            this.btnBack.TabIndex = 0;
            this.btnBack.Text = "back";
            this.btnBack.UseVisualStyleBackColor = true;
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.tabControl1);
            this.Name = "frmMain";
            this.Text = "Edument.FileTree";
            this.tabControl1.ResumeLayout(false);
            this.tabTreeView.ResumeLayout(false);
            this.tabListView.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabTreeView;
        private System.Windows.Forms.TabPage tabListView;
        private System.Windows.Forms.Button btnBack;
        private System.Windows.Forms.ListView listViewFile;
        private System.Windows.Forms.TreeView trViewFile;
    }
}

