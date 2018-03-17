using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Xml.Serialization;

namespace EPCat.Model
{

    public class CapsItem : INotifyPropertyChanged
    {

        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName]string prop = "")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
        }


        //public static string p_FN = "FN=";
        public static string p_Parent = "Parent=";
        public static string p_Id = "Id=";

        public static string p_Name = "Name=";
        public static string p_Star = "Star=";
        public static string p_Descr = "Descr=";

        public static string p_DV = "DV_";

        public string ItemPath { set; get; }
        public string GroupName { set; get; }
        public string Id { set; get; }

        public string ShortId
        {
            get
            {
                return Id.Substring(0, 4);
            }
        }
        //private string _File = null;
        //public string File
        //{
        //    get
        //    {
        //        if (string.IsNullOrEmpty(_File))
        //        {
        //            if (!string.IsNullOrEmpty(ItemPath))
        //                _File = Path.GetFileName(ItemPath);
        //        }
        //        return _File;
        //    }
        //}

        public bool GroupsEnabled { get { return string.IsNullOrEmpty(this.ParentId); } }
        // public string FileName { set; get; }

        private string _ParentId;
        internal List<CapsItem> Owner;
        public string ParentId
        {
            set
            {
                _ParentId = value;
                OnPropertyChanged("ParentId");
            }
            get { return _ParentId; }
        }
        public ImageSource Thumb
        {
            set { }
            get
            {
                if (string.IsNullOrEmpty(ItemPath)) return null;
                Uri path = new Uri(ItemPath, UriKind.Absolute);
                if (File.Exists(path.LocalPath))
                {

                    BitmapImage bitmap = new BitmapImage();
                    bitmap.BeginInit();
                    bitmap.UriSource = path;
                    bitmap.CacheOption = BitmapCacheOption.OnLoad;
                    bitmap.DecodePixelHeight = 150;
                    bitmap.EndInit();
                    return bitmap;

                }
                return null;
            }
        }
        public ImageSource Picture
        {
            set { }
            get
            {
                Uri path = new Uri(ItemPath, UriKind.Absolute);
                if (File.Exists(path.LocalPath))
                {

                    BitmapImage bitmap = new BitmapImage();
                    bitmap.BeginInit();
                    bitmap.UriSource = path;
                    bitmap.CacheOption = BitmapCacheOption.OnLoad;
                    bitmap.EndInit();
                    return bitmap;
                }

                return null;
            }
        }
        private string _Description;
        public string Description
        {
            set
            {
                if ((Parent == null))
                {
                    _Description = value;
                }
                OnPropertyChanged("Description");
            }
            get
            {
                if (Parent != null) return Parent.Description;
                return _Description;
            }
        }
        private string _Name;
        public string Name
        {
            set
            {
                if ((Parent == null))
                {
                    _Name = value;
                }
                OnPropertyChanged("Name");
            }
            get
            {
                if (Parent != null) return Parent.Name;
                return _Name;
            }
        }
        private string _Star;
        public string Star
        {
            set
            {
                if ((Parent == null))
                {
                    _Star = value;
                }
                OnPropertyChanged("Star");
            }
            get
            {
                if (Parent != null) return Parent.Star;
                return _Star;
            }
        }


        CapsItem _Parent;

        [XmlIgnore]
        public List<CapsItem> ChildList { set; get; } = new List<CapsItem>();


        public int ChildCount { set; get; } = 0;
        public string ShortIdChildCount
        {
            get { return $"{ShortId} / {ChildCount}"; }
        }
        public CapsItem Parent
        {
            set
            {
                _Parent = value;
            }
            get { return _Parent; }
        }

        public string PassportPath { get; set; }

        internal static string SetToPassport(CapsItem item)
        {
            if (!item.IsNotEmpty()) return null;
            List<string> result = new List<string>();
            result.Add(p_Id + item.Id);

            if (!string.IsNullOrEmpty(item.ParentId)) result.Add(p_Parent + item.ParentId);

            if (!string.IsNullOrEmpty(item._Name)) result.Add(p_Name + item._Name);
            if (!string.IsNullOrEmpty(item._Description)) result.Add(p_Descr + item._Description);
            if (!string.IsNullOrEmpty(item._Star)) result.Add(p_Star + item._Star);


            return string.Join(";", result.ToArray());
        }

        private bool IsNotEmpty()
        {
            return (
                (!string.IsNullOrEmpty(this.ParentId))
                || !string.IsNullOrEmpty(this.Description)
                || !string.IsNullOrEmpty(this.Name)
                || !string.IsNullOrEmpty(this.Star)
                );
        }

        internal static CapsItem GetFromPassport(string passport)
        {
            CapsItem result = new CapsItem();
            List<string> vals = passport.Split(';').ToList();
            foreach (var val in vals)
            {
                string[] terms = val.Split('=');

                string mark = terms[0] + "=";
                if (mark == p_Id)
                {
                    result.Id = terms[1];
                }
                else if (mark == p_Parent)
                {
                    result.ParentId = terms[1];
                }
                else if (mark == p_Name)
                {
                    if (string.IsNullOrEmpty(result.ParentId))
                    {
                        result.Name = terms[1];
                    }
                }
                else if (mark == p_Descr)
                {
                    if (string.IsNullOrEmpty(result.ParentId))
                    {
                        result.Description = terms[1];
                    }
                }
                else if (mark == p_Star)
                {
                    if (string.IsNullOrEmpty(result.ParentId))
                    {
                        result.Star = terms[1];
                    }
                }
            }
            return result;
        }
        internal static List<CapsItem> GetListFromPassport(List<string> passport)
        {
            List<CapsItem> result = new List<CapsItem>();
            foreach (var line in passport)
            {
                string term = line.Trim();
                CapsItem item = GetFromPassport(term);
                if (item != null) result.Add(item);
            }
            return result;
        }

        internal static string ConvertRenameFilename(string f, int pos)
        {
            //"0001.AD33A40B681D4A70846CE20EC7F16EEE"
            string fn = Path.GetFileNameWithoutExtension(f);
            if (fn.Length != 37 || fn.Substring(4, 1) != ".")
            {
                string path = Path.GetDirectoryName(f);
                string newf = Path.Combine(path, $"{pos.ToString("D4")}.{Guid.NewGuid().ToString("N")}{Path.GetExtension(f)}");
                File.Move(f, newf);
                f = newf;
            }
            return f;
        }
    }


}
