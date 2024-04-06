using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blackjack_GUI_temp1
{
    public struct Card
    {
        public Card(string constsuit, string constface)
        {
            Suit = constsuit;

            Face = constface;

        }
        public string Suit { get; set; }
        public string Face { get; set; }

    }

    public class Deck
    {
        public Deck()
        {
            String[] suitlist = new string[] { "spades", "diamonds", "clubs", "hearts" };
            String[] facelist = new string[] { "1", "2", "3", "4", "5", "6", "7", "8", "9", "10", "J", "Q", "K" };
            int slotsleft = 52;
            int location;
            int i;
            Random rng = new Random();

            foreach (string suit in suitlist)
            {
                foreach (string face in facelist)
                {
                    location = rng.Next(slotsleft--);
                    i = -1;

                    while (location != -1)
                    {
                        ++i;
                        if (cardlist[i].Suit == null)
                        {
                            --location;
                        }


                    }
                    Console.WriteLine(suit + "_" + face + ", " + i);
                    cardlist[i] = new Card(suit, face);
                }

            }




        }
        private Card[] cardlist = new Card[52];
        public int topcard = 51;

        public Card Draw()
        {
            if (topcard != -1)
            {
                return cardlist[topcard--];
            }
            else
            {
                return new Card(null, null);
            }

        }
    }

    public class Hand
    {
        public Hand()
        {
        }
        public Card[] cardlist = new Card[8];
        int nextempty = 0;

        public void DrawFrom(Deck gamedeck)
        {
            if (nextempty != 8)
            {
                cardlist[nextempty++] = gamedeck.Draw();
            }
        }

        public int sum()
        {
            int runningTotal = 0;
            int aceCount = 0;

            for (int i = 0; i < cardlist.Length; i++)
            {
                switch (cardlist[i].Face)
                {
                    case "1":
                        aceCount += 1;
                        break;
                    case "2":
                        runningTotal += 2;
                        break;
                    case "3":
                        runningTotal += 3;
                        break;
                    case "4":
                        runningTotal += 4;
                        break;
                    case "5":
                        runningTotal += 5;
                        break;
                    case "6":
                        runningTotal += 6;
                        break;
                    case "7":
                        runningTotal += 7;
                        break;
                    case "8":
                        runningTotal += 8;
                        break;
                    case "9":
                        runningTotal += 9;
                        break;
                    case "10":
                    case "J":
                    case "Q":
                    case "K":
                        runningTotal += 10;
                        break;
                }
            }
            if ((10 - runningTotal) >= (aceCount - 1))
            {
                runningTotal += 11 + (aceCount - 1);
            }
            else
            {
                runningTotal += aceCount;
            }
            return runningTotal;
        }
    }



}
