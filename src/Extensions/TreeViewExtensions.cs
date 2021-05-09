﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using static WVN.WinForms.Utils.IOHelper;

namespace WVN.WinForms.Extensions
{
    public static class TreeViewExtensions
    {
        #region Load TreeView from folders
        public static int LoadFolders(this TreeView tvw, string path, string imageKey, string filter = "")
        {
            tvw.Nodes.Clear();
            TreeNode root = tvw.Nodes.Add(path, path, imageKey, imageKey);
            root.Tag = path;
            tvw.LoadFolders(root, path, filter);
            root.Expand();
            return root.Nodes.Count;
        }

        public static void LoadFolders(this TreeView tvw, TreeNode root, string path, string imageKey, string filter = "")
        {
            try
            {
                tvw.BeginUpdate();

                //check if the current node has child nodes (subfolders)
                //if it has, then check for new folders, else add subfolder (if any)

                var folders = new List<string>(Directory.EnumerateDirectories(path));
                if (!string.IsNullOrWhiteSpace(filter))
                {
                    folders = folders.Where(name => name.Contains(filter, true)).ToList();
                }

                if (root.Nodes.Count == 0)
                {
                    foreach (var folder in folders)
                    {
                        string folderName = GetFolderName(folder);
                        TreeNode node = root.Nodes.Add(folder, folderName, imageKey, imageKey);
                        node.Tag = folder;
                        //add dummy
                        node.Nodes.Add("dummy");
                    }
                }
                else
                {
                }
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                tvw.EndUpdate();
            }
        }

        #endregion
    }
}
