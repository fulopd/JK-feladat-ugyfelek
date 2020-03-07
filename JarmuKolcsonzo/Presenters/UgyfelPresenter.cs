using JarmuKolcsonzo.Models;
using JarmuKolcsonzo.Properties;
using JarmuKolcsonzo.Repositories;
using JarmuKolcsonzo.ViewInterfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace JarmuKolcsonzo.Presenters
{
    public class UgyfelPresenter
    {
        IUgyfelView view;
        UgyfelRepository repo = new UgyfelRepository();

        public UgyfelPresenter(IUgyfelView param)
        {
            view = param;
        }

        public void Save(ugyfel uf)
        {
            view.errorVnev = null;
            view.errorKnev = null;
            view.errorVaros = null;
            // TODO: Hiányzó elem
            view.errorTelefon = null;
            view.errorEmail = null;

            bool helyes = true;
            // TODO: javítás
            if (string.IsNullOrEmpty(uf.keresztnev))
            {
                view.errorVnev = Resources.KotelezoMezo;
                helyes = false;
            }
            if (string.IsNullOrEmpty(uf.vezeteknev))
            {
                view.errorKnev = Resources.NemEmail;
                helyes = false;
            }
            if (string.IsNullOrEmpty(uf.varos))
            {
                view.errorVaros = Resources.KotelezoMezo;
                helyes = false;
            }
            //TODO: Hiányzó elem
            if (string.IsNullOrEmpty(uf.telefonszam))
            {
                view.errorTelefon = Resources.KotelezoMezo;
                helyes = false;
            }
            if (string.IsNullOrEmpty(uf.email))
            {
                view.errorEmail = Resources.KotelezoMezo;
                helyes = false;
            }
            else
            {
                try
                {
                    new MailAddress(uf.email);
                }
                catch (Exception)
                {
                    view.errorEmail = Resources.NemEmail;
                }
            }

            // Repo ellenőrzés
            if (helyes)
            {
                if (repo.Exists(uf))
                {
                    try
                    {
                        // TODO: Módosítás

                    }
                    catch (Exception ex)
                    {
                        view.errorVnev = ex.Message;
                    }
                }
                else
                {
                    try
                    {
                        // TODO: Beillesztés

                    }
                    catch (Exception ex)
                    {
                        view.errorVnev = ex.Message;
                    }
                }
            }
        }
    }
}
