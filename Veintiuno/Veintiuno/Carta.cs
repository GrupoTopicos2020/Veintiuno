using System;
using System.Collections.Generic;
using System.Text;

namespace Veintiuno {
    
    /*
     * Clase que crea una carta y sus valores solamente.
     */
    class Carta {

        public enum SuitCarta
            {
                Hearts,
                Spades,
                Clubs,
                Diamonds
            }
        public string NumeroCarta { get; set; }

        public readonly SuitCarta suit;

        public int ValorCarta { get; set; }
       
        
        public Carta(SuitCarta suitcarta, string numerocarta, int valorcarta) 
            {

            this.NumeroCarta = numerocarta;
            this.suit = suitcarta;
            this.ValorCarta = valorcarta;  

            }

        public int AsignacionValor(Carta carta)
        {

            if (carta.NumeroCarta == "J" | carta.NumeroCarta == "Q" | carta.NumeroCarta == "K")
            {
                return carta.ValorCarta = 10;

            }
            else
                {
                int valor = 0;

                int.TryParse(carta.NumeroCarta, out valor);
                carta.ValorCarta = valor;

                return carta.ValorCarta;
                }
            }


        }
    }

