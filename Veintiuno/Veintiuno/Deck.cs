using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Veintiuno {
    
    /*
     * Clase que contiene los metodos para crear mazos de cartas
     * y barajearlos.
     */
    class Deck {

        public Deck() {

            InicializarDeck();


        }


        private void CrearCartasDelPalo(ref int contador, ref Carta[] Mazo, Suit elSuit)
        {
            Mazo[contador++] = new Carta("A", elSuit);
            for (int i = 2; i <= 10; i++)
            {
                Mazo[contador++] = new Carta(i, elSuit);
            }
            Mazo[contador++] = new Carta("J", elSuit);
            Mazo[contador++] = new Carta("Q", elSuit);
            Mazo[contador++] = new Carta("K", elSuit);
        }
        public void InicializarDeck()
        {
            int contador = 0;
            Carta[] Mazo = new Carta[52];
            CrearCartasDelPalo(ref contador,ref Mazo,Suit.Hearts);
            CrearCartasDelPalo(ref contador, ref Mazo, Suit.Diamonds);
            CrearCartasDelPalo(ref contador, ref Mazo, Suit.Clubs);
            CrearCartasDelPalo(ref contador, ref Mazo, Suit.Spades);

            Barajar(Mazo);
        }

        public Carta[] Barajar(Carta[] Mazo) 
        { var rand = new Random();
            Carta[] Mazo2 = new Carta[52];
            int contador = 51;
            while (Mazo.Length != 0)
                {
                int numero = rand.Next(0, 52);
                while (Mazo[numero] != null)

                {
                    
                    Array.Copy(Mazo, numero, Mazo2, contador--, 1);
                    Array.Clear(Mazo, numero,1);
                }       
            }

            for (int i = 2; i <= Mazo2.Length; i++)
            {
                Console.WriteLine(Mazo2[i]);
            }

            Console.WriteLine();
            return Mazo2;
        }
    }
}
