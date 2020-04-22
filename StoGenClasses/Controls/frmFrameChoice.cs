﻿using DevExpress.XtraGrid.Columns;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace StoGen.Classes
{
    public partial class frmFrameChoice : Form
    {
        public frmFrameChoice()
        {
            InitializeComponent();
        }
        MenuDescriptopnItem[] Columns;
        public static DialogResult ShowOptionsmenu(List<ChoiceMenuItem> itemlist)
        {
            DialogResult result = DialogResult.Cancel;
            using (frmFrameChoice frm = new frmFrameChoice())
            {
                if (itemlist.Count>0)
                {
                    frm.Columns = itemlist[0].Props;
                    if (frm.Columns != null)
                    {
                        int i = 0;
                        foreach (MenuDescriptopnItem prop in frm.Columns)
                        {
                            i++;
                            GridColumn col = new GridColumn();
                            col.FieldName = prop.Caption;
                            col.Caption = prop.Caption;
                            col.UnboundType = DevExpress.Data.UnboundColumnType.String;
                            col.Name = "gc" + col.Caption;
                            col.VisibleIndex = i;
                            frm.gridView1.Columns.Add(col);
                            if (prop.isGroupColumn)
                            {
                                col.Group();
                            }
                        }
                    }
                }

                frm.BS.DataSource = itemlist;
                frm.gridView1.BestFitColumns(true);
                
                //frm.gridView1.ExpandAllGroups();
                result = frm.ShowDialog();
                if (result == DialogResult.OK)
                {
                    frm.Process();
                }
            }
            return result;
        }

        private void frmFrameChoice_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData ==Keys.Back)            
            {
                this.DialogResult = System.Windows.Forms.DialogResult.Cancel;
                this.Close();
            }
            else if (e.KeyData == Keys.Enter) 
            {
                this.DialogResult = System.Windows.Forms.DialogResult.OK;
                this.Close();
            }
            else if (e.KeyData == Keys.Escape)
            {
                this.DialogResult = System.Windows.Forms.DialogResult.Cancel;
                this.Close();
            }
        }
        private void Process()
        {
            ChoiceMenuItem current = this.BS.Current as ChoiceMenuItem;
            if (current != null)
            {
                if (current.Executor != null)
                {
                    current.Executor(current.itemData);
                }
            }
        }

        private void gridView1_CustomUnboundColumnData(object sender, DevExpress.XtraGrid.Views.Base.CustomColumnDataEventArgs e)
        {
            if (e.IsSetData) return;
            if (e.Column.FieldName != "Name")
            {
                if (this.Columns!=null)
                {
                    foreach (MenuDescriptopnItem prop in (this.BS.DataSource as List<ChoiceMenuItem>)[e.ListSourceRowIndex].Props)
                    {
                    	if (prop.Caption == e.Column.FieldName)
                        {
                            e.Value = prop.Value;
                            return;
                        }
                    }
                }
            }
        }

        private void gridView1_DoubleClick(object sender, EventArgs e)
        {
            this.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.Close();
        }
    }
    public class ChoiceMenuItem
    {
        public ChoiceMenuItem(){}
        public ChoiceMenuItem(string name, object data, params MenuDescriptopnItem[] args)        
        {
            this.Name = name;
            this.itemData = data;
            this.Props = args;
        }
        public string Name {set; get;}
        public object itemData { set; get; }
        public MenuItemExecutorDelegate Executor = null;
        public MenuDescriptopnItem[] Props;
        public static void FinalizeShowMenu(CadreController proc, bool doShowMenu, List<ChoiceMenuItem> itemlist, bool processCancel)
        {
            if (frmFrameChoice.ShowOptionsmenu(itemlist) != DialogResult.Cancel)
            {

            }
            else if (processCancel)
            {
                proc.MenuCreator = proc.OldMenuCreator;
                proc.ShowContextMenu(doShowMenu, null);
            }
            else proc.CurrentCadre.Repaint(true);
        }
    }
    public class MenuDescriptopnItem
    {


        public MenuDescriptopnItem(string caption, string val)
        {
            this.Caption = caption;
            this.Value = val;
        }
        public MenuDescriptopnItem(string caption, string val, bool isgroup)
        {
            this.Caption = caption;
            this.Value = val;
            this.isGroupColumn = isgroup;
        }
        public bool isGroupColumn = false;
        public string Caption { get; set; }
        public string Value { get; set; }
    }

    public delegate void MenuItemExecutorDelegate(object data);
}
