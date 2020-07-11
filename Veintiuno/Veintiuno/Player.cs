using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace Veintiuno {


    /*
     * Jugadores en el juego.
     */
    class Player {

        public string name { get; set; }

        public int number { get; set; }

        public List<Carta> mano = new List<Carta>(); //La mano de cada jugador.
        public bool jugando = true;
        public int suma = 0;



        public Player(string namePlayer)
        {
            this.name = namePlayer;
        }
        
        public void AgregarCartas(Carta x) {
            mano.Add(x);
            suma += x.ValorCarta;
        }


        public void CheckSuma() {
            if (suma > 21) {
                if (mano.Contains(new Carta("A"))) {
                    suma -= 10;
                }

                this.jugando = false;
                Console.WriteLine(name + " SE HA PASADO!");
            } else if (suma == 21) {
                this.jugando = false;
                Console.WriteLine(name + " TIENE 21!");
            }
        }


        public void PrintMano() {
            foreach (Carta x in mano) {
                Console.Write(x.PrintCarta() + " ");
            }
            Console.WriteLine("\nSuma: " + suma + "\n");
            
        }

        /*
         * OPTIMIZAR
         */
        public void PrintDealer() {
            Console.WriteLine(mano.ElementAt(0).PrintCarta() + " " + "[?|?]");
        }

        public void PrintPlayerInfo() {
            Console.WriteLine("\n\n[Nombre] " + name + "\n[Suma] " + suma);
        }



        public static int sumadeCarta(Carta carta)
        {
            int Resultado = 0;
            //Carta carta1 = new Carta(0,"",0);
            ////carta1.ValorCarta = 0;

            //Carta carta2 = new Carta(0,"",0);
            ////carta2.ValorCarta = 0;

            //Carta carta3 = new Carta(0,"",0);
            ////carta3.ValorCarta = 0;
            
            //Carta carta4 = new Carta(0,"",0);
            ////carta4.ValorCarta = 0;

            //Resultado = carta1.ValorCarta + carta2.ValorCarta + carta3.ValorCarta + carta4.ValorCarta;


            return Resultado;
        } 





    }
}
