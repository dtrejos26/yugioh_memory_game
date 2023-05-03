using System;

using System.Drawing;

using System.Linq;

using System.Threading.Tasks;
using System.Windows.Forms;

namespace Game
{
    public partial class Form1 : Form
    {
       
        private int cont;   
        private Carta uno;
        private Carta dos;
        private int contCarta;      
        public static Juego juego;
        public static Timer opo;

        public static NumericUpDown nj1;
        public static NumericUpDown nj2;


        public Form1()
        {
                 
            cont = 0;
            InitializeComponent();
            juego = new Juego(splitContainer1);

            juego.preCargar();

            



        }

        private void Form1_Load(object sender, EventArgs e)
        {

            juego.iniciarlizar();            
            opo = timer3;

            nj1 = numericUpDown1;
            nj2 = numericUpDown2;

            
        }



        private async void eventoClickCarta(object sender, EventArgs e)
        {
            contCarta++;

            
            Carta pb = (Carta)sender;

            pb.vista = true;
            pb.mostrar();

            pbVistaPrevia.BackgroundImage = pb.imagenMonstruo;
            pb.volteada = true;



            if (timer3.Enabled)
            {
                
                if (contCarta == 1)
                {
                    uno = pb;

                }
                else if (contCarta == 2)
                {

                    dos = pb;
                    await Task.Delay(1000);   // ESPERA 1 SEGUNDO ANTES DE VERIFICAR, ESTO ES PARA QUE SE VEA MEJOR VISUALMENTE
                    contCarta = juego.validarOponente(uno, dos, contCarta);


                }



            }
            else
            {

                if (contCarta == 1)
                {
                    uno = pb;

                }
                else if (contCarta == 2)
                {

                    dos = pb;
                    await Task.Delay(1000);   // ESPERA 1 SEGUNDO ANTES DE VERIFICAR, ESTO ES PARA QUE SE VEA MEJOR VISUALMENTE
                    contCarta = juego.validar(uno, dos, contCarta);


                }

                



            }


        }



        private void timer1_Tick(object sender, EventArgs e)
        {
            cont++;
            lbTimer.Text = cont.ToString();


        }


        private void timer2_Tick(object sender, EventArgs e)
        {

            juego.cambiarFondoPantalla();

        }


        private void button4_Click(object sender, EventArgs e)
        {
            agregarEventos();
            juego.cargar();

            
           

        }

        private void button3_Click(object sender, EventArgs e)
        {


            DialogResult resultado = openFileDialog1.ShowDialog();

            if (resultado == DialogResult.OK)
            {

                Image fondoPantalla = Image.FromFile(openFileDialog1.FileName);

                lbFotoJugador.BackgroundImage = fondoPantalla;
            }


        }


        public void infoCarta(object sender, EventArgs e)
        {

            

            Carta pb = (Carta)sender;


            if (pb.volteada == false)
            {

                pbVistaPrevia.BackgroundImage = null;

            }else
            {

                pbVistaPrevia.BackgroundImage = pb.imagenMonstruo;
            }

            

        }
        


        private void agregarEventos()
        {

            var children = splitContainer1.Panel2.Controls.OfType<Control>();
           
            foreach (Carta p in children)
            {
       
               
                p.Click += this.eventoClickCarta;
                p.MouseHover += this.infoCarta;

            

            }

        }

        private void button1_Click(object sender, EventArgs e)
        {

            Close();


        }

        

        private void timer3_Tick(object sender, EventArgs e)
        {

            var children = splitContainer1.Panel2.Controls.OfType<Control>();


            int cantidad = children.Count<Control>();
            Random rnd = new Random();
            int cual = rnd.Next(cantidad);

            Control c = children.ElementAt(cual);

            if(c.Visible)
            {

                juego.oponente.escogerCarta((Carta)c);

            }else
            {

                return;
            }

            


        }

        private void splitContainer1_Panel2_Paint(object sender, PaintEventArgs e)
        {

        }
    }   


}
