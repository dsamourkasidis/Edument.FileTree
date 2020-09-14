using Edument.FileTree.Core;
using Edument.FileTree.Core.Entity;
using Edument.FileTree.Core.Service;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.ListViewItem;

namespace Edument.FileTree.UI.Desktop
{
    public partial class frmMain : Form
    {
        private const string FILEPATHS = "filepaths";
        private string[] filepaths;
        private FileTreeService fileTreeService;
        private Core.Entity.FileTree tree;
        public frmMain()
        {
            InitializeComponent();
            LoadSettings();
            InitTreeService();
            InitTabTreeView();
            InitTabListView();
        }


        private void LoadSettings()
        {
            IConfiguration config = new ConfigurationBuilder()
                .AddJsonFile("appsettings.json", true, true)
                .Build();
            IConfigurationSection myArraySection = config.GetSection(FILEPATHS);
            filepaths = myArraySection.GetChildren().ToArray().Select(c => c.Value).ToArray();
        }
        private void InitTreeService()
        {
            fileTreeService = new FileTreeService(filepaths);
            tree = fileTreeService.GetFileTree();
        }

        /// <summary>
        /// The Tree View UI tab. Uses a windows forms TreeView control to visualise our FileTree.
        /// Contains a context menu to add/edit/delete.
        /// </summary>
        #region TreeView Tab
        private void InitTabTreeView()
        {
            LoadTreeView();
            LoadContextMenu();
            trViewFile.Dock = DockStyle.Fill;
        }
        private void LoadTreeView()
        {
            var treeView = tree.Root.ToTreeNode();
            trViewFile.Nodes.Add(treeView);
            trViewFile.LabelEdit = true;
        }
        private void LoadContextMenu()
        {
            ToolStripMenuItem addNode = new ToolStripMenuItem("Add");
            addNode.Click += AddNode_Click;
            ToolStripMenuItem editNode = new ToolStripMenuItem("Edit");
            editNode.Click += EditNode_Click;
            ToolStripMenuItem deleteNode = new ToolStripMenuItem("Delete");
            deleteNode.Click += DeleteNode_Click;

            trViewFile.ContextMenuStrip = new ContextMenuStrip();
            trViewFile.ContextMenuStrip.Items.Add(addNode);
            trViewFile.ContextMenuStrip.Items.Add(editNode);
            trViewFile.ContextMenuStrip.Items.Add(deleteNode);

            trViewFile.NodeMouseClick += (sender, args) => trViewFile.SelectedNode = args.Node;
        }

        private void AddNode_Click(object sender, EventArgs e)
        {
            var newNode = new TreeNode();
            newNode.Text = "";
            trViewFile.SelectedNode.Nodes.Add(newNode);
            trViewFile.SelectedNode = trViewFile.SelectedNode.Nodes[trViewFile.SelectedNode.Nodes.Count - 1];
            trViewFile.SelectedNode.BeginEdit();
        }
        private void EditNode_Click(object sender, EventArgs e)
        {
            trViewFile.SelectedNode.BeginEdit();
        }

        private void DeleteNode_Click(object sender, EventArgs e)
        {
            trViewFile.SelectedNode.Remove();
        }
        #endregion

        /// <summary>
        /// The List View UI tab. Uses a windows forms ListView control to visualise our FileTree.
        /// Contains a back button for navigation. Could also use a similar context menu as in the treeview
        /// </summary>
        #region ListView Tab
        private void InitTabListView()
        {
            LoadListView();
            btnBack.Click += BtnBack_Click;
            btnBack.Enabled = false;
        }
        private void LoadListView()
        {
            listViewFile.Activation = ItemActivation.Standard;
            listViewFile.ItemActivate += ListViewFile_ItemActivate;
            var listViewItem = new ListViewItem(tree.Root.Value);
            listViewItem.Tag = tree.Root;
            listViewFile.Items.Add(listViewItem);
        }
        private void ListViewFile_ItemActivate(object sender, EventArgs e)
        {
            if (listViewFile.SelectedItems.Count == 0) return;
            var selectedNode = (FileTreeNode)listViewFile.SelectedItems[0].Tag;
            if (selectedNode.Children.Count > 0)
            {
                UpdateListView(selectedNode);
            }
        }
        private void BtnBack_Click(object sender, EventArgs e)
        {
            var currentNode = ((FileTreeNode)listViewFile.Items[0].Tag).Parent;
            UpdateListView((FileTreeNode)(currentNode.Parent));
        }
        private void UpdateBtnBackStatus(FileTreeNode currentNode)
        {
            btnBack.Enabled = currentNode != tree.Root;
        }
        private void UpdateListView(FileTreeNode currentNode)
        {
            listViewFile.Items.Clear();
            foreach (var child in currentNode.Children)
            {
                var listViewItem = new ListViewItem(child.Value);
                listViewItem.Tag = child;
                listViewFile.Items.Add(listViewItem);
            }
            UpdateBtnBackStatus(currentNode);
        }
        #endregion
    }
}
