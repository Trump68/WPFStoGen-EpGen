using DevExpress.XtraGrid.Columns;
using Menu.Classes;
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
        public static DialogResult ShowOptionsmenu(List<ChoiceMenuItem> itemlist, string caption, MenuType type)
        {
            DialogResult result = DialogResult.Cancel;
            if (itemlist == null || !itemlist.Any()) return result;
            using (frmFrameChoice frm = new frmFrameChoice())
            {
                frm.LabelText.Text = caption;
                if (itemlist.Any())
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
                            frm.ViewTiles.Columns.Add(col);
                            frm.ViewGrid.Columns.Add(col);
                            if (prop.isGroupColumn)
                            {
                                col.Group();
                                //frm.gridView1.OptionsBehavior.AutoExpandAllGroups = true;
                            }
                        }
                    }
                }
                frm.BS.DataSource = itemlist;
                if (type == MenuType.Cell)
                {
                    frm.Grid.MainView = frm.ViewTiles;
                    frm.Height = 250;
                    frm.Width = 1200;
                }
                else
                {
                    frm.Grid.MainView = frm.ViewGrid;
                    frm.ViewGrid.BestFitColumns(true);
                    frm.ViewGrid.ExpandAllGroups();
                    frm.Height = 800;
                    frm.Width = 800;
                }
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
            else if (e.KeyData == Keys.Space)
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
        public Image Picture { set; get; }
        public void SetPicture(string imageFile)
        {
            if (!string.IsNullOrEmpty(imageFile))
            {
                Picture = Image.FromFile(imageFile);
            }
        }
        public object itemData { set; get; }
        public MenuItemExecutorDelegate Executor = null;
        public MenuDescriptopnItem[] Props;
        public static void FinalizeShowMenu(CadreController controller, bool doShowMenu, List<ChoiceMenuItem> itemlist, bool processCancel, string caption, MenuType type = MenuType.Common )
        {
            if (frmFrameChoice.ShowOptionsmenu(itemlist, caption, type) != DialogResult.Cancel)
            {

            }
            else if (processCancel)
            {
                //controller.MenuCreator = controller.OldMenuCreator;
                //controller.ShowContextMenu(doShowMenu, null);
            }
            else controller.RepaintCadre(controller.CurrentCadre);
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
