using System;
using System.Collections.Generic;
using System.Text;

namespace Veintiuno {

    /*
     * Clase que crea una carta y sus valores solamente.
     */
    class Carta {


        public string NumeroCarta { get; set; }
        public int ValorCarta { get; set; }
        public Suit ElSuit { get; set; }
        public char suit { get; set; }

        public Carta(int numerocarta, Suit elSuit) {
            ElSuit = elSuit;
            ValorCarta = numerocarta;
            if (2 <= numerocarta && numerocarta <= 9)
                NumeroCarta = numerocarta.ToString();
        }

        public Carta(string numerocarta, Suit elSuit) {

            this.NumeroCarta = numerocarta;
            this.ElSuit = elSuit;
            if (NumeroCarta == "J" || NumeroCarta == "Q" || NumeroCarta == "K")
                this.ValorCarta = 10;
            if ('2' <= NumeroCarta[0] && NumeroCarta[0] <= '9')
                this.ValorCarta = (int)NumeroCarta[0];
            if (NumeroCarta == "A")
                this.ValorCarta = 11;
        }

        /*
         * Numero es el numero o la letra.
         * Constructor principal para crear el deck.
         */
        public Carta(string num, char suit) {
            this.NumeroCarta = num;
            this.suit = suit;
            if (NumeroCarta == "J" || NumeroCarta == "Q" || NumeroCarta == "K") {
                this.ValorCarta = 10;
            } else if (NumeroCarta == "A") {
                this.ValorCarta = 11;
            } else {
                this.ValorCarta = int.Parse(NumeroCarta);
            }
        }

        public Carta(string num) {
            this.NumeroCarta = num;
            if (NumeroCarta == "J" || NumeroCarta == "Q" || NumeroCarta == "K") {
                this.ValorCarta = 10;
            } else if (NumeroCarta == "A") {
                this.ValorCarta = 11;
            } else {
                this.ValorCarta = int.Parse(NumeroCarta);
            }
        }

        /*
         * Usado para imprimir las cartas con mas facilidad.
         */
        public string PrintCarta() {
            return "[" + this.NumeroCarta + "|" + this.suit + "]"; 
        }

    }
}

