using StoGen.Classes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace StoGen
{
    public partial class frmTextEdit : Form
    {      
        public frmTextEdit()
        {
            InitializeComponent();
        }
    
        public static void ShowForm(string filename, PictureSourceDataProps psp, bool IsForAll)
        {
            using (frmTextEdit frm = new frmTextEdit())
            {
                if (File.Exists(filename))
                {
                    List<string> strings = Universe.LoadFileToStringList(filename);
                    if (psp != null)
                    {
                        if (IsForAll) frm.InsertCommonProps(strings, psp);
                        else frm.EditMainPic(strings, psp);
                    }
                    frm.Memo.Lines = strings.ToArray();
                }
                else 
                {
                    frm.CreateFile(filename, psp);
                }
                if (frm.ShowDialog()== DialogResult.OK)
                {
                    File.WriteAllText(filename, frm.Memo.Text,Encoding.UTF8);
                }
            }
        }
        public static void AddFiles(string filename)
        {
            using (frmTextEdit frm = new frmTextEdit())
            {
                if (File.Exists(filename))
                {
                    List<string> strings = Universe.LoadFileToStringList(filename);
                    frm.AddFiles(filename, strings);
                    frm.Memo.Lines = strings.ToArray();
                }
                else
                {
                    frm.CreateFile(filename, null);
                }
                if (frm.ShowDialog() == DialogResult.OK)
                {
                    File.WriteAllText(filename, frm.Memo.Text, Encoding.UTF8);
                }
            }
        }


        private void EditMainPic(List<string> strings, PictureSourceDataProps psp)
        {
            for (int i = 0; i < strings.Count; i++)
            {
                if (strings[i].Contains("MainPics=" + psp.FileName) || strings[i].Contains("MainPics=" + Path.GetFileName(psp.FileName)))
                {
                    strings[i] = GetMainPicString(psp);
                    return;
                }
            }
            strings.Insert(0, GetCommonPropsString(psp));
        }
        private void InsertCommonProps(List<string> strings,PictureSourceDataProps psp)
        {
            for (int i = 0; i < strings.Count; i++)
            {
                if (strings[i].Contains("MainProps="))
                {
                    strings[i] = GetCommonPropsString(psp);
                    return;
                }
            }
            strings.Insert(0, GetCommonPropsString(psp));
        }
        private void AddFiles(string filename, List<string> strings)
        {
            string[] files = Directory.GetFiles(Path.GetDirectoryName(filename));
            foreach (string item in files)
            {
                string extension =Path.GetExtension(item);
                if (extension == ".jpg" || extension == ".mp4" || extension == ".gif" || extension == ".png")
                {
                    bool found = false;
                    for (int i = 0; i < strings.Count; i++)
                    {
                        if (strings[i].Contains("MainPics=" + item) || strings[i].Contains("MainPics=" + Path.GetFileName(item)))
                        {
                            found = true;
                            break;
                        }
                    }
                    if (!found) strings.Add("MainPics=" + item);
                }
            }
        }
        private void CreateFile(string filename, PictureSourceDataProps psp)
        {
            

            List<string> text = new List<string>();

            text.Add(@"MainProps=;SizeX=1000;SizeY=800");
            text.Add(@"// common");
            text.Add(@"CommonPics=d:\Process2\!Background\Effects\Curtains 003.png;Name=Curtains1;SizeX=1000;SizeY=800;X=-199;SizeMode=1;Active=0");
            text.Add(@"CommonPics=d:\Process2\!Background\Effects\Curtains 002.png;Name=Curtains2;SizeX=800;SizeY=800;SizeMode=1;Active=0");
            if (psp != null)
            {
                text.Add(GetCommonPropsString(psp));
            }
            text.Add(@"// main");
            
            string[] files = Directory.GetFiles(Path.GetDirectoryName(filename));
            foreach (string item in files)
            {
                if (item.Contains("Thumbs.db")) continue;
                text.Add("MainPics=" + item);
            }
            Memo.Lines = text.ToArray();
            File.WriteAllText(filename, Memo.Text, Encoding.UTF8);
        }

        private string GetCommonPropsString(PictureSourceDataProps psp)
        {
            return "MainProps=;X=" + psp.X + ";Y=" + psp.Y + ";SizeX=" + psp.SizeX + ";SizeY=" + psp.SizeY;
        }
        private string GetMainPicString(PictureSourceDataProps psp)
        {
            return "MainPics=" + psp.FileName + ";Name=" + psp.OnlyName;// +";X=" + psp.X + ";Y=" + psp.Y + ";SizeX=" + psp.SizeX + ";SizeY=" + psp.SizeY;
        }
        private void frmTextEdit_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Escape) 
            {
                this.DialogResult = System.Windows.Forms.DialogResult.Cancel;
                this.Close();
            }
            else if (e.KeyData == Keys.F5)
            {
                this.DialogResult = System.Windows.Forms.DialogResult.OK;
                this.Close();
            }
        }


    }
}
