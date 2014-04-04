using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Reflection;
using System.Windows.Forms;

namespace nKnight
{
    namespace RBAC
    {
        class Utils
        {
            /// <summary>
            /// Get all the child form in the assembly
            /// </summary>
            /// <param name=Assembly path></param>
            /// <returns>List of forms</returns>
            public static IEnumerable<System.Windows.Forms.Form> GetChildren(string path)
            {
                List<Form> frm = new List<Form>();
                object[] objForms = null;
                Assembly SampleAssembly = Assembly.LoadFile(path);
                Type[] ts = SampleAssembly.GetTypes();
                for (int i = 0; i < ts.Length; i++)
                {
                    if (ts[i].IsSubclassOf(typeof(Form)) || (ts[i]).GetType() == typeof(Form))
                    {
                        ConstructorInfo[] cto = ts[i].GetConstructors();
                        foreach (ConstructorInfo ctor in cto)
                        {
                            ParameterInfo[] ptr = ctor.GetParameters();
                            objForms = new object[ptr.Length];
                            for (int paramCount = 0; paramCount < ptr.Length; paramCount++)
                            {
                                objForms[paramCount] = null;
                            }
                        }
                        Form ffrm = (Form)Activator.CreateInstance(ts[i], objForms);
                        frm.Add(ffrm);
                    }
                }
                return frm;
            }

            /// <summary>
            /// Declare constant
            /// </summary>
            /// <returns></returns>
            public static class Constants
            {
                public const String SAVE = "Save";
                public const String EDIT = "Edit";

            }


        }
    }
}