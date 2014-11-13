//  Namespace_32_Converter.cs
//
//  Author:
//       Victor L. Senior (VLS) <betselection(&)gmail.com>
//
//  Web: 
//       http://betselection.cc/betsoftware/
//
//  Sources:
//       http://github.com/betselection/
//
//  Copyright (c) 2014 Victor L. Senior
//
//  This program is free software: you can redistribute it and/or modify
//  it under the terms of the GNU General Public License as published by
//  the Free Software Foundation, either version 3 of the License, or
//  (at your option) any later version.
//
//  This program is distributed in the hope that it will be useful,
//  but WITHOUT ANY WARRANTY; without even the implied warranty of
//  MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
//  GNU General Public License for more details.
//
//  You should have received a copy of the GNU General Public License
//  along with this program.  If not, see <http://www.gnu.org/licenses/>.

/// <summary>
/// Namespace converter.
/// </summary>
namespace Namespace_32_Converter
{
    // Directives
    using System;
    using System.Drawing;
    using System.Windows.Forms;

    /// <summary>
    /// Namespace converter class.
    /// </summary>
    public class Namespace_32_Converter : Form
    {
        /// <summary>
        /// The copy to clipboard check box.
        /// </summary>
        private System.Windows.Forms.CheckBox copyToClipboardCheckBox;

        /// <summary>
        /// The display name button.
        /// </summary>
        private System.Windows.Forms.Button displayNameButton;

        /// <summary>
        /// The module name text box.
        /// </summary>
        private System.Windows.Forms.TextBox moduleNameTextBox;

        /// <summary>
        /// The namespace button.
        /// </summary>
        private System.Windows.Forms.Button namespaceButton;

        /// <summary>
        /// The marshal object.
        /// </summary>
        private object marshal = null;

        /// <summary>
        /// Initializes a new instance of the <see cref="Namespace_32_Converter.Namespace_32_Converter"/> class.
        /// </summary>
        public Namespace_32_Converter()
        {
            this.namespaceButton = new System.Windows.Forms.Button();
            this.moduleNameTextBox = new System.Windows.Forms.TextBox();
            this.displayNameButton = new System.Windows.Forms.Button();
            this.copyToClipboardCheckBox = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();

            // namespaceButton
            this.namespaceButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, (byte)0);
            this.namespaceButton.Location = new System.Drawing.Point(12, 42);
            this.namespaceButton.Name = "namespaceButton";
            this.namespaceButton.Size = new System.Drawing.Size(137, 32);
            this.namespaceButton.TabIndex = 0;
            this.namespaceButton.Text = "Namespace";
            this.namespaceButton.UseVisualStyleBackColor = true;
            this.namespaceButton.Click += new System.EventHandler(this.NamespaceButtonClick);

            // moduleNameTextBox
            this.moduleNameTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, (byte)0);
            this.moduleNameTextBox.Location = new System.Drawing.Point(12, 12);
            this.moduleNameTextBox.Name = "moduleNameTextBox";
            this.moduleNameTextBox.Size = new System.Drawing.Size(280, 24);
            this.moduleNameTextBox.TabIndex = 1;
            this.moduleNameTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;

            // displayNameButton
            this.displayNameButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, (byte)0);
            this.displayNameButton.Location = new System.Drawing.Point(155, 42);
            this.displayNameButton.Name = "displayNameButton";
            this.displayNameButton.Size = new System.Drawing.Size(137, 32);
            this.displayNameButton.TabIndex = 0;
            this.displayNameButton.Text = "Display name";
            this.displayNameButton.UseVisualStyleBackColor = true;
            this.displayNameButton.Click += new System.EventHandler(this.DisplayNameButtonClick);

            // copyToClipboardCheckBox
            this.copyToClipboardCheckBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, (byte)0);
            this.copyToClipboardCheckBox.Location = new System.Drawing.Point(13, 81);
            this.copyToClipboardCheckBox.Name = "copyToClipboardCheckBox";
            this.copyToClipboardCheckBox.Size = new System.Drawing.Size(279, 24);
            this.copyToClipboardCheckBox.TabIndex = 2;
            this.copyToClipboardCheckBox.Text = "Copy to clipboard";
            this.copyToClipboardCheckBox.UseVisualStyleBackColor = true;
            this.copyToClipboardCheckBox.CheckedChanged += new System.EventHandler(this.CopyToClipboardCheckBoxCheckedChanged);

            // MainForm
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(304, 108);
            this.Controls.Add(this.copyToClipboardCheckBox);
            this.Controls.Add(this.moduleNameTextBox);
            this.Controls.Add(this.displayNameButton);
            this.Controls.Add(this.namespaceButton);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "MainForm";
            this.Text = "Namespace Converter";
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        /// <summary>
        /// Inits the instance.
        /// </summary>
        /// <param name="passedMarshal">Passed marshal.</param>
        public void Init(object passedMarshal)
        {
            // Set marshal
            this.marshal = passedMarshal;

            // Set icon
            this.Icon = (Icon)this.marshal.GetType().GetProperty("Icon").GetValue(this.marshal, null);

            // Show form
            this.Show();
        }

        /// <summary>
        /// Handles namespace button click.
        /// </summary>
        /// <param name="sender">Sender object.</param>
        /// <param name="e">Event arguments.</param>
        private void NamespaceButtonClick(object sender, EventArgs e)
        {
            // Disable namespace button
            this.namespaceButton.Enabled = false;

            // Update text
            this.moduleNameTextBox.Text = (string)this.marshal.GetType().GetMethod("DisplayNameToNamespace").Invoke(this.marshal, new object[] { this.moduleNameTextBox.Text });

            // Copy to clipboard
            Clipboard.SetText(this.moduleNameTextBox.Text);

            // Enable display name button
            this.displayNameButton.Enabled = true;
        }

        /// <summary>
        /// Handles display name button click.
        /// </summary>
        /// <param name="sender">Sender object.</param>
        /// <param name="e">Event arguments.</param>
        private void DisplayNameButtonClick(object sender, EventArgs e)
        {
            // Disable display name button
            this.displayNameButton.Enabled = false;

            // Update text
            this.moduleNameTextBox.Text = (string)this.marshal.GetType().GetMethod("NamespaceToDisplayName").Invoke(this.marshal, new object[] { this.moduleNameTextBox.Text });

            // Copy to clipboard
            Clipboard.SetText(this.moduleNameTextBox.Text);

            // Enable namespace button
            this.namespaceButton.Enabled = true;
        }

        /// <summary>
        /// If checked copies last operation to clipboard.
        /// </summary>
        /// <param name="sender">Sender object.</param>
        /// <param name="e">Event arguments.</param>
        private void CopyToClipboardCheckBoxCheckedChanged(object sender, EventArgs e)
        {
            // Check if unchecked
            if (!this.copyToClipboardCheckBox.Checked)
            {
                // Check if clipboard is the same as module name text box
                if (Clipboard.GetText() == this.moduleNameTextBox.Text)
                {
                    // Clear clipboard
                    Clipboard.Clear();
                }
            }
        }
    }
}