﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Reflection;
using System.Resources;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Blackjack_GUI_temp1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
        start:

            InitializeComponent();

            rm = Properties.Resources.ResourceManager;

            button1.Visible = false;
            button2.Visible = false;

            game = new Game();

            addtoPicturebox(game.playerhand.cardlist[0], playerbox0);
            addtoPicturebox(game.playerhand.cardlist[1], playerbox1);
            addtoPicturebox(game.dealerhand.cardlist[0], dealerbox0);
            addtoPicturebox(new Card(null, null), dealerbox1);
            playercardcount = 2;
            dealercardcount = 2;

            if (game.playerhand.sum() == 21)
            {
                Application.Run(new GameEndDialog("Blackjack! You win!"));
                goto start;
            }
            else if (game.dealerhand.sum() == 21)
            {
                Application.Run(new GameEndDialog("Dealer wins by blackjack."));
                goto start;
            }

            button1.Visible = true;
            button2.Visible = true;




        }

        private void button1_Click(object sender, EventArgs e)
        {
            hit(game.playerhand);
            ++playercardcount;
            updatePictureBoxes();
            int temp = game.playerhand.sum();

            if (temp == 21)
            {
                this.Hide();
                GameEndDialog di = new GameEndDialog("21! You win!");
                di.ShowDialog();
                this.Close();
            }
            else if (temp > 21)
            {
                this.Hide();
                GameEndDialog di = new GameEndDialog("Bust! You lose!");
                di.ShowDialog();
                this.Close();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            addtoPicturebox(game.dealerhand.cardlist[1], dealerbox1);
            while (game.playerhand.sum() > game.dealerhand.sum())
            {
                Thread.Sleep(1000);
                
                hit(game.dealerhand);
                dealercardcount++;
                updatePictureBoxes();
                
            }

            if(game.dealerhand.sum() > 21)
            {
                this.Hide();
                GameEndDialog di = new GameEndDialog("The dealer has busted!");
                di.ShowDialog();
                this.Close();
            }
            else if (game.dealerhand.sum() > game.playerhand.sum())
            {
                this.Hide();
                GameEndDialog di = new GameEndDialog("The dealer wins!");
                di.ShowDialog();
                this.Close();
            }
            else
            {
                this.Hide();
                GameEndDialog di = new GameEndDialog("A push! Nobody wins!");
                di.ShowDialog();
                this.Close();
            }


        }


        public void addtoPicturebox(Card card, PictureBox picturebox)
        {
            if (card.Suit == null)
            {
                picturebox.Image = Properties.Resources.cardback;
            }
            else
            {
                string cardname = card.Suit + "_" + card.Face;

                picturebox.Image = (Image)rm.GetObject(cardname);
            }

        }

        public void updatePictureBoxes()
        {
            switch (playercardcount)
            {
                case 8:
                    addtoPicturebox(game.playerhand.cardlist[7], playerbox7);
                    goto case 7;
                case 7:
                    addtoPicturebox(game.playerhand.cardlist[6], playerbox6);
                    goto case 6;
                case 6:
                    addtoPicturebox(game.playerhand.cardlist[5], playerbox5);
                    goto case 5;
                case 5:
                    addtoPicturebox(game.playerhand.cardlist[4], playerbox4);
                    goto case 4;
                case 4:
                    addtoPicturebox(game.playerhand.cardlist[3], playerbox3);
                    goto case 3;
                case 3:
                    addtoPicturebox(game.playerhand.cardlist[2], playerbox2);
                    break; ;

            }

            switch (dealercardcount)
            {
                case 8:
                    addtoPicturebox(game.dealerhand.cardlist[7], dealerbox7);
                    goto case 7;
                case 7:
                    addtoPicturebox(game.dealerhand.cardlist[6], dealerbox6);
                    goto case 6;
                case 6:
                    addtoPicturebox(game.dealerhand.cardlist[5], dealerbox5);
                    goto case 5;
                case 5:
                    addtoPicturebox(game.dealerhand.cardlist[4], dealerbox4);
                    goto case 4;
                case 4:
                    addtoPicturebox(game.dealerhand.cardlist[3], dealerbox3);
                    goto case 3;
                case 3:
                    addtoPicturebox(game.dealerhand.cardlist[2], dealerbox2);
                    break; ;

            }
        }

        public void hit(Hand hand)
        {
            hand.DrawFrom(game.gamedeck);
        }

        Game game;
        ResourceManager rm;
        int playercardcount;
        int dealercardcount;
        
    }
}
