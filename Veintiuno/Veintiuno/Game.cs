using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Security.Cryptography.X509Certificates;
using System.Text;

namespace Veintiuno {
    
    /*
     * Clase que contiene la logica del juego.
     */
    class Game {

        bool isRunning = false;

        List<Player> players = new List<Player>();
        Player dealer = new Player("Dealer");
        public Deck cartas = new Deck();

        /*
         * Clase con la logica.
         */
        public Game() {

            Console.Clear();
            Console.WriteLine("//Juego ejecutandose");

            isRunning = true;

            AgregarPlayers();

            Console.Clear();
            Console.WriteLine("JUEGO COMENZADO\n\n");


            //Partidas.
            while (isRunning) {

                //Repartiendo cartas.
                foreach (Player x in players) {
                    x.AgregarCartas(cartas.DarCarta());
                    x.AgregarCartas(cartas.DarCarta());
                }

                dealer.AgregarCartas(cartas.DarCarta());
                dealer.AgregarCartas(cartas.DarCarta());


                //Turno de cada jugador.
                foreach (Player x in players) {

                    if (x.jugando == true) {
                        Console.Clear();

                        Console.WriteLine("DEALER");
                        Console.Write("Mano: ");
                        dealer.PrintDealer();

                        Console.WriteLine("\n\nTURNO DE " + x.name + "\n");

                        Console.Write("Mano: ");
                        x.PrintMano();
                        x.CheckSuma();

                        Console.WriteLine("Que desea hacer?");
                        Console.WriteLine("(A) PEDIR");
                        Console.WriteLine("(B) QUEDARSE\n(Podras seguir pidiendo con A o detenerte con B)");

                        while (x.jugando) {

                            string user = Console.ReadLine();

                            if (user == "a") {
                                Console.WriteLine("PIDIENDO CARTA\n");

                                x.AgregarCartas(cartas.DarCarta());
                                Console.Write("Mano: ");
                                x.PrintMano();
                                x.CheckSuma();

                                if (x.jugando == false) {
                                    break;
                                }

                            } else if (user == "b") {
                                x.jugando = false;
                                break;
                            }

                        }

                        Console.ReadLine();
                    
                    } else {
                        Console.WriteLine(x.name + " HA SIDO ELIMINADO!");
                    }

                }

                while (dealer.jugando) {
                    Console.Clear();
                    Console.WriteLine("\n\nTURNO DEL DEALER\n");
                    dealer.PrintMano();
                    dealer.CheckSuma();

                    if (dealer.suma < 17) {
                        dealer.AgregarCartas(cartas.DarCarta());
                        for (int i = 0; i < 3; i++) {
                            Console.Write(". ");
                            System.Threading.Thread.Sleep(1500);
                        }
                    } else {
                        dealer.jugando = false;
                    }

                    System.Threading.Thread.Sleep(2000);


                }

                GetGanadores();
                Console.ReadLine();

                Console.Clear();
                Console.WriteLine("Volver a jugar? (s / n)");

                string input = Console.ReadLine();

                if (input == "s") {
                    Reiniciar();
                } else if (input == "n") {
                    isRunning = false;
                    break;
                }


            }
        }

        public void GetGanadores() {
            Console.Clear();
            Console.WriteLine("Jugadores: ");

            //Revisar por 21.
            foreach (Player x in players) {
                if (x.suma == 21) {
                    x.PrintPlayerInfo();
                }
            }
            if (dealer.suma == 21) {
                dealer.PrintPlayerInfo();
            }

            //Revisar por orden.
            int score = 0;
            foreach (Player x in players) {
                if (x.suma > score && x.suma < 22) {
                    score = x.suma;
                }
            }
            if (dealer.suma > score && dealer.suma < 22) {
                score = dealer.suma;
            }

            foreach (Player x in players) {
                if (x.suma == score) {
                    Console.WriteLine(x.name + " HA GANADO!");
                } else if (x.suma != score) {
                    Console.WriteLine(x.name + " HA PERDIDO!");
                }
            }
            if (dealer.suma == score) {
                Console.WriteLine(dealer.name + " HA GANADO!");
            } else if (dealer.suma != score) {
                Console.WriteLine(dealer.name + " HA PERDIDO!");
            }
            




            Console.WriteLine("\n\nInfo:");
            dealer.PrintPlayerInfo();

            foreach (Player x in players) {
                x.PrintPlayerInfo();
            }
            
        }

        public void Reiniciar() {


            dealer.suma = 0;
            cartas.mazoUsado.AddRange(dealer.mano);
            dealer.mano.Clear();
            dealer.jugando = true;

            foreach (Player x in players) {
                x.suma = 0;
                cartas.mazoUsado.AddRange(x.mano);
                x.mano.Clear();
                x.jugando = true;
            }

            cartas.Barajear();
        }

        public void AgregarPlayers() {

            Console.Clear();
            Console.WriteLine("AGREGANDO JUGADORES");

            while (true) {

                Console.Write("Nombre: ");
                string nombre = Console.ReadLine();
                Console.WriteLine();

                players.Add(new Player(nombre));

                Console.WriteLine("Agregar otro jugador? (s / n)");
                char input = char.Parse(Console.ReadLine());

                if (input != 's') {
                    break;
                }

            }
        }



    }
}
