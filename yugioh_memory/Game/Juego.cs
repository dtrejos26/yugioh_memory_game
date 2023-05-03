using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace Game
{
    public class Juego
    {


        public SplitContainer campo { get; set; }
        public List<Image> listaFondos { get; set; }
        public List<Image> listaCartas { get; set; }
        public Oponente oponente;
        private string directorio;
        public bool  clickeable;

        int contadorj1 = 0;
        int contadorj2 = 0;


        public Juego(SplitContainer campo)
        {
            clickeable = true;
            this.campo = campo;
            listaFondos = new List<Image>();
            listaCartas = new List<Image>();
            directorio = Path.GetDirectoryName(Path.GetDirectoryName(Directory.GetCurrentDirectory()));

        }




        public void preCargar()
        {

            string[] dirFondo = Directory.GetFiles(directorio+ "\\resources\\Yugioh backgrounds");
            foreach (string dir in dirFondo)
            {

                Image img = Image.FromFile(dir);
                listaFondos.Add(img);

            }

            string[] dirCartas = Directory.GetFiles(directorio + "\\resources\\Cartas Yugioh");
            foreach (string dir in dirCartas)
            {
                Image card = Image.FromFile(dir);

                listaCartas.Add(card);

            }

        }

        public void cargar()
        {


            int cantidadCartas = listaCartas.Count;
            var children = campo.Panel2.Controls.OfType<Control>();
            int idCarta = 0;
            foreach (Carta c in children)
            {
                idCarta++;
               
                c.id = idCarta;
                c.imagenVolteada = Image.FromFile(directorio + "\\resources\\yugi.png");
                Random rnd = new Random();
                int cual = rnd.Next(cantidadCartas); // 
                c.imagenMonstruo = listaCartas[cual];

                c.BackgroundImageLayout = ImageLayout.Stretch;
                c.Anchor = AnchorStyles.None;
                c.BackgroundImage = c.imagenVolteada;
                



            }

        }


      

        public void iniciarlizar()
        {

            campo.IsSplitterFixed = true;
            campo.BorderStyle = BorderStyle.Fixed3D;
            campo.Panel1.BackColor = Color.Gray;
            campo.Panel2.BackgroundImageLayout = ImageLayout.Stretch;
            campo.Panel2.BackgroundImage = listaFondos[0];

            oponente = new Oponente();

        }




        public int validar(Carta uno, Carta dos, int contCarta)
        {

            oponente.cartasVistas.Add(uno);
            oponente.cartasVistas.Add(dos);

            if (dos.id != uno.id)
            {

                if (uno.imagenMonstruo == dos.imagenMonstruo)
                {
                    contadorj2 += 1;
                    // MessageBox.Show("Bien!");


                    uno.destruir();
                    dos.destruir();


                    oponente.cartasVistas.Remove(uno);
                    oponente.cartasVistas.Remove(dos);


                    Form1.nj2.Text = contadorj2.ToString();

                }
                else
                {

                    // MessageBox.Show("Mal!");



                    uno.voltear();
                    dos.voltear();

                    uno.volteada = false;
                    dos.volteada = false;
                   
                    Form1.opo.Start();
                    Form1.juego.campo.Panel2.Enabled = false;
                }

                contCarta = 0;

            }
            else
            {
                contCarta = 1;
                MessageBox.Show("Selecione una carta diferente!");
            }


            return contCarta;

        }


        public void cambiarFondoPantalla()
        {

            int cantidad = listaFondos.Count;
            Random rnd = new Random();
            int cual = rnd.Next(cantidad);
            campo.Panel2.BackgroundImage = listaFondos[cual];

        }


        public int validarOponente(Carta uno, Carta dos, int contCarta)
        {

            oponente.cartasVistas.Add(uno);
            oponente.cartasVistas.Add(dos);

            if (dos.id != uno.id)
            {

                if (uno.imagenMonstruo == dos.imagenMonstruo)
                {

                    contadorj1 += 1;
                    // MessageBox.Show("Bien!");

                    uno.destruir();
                    dos.destruir();

                    oponente.cartasVistas.Remove(uno);
                    oponente.cartasVistas.Remove(dos);

                    Form1.nj1.Text = contadorj1.ToString();
                    

                }
                else
                {

                    // MessageBox.Show("Mal!");

                    uno.voltear();
                    dos.voltear();

                    uno.volteada = false;
                    dos.volteada = false;
                   
                    Form1.opo.Stop();
                    Form1.juego.campo.Panel2.Enabled = true;

                }

                contCarta = 0;

            }
            else
            {
                contCarta = 1;
                
            }


            return contCarta;

        }

    }
}
