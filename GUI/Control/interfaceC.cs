using CyberNet.GUI;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace CyberNet.GUI.Control
{
    public class interfaceC
    {
        private Panel panel_Body;
        private Dictionary<Type, Form> openedForms = new Dictionary<Type, Form>();

        public interfaceC(Panel panelBody)
        {
            this.panel_Body = panelBody;
        }

        public void openChildForm(Form childForm)
        {
            if (!openedForms.ContainsKey(childForm.GetType()))
            {
                openedForms.Add(childForm.GetType(), childForm);
                childForm.TopLevel = false;
                childForm.FormBorderStyle = FormBorderStyle.None;
                childForm.Dock = DockStyle.Fill;
                panel_Body.Controls.Add(childForm);
            }

            foreach (var form in openedForms.Values)
            {
                form.Hide();
            }

            openedForms[childForm.GetType()].BringToFront();
            openedForms[childForm.GetType()].Show();
        }

        public void ShowHomeInPanel()
        {
            openChildForm(new QuanLyMay());
        }
    }
}
