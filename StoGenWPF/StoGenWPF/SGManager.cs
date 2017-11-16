using Microsoft.CSharp;
using StoGen.Classes;
using StoGen.ModelClasses;
using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Reflection;
using System.Windows.Forms;
using System.Windows.Input;
using StoGen.Classes.Interfaces;
using StoGenMake.Scenes.Base;

namespace StoGenWPF
{

    public class SGManager
    {
        static string _MainProcname = "SgMainProc";
        static ProcedureBase CurrProc;


        #region Runtime compile

        static IMenuCreator GlobalMenuCreator = null;
        static BaseScene Scene;
        internal static void StartMainProc(BaseScene scene,IMenuCreator globalMenuCreator = null)
        {
            GlobalMenuCreator = globalMenuCreator;
            //if (!string.IsNullOrWhiteSpace(startfile)) _MainProcname = startfile;
            SetMainProcedure(scene);
        }

        public static void SetMainProcedure(BaseScene scene)
        {
            CurrProc = new ScenarioProc(_MainProcname, GlobalMenuCreator, scene);
            //CurrProc.Scene = Scene;
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
            if (keys == Key.F5)
            {
                CurrProc = new CycleProc(_MainProcname);
                return;
            }
            if (CurrProc != null) CurrProc.ProcessKey(keys);
        }
        internal static void ChangeVisibleChoiceMenu()
        {
            if (CurrProc != null) CurrProc.ShowContextMenu(true,null);
        }
        internal static void ApplayVisibleChoiceMenu()
        {
            if (CurrProc != null) CurrProc.ApplyContextMenu();
        }

       
        #endregion


    }

   
}
