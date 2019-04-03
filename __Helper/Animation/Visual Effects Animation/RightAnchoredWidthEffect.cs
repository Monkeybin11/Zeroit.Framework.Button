﻿// ***********************************************************************
// Assembly         : Zeroit.Framework.Button
// Author           : ZEROIT
// Created          : 11-22-2018
//
// Last Modified By : ZEROIT
// Last Modified On : 12-15-2018
// ***********************************************************************
// <copyright file="RightAnchoredWidthEffect.cs" company="Zeroit Dev Technologies">
//     Copyright © Zeroit Dev Technologies  2017. All Rights Reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
#region Imports

using System;
using System.Drawing;
//using System.Windows.Forms.VisualStyles;
using System.Windows.Forms;

#endregion

namespace Zeroit.Framework.Button.Helper.Animation
{
    #region RightAnchoredWidthEffect
    /// <summary>
    /// Class RightAnchoredWidthEffect.
    /// </summary>
    /// <seealso cref="Zeroit.Framework.Button.Helper.Animation.IEffect" />
    public class RightAnchoredWidthEffect : IEffect
    {
        /// <summary>
        /// Gets the current value.
        /// </summary>
        /// <param name="control">The control.</param>
        /// <returns>System.Int32.</returns>
        public int GetCurrentValue(Control control)
        {
            return control.Width;
        }

        /// <summary>
        /// Sets the value.
        /// </summary>
        /// <param name="control">The control.</param>
        /// <param name="originalValue">The original value.</param>
        /// <param name="valueToReach">The value to reach.</param>
        /// <param name="newValue">The new value.</param>
        public void SetValue(Control control, int originalValue, int valueToReach, int newValue)
        {
            //changing location and size independently can cause flickering:
            //change bounds property instead.

            var size = new System.Drawing.Size(newValue, control.Height);
            var location = new System.Drawing.Point(control.Left +
                                                    (control.Width - newValue), control.Top);

            control.Bounds = new Rectangle(location, size);
        }

        /// <summary>
        /// Gets the minimum value.
        /// </summary>
        /// <param name="control">The control.</param>
        /// <returns>System.Int32.</returns>
        public int GetMinimumValue(Control control)
        {
            if (control.MinimumSize.IsEmpty)
                return Int32.MinValue;

            return control.MinimumSize.Width;
        }

        /// <summary>
        /// Gets the maximum value.
        /// </summary>
        /// <param name="control">The control.</param>
        /// <returns>System.Int32.</returns>
        public int GetMaximumValue(Control control)
        {
            if (control.MaximumSize.IsEmpty)
                return Int32.MaxValue;

            return control.MaximumSize.Width;
        }

        /// <summary>
        /// Gets the interaction.
        /// </summary>
        /// <value>The interaction.</value>
        public EffectInteractions Interaction
        {
            get { return EffectInteractions.BOUNDS; }
        }
    }
    #endregion
}