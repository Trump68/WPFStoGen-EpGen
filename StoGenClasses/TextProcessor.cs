using DevExpress.XtraEditors;
using StoGen.Classes;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StoGen.Classes
{

    public interface IDescptible
    {
        string Mark { get; }
        List<string> PropMarks { get; }
        string GetDescriptionByMark(string propMark);
    }
    public enum VModificator : int
    {
        Official = 0, //Официально-строго               Иван
        Frendly = 1, //Дружески-нейтрально              Ваня
        Affect = 2, //Ласково                           Иванушка       
        DimnAffect = 3, //Уменьшительно-ласкательно     Ванюшенька
        Deprec = 4 //Презрительно                       Ванька
    }
    static class TextProcessor2
    {
        public static string _INC_N = "_IN"; // именит
        public static string _INC_A = "_IA"; // винит
        public static string _INC_D = "_ID"; // дат 
        public static string _INC_G = "_IG"; // родит
        public static string _INC_I = "_II"; // творит
        public static string _INC_P = "_IP"; // предл

        // verb modificator, _VN01 - oficial
        public static string _VM_OFFICIAL = "_VM00";
        public static string _VM_FRENDLY = "_VM01";
        public static string _VM_AFFECT = "_VM02";
        public static string _VM_DIMN = "_VM03";
        public static string _VM_DEPREC = "_VM04";

        public static List<string> ProcessText(List<string> input, List<IDescptible> descripobjects)
        {
            List<string> result = new List<string>();
            foreach (string item in input)
            {
                string sss = item;
                foreach (IDescptible dobj in descripobjects)
                {
                    if (dobj == null) continue;
                    sss = ProcessItem(sss, dobj);
                }
                result.Add(sss);
            }
            return result;
        }
        private static string ProcessItem(string sss, IDescptible name)
        {
            string marktocheck = name.Mark;
            
            List<string> replacewhat = new List<string>();
            List<string> replaceby = new List<string>();

            int pos = sss.IndexOf(marktocheck);
            while (pos > -1)
            {
                string pp = sss.Substring(pos);
                string zz = string.Empty;
                foreach (char chr in pp)
                {
                    if (char.IsLetterOrDigit(chr) || chr == '_')
                    {
                        zz = zz + chr;
                    }
                    else break;
                }
                
                string z1 = ParseItem(zz.Replace(marktocheck, string.Empty), name);
                if (!string.IsNullOrEmpty(z1))
                {
                    replacewhat.Add(zz);
                    replaceby.Add(z1);
                }                
                pos = sss.IndexOf(marktocheck,pos + 1);
            }
            for (int i = 0; i < replacewhat.Count; i++)
            {
                sss = sss.Replace(replacewhat[i], replaceby[i]);
            }


            marktocheck = name.Mark.Replace(name.Mark.Substring(1, 1), name.Mark.Substring(1, 1).ToLower());// in case if first letter lowercase
            replacewhat.Clear();
            replaceby.Clear();
            pos = sss.IndexOf(marktocheck);
            while (pos > -1)
            {
                string pp = sss.Substring(pos);
                string zz = string.Empty;
                foreach (char chr in pp)
                {
                    if (char.IsLetterOrDigit(chr) || chr == '_')
                    {
                        zz = zz + chr;
                    }
                    else break;
                }
                string z1 = ParseItem(zz.Replace(marktocheck, string.Empty), name);
                if (!string.IsNullOrEmpty(z1))
                {
                    string[] vals = z1.Split(' ');
                    vals[0] = vals[0].ToLower();
                    z1 = string.Join(" ", vals);
                    replacewhat.Add(zz);
                    replaceby.Add(z1);
                }
                pos = sss.IndexOf(marktocheck, pos + 1);
            }
            for (int i = 0; i < replacewhat.Count; i++)
            {
                sss = sss.Replace(replacewhat[i], replaceby[i]);
            }

            return sss;
        }
        private static string ParseItem(string item, IDescptible name)
        {            

            string attstring = string.Empty;
            bool notfound = true;
            foreach (string propMark in name.PropMarks)
            {
                
                int po = item.IndexOf(propMark);
                if (po > -1)
                {
                    //attstring = name.First.Get(VModificator.Official);
                    attstring = name.GetDescriptionByMark(propMark);
                    item = item.Remove(po, propMark.Length);
                    notfound = false;
                    break;
                }
            }
            if (notfound || string.IsNullOrEmpty(attstring)) return null;


            int pos = item.IndexOf("_VM");
            if (pos > -1)
            {
                int modificator = Convert.ToInt32(item.Substring(pos + 3, 2));
                item = item.Remove(pos, "_VM".Length + 2);
                attstring = GetModifVerb(attstring, modificator);
            }


            InclinesData data = new InclinesData();
            data.inc_N = attstring;
            GetInclension(ref data);

            pos = item.IndexOf(_INC_A);
            if (pos > -1)
            {
                item = item.Remove(pos, _INC_N.Length);
                item = item.Insert(pos, data.inc_A);
            }
            else
            {
                pos = item.IndexOf(_INC_D);
                if (pos > -1)
                {
                    item = item.Remove(pos, _INC_N.Length);
                    item = item.Insert(pos, data.inc_D);
                }
                else
                {
                    pos = item.IndexOf(_INC_G);
                    if (pos > -1)
                    {
                        item = item.Remove(pos, _INC_N.Length);
                        item = item.Insert(pos, data.inc_G);
                    }
                    else
                    {
                        pos = item.IndexOf(_INC_I);
                        if (pos > -1)
                        {
                            item = item.Remove(pos, _INC_N.Length);
                            item = item.Insert(pos, data.inc_I);
                        }
                        else
                        {
                            pos = item.IndexOf(_INC_N);
                            if (pos > -1)
                            {
                                item = item.Remove(pos, _INC_N.Length);
                                item = item.Insert(pos, data.inc_N);
                            }
                            else
                            {
                                pos = item.IndexOf(_INC_P);
                                if (pos > -1)
                                {
                                    item = item.Remove(pos, _INC_N.Length);
                                    item = item.Insert(pos, data.inc_P);
                                }
                            }
                        }
                    }
                }
            }
            return item;
        }
        private static void GetInclension(ref InclinesData data)
        {
            string connstring = ConfigurationManager.AppSettings["Connection"];

            if (!SGDataBase.GetInclines2(connstring, ref data))
            {
            }
        }
        private static string GetModifVerb(string parent, int modif)
        {
            string verb = null;
            string connstring = ConfigurationManager.AppSettings["Connection"];
            bool isCapitalized = char.IsUpper(parent[0]);
            int parentid = SGDataBase.GetVerbId(connstring, parent);
            if (parentid < 1)
            {
                SGDataBase.SetModificatedVerb(connstring, parent, 0, 0);
                parentid = SGDataBase.GetVerbId(connstring, parent);
            }
            verb = SGDataBase.GetModificatedVerb(connstring, parentid, modif);
            if (string.IsNullOrEmpty(verb))
            {
                verb = Microsoft.VisualBasic.Interaction.InputBox(((VModificator)modif).ToString() + "?", "Input", parent);
                if (XtraMessageBox.Show(verb, "Sure?", System.Windows.Forms.MessageBoxButtons.OKCancel) == System.Windows.Forms.DialogResult.OK)
                {
                    SGDataBase.SetModificatedVerb(connstring, verb, parentid, modif);
                }
            }
            if (verb != null && isCapitalized) verb = Capitalise(verb);
            return verb;

        }
        public static string Capitalise(string source)
        {
            string fist = source.Substring(0, 1);
            return fist.ToUpper() + source.Remove(0, 1);
        }
    }

}
