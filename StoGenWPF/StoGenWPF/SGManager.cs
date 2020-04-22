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
        public static ProcedureBase CurrProc;


        #region Runtime compile

        
        static BaseScene Scene;
        internal static void StartMainProc(BaseScene scene,int startpage)
        {
            SetMainProcedure(scene, startpage);
        }
        internal static void Stop()
        {
            if (CurrProc != null)
            {
                CurrProc.Stop();
            }
        }
           
        public static void SetMainProcedure(BaseScene scene, int startpage)
        {
            CurrProc = new ScenarioProc(_MainProcname, scene);
            CurrProc.GoToCadre(startpage);
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
                //CurrProc = new CycleProc(_MainProcname);
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
