using System;
using System.Collections.Generic;
using System.Text;


namespace Veintiuno {


    /*
     * Jugadores en el juego.
     */
    class Player {



        public string namePlayer { get; set; }

        public int score { get; set; }

        public int numberPlayer { get; set; }

        public int home { get; set; }

        public Player(string namePlayer, int score, int numberPlayer, int home)
        {
            this.namePlayer = namePlayer;
            this.score = score;
            this.numberPlayer = numberPlayer;
            this.home = home;

        }

        public static int sumadeCarta(Carta carta)
        {
            int Resultado = 0;
            Carta carta1 = new Carta(0,"",0);
            //carta1.ValorCarta = 0;

            Carta carta2 = new Carta(0,"",0);
            //carta2.ValorCarta = 0;

            Carta carta3 = new Carta(0,"",0);
            //carta3.ValorCarta = 0;
            
            Carta carta4 = new Carta(0,"",0);
            //carta4.ValorCarta = 0;

            Resultado = carta1.ValorCarta + carta2.ValorCarta + carta3.ValorCarta + carta4.ValorCarta;



            return Resultado;
        } 





    }
}
