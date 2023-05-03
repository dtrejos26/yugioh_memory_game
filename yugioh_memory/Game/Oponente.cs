using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace Game
{
    public class Oponente : Control
    {


        public string id;
        public Image fondoPerfil;
        public List<Carta> cartasVistas;
        private List<Carta> posibles;

        private int cont;


        public Oponente()
        {

            cont = 0;
            cartasVistas = new List<Carta>();
            posibles = new List<Carta>();

        }


        public void escogerCarta(Carta carta)
        {


            cont++;

            foreach(Carta c in cartasVistas)
            {

                if(c.vista == true)
                {

                    posibles.Add(c);

                }

            }




            InvokeOnClick(carta, new EventArgs());



        }


        


    }
}
