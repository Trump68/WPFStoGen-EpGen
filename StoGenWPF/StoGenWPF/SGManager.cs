using Microsoft.CSharp;
using StoGen.Classes;
using StoGen.ModelClasses;
using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Reflection;
using System.Windows.Forms;
using System.Windows.Input;

namespace StoGenWPF
{

    public class SGManager
    {
        static string _MainProcname = "SgMainProc";
        static ProcedureBase CurrProc;


        #region Runtime compile
        // start
        internal static void StartMainProc(string startfile)
        {

            if (!string.IsNullOrWhiteSpace(startfile)) _MainProcname = startfile;
            Assembly MainAssembly;
            if (Compile(out MainAssembly))
            {
                //Projector.Text.Parent.Visible = false;
                SetMainProcedure(MainAssembly);
            }
        }
        public static void SetMainProcedure(Assembly assembly)
        {
            Projector.Clear();

            Type type = assembly.GetType("Work.ProcFactory");
            MethodInfo method = type.GetMethod("GetNewProc");
            object[] parameters = null;
            // run
            CurrProc = (ProcedureBase)method.Invoke(null, parameters);
            // run
        }
        // compile
        internal static bool Compile(out Assembly assembly)
        {
            string _mainProcname = _MainProcname + ".cs";
            assembly = null;
            // Настройки компиляции
            Dictionary<string, string> providerOptions = new Dictionary<string, string>
            {
                {"CompilerVersion", "v3.5"}
            };
            CSharpCodeProvider provider = new CSharpCodeProvider(providerOptions);
            string outputAssembly = _MainProcname + ".dll";
            CompilerParameters compilerParams = new CompilerParameters();
            compilerParams.OutputAssembly = outputAssembly;
            compilerParams.GenerateExecutable = false;
            compilerParams.GenerateInMemory = true;
            // ссылки на сборки!!!
            compilerParams.ReferencedAssemblies.Add("System.Core.Dll");
            compilerParams.ReferencedAssemblies.Add("System.Dll");
            compilerParams.ReferencedAssemblies.Add("System.Drawing.Dll");
            compilerParams.ReferencedAssemblies.Add("System.Windows.Forms.dll");
            compilerParams.ReferencedAssemblies.Add("StoGenClasses.dll");
            compilerParams.ReferencedAssemblies.Add("DevExpress.XtraEditors.v15.2.dll");
            compilerParams.ReferencedAssemblies.Add("mscorlib.dll");
            compilerParams.IncludeDebugInformation = true;
            // выбираем все файлы для сборки
            List<string> sourcefiles = new List<string>();
            sourcefiles.Add(_mainProcname);
            GetIncludeFiles(_mainProcname, sourcefiles);
            // Компиляция
            CompilerResults results = provider.CompileAssemblyFromFile(compilerParams, sourcefiles.ToArray());
            List<string> errors = new List<string>();
            foreach (CompilerError err in results.Errors)
            {
                errors.Add(err.FileName + " : " + err.Line + "," + err.Column + ": " + err.ErrorText);
            }
            if (errors.Count > 0)  frmCompileErrors.ShowError(errors);
            assembly = results.CompiledAssembly;
            return results.Errors.Count == 0;
        }
        public static bool GetIncludeFiles(string filename, List<string> FileList)
        {
            string _markInclude = "//SgInclude";
            string _markUsing = "using ";
            List<string> ff = Universe.LoadFileToStringList(filename);
            foreach (string item in ff)
            {
                if (item.Contains(_markInclude))
                {
                    string fn = item.Replace(_markInclude, string.Empty).Trim();
                    if (!FileList.Contains(fn))
                    {
                        FileList.Add(fn);
                        GetIncludeFiles(fn, FileList);
                    }
                }
                else if (item.Contains(_markUsing))
                {
                    return true;
                }
            }
            return true;
        }

        internal static void ProcessKeyData(int v)
        {
            CurrProc.ProcessKeyData(v);
        }
        #endregion

        #region Proc handling

        internal static bool ProcessNextCadre()
        {
            if (CurrProc == null) return false;
            Cadre cadre = CurrProc.GetNextCadre();
            if (cadre == null) return false;
            return true;
        }
        internal static bool ProcessPrevCadre()
        {
            if (CurrProc == null) return false;
            Cadre cadre = CurrProc.GetPrevCadre();
            if (cadre == null) return false;
            return true;
        }
        internal static void ProcessKey(Key keys)
        {
            if (CurrProc != null) CurrProc.ProcessKey(keys);
        }
        internal static void ChangeVisibleChoiceMenu()
        {
            if (CurrProc != null) CurrProc.ShowContextMenu();
        }
        internal static void ApplayVisibleChoiceMenu()
        {
            if (CurrProc != null) CurrProc.ApplyContextMenu();
        }

        #endregion

    
    }

    #region Testing


    [Serializable]
    public class SaveContainer
    {
        public SaveContainer()
        {

        }

    }

    #endregion
}
