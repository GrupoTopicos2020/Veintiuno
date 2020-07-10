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

        /*public static int sumadeCarta(Carta carta)
        {


            return;
        }*/ 





    }
}
