using System.Drawing;
using System.Windows.Forms;
using System;
using System.Linq;
using System.Threading.Tasks;


namespace Game
{
    public class Carta : PictureBox
    {


        public Image imagenMonstruo { get; set; }
        public Image imagenVolteada { get; set; }
        public int id { get; set; }
        public bool volteada;
        public bool vista;
        public bool clickable { get; set; }


        public Carta()
        {

            
            clickable = true;
            vista = false;
            volteada = false;
            imagenMonstruo = null;
            imagenVolteada = null;
            id = 0;
        }


        public void voltear()
        {

            BackgroundImage = imagenVolteada;

        }


        public void mostrar()
        {

            BackgroundImage = imagenMonstruo;

        }


        public void destruir()
        {

            Dispose();

        }

    }
}
