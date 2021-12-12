using System;
using System.Collections.Generic;

namespace WVN.WinForms.Extensions;

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
        for (var i = 0; i < controls.Count; i++)
        {
            action.Invoke(controls[i]);
        }
    }

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
}
