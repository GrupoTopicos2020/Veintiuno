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

        public List<Carta> mazo = new List<Carta>(); //Mazon resultante.
        public List<Carta> mazoUsado = new List<Carta>();


        /*
         * Constructor que se usa siempre que se quiera inicializar el mazo.
         */
        public Deck() {
            CrearMazo();
            Barajear();
        }


        /*
         * Combinacion para un mazo completo de 52 cartas.
         */
        public void CrearMazo() {
            char[] suits = { 'D', 'C', 'T', 'P' };
            string[] nums = { "A", "2", "3", "4", "5", "6", "7", "8", "9", "10", "J", "Q", "K" };

            for (int s = 0; s < suits.Length; s++) {

                for (int n = 0; n < nums.Length; n++) {

                    mazo.Add(new Carta(nums[n], suits[s]));

                }

            }

            //Remover su uso en memoria.
            suits = null; 
            nums = null;

        }


        /*
         * Intercambio sencillo de cartas. 
         */
        public void Barajear() {
            List<Carta> tmp = new List<Carta>(); //Lista temporal

            mazo.AddRange(mazoUsado); //Agregando las cartas usadas de vuelta al mazo para volver a barajear.

            //Agregar una carta aleatoria, sacarla del mazo y meterlo en tmp.
            for (int i = 0; i < 52; i++) {
                int rand = new Random().Next(0, mazo.Count());

                tmp.Add(mazo.ElementAt(rand));
                mazo.RemoveAt(rand);
            }

            mazo.AddRange(tmp); //Meter todas las cartas de tmp en el mazo.
            tmp = null; //Liberar espacio en memoria.

        }

        public Carta DarCarta() {
            Carta x = mazo.ElementAt(0);
            mazo.RemoveAt(0);

            return x;
        }

        public void PrintMazo() {
            foreach (Carta x in mazo) {
                Console.WriteLine(x.PrintCarta());
            }
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
