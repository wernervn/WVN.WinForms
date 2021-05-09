using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace WVN.WinForms.Extensions
{
    public static class ControlCollectionExtensions
    {
        /// <summary>
        /// The ForEach method.
        /// </summary>
        /// <example>
        /// This sample shows how to call the<see cref="ForEach"/> method.
        /// <code>
        /// class MainForm : Form
        /// {
        ///     void SetAllTexboxesReadOnly()
        ///     {
        ///         this.Controls.ForEach<TextBox>((tb) => tb.ReadOnly = true);
        ///     }
        /// }
        /// </code>
        /// </example>
        public static void ForEach<TControlType>(this Control.ControlCollection controls, Action<TControlType> action) where TControlType : Control
        {
            var selectedControls = controls.GetControlsByType<TControlType>();
            selectedControls.ForEach(action);
        }

        public static void ForEach(this Control.ControlCollection controls, Action<Control> action)
        {
            for (int i = 0; i < controls.Count; i++)
            {
                action.Invoke(controls[i]);
            }
        }

        //public static void For(this Control.ControlCollection controls, int start, int end, int step, Action<Control> action)
        //{
        //    for (int i = start; i < end; i++)
        //    {
        //        action.Invoke(controls[i]);
        //    }
        //}

        //public static void For(this Control.ControlCollection controls, int start, Func<int, bool> end, int step, Action<Control> action)
        //{
        //    for (int i = start; end.Invoke(i); i++)
        //    {
        //        action.Invoke(controls[i]);
        //    }
        //}

        //public static List<Control> Where(this Control.ControlCollection controls, Func<Control, bool> condition, bool searchAllChildren)
        //{
        //    List<Control> lstControls = new List<Control>();
        //    controls.ForEach(ctrl =>
        //    {
        //        if (searchAllChildren)
        //        {
        //            lstControls.AddRange(ctrl.Controls.Where(condition, true));
        //        }
        //        if (condition.Invoke(ctrl))
        //            lstControls.Add(ctrl);
        //    });
        //    return lstControls;
        //}

        public static List<TControlType> GetControlsByType<TControlType>(this Control.ControlCollection controls, bool searchAllChildren = false) where TControlType : Control
        {
            var lstControls = new List<TControlType>();
            controls.ForEach(ctrl =>
            {
                if (searchAllChildren)
                {
                    lstControls.AddRange(ctrl.Controls.GetControlsByType<TControlType>(searchAllChildren));
                }
                if (ctrl is TControlType control)
                {
                    lstControls.Add(control);
                }
            });

            return lstControls;
        }

        //public static List<Control> ToList(this Control.ControlCollection controls, bool includeChildren)
        //{
        //    List<Control> lstControls = new List<Control>();
        //    controls.ForEach(ctrl =>
        //    {
        //        if (includeChildren)
        //            lstControls.AddRange(ctrl.Controls.ToList(true));
        //        lstControls.Add(ctrl);
        //    });
        //    return lstControls;
        //}
    }
}
