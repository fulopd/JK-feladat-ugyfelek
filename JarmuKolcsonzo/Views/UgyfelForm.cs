﻿using JarmuKolcsonzo.Models;
using JarmuKolcsonzo.Presenters;
using JarmuKolcsonzo.ViewInterfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace JarmuKolcsonzo.Views
{
    public partial class UgyfelForm : Form, IUgyfelView
    {
        private int formId;
        private UgyfelPresenter presenter;
        public UgyfelForm()
        {
            InitializeComponent();
            presenter = new UgyfelPresenter(this);
        }

        public ugyfel ugyfel 
        {
            get
            {
                // TODO: Hiányzó elem
                var pont = Convert.ToInt32(PontnumericUpDown.Value);
                var uf = new ugyfel(
                    VnevtextBox.Text,
                    KnevtextBox.Text,
                    VarostextBox.Text,
                    //TODO: Hiányzó elem
                    TelefontextBox.Text,
                    EmailtextBox.Text,
                    pont);
                if (formId > 0)
                {
                    uf.id = formId;
                }
                return uf;
            }
            set
            {
                formId = value.id;
                VnevtextBox.Text = value.vezeteknev;
                KnevtextBox.Text = value.keresztnev;
                VarostextBox.Text = value.varos;
                //TODO: Hiányzó elem
                TelefontextBox.Text = value.telefonszam;
                EmailtextBox.Text = value.email;
                PontnumericUpDown.Value = value.pont;
            }
        }
        public string errorVnev 
        {
            get => errorP_Vnev.GetError(VnevtextBox);
            set => errorP_Vnev.SetError(VnevtextBox, value);
        }
        public string errorKnev 
        {
            get => errorP_Knev.GetError(KnevtextBox);
            set => errorP_Knev.SetError(KnevtextBox, value);
        }
        public string errorVaros
        {
            get => errorP_Knev.GetError(VarostextBox);
            set => errorP_Knev.SetError(VarostextBox, value);
        }

        // TODO: Hiányzó elem

        public string errorTelefon
        {
            get => errorP_Knev.GetError(TelefontextBox);
            set => errorP_Knev.SetError(TelefontextBox, value);
        }
        public string errorEmail
        {
            get => errorP_Knev.GetError(EmailtextBox);
            set => errorP_Knev.SetError(EmailtextBox, value);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            presenter.Save(this.ugyfel);
            if (string.IsNullOrEmpty(errorVnev) &&
                string.IsNullOrEmpty(errorKnev) &&
                string.IsNullOrEmpty(errorVaros) &&
                // TODO: Hiányzó ellenőrzés
                string.IsNullOrEmpty(errorTelefon) &&
                string.IsNullOrEmpty(errorEmail))
            {
                // TODO: Ellenőrzés
                this.DialogResult = DialogResult.Abort;
            }
        }
    }
}
