﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Notifications;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Media.Imaging;
using Windows.UI.Xaml.Navigation;
using YuGhiOhBattleHandler;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace YuGhiOhTester
{

    public enum CurrentlySelectedCardType
    {
        Hand,
        Monster,
        None
    }

    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        public static Random rand = new Random();
        private Player me;
        private Object myCurrentlySelectedCard;
        private StackPanel myCurrentlySelectedStackPanel;
        private BitmapImage cardBack;
        private CurrentlySelectedCardType currentlySelectedCardType;
        //Normally both Player1 and Player 2 would not be stored by the users.
        private Player p1;
        private Player p2;

        public MainPage()
        {
            this.InitializeComponent();

            //Here is where code should go to build personal Decks. For now we make a random deck (first 40 cards in database).
            //Both players will use the same deck for this test app.
            MainDeckBuilder mdb = new MainDeckBuilder();
            List<Object> randomDeck = mdb.getRandomDeck() as List<Object>;
            List<Object> randomSideDeck = new List<Object>();
            List<Object> randomExtraDeck = new List<Object>();

            //Initialize Card Back
            cardBack = mdb.getCardBack();

            //Build the players just like a Network Manager would do.
            int random1 = rand.Next();
            int random2 = rand.Next();
            int randomGameId = rand.Next();
            p1 = new Player(random1, "SethRocks!");
            p2 = new Player(random2, "BobSucks!");

            //Now the network manager would give a handle to the users and to the game.
            //Since this is just for testing we will control both players from this one class.
            Game g = new Game(p1, p2, randomGameId);
            if (g.RequestSetPlayer1Deck(randomDeck, randomSideDeck, randomExtraDeck) && g.RequestSetPlayer2Deck(randomDeck, randomSideDeck, randomExtraDeck))
            {
                g.StartGame();
                MyUserName.Text = p1.getUsername();
                OpponentUsernameBlock.Text = p2.getUsername();

                //Normally only the game and corresponding player will be able to use the get hand function
                //because they will be the only entities which have a handle to the player
                me = p1;
                List<Object> hand = me.getHand() as List<Object>;
                for (int i = 0; i < hand.Count; i++)
                {
                    placeHandCardOnGUI(hand[i], i);
                }
                collapseUnused();
            }
        }

        private void collapseUnused()
        {
            if (MyHandOneImage.Source == null)
            {
                MyHandOneZone.Visibility = Visibility.Collapsed;
            }
            else
            {
                MyHandOneZone.Visibility = Visibility.Visible;
            }
            if (MyHandTwoImage.Source == null)
            {
                MyHandTwoZone.Visibility = Visibility.Collapsed;
            }
            else
            {
                MyHandTwoZone.Visibility = Visibility.Visible;
            }
            if (MyHandThreeImage.Source == null)
            {
                MyHandThreeZone.Visibility = Visibility.Collapsed;
            }
            else
            {
                MyHandThreeZone.Visibility = Visibility.Visible;
            }
            if (MyHandFourImage.Source == null)
            {
                MyHandFourZone.Visibility = Visibility.Collapsed;
            }
            else
            {
                MyHandFourZone.Visibility = Visibility.Visible;
            }
            if (MyHandFiveImage.Source == null)
            {
                MyHandFiveZone.Visibility = Visibility.Collapsed;
            }
            else
            {
                MyHandFiveZone.Visibility = Visibility.Visible;
            }
            if (MyHandSixImage.Source == null)
            {
                MyHandSixZone.Visibility = Visibility.Collapsed;
            }
            else
            {
                MyHandSixZone.Visibility = Visibility.Visible;
            }
            if (MyMonsterOneImage.Source == null)
            {
                MyMonsterOneZone.Visibility = Visibility.Collapsed;
            }
            else
            {
                MyMonsterOneZone.Visibility = Visibility.Visible;
            }
            if (MyMonsterTwoImage.Source == null)
            {
                MyMonsterTwoZone.Visibility = Visibility.Collapsed;
            }
            else
            {
                MyMonsterTwoZone.Visibility = Visibility.Visible;
            }
            if (MyMonsterThreeImage.Source == null)
            {
                MyMonsterThreeZone.Visibility = Visibility.Collapsed;
            }
            else
            {
                MyMonsterThreeZone.Visibility = Visibility.Visible;
            }
            if (MyMonsterFourImage.Source == null)
            {
                MyMonsterFourZone.Visibility = Visibility.Collapsed;
            }
            else
            {
                MyMonsterFourZone.Visibility = Visibility.Visible;
            }
            if (MyMonsterFiveImage.Source == null)
            {
                MyMonsterFiveZone.Visibility = Visibility.Collapsed;
            }
            else
            {
                MyMonsterFiveZone.Visibility = Visibility.Visible;
            }
            if (MyMonsterSixImage.Source == null)
            {
                MyMonsterSixZone.Visibility = Visibility.Collapsed;
            }
            else
            {
                MyMonsterSixZone.Visibility = Visibility.Visible;
            }
            if (MySpellOneImage.Source == null)
            {
                MySpellOneZone.Visibility = Visibility.Collapsed;
            }
            else
            {
                MySpellOneZone.Visibility = Visibility.Visible;
            }
            if (MySpellTwoImage.Source == null)
            {
                MySpellTwoZone.Visibility = Visibility.Collapsed;
            }
            else
            {
                MySpellTwoZone.Visibility = Visibility.Visible;
            }
            if (MySpellThreeImage.Source == null)
            {
                MySpellThreeZone.Visibility = Visibility.Collapsed;
            }
            else
            {
                MySpellThreeZone.Visibility = Visibility.Visible;
            }
            if (MySpellFourImage.Source == null)
            {
                MySpellFourZone.Visibility = Visibility.Collapsed;
            }
            else
            {
                MySpellFourZone.Visibility = Visibility.Visible;
            }
            if (MySpellFiveImage.Source == null)
            {
                MySpellFiveZone.Visibility = Visibility.Collapsed;
            }
            else
            {
                MySpellFiveZone.Visibility = Visibility.Visible;
            }
            if (MySpellSixImage.Source == null)
            {
                MySpellSixZone.Visibility = Visibility.Collapsed;
            }
            else
            {
                MySpellSixZone.Visibility = Visibility.Visible;
            }
            if (OppMonsterOneImage.Source == null)
            {
                OppMonsterOneZone.Visibility = Visibility.Collapsed;
            }
            else
            {
                OppMonsterOneZone.Visibility = Visibility.Visible;
            }
            if (OppMonsterTwoImage.Source == null)
            {
                OppMonsterTwoZone.Visibility = Visibility.Collapsed;
            }
            else
            {
                OppMonsterTwoZone.Visibility = Visibility.Visible;
            }
            if (OppMonsterThreeImage.Source == null)
            {
                OppMonsterThreeZone.Visibility = Visibility.Collapsed;
            }
            else
            {
                OppMonsterThreeZone.Visibility = Visibility.Visible;
            }
            if (OppMonsterFourImage.Source == null)
            {
                OppMonsterFourZone.Visibility = Visibility.Collapsed;
            }
            else
            {
                OppMonsterFourZone.Visibility = Visibility.Visible;
            }
            if (OppMonsterFiveImage.Source == null)
            {
                OppMonsterFiveZone.Visibility = Visibility.Collapsed;
            }
            else
            {
                OppMonsterFiveZone.Visibility = Visibility.Visible;
            }
            if (OppMonsterSixImage.Source == null)
            {
                OppMonsterSixZone.Visibility = Visibility.Collapsed;
            }
            else
            {
                OppMonsterSixZone.Visibility = Visibility.Visible;
            }
            if (OppSpellOneImage.Source == null)
            {
                OppSpellOneZone.Visibility = Visibility.Collapsed;
            }
            else
            {
                OppSpellOneZone.Visibility = Visibility.Visible;
            }
            if (OppSpellTwoImage.Source == null)
            {
                OppSpellTwoZone.Visibility = Visibility.Collapsed;
            }
            else
            {
                OppSpellTwoZone.Visibility = Visibility.Visible;
            }
            if (OppSpellThreeImage.Source == null)
            {
                OppSpellThreeZone.Visibility = Visibility.Collapsed;
            }
            else
            {
                OppSpellThreeZone.Visibility = Visibility.Visible;
            }
            if (OppSpellFourImage.Source == null)
            {
                OppSpellFourZone.Visibility = Visibility.Collapsed;
            }
            else
            {
                OppSpellFourZone.Visibility = Visibility.Visible;
            }
            if (OppSpellFiveImage.Source == null)
            {
                OppSpellFiveZone.Visibility = Visibility.Collapsed;
            }
            else
            {
                OppSpellFiveZone.Visibility = Visibility.Visible;
            }
            if (OppSpellSixImage.Source == null)
            {
                OppSpellSixZone.Visibility = Visibility.Collapsed;
            }
            else
            {
                OppSpellSixZone.Visibility = Visibility.Visible;
            }

        }

        private void placeMyMonsterCardsOnGUI()
        {
            List<MonsterCard> faceDownCards = me.getFaceDownCardsInMonsterZone() as List<MonsterCard>;
            List<MonsterCard> faceUpCards = me.getFaceUpMonstersInMonsterZone() as List<MonsterCard>;
            for (int i = 0; i < faceDownCards.Count; i++)
            {
                if (i == 0)
                {
                    MonsterCard c = faceDownCards[i];
                    MyMonsterOneZone.Visibility = Visibility.Visible;
                    MyMonsterOneAttackPoints.Visibility = Visibility.Visible;
                    MyMonsterOneDefensePoints.Visibility = Visibility.Visible;
                    MyMonsterOneAttackPoints.Text = "ATK: " + c.getAttackPoints() + " "+ c.getBattlePosition().ToString();
                    MyMonsterOneDefensePoints.Text = "DEF: " + c.getDefensePoints() + " "+ c.getFace();
                    MyMonsterOneNameBlock.Text = c.getName();
                    MyMonsterOneImage.Source = c.getImage();
                }
                else if (i == 1)
                {
                    MonsterCard c = faceDownCards[i];
                    MyMonsterTwoZone.Visibility = Visibility.Visible;
                    MyMonsterTwoAttackPoints.Visibility = Visibility.Visible;
                    MyMonsterTwoDefensePoints.Visibility = Visibility.Visible;
                    MyMonsterTwoAttackPoints.Text = "ATK: " + c.getAttackPoints() + " " + c.getBattlePosition().ToString();
                    MyMonsterTwoDefensePoints.Text = "DEF: " + c.getDefensePoints() +  " " + c.getFace();
                    MyMonsterTwoNameBlock.Text = c.getName();
                    MyMonsterTwoImage.Source = c.getImage();
                }
                else if (i == 2)
                {
                    MonsterCard c = faceDownCards[i];
                    MyMonsterThreeZone.Visibility = Visibility.Visible;
                    MyMonsterThreeAttackPoints.Visibility = Visibility.Visible;
                    MyMonsterThreeDefensePoints.Visibility = Visibility.Visible;
                    MyMonsterThreeAttackPoints.Text = "ATK: " + c.getAttackPoints() + " " + c.getBattlePosition().ToString();
                    MyMonsterThreeDefensePoints.Text = "DEF: " + c.getDefensePoints() + " " + c.getFace();
                    MyMonsterThreeNameBlock.Text = c.getName();
                    MyMonsterThreeImage.Source = c.getImage();
                }
                else if (i == 3)
                {
                    MonsterCard c = faceDownCards[i];
                    MyMonsterFourZone.Visibility = Visibility.Visible;
                    MyMonsterFourAttackPoints.Visibility = Visibility.Visible;
                    MyMonsterFourDefensePoints.Visibility = Visibility.Visible;
                    MyMonsterFourAttackPoints.Text = "ATK: " + c.getAttackPoints() + " " + c.getBattlePosition().ToString();
                    MyMonsterFourDefensePoints.Text = "DEF: " + c.getDefensePoints() + " " + c.getFace();
                    MyMonsterFourNameBlock.Text = c.getName();
                    MyMonsterFourImage.Source = c.getImage();
                }
                else if (i == 4)
                {
                    MonsterCard c = faceDownCards[i];
                    MyMonsterFiveZone.Visibility = Visibility.Visible;
                    MyMonsterFiveAttackPoints.Visibility = Visibility.Visible;
                    MyMonsterFiveDefensePoints.Visibility = Visibility.Visible;
                    MyMonsterFiveAttackPoints.Text = "ATK: " + c.getAttackPoints() + " " + c.getBattlePosition().ToString();
                    MyMonsterFiveDefensePoints.Text = "DEF: " + c.getDefensePoints() + " " + c.getFace();
                    MyMonsterFiveNameBlock.Text = c.getName();
                    MyMonsterFiveImage.Source = c.getImage();
                }
                else if (i == 5)
                {
                    MonsterCard c = faceDownCards[i];
                    MyMonsterSixZone.Visibility = Visibility.Visible;
                    MyMonsterSixAttackPoints.Visibility = Visibility.Visible;
                    MyMonsterSixDefensePoints.Visibility = Visibility.Visible;
                    MyMonsterSixAttackPoints.Text = "ATK: " + c.getAttackPoints() + " " + c.getBattlePosition().ToString();
                    MyMonsterSixDefensePoints.Text = "DEF: " + c.getDefensePoints() + " " + c.getFace();
                    MyMonsterSixNameBlock.Text = c.getName();
                    MyMonsterSixImage.Source = c.getImage();
                }
            }
            for (int i = 0; i < faceUpCards.Count; i++)
            {
                if (i + faceDownCards.Count == 0)
                {
                    MonsterCard c = faceUpCards[i];
                    MyMonsterOneZone.Visibility = Visibility.Visible;
                    MyMonsterOneAttackPoints.Visibility = Visibility.Visible;
                    MyMonsterOneDefensePoints.Visibility = Visibility.Visible;
                    MyMonsterOneAttackPoints.Text = "ATK: " + c.getAttackPoints() + " " + c.getBattlePosition().ToString();
                    MyMonsterOneDefensePoints.Text = "DEF: " + c.getDefensePoints() + " " + c.getFace();
                    MyMonsterOneNameBlock.Text = c.getName();
                    MyMonsterOneImage.Source = c.getImage();
                }
                else if (i + faceDownCards.Count == 1)
                {
                    MonsterCard c = faceUpCards[i];
                    MyMonsterTwoZone.Visibility = Visibility.Visible;
                    MyMonsterTwoAttackPoints.Visibility = Visibility.Visible;
                    MyMonsterTwoDefensePoints.Visibility = Visibility.Visible;
                    MyMonsterTwoAttackPoints.Text = "ATK: " + c.getAttackPoints() + " " + c.getBattlePosition().ToString();
                    MyMonsterTwoDefensePoints.Text = "DEF: " + c.getDefensePoints() + " " + c.getFace();
                    MyMonsterTwoNameBlock.Text = c.getName();
                    MyMonsterTwoImage.Source = c.getImage();
                }
                else if (i + faceDownCards.Count == 2)
                {
                    MonsterCard c = faceUpCards[i];
                    MyMonsterThreeZone.Visibility = Visibility.Visible;
                    MyMonsterThreeAttackPoints.Visibility = Visibility.Visible;
                    MyMonsterThreeDefensePoints.Visibility = Visibility.Visible;
                    MyMonsterThreeAttackPoints.Text = "ATK: " + c.getAttackPoints() + " " + c.getBattlePosition().ToString();
                    MyMonsterThreeDefensePoints.Text = "DEF: " + c.getDefensePoints() + " " + c.getFace();
                    MyMonsterThreeNameBlock.Text = c.getName();
                    MyMonsterThreeImage.Source = c.getImage();
                }
                else if (i + faceDownCards.Count == 3)
                {
                    MonsterCard c = faceUpCards[i];
                    MyMonsterFourZone.Visibility = Visibility.Visible;
                    MyMonsterFourAttackPoints.Visibility = Visibility.Visible;
                    MyMonsterFourDefensePoints.Visibility = Visibility.Visible;
                    MyMonsterFourAttackPoints.Text = "ATK: " + c.getAttackPoints() + " " + c.getBattlePosition().ToString();
                    MyMonsterFourDefensePoints.Text = "DEF: " + c.getDefensePoints() + " " + c.getFace();
                    MyMonsterFourNameBlock.Text = c.getName();
                    MyMonsterFourImage.Source = c.getImage();
                }
                else if (i + faceDownCards.Count == 4)
                {
                    MonsterCard c = faceUpCards[i];
                    MyMonsterFiveZone.Visibility = Visibility.Visible;
                    MyMonsterFiveAttackPoints.Visibility = Visibility.Visible;
                    MyMonsterFiveDefensePoints.Visibility = Visibility.Visible;
                    MyMonsterFiveAttackPoints.Text = "ATK: " + c.getAttackPoints() + " " + c.getBattlePosition().ToString();
                    MyMonsterFiveDefensePoints.Text = "DEF: " + c.getDefensePoints() + " " + c.getFace();
                    MyMonsterFiveNameBlock.Text = c.getName();
                    MyMonsterFiveImage.Source = c.getImage();
                }
                else if (i + faceDownCards.Count == 5)
                {
                    MonsterCard c = faceUpCards[i];
                    MyMonsterSixZone.Visibility = Visibility.Visible;
                    MyMonsterSixAttackPoints.Visibility = Visibility.Visible;
                    MyMonsterSixDefensePoints.Visibility = Visibility.Visible;
                    MyMonsterSixAttackPoints.Text = "ATK: " + c.getAttackPoints() + " " + c.getBattlePosition().ToString();
                    MyMonsterSixDefensePoints.Text = "DEF: " + c.getDefensePoints() + " " + c.getFace();
                    MyMonsterSixNameBlock.Text = c.getName();
                    MyMonsterSixImage.Source = c.getImage();
                }
            }

        }

        private void placeHandCardOnGUI(object cardToPlace, int index)
        {
            if (index == 0)
            {
                if (cardToPlace is MonsterCard)
                {
                    MonsterCard c = cardToPlace as MonsterCard;
                    MyHandOneAttackPoints.Visibility = Visibility.Visible;
                    MyHandOneDefensePoints.Visibility = Visibility.Visible;
                    MyHandOneAttackPoints.Text = "ATK: " + c.getAttackPoints() + "";
                    MyHandOneDefensePoints.Text = "DEF: " + c.getDefensePoints() + "";
                    MyHandOneNameBlock.Text = c.getName();
                    MyHandOneImage.Source = c.getImage();
                    MyHandOneDescBlock.Visibility = Visibility.Collapsed;
                }
                else if (cardToPlace is SpellAndTrapCard)
                {
                    SpellAndTrapCard c = cardToPlace as SpellAndTrapCard;
                    MyHandOneAttackPoints.Visibility = Visibility.Collapsed;
                    MyHandOneDefensePoints.Visibility = Visibility.Collapsed;
                    MyHandOneNameBlock.Text = c.getName();
                    MyHandOneImage.Source = c.getImage();
                    MyHandOneDescBlock.Visibility = Visibility.Visible;
                    MyHandOneDescBlock.Text = c.getDescription();
                }
            }
            else if (index == 1)
            {
                if (cardToPlace is MonsterCard)
                {
                    MonsterCard c = cardToPlace as MonsterCard;
                    MyHandTwoAttackPoints.Visibility = Visibility.Visible;
                    MyHandTwoDefensePoints.Visibility = Visibility.Visible;
                    MyHandTwoAttackPoints.Text = "ATK: " + c.getAttackPoints() + "";
                    MyHandTwoDefensePoints.Text = "DEF: " + c.getDefensePoints() + "";
                    MyHandTwoNameBlock.Text = c.getName();
                    MyHandTwoImage.Source = c.getImage();
                    MyHandTwoDescBlock.Visibility = Visibility.Collapsed;
                }
                else if (cardToPlace is SpellAndTrapCard)
                {
                    SpellAndTrapCard c = cardToPlace as SpellAndTrapCard;
                    MyHandTwoAttackPoints.Visibility = Visibility.Collapsed;
                    MyHandTwoDefensePoints.Visibility = Visibility.Collapsed;
                    MyHandTwoNameBlock.Text = c.getName();
                    MyHandTwoImage.Source = c.getImage();
                    MyHandTwoDescBlock.Visibility = Visibility.Visible;
                    MyHandTwoDescBlock.Text = c.getDescription();
                }
            }
            else if (index == 2)
            {
                if (cardToPlace is MonsterCard)
                {
                    MonsterCard c = cardToPlace as MonsterCard;
                    MyHandThreeAttackPoints.Visibility = Visibility.Visible;
                    MyHandThreeDefensePoints.Visibility = Visibility.Visible;
                    MyHandThreeAttackPoints.Text = "ATK: " + c.getAttackPoints() + "";
                    MyHandThreeDefensePoints.Text = "DEF: " + c.getDefensePoints() + "";
                    MyHandThreeNameBlock.Text = c.getName();
                    MyHandThreeImage.Source = c.getImage();
                    MyHandThreeDescBlock.Visibility = Visibility.Collapsed;
                }
                else if (cardToPlace is SpellAndTrapCard)
                {
                    SpellAndTrapCard c = cardToPlace as SpellAndTrapCard;
                    MyHandThreeAttackPoints.Visibility = Visibility.Collapsed;
                    MyHandThreeDefensePoints.Visibility = Visibility.Collapsed;
                    MyHandThreeNameBlock.Text = c.getName();
                    MyHandThreeImage.Source = c.getImage();
                    MyHandThreeDescBlock.Visibility = Visibility.Visible;
                    MyHandThreeDescBlock.Text = c.getDescription();
                }
            }
            else if (index == 3)
            {
                if (cardToPlace is MonsterCard)
                {
                    MonsterCard c = cardToPlace as MonsterCard;
                    MyHandFourAttackPoints.Visibility = Visibility.Visible;
                    MyHandFourDefensePoints.Visibility = Visibility.Visible;
                    MyHandFourAttackPoints.Text = "ATK: " + c.getAttackPoints() + "";
                    MyHandFourDefensePoints.Text = "DEF: " + c.getDefensePoints() + "";
                    MyHandFourNameBlock.Text = c.getName();
                    MyHandFourImage.Source = c.getImage();
                    MyHandFourDescBlock.Visibility = Visibility.Collapsed;
                }
                else if (cardToPlace is SpellAndTrapCard)
                {
                    SpellAndTrapCard c = cardToPlace as SpellAndTrapCard;
                    MyHandFourAttackPoints.Visibility = Visibility.Collapsed;
                    MyHandFourDefensePoints.Visibility = Visibility.Collapsed;
                    MyHandFourNameBlock.Text = c.getName();
                    MyHandFourImage.Source = c.getImage();
                    MyHandFourDescBlock.Visibility = Visibility.Visible;
                    MyHandFourDescBlock.Text = c.getDescription();
                }
            }
            else if (index == 4)
            {
                if (cardToPlace is MonsterCard)
                {
                    MonsterCard c = cardToPlace as MonsterCard;
                    MyHandFiveAttackPoints.Visibility = Visibility.Visible;
                    MyHandFiveDefensePoints.Visibility = Visibility.Visible;
                    MyHandFiveAttackPoints.Text = "ATK: " + c.getAttackPoints() + "";
                    MyHandFiveDefensePoints.Text = "DEF: " + c.getDefensePoints() + "";
                    MyHandFiveNameBlock.Text = c.getName();
                    MyHandFiveImage.Source = c.getImage();
                    MyHandFiveDescBlock.Visibility = Visibility.Collapsed;
                }
                else if (cardToPlace is SpellAndTrapCard)
                {
                    SpellAndTrapCard c = cardToPlace as SpellAndTrapCard;
                    MyHandFiveAttackPoints.Visibility = Visibility.Collapsed;
                    MyHandFiveDefensePoints.Visibility = Visibility.Collapsed;
                    MyHandFiveNameBlock.Text = c.getName();
                    MyHandFiveImage.Source = c.getImage();
                    MyHandFiveDescBlock.Visibility = Visibility.Visible;
                    MyHandFiveDescBlock.Text = c.getDescription();
                }
            }
            else if (index == 5)
            {
                if (cardToPlace is MonsterCard)
                {
                    MonsterCard c = cardToPlace as MonsterCard;
                    MyHandSixAttackPoints.Visibility = Visibility.Visible;
                    MyHandSixDefensePoints.Visibility = Visibility.Visible;
                    MyHandSixAttackPoints.Text = "ATK: " + c.getAttackPoints() + "";
                    MyHandSixDefensePoints.Text = "DEF: " + c.getDefensePoints() + "";
                    MyHandSixNameBlock.Text = c.getName();
                    MyHandSixImage.Source = c.getImage();
                    MyHandSixDescBlock.Visibility = Visibility.Collapsed;
                }
                else if (cardToPlace is SpellAndTrapCard)
                {
                    SpellAndTrapCard c = cardToPlace as SpellAndTrapCard;
                    MyHandSixAttackPoints.Visibility = Visibility.Collapsed;
                    MyHandSixDefensePoints.Visibility = Visibility.Collapsed;
                    MyHandSixNameBlock.Text = c.getName();
                    MyHandSixImage.Source = c.getImage();
                    MyHandSixDescBlock.Visibility = Visibility.Visible;
                    MyHandSixDescBlock.Text = c.getDescription();
                }
            }
        }

        private void MyHandOneZone_Tapped(object sender, TappedRoutedEventArgs e)
        {
            if (myCurrentlySelectedStackPanel == null || (myCurrentlySelectedStackPanel != (sender as StackPanel)))
            {
                if (myCurrentlySelectedStackPanel != null && currentlySelectedCardType == CurrentlySelectedCardType.Hand)
                {
                    myCurrentlySelectedStackPanel.BorderBrush = new SolidColorBrush(Windows.UI.Color.FromArgb(255, 128, 0, 128));
                }
                else if (myCurrentlySelectedCard != null && currentlySelectedCardType == CurrentlySelectedCardType.Monster)
                {
                    myCurrentlySelectedStackPanel.BorderBrush = new SolidColorBrush(Windows.UI.Color.FromArgb(255, 239, 244, 255));
                }
                StackPanel s = sender as StackPanel;
                s.BorderBrush = new SolidColorBrush(Windows.UI.Color.FromArgb(255, 0, 255, 0));
                myCurrentlySelectedCard = me.getHand()[0];
                myCurrentlySelectedStackPanel = s;
                currentlySelectedCardType = CurrentlySelectedCardType.Hand;
            }
            else
            {
                disEngageCurrentlySelected();
            }
        }

        private void MyHandTwoZone_Tapped(object sender, TappedRoutedEventArgs e)
        {
            if (myCurrentlySelectedStackPanel == null || (myCurrentlySelectedStackPanel != (sender as StackPanel)))
            {
                if (myCurrentlySelectedStackPanel != null && currentlySelectedCardType == CurrentlySelectedCardType.Hand)
                {
                    myCurrentlySelectedStackPanel.BorderBrush = new SolidColorBrush(Windows.UI.Color.FromArgb(255, 128, 0, 128));
                }
                else if (myCurrentlySelectedCard != null && currentlySelectedCardType == CurrentlySelectedCardType.Monster)
                {
                    myCurrentlySelectedStackPanel.BorderBrush = new SolidColorBrush(Windows.UI.Color.FromArgb(255, 239, 244, 255));
                }
                StackPanel s = sender as StackPanel;
                s.BorderBrush = new SolidColorBrush(Windows.UI.Color.FromArgb(255, 0, 255, 0));
                myCurrentlySelectedCard = me.getHand()[1];
                myCurrentlySelectedStackPanel = s;
                currentlySelectedCardType = CurrentlySelectedCardType.Hand;
            }
            else
            {
                disEngageCurrentlySelected();
            }
        }

        private void MyHandThreeZone_Tapped(object sender, TappedRoutedEventArgs e)
        {
            if (myCurrentlySelectedStackPanel == null || (myCurrentlySelectedStackPanel != (sender as StackPanel)))
            {
                if (myCurrentlySelectedStackPanel != null && currentlySelectedCardType == CurrentlySelectedCardType.Hand)
                {
                    myCurrentlySelectedStackPanel.BorderBrush = new SolidColorBrush(Windows.UI.Color.FromArgb(255, 128, 0, 128));
                }
                else if (myCurrentlySelectedCard != null && currentlySelectedCardType == CurrentlySelectedCardType.Monster)
                {
                    myCurrentlySelectedStackPanel.BorderBrush = new SolidColorBrush(Windows.UI.Color.FromArgb(255, 239, 244, 255));
                }
                StackPanel s = sender as StackPanel;
                s.BorderBrush = new SolidColorBrush(Windows.UI.Color.FromArgb(255, 0, 255, 0));
                myCurrentlySelectedCard = me.getHand()[2];
                myCurrentlySelectedStackPanel = s;
                currentlySelectedCardType = CurrentlySelectedCardType.Hand;
            }
            else
            {
                disEngageCurrentlySelected();
            }
        }

        private void MyHandFourZone_Tapped(object sender, TappedRoutedEventArgs e)
        {
            if (myCurrentlySelectedStackPanel == null || (myCurrentlySelectedStackPanel != (sender as StackPanel)))
            {
                if (myCurrentlySelectedStackPanel != null && currentlySelectedCardType == CurrentlySelectedCardType.Hand)
                {
                    myCurrentlySelectedStackPanel.BorderBrush = new SolidColorBrush(Windows.UI.Color.FromArgb(255, 128, 0, 128));
                }
                else if (myCurrentlySelectedCard != null && currentlySelectedCardType == CurrentlySelectedCardType.Monster)
                {
                    myCurrentlySelectedStackPanel.BorderBrush = new SolidColorBrush(Windows.UI.Color.FromArgb(255, 239, 244, 255));
                }
                StackPanel s = sender as StackPanel;
                s.BorderBrush = new SolidColorBrush(Windows.UI.Color.FromArgb(255, 0, 255, 0));
                myCurrentlySelectedCard = me.getHand()[3];
                myCurrentlySelectedStackPanel = s;
                currentlySelectedCardType = CurrentlySelectedCardType.Hand;
            }
            else
            {
                disEngageCurrentlySelected();
            }
        }

        private void MyHandFiveZone_Tapped(object sender, TappedRoutedEventArgs e)
        {
            if (myCurrentlySelectedStackPanel == null || (myCurrentlySelectedStackPanel != (sender as StackPanel)))
            {
                if (myCurrentlySelectedStackPanel != null && currentlySelectedCardType == CurrentlySelectedCardType.Hand)
                {
                    myCurrentlySelectedStackPanel.BorderBrush = new SolidColorBrush(Windows.UI.Color.FromArgb(255, 128, 0, 128));
                }
                else if (myCurrentlySelectedCard != null && currentlySelectedCardType == CurrentlySelectedCardType.Monster)
                {
                    myCurrentlySelectedStackPanel.BorderBrush = new SolidColorBrush(Windows.UI.Color.FromArgb(255, 239, 244, 255));
                }
                StackPanel s = sender as StackPanel;
                s.BorderBrush = new SolidColorBrush(Windows.UI.Color.FromArgb(255, 0, 255, 0));
                myCurrentlySelectedCard = me.getHand()[4];
                myCurrentlySelectedStackPanel = s;
                currentlySelectedCardType = CurrentlySelectedCardType.Hand;
            }
            else
            {
                disEngageCurrentlySelected();
            }
        }

        private void MyHandSixZone_Tapped(object sender, TappedRoutedEventArgs e)
        {
            if (myCurrentlySelectedStackPanel == null || (myCurrentlySelectedStackPanel != (sender as StackPanel)))
            {
                if (myCurrentlySelectedStackPanel != null && currentlySelectedCardType == CurrentlySelectedCardType.Hand)
                {
                    myCurrentlySelectedStackPanel.BorderBrush = new SolidColorBrush(Windows.UI.Color.FromArgb(255, 128, 0, 128));
                }
                else if (myCurrentlySelectedCard != null && currentlySelectedCardType == CurrentlySelectedCardType.Monster)
                {
                    myCurrentlySelectedStackPanel.BorderBrush = new SolidColorBrush(Windows.UI.Color.FromArgb(255, 239, 244, 255));
                }
                StackPanel s = sender as StackPanel;
                s.BorderBrush = new SolidColorBrush(Windows.UI.Color.FromArgb(255, 0, 255, 0));
                myCurrentlySelectedCard = me.getHand()[5];
                myCurrentlySelectedStackPanel = s;
                currentlySelectedCardType = CurrentlySelectedCardType.Hand;
            }
            else
            {
                disEngageCurrentlySelected();
            }
        }

        private void disEngageCurrentlySelected()
        {
            if (myCurrentlySelectedStackPanel != null)
            {
                myCurrentlySelectedStackPanel.BorderBrush = new SolidColorBrush(Windows.UI.Color.FromArgb(255, 128, 0, 128));
            }
            myCurrentlySelectedStackPanel = null;
            myCurrentlySelectedCard = null;
            currentlySelectedCardType = CurrentlySelectedCardType.None;
        }

        private void clearHandOnGUI()
        {
            MyHandOneAttackPoints.Visibility = Visibility.Collapsed;
            MyHandOneDefensePoints.Visibility = Visibility.Collapsed;
            MyHandOneAttackPoints.Text = "";
            MyHandOneDefensePoints.Text = "";
            MyHandOneNameBlock.Text = "";
            MyHandOneImage.Source = null;
            MyHandOneDescBlock.Visibility = Visibility.Collapsed;

            MyHandTwoAttackPoints.Visibility = Visibility.Collapsed;
            MyHandTwoDefensePoints.Visibility = Visibility.Collapsed;
            MyHandTwoAttackPoints.Text = "";
            MyHandTwoDefensePoints.Text = "";
            MyHandTwoNameBlock.Text = "";
            MyHandTwoImage.Source = null;
            MyHandTwoDescBlock.Visibility = Visibility.Collapsed;

            MyHandThreeAttackPoints.Visibility = Visibility.Collapsed;
            MyHandThreeDefensePoints.Visibility = Visibility.Collapsed;
            MyHandThreeAttackPoints.Text = "";
            MyHandThreeDefensePoints.Text = "";
            MyHandThreeNameBlock.Text = "";
            MyHandThreeImage.Source = null;
            MyHandThreeDescBlock.Visibility = Visibility.Collapsed;

            MyHandFourAttackPoints.Visibility = Visibility.Collapsed;
            MyHandFourDefensePoints.Visibility = Visibility.Collapsed;
            MyHandFourAttackPoints.Text = "";
            MyHandFourDefensePoints.Text = "";
            MyHandFourNameBlock.Text = "";
            MyHandFourImage.Source = null;
            MyHandFourDescBlock.Visibility = Visibility.Collapsed;

            MyHandFiveAttackPoints.Visibility = Visibility.Collapsed;
            MyHandFiveDefensePoints.Visibility = Visibility.Collapsed;
            MyHandFiveAttackPoints.Text = "";
            MyHandFiveDefensePoints.Text = "";
            MyHandFiveNameBlock.Text = "";
            MyHandFiveImage.Source = null;
            MyHandFiveDescBlock.Visibility = Visibility.Collapsed;

            MyHandSixAttackPoints.Visibility = Visibility.Collapsed;
            MyHandSixDefensePoints.Visibility = Visibility.Collapsed;
            MyHandSixAttackPoints.Text = "";
            MyHandSixDefensePoints.Text = "";
            MyHandSixNameBlock.Text = "";
            MyHandSixImage.Source = null;
            MyHandSixDescBlock.Visibility = Visibility.Collapsed;
        }

        private void MyMonsterZonePanel_Tapped(object sender, TappedRoutedEventArgs e)
        {
            if (myCurrentlySelectedCard != null && currentlySelectedCardType != CurrentlySelectedCardType.Monster)
            {
                if (myCurrentlySelectedCard is MonsterCard)
                {
                    string result = me.NormalSummon(myCurrentlySelectedCard);
                    if (result == "")
                    {
                        disEngageCurrentlySelected();
                        clearMyMonsterCardsOnGUI();
                        placeMyMonsterCardsOnGUI();
                        clearHandOnGUI();
                        List<Object> hand = me.getHand() as List<Object>;
                        for (int i = 0; i < hand.Count; i++)
                        {
                            placeHandCardOnGUI(hand[i], i);
                        }
                    }
                    else
                    {
                        // template to load for showing Toast Notification
                        var xmlToastTemplate = "<toast launch=\"app-defined-string\">" +
                                                 "<visual>" +
                                                   "<binding template =\"ToastGeneric\">" +
                                                     "<text>Can't Summon Monster</text>" +
                                                     "<text>" +
                                                       result +
                                                     "</text>" +
                                                   "</binding>" +
                                                 "</visual>" +
                                               "</toast>";
                        // load the template as XML document
                        var xmlDocument = new Windows.Data.Xml.Dom.XmlDocument();
                        xmlDocument.LoadXml(xmlToastTemplate);
                        ToastNotification toast = new ToastNotification(xmlDocument);
                        ToastNotificationManager.CreateToastNotifier().Show(toast);
                    }
                }
            }
        }
        /*
        private void EndTurnBtn_Tapped(object sender, TappedRoutedEventArgs e)
        {
            me.EndTurn();

            //Do Some Random Action for Player2
            IList<Object> player2Hand = p2.getHand();
            Object toPlay = null;
            for (int i = 0; i < player2Hand.Count; i++)
            {
                if (player2Hand[i] is MonsterCard && (player2Hand[i] as MonsterCard).getLevel() <= 4)
                {
                    toPlay = player2Hand[i];
                    break;
                }
            }
            string result = p2.NormalSummon(toPlay);

            //Update GUI
            if (result == "")
            {
                clearOppMonsterCardsOnGUI();
                placeOppMonsterCardsOnGUI();
            }
            else
            {
                // template to load for showing Toast Notification
                var xmlToastTemplate = "<toast launch=\"app-defined-string\">" +
                                         "<visual>" +
                                           "<binding template =\"ToastGeneric\">" +
                                             "<text>Opp Can't Summon Monster</text>" +
                                             "<text>" +
                                               result +
                                             "</text>" +
                                           "</binding>" +
                                         "</visual>" +
                                       "</toast>";
                // load the template as XML document
                var xmlDocument = new Windows.Data.Xml.Dom.XmlDocument();
                xmlDocument.LoadXml(xmlToastTemplate);
                ToastNotification toast = new ToastNotification(xmlDocument);
                ToastNotificationManager.CreateToastNotifier().Show(toast);
            }

            p2.EndTurn();

            //Update GUI
            clearMyMonsterCardsOnGUI();
            clearMySpellAndTrapCardsOnGUI();
            placeMyMonsterCardsOnGUI();
            placeMySpellAndTrapCardsOnGUI();
            clearHandOnGUI();
            List<Object> hand = me.getHand() as List<Object>;
            for (int i = 0; i < hand.Count; i++)
            {
                placeHandCardOnGUI(hand[i], i);
            }
            collapseUnused();
        }
        */
        private void placeOppMonsterCardsOnGUI()
        {
            int faceDownCards = me.getOpponent().getNumberOfFaceDownCardsInMonsterZone();
            List<MonsterCard> faceUpCards = me.getOpponent().getFaceUpMonstersInMonsterZone() as List<MonsterCard>;
            for (int i = 0; i < faceDownCards; i++)
            {
                if (i == 0)
                {
                    OppMonsterOneZone.Visibility = Visibility.Visible;
                    OppMonsterOneAttackPoints.Visibility = Visibility.Visible;
                    OppMonsterOneDefensePoints.Visibility = Visibility.Visible;
                    OppMonsterOneAttackPoints.Text = "ATK: ? DEFMode";
                    OppMonsterOneDefensePoints.Text = "DEF: ? FDown";
                    OppMonsterOneNameBlock.Text = "?";
                    OppMonsterOneImage.Source = cardBack;
                }
                else if (i == 1)
                {
                    OppMonsterTwoZone.Visibility = Visibility.Visible;
                    OppMonsterTwoAttackPoints.Visibility = Visibility.Visible;
                    OppMonsterTwoDefensePoints.Visibility = Visibility.Visible;
                    OppMonsterTwoAttackPoints.Text = "ATK: ? DEFMode";
                    OppMonsterTwoDefensePoints.Text = "DEF: ? FDown";
                    OppMonsterTwoNameBlock.Text = "?";
                    OppMonsterTwoImage.Source = cardBack;
                }
                else if (i == 2)
                {
                    OppMonsterThreeZone.Visibility = Visibility.Visible;
                    OppMonsterThreeAttackPoints.Visibility = Visibility.Visible;
                    OppMonsterThreeDefensePoints.Visibility = Visibility.Visible;
                    OppMonsterThreeAttackPoints.Text = "ATK: ? DEFMode";
                    OppMonsterThreeDefensePoints.Text = "DEF: ? FDown";
                    OppMonsterThreeNameBlock.Text = "?";
                    OppMonsterThreeImage.Source = cardBack;
                }
                else if (i == 3)
                {
                    OppMonsterFourZone.Visibility = Visibility.Visible;
                    OppMonsterFourAttackPoints.Visibility = Visibility.Visible;
                    OppMonsterFourDefensePoints.Visibility = Visibility.Visible;
                    OppMonsterFourAttackPoints.Text = "ATK: ? DEFMode";
                    OppMonsterFourDefensePoints.Text = "DEF: ? FDown";
                    OppMonsterFourNameBlock.Text = "?";
                    OppMonsterFourImage.Source = cardBack;
                }
                else if (i == 4)
                {
                    OppMonsterFiveZone.Visibility = Visibility.Visible;
                    OppMonsterFiveAttackPoints.Visibility = Visibility.Visible;
                    OppMonsterFiveDefensePoints.Visibility = Visibility.Visible;
                    OppMonsterFiveAttackPoints.Text = "ATK: ? DEFMode";
                    OppMonsterFiveDefensePoints.Text = "DEF: ? FDown";
                    OppMonsterFiveNameBlock.Text = "?";
                    OppMonsterFiveImage.Source = cardBack;
                }
                else if (i == 5)
                {
                    OppMonsterSixZone.Visibility = Visibility.Visible;
                    OppMonsterSixAttackPoints.Visibility = Visibility.Visible;
                    OppMonsterSixDefensePoints.Visibility = Visibility.Visible;
                    OppMonsterSixAttackPoints.Text = "ATK: ? DEFMode";
                    OppMonsterSixDefensePoints.Text = "DEF: ? FDown";
                    OppMonsterSixNameBlock.Text = "?";
                    OppMonsterSixImage.Source = cardBack;
                }
            }
            for (int i = 0; i < faceUpCards.Count; i++)
            {
                if (i + faceDownCards == 0)
                {
                    MonsterCard c = faceUpCards[i];
                    OppMonsterOneZone.Visibility = Visibility.Visible;
                    OppMonsterOneAttackPoints.Visibility = Visibility.Visible;
                    OppMonsterOneDefensePoints.Visibility = Visibility.Visible;
                    OppMonsterOneAttackPoints.Text = "ATK: " + c.getAttackPoints() + " "+ c.getBattlePosition().ToString();
                    OppMonsterOneDefensePoints.Text = "DEF: " + c.getDefensePoints() + " FUp";
                    OppMonsterOneNameBlock.Text = c.getName();
                    OppMonsterOneImage.Source = c.getImage();
                }
                else if (i + faceDownCards == 1)
                {
                    MonsterCard c = faceUpCards[i];
                    OppMonsterTwoZone.Visibility = Visibility.Visible;
                    OppMonsterTwoAttackPoints.Visibility = Visibility.Visible;
                    OppMonsterTwoDefensePoints.Visibility = Visibility.Visible;
                    OppMonsterTwoAttackPoints.Text = "ATK: " + c.getAttackPoints() + " " + c.getBattlePosition().ToString();
                    OppMonsterTwoDefensePoints.Text = "DEF: " + c.getDefensePoints() + " FUp";
                    OppMonsterTwoNameBlock.Text = c.getName();
                    OppMonsterTwoImage.Source = c.getImage();
                }
                else if (i + faceDownCards == 2)
                {
                    MonsterCard c = faceUpCards[i];
                    OppMonsterThreeZone.Visibility = Visibility.Visible;
                    OppMonsterThreeAttackPoints.Visibility = Visibility.Visible;
                    OppMonsterThreeDefensePoints.Visibility = Visibility.Visible;
                    OppMonsterThreeAttackPoints.Text = "ATK: " + c.getAttackPoints() + " " + c.getBattlePosition().ToString();
                    OppMonsterThreeDefensePoints.Text = "DEF: " + c.getDefensePoints() + " FUp";
                    OppMonsterThreeNameBlock.Text = c.getName();
                    OppMonsterThreeImage.Source = c.getImage();
                }
                else if (i + faceDownCards == 3)
                {
                    MonsterCard c = faceUpCards[i];
                    OppMonsterFourZone.Visibility = Visibility.Visible;
                    OppMonsterFourAttackPoints.Visibility = Visibility.Visible;
                    OppMonsterFourDefensePoints.Visibility = Visibility.Visible;
                    OppMonsterFourAttackPoints.Text = "ATK: " + c.getAttackPoints() + " " + c.getBattlePosition().ToString();
                    OppMonsterFourDefensePoints.Text = "DEF: " + c.getDefensePoints() + " FUp";
                    OppMonsterFourNameBlock.Text = c.getName();
                    OppMonsterFourImage.Source = c.getImage();
                }
                else if (i + faceDownCards == 4)
                {
                    MonsterCard c = faceUpCards[i];
                    OppMonsterFiveZone.Visibility = Visibility.Visible;
                    OppMonsterFiveAttackPoints.Visibility = Visibility.Visible;
                    OppMonsterFiveDefensePoints.Visibility = Visibility.Visible;
                    OppMonsterFiveAttackPoints.Text = "ATK: " + c.getAttackPoints() + " " + c.getBattlePosition().ToString();
                    OppMonsterFiveDefensePoints.Text = "DEF: " + c.getDefensePoints() + " FUp";
                    OppMonsterFiveNameBlock.Text = c.getName();
                    OppMonsterFiveImage.Source = c.getImage();
                }
                else if (i + faceDownCards == 5)
                {
                    MonsterCard c = faceUpCards[i];
                    OppMonsterSixZone.Visibility = Visibility.Visible;
                    OppMonsterSixAttackPoints.Visibility = Visibility.Visible;
                    OppMonsterSixDefensePoints.Visibility = Visibility.Visible;
                    OppMonsterSixAttackPoints.Text = "ATK: " + c.getAttackPoints() + " " + c.getBattlePosition().ToString();
                    OppMonsterSixDefensePoints.Text = "DEF: " + c.getDefensePoints() + " FUp";
                    OppMonsterSixNameBlock.Text = c.getName();
                    OppMonsterSixImage.Source = c.getImage();
                }
            }
        }

        private void MySpellAndTrapZonePanel_Tapped(object sender, TappedRoutedEventArgs e)
        {
            if (myCurrentlySelectedCard != null)
            {
                if (myCurrentlySelectedCard is SpellAndTrapCard)
                {
                    string result = me.CastSpellOrTrap(myCurrentlySelectedCard);
                    if (result == "")
                    {
                        disEngageCurrentlySelected();
                        clearMySpellAndTrapCardsOnGUI();
                        placeMySpellAndTrapCardsOnGUI();
                        clearMyMonsterCardsOnGUI();
                        placeMyMonsterCardsOnGUI();
                        clearOppMonsterCardsOnGUI();
                        placeOppMonsterCardsOnGUI();
                        clearHandOnGUI();
                        List<Object> hand = me.getHand() as List<Object>;
                        for (int i = 0; i < hand.Count; i++)
                        {
                            placeHandCardOnGUI(hand[i], i);
                        }
                        collapseUnused();
                        updateLifePoints();
                    }
                    else
                    {
                        // template to load for showing Toast Notification
                        var xmlToastTemplate = "<toast launch=\"app-defined-string\">" +
                                                 "<visual>" +
                                                   "<binding template =\"ToastGeneric\">" +
                                                     "<text>Can't Summon Monster</text>" +
                                                     "<text>" +
                                                       result +
                                                     "</text>" +
                                                   "</binding>" +
                                                 "</visual>" +
                                               "</toast>";
                        // load the template as XML document
                        var xmlDocument = new Windows.Data.Xml.Dom.XmlDocument();
                        xmlDocument.LoadXml(xmlToastTemplate);
                        ToastNotification toast = new ToastNotification(xmlDocument);
                        ToastNotificationManager.CreateToastNotifier().Show(toast);
                    }
                }
            }
        }

        private void clearOppMonsterCardsOnGUI()
        {
            OppMonsterOneAttackPoints.Visibility = Visibility.Collapsed;
            OppMonsterOneDefensePoints.Visibility = Visibility.Collapsed;
            OppMonsterOneAttackPoints.Text = "";
            OppMonsterOneDefensePoints.Text = "";
            OppMonsterOneNameBlock.Text = "";
            OppMonsterOneImage.Source = null;
            //OppMonsterDescBlock.Visibility = Visibility.Collapsed;

            OppMonsterTwoAttackPoints.Visibility = Visibility.Collapsed;
            OppMonsterTwoDefensePoints.Visibility = Visibility.Collapsed;
            OppMonsterTwoAttackPoints.Text = "";
            OppMonsterTwoDefensePoints.Text = "";
            OppMonsterTwoNameBlock.Text = "";
            OppMonsterTwoImage.Source = null;
            //OppMonsterTwoDescBlock.Visibility = Visibility.Collapsed;

            OppMonsterThreeAttackPoints.Visibility = Visibility.Collapsed;
            OppMonsterThreeDefensePoints.Visibility = Visibility.Collapsed;
            OppMonsterThreeAttackPoints.Text = "";
            OppMonsterThreeDefensePoints.Text = "";
            OppMonsterThreeNameBlock.Text = "";
            OppMonsterThreeImage.Source = null;
            //OppMonsterThreeDescBlock.Visibility = Visibility.Collapsed;

            OppMonsterFourAttackPoints.Visibility = Visibility.Collapsed;
            OppMonsterFourDefensePoints.Visibility = Visibility.Collapsed;
            OppMonsterFourAttackPoints.Text = "";
            OppMonsterFourDefensePoints.Text = "";
            OppMonsterFourNameBlock.Text = "";
            OppMonsterFourImage.Source = null;
            //OppMonsterFourDescBlock.Visibility = Visibility.Collapsed;

            OppMonsterFiveAttackPoints.Visibility = Visibility.Collapsed;
            OppMonsterFiveDefensePoints.Visibility = Visibility.Collapsed;
            OppMonsterFiveAttackPoints.Text = "";
            OppMonsterFiveDefensePoints.Text = "";
            OppMonsterFiveNameBlock.Text = "";
            OppMonsterFiveImage.Source = null;
            //OppMonsterFiveDescBlock.Visibility = Visibility.Collapsed;

            OppMonsterSixAttackPoints.Visibility = Visibility.Collapsed;
            OppMonsterSixDefensePoints.Visibility = Visibility.Collapsed;
            OppMonsterSixAttackPoints.Text = "";
            OppMonsterSixDefensePoints.Text = "";
            OppMonsterSixNameBlock.Text = "";
            OppMonsterSixImage.Source = null;
            //OppMonsterSixDescBlock.Visibility = Visibility.Collapsed;
        }

        private void clearMyMonsterCardsOnGUI()
        {
            MyMonsterOneAttackPoints.Visibility = Visibility.Collapsed;
            MyMonsterOneDefensePoints.Visibility = Visibility.Collapsed;
            MyMonsterOneAttackPoints.Text = "";
            MyMonsterOneDefensePoints.Text = "";
            MyMonsterOneNameBlock.Text = "";
            MyMonsterOneImage.Source = null;
            //OppMonsterDescBlock.Visibility = Visibility.Collapsed;

            MyMonsterTwoAttackPoints.Visibility = Visibility.Collapsed;
            MyMonsterTwoDefensePoints.Visibility = Visibility.Collapsed;
            MyMonsterTwoAttackPoints.Text = "";
            MyMonsterTwoDefensePoints.Text = "";
            MyMonsterTwoNameBlock.Text = "";
            MyMonsterTwoImage.Source = null;
            //OppMonsterTwoDescBlock.Visibility = Visibility.Collapsed;

            MyMonsterThreeAttackPoints.Visibility = Visibility.Collapsed;
            MyMonsterThreeDefensePoints.Visibility = Visibility.Collapsed;
            MyMonsterThreeAttackPoints.Text = "";
            MyMonsterThreeDefensePoints.Text = "";
            MyMonsterThreeNameBlock.Text = "";
            MyMonsterThreeImage.Source = null;
            //OppMonsterThreeDescBlock.Visibility = Visibility.Collapsed;

            MyMonsterFourAttackPoints.Visibility = Visibility.Collapsed;
            MyMonsterFourDefensePoints.Visibility = Visibility.Collapsed;
            MyMonsterFourAttackPoints.Text = "";
            MyMonsterFourDefensePoints.Text = "";
            MyMonsterFourNameBlock.Text = "";
            MyMonsterFourImage.Source = null;
            //OppMonsterFourDescBlock.Visibility = Visibility.Collapsed;

            MyMonsterFiveAttackPoints.Visibility = Visibility.Collapsed;
            MyMonsterFiveDefensePoints.Visibility = Visibility.Collapsed;
            MyMonsterFiveAttackPoints.Text = "";
            MyMonsterFiveDefensePoints.Text = "";
            MyMonsterFiveNameBlock.Text = "";
            MyMonsterFiveImage.Source = null;
            //OppMonsterFiveDescBlock.Visibility = Visibility.Collapsed;

            MyMonsterSixAttackPoints.Visibility = Visibility.Collapsed;
            MyMonsterSixDefensePoints.Visibility = Visibility.Collapsed;
            MyMonsterSixAttackPoints.Text = "";
            MyMonsterSixDefensePoints.Text = "";
            MyMonsterSixNameBlock.Text = "";
            MyMonsterSixImage.Source = null;
            //OppMonsterSixDescBlock.Visibility = Visibility.Collapsed;
        }

        private void clearMySpellAndTrapCardsOnGUI()
        {
            //MySpellOneAttackPoints.Visibility = Visibility.Collapsed;
            //MySpellOneDefensePoints.Visibility = Visibility.Collapsed;
            //MySpellOneAttackPoints.Text = "";
            //MySpellOneDefensePoints.Text = "";
            MySpellOneNameBlock.Text = "";
            MySpellOneImage.Source = null;
            MySpellOneDescBlock.Visibility = Visibility.Collapsed;

            //MySpellTwoAttackPoints.Visibility = Visibility.Collapsed;
            //MySpellTwoDefensePoints.Visibility = Visibility.Collapsed;
            //MySpellTwoAttackPoints.Text = "";
            //MySpellTwoDefensePoints.Text = "";
            MySpellTwoNameBlock.Text = "";
            MySpellTwoImage.Source = null;
            MySpellTwoDescBlock.Visibility = Visibility.Collapsed;

            //MySpellThreeAttackPoints.Visibility = Visibility.Collapsed;
            //MySpellThreeDefensePoints.Visibility = Visibility.Collapsed;
            //MySpellThreeAttackPoints.Text = "";
            //MySpellThreeDefensePoints.Text = "";
            MySpellThreeNameBlock.Text = "";
            MySpellThreeImage.Source = null;
            MySpellThreeDescBlock.Visibility = Visibility.Collapsed;

            //MySpellFourAttackPoints.Visibility = Visibility.Collapsed;
            //MySpellFourDefensePoints.Visibility = Visibility.Collapsed;
            //MySpellFourAttackPoints.Text = "";
            //MySpellFourDefensePoints.Text = "";
            MySpellFourNameBlock.Text = "";
            MySpellFourImage.Source = null;
            MySpellFourDescBlock.Visibility = Visibility.Collapsed;

            //MySpellFiveAttackPoints.Visibility = Visibility.Collapsed;
            //MySpellFiveDefensePoints.Visibility = Visibility.Collapsed;
            //MySpellFiveAttackPoints.Text = "";
            //MySpellFiveDefensePoints.Text = "";
            MySpellFiveNameBlock.Text = "";
            MySpellFiveImage.Source = null;
            MySpellFiveDescBlock.Visibility = Visibility.Collapsed;

            //MySpellSixAttackPoints.Visibility = Visibility.Collapsed;
            //MySpellSixDefensePoints.Visibility = Visibility.Collapsed;
            //MySpellSixAttackPoints.Text = "";
            //MySpellSixDefensePoints.Text = "";
            MySpellSixNameBlock.Text = "";
            MySpellSixImage.Source = null;
            MySpellSixDescBlock.Visibility = Visibility.Collapsed;
        }

        private void updateLifePoints()
        {
            int myLifePoints = me.getLifePoints();
            int oppLifePoints = me.getOpponent().getLifePoints();
            if (myLifePoints > 8000)
            {
                MyLifePointBar.Maximum = myLifePoints;
                MyLifePointBar.Value = myLifePoints;
                MyLifePointsText.Text = myLifePoints + "";
            }
            else
            {
                MyLifePointBar.Value = myLifePoints;
                MyLifePointsText.Text = myLifePoints + "";
            }
            if (oppLifePoints > 8000)
            {
                OpponentLifepointsBar.Maximum = oppLifePoints;
                OpponentLifepointsBar.Value = oppLifePoints;
                OppLifePointsText.Text = oppLifePoints + "";
            }
            else
            {
                OpponentLifepointsBar.Value = oppLifePoints;
                OppLifePointsText.Text = oppLifePoints + "";
            }
        }

        private void placeMySpellAndTrapCardsOnGUI()
        {
            List<SpellAndTrapCard> faceDownCards = me.getFaceDownCardsInSpellAndTrapZone() as List<SpellAndTrapCard>;
            List<SpellAndTrapCard> faceUpCards = me.getFaceUpCardsInSpellAndTrapZone() as List<SpellAndTrapCard>;
            for (int i = 0; i < faceDownCards.Count; i++)
            {
                if (i == 0)
                {
                    SpellAndTrapCard c = faceDownCards[i];
                    MySpellOneZone.Visibility = Visibility.Visible;
                    MySpellOneDescBlock.Visibility = Visibility.Visible;
                    MySpellOneDescBlock.Text = c.getDescription();
                    MySpellOneNameBlock.Text = c.getName() + "FDown";
                    MySpellOneImage.Source = c.getImage();
                }
                else if (i == 1)
                {
                    SpellAndTrapCard c = faceDownCards[i];
                    MySpellTwoZone.Visibility = Visibility.Visible;
                    MySpellTwoDescBlock.Visibility = Visibility.Visible;
                    MySpellTwoDescBlock.Text = c.getDescription();
                    MySpellTwoNameBlock.Text = c.getName() + "FDown";
                    MySpellTwoImage.Source = c.getImage();
                }
                else if (i == 2)
                {
                    SpellAndTrapCard c = faceDownCards[i];
                    MySpellThreeZone.Visibility = Visibility.Visible;
                    MySpellThreeDescBlock.Visibility = Visibility.Visible;
                    MySpellThreeDescBlock.Text = c.getDescription();
                    MySpellThreeNameBlock.Text = c.getName() + "FDown";
                    MySpellThreeImage.Source = c.getImage();
                }
                else if (i == 3)
                {
                    SpellAndTrapCard c = faceDownCards[i];
                    MySpellFourZone.Visibility = Visibility.Visible;
                    MySpellFourDescBlock.Visibility = Visibility.Visible;
                    MySpellFourDescBlock.Text = c.getDescription();
                    MySpellFourNameBlock.Text = c.getName() + "FDown";
                    MySpellFourImage.Source = c.getImage();
                }
                else if (i == 4)
                {
                    SpellAndTrapCard c = faceDownCards[i];
                    MySpellFiveZone.Visibility = Visibility.Visible;
                    MySpellFiveDescBlock.Visibility = Visibility.Visible;
                    MySpellFiveDescBlock.Text = c.getDescription();
                    MySpellFiveNameBlock.Text = c.getName() + "FDown";
                    MySpellFiveImage.Source = c.getImage();
                }
                else if (i == 5)
                {
                    SpellAndTrapCard c = faceDownCards[i];
                    MySpellSixZone.Visibility = Visibility.Visible;
                    MySpellSixDescBlock.Visibility = Visibility.Visible;
                    MySpellSixDescBlock.Text = c.getDescription();
                    MySpellSixNameBlock.Text = c.getName() + "FDown";
                    MySpellSixImage.Source = c.getImage();
                }
            }
            for (int i = 0; i < faceUpCards.Count; i++)
            {
                if (i + faceDownCards.Count == 0)
                {
                    SpellAndTrapCard c = faceDownCards[i];
                    MySpellOneZone.Visibility = Visibility.Visible;
                    MySpellOneDescBlock.Visibility = Visibility.Visible;
                    MySpellOneDescBlock.Text = c.getDescription();
                    MySpellOneNameBlock.Text = c.getName() + "FUp";
                    MySpellOneImage.Source = c.getImage();
                }
                else if (i + faceDownCards.Count == 1)
                {
                    SpellAndTrapCard c = faceDownCards[i];
                    MySpellTwoZone.Visibility = Visibility.Visible;
                    MySpellTwoDescBlock.Visibility = Visibility.Visible;
                    MySpellTwoDescBlock.Text = c.getDescription();
                    MySpellTwoNameBlock.Text = c.getName() + "FUp";
                    MySpellTwoImage.Source = c.getImage();
                }
                else if (i + faceDownCards.Count == 2)
                {
                    SpellAndTrapCard c = faceDownCards[i];
                    MySpellThreeZone.Visibility = Visibility.Visible;
                    MySpellThreeDescBlock.Visibility = Visibility.Visible;
                    MySpellThreeDescBlock.Text = c.getDescription();
                    MySpellThreeNameBlock.Text = c.getName() + "FUp";
                    MySpellThreeImage.Source = c.getImage();
                }
                else if (i + faceDownCards.Count == 3)
                {
                    SpellAndTrapCard c = faceDownCards[i];
                    MySpellFourZone.Visibility = Visibility.Visible;
                    MySpellFourDescBlock.Visibility = Visibility.Visible;
                    MySpellFourDescBlock.Text = c.getDescription();
                    MySpellFourNameBlock.Text = c.getName() + "FUp";
                    MySpellFourImage.Source = c.getImage();
                }
                else if (i + faceDownCards.Count == 4)
                {
                    SpellAndTrapCard c = faceDownCards[i];
                    MySpellFiveZone.Visibility = Visibility.Visible;
                    MySpellFiveDescBlock.Visibility = Visibility.Visible;
                    MySpellFiveDescBlock.Text = c.getDescription();
                    MySpellFiveNameBlock.Text = c.getName() + "FUp";
                    MySpellFiveImage.Source = c.getImage();
                }
                else if (i + faceDownCards.Count == 5)
                {
                    SpellAndTrapCard c = faceDownCards[i];
                    MySpellSixZone.Visibility = Visibility.Visible;
                    MySpellSixDescBlock.Visibility = Visibility.Visible;
                    MySpellSixDescBlock.Text = c.getDescription();
                    MySpellSixNameBlock.Text = c.getName() + "FUp";
                    MySpellSixImage.Source = c.getImage();
                }
            }
        }

        private void MyMonsterOneZone_Tapped(object sender, TappedRoutedEventArgs e)
        {
            if (myCurrentlySelectedCard is SpellAndTrapCard)
            {
                string result = me.TryEquip(myCurrentlySelectedCard, MyMonsterOneNameBlock.Text);
                if (result == "")
                {
                    clearMyMonsterCardsOnGUI();
                    placeMyMonsterCardsOnGUI();
                    clearHandOnGUI();
                    List<Object> hand = me.getHand() as List<Object>;
                    for (int i = 0; i < hand.Count; i++)
                    {
                        placeHandCardOnGUI(hand[i], i);
                    }
                    collapseUnused();
                }
                else
                {
                    // template to load for showing Toast Notification
                    var xmlToastTemplate = "<toast launch=\"app-defined-string\">" +
                                             "<visual>" +
                                               "<binding template =\"ToastGeneric\">" +
                                                 "<text>Can't Equip to Monster</text>" +
                                                 "<text>" +
                                                   result +
                                                 "</text>" +
                                               "</binding>" +
                                             "</visual>" +
                                           "</toast>";
                    // load the template as XML document
                    var xmlDocument = new Windows.Data.Xml.Dom.XmlDocument();
                    xmlDocument.LoadXml(xmlToastTemplate);
                    ToastNotification toast = new ToastNotification(xmlDocument);
                    ToastNotificationManager.CreateToastNotifier().Show(toast);
                }
            }
            else
            {
                if (myCurrentlySelectedStackPanel == null || (myCurrentlySelectedStackPanel != (sender as StackPanel)))
                {
                    if (myCurrentlySelectedStackPanel != null && currentlySelectedCardType == CurrentlySelectedCardType.Hand)
                    {
                        myCurrentlySelectedStackPanel.BorderBrush = new SolidColorBrush(Windows.UI.Color.FromArgb(255, 128, 0, 128));
                    }
                    else if (myCurrentlySelectedCard != null && currentlySelectedCardType == CurrentlySelectedCardType.Monster)
                    {
                        myCurrentlySelectedStackPanel.BorderBrush = new SolidColorBrush(Windows.UI.Color.FromArgb(255, 239, 244, 255));
                    }
                    StackPanel s = sender as StackPanel;
                    s.BorderBrush = new SolidColorBrush(Windows.UI.Color.FromArgb(255, 0, 255, 0));
                    myCurrentlySelectedCard = getField()[0];
                    myCurrentlySelectedStackPanel = s;
                    currentlySelectedCardType = CurrentlySelectedCardType.Monster;
                }
                else
                {
                    disEngageCurrentlySelected();
                }
            }
        }

        private List<MonsterCard> getField()
        {
            List<MonsterCard> faceDownCards = me.getFaceDownCardsInMonsterZone() as List<MonsterCard>;
            List<MonsterCard> faceUpCards = me.getFaceUpMonstersInMonsterZone() as List<MonsterCard>;
            List<MonsterCard> toReturn = faceDownCards.Concat(faceUpCards).ToList<MonsterCard>();
            return toReturn;
        }

        private void MyMonsterTwoZone_Tapped(object sender, TappedRoutedEventArgs e)
        {
            if (myCurrentlySelectedCard is SpellAndTrapCard)
            {
                string result = me.TryEquip(myCurrentlySelectedCard, MyMonsterTwoNameBlock.Text);
                if (result == "")
                {
                    clearMyMonsterCardsOnGUI();
                    placeMyMonsterCardsOnGUI();
                    clearHandOnGUI();
                    List<Object> hand = me.getHand() as List<Object>;
                    for (int i = 0; i < hand.Count; i++)
                    {
                        placeHandCardOnGUI(hand[i], i);
                    }
                    collapseUnused();
                }
                else
                {
                    // template to load for showing Toast Notification
                    var xmlToastTemplate = "<toast launch=\"app-defined-string\">" +
                                             "<visual>" +
                                               "<binding template =\"ToastGeneric\">" +
                                                 "<text>Can't Equip to Monster</text>" +
                                                 "<text>" +
                                                   result +
                                                 "</text>" +
                                               "</binding>" +
                                             "</visual>" +
                                           "</toast>";
                    // load the template as XML document
                    var xmlDocument = new Windows.Data.Xml.Dom.XmlDocument();
                    xmlDocument.LoadXml(xmlToastTemplate);
                    ToastNotification toast = new ToastNotification(xmlDocument);
                    ToastNotificationManager.CreateToastNotifier().Show(toast);
                }
            }
            else
            {
                if (myCurrentlySelectedStackPanel == null || (myCurrentlySelectedStackPanel != (sender as StackPanel)))
                {
                    if (myCurrentlySelectedStackPanel != null && currentlySelectedCardType == CurrentlySelectedCardType.Hand)
                    {
                        myCurrentlySelectedStackPanel.BorderBrush = new SolidColorBrush(Windows.UI.Color.FromArgb(255, 128, 0, 128));
                    }
                    else if (myCurrentlySelectedCard != null && currentlySelectedCardType == CurrentlySelectedCardType.Monster)
                    {
                        myCurrentlySelectedStackPanel.BorderBrush = new SolidColorBrush(Windows.UI.Color.FromArgb(255, 239, 244, 255));
                    }
                    StackPanel s = sender as StackPanel;
                    s.BorderBrush = new SolidColorBrush(Windows.UI.Color.FromArgb(255, 0, 255, 0));
                    myCurrentlySelectedCard = getField()[1];
                    myCurrentlySelectedStackPanel = s;
                    currentlySelectedCardType = CurrentlySelectedCardType.Monster;
                }
                else
                {
                    disEngageCurrentlySelected();
                }
            }
        }

        private void MyMonsterThreeZone_Tapped(object sender, TappedRoutedEventArgs e)
        {
            if (myCurrentlySelectedCard is SpellAndTrapCard)
            {
                string result = me.TryEquip(myCurrentlySelectedCard, MyMonsterThreeNameBlock.Text);
                if (result == "")
                {
                    clearMyMonsterCardsOnGUI();
                    placeMyMonsterCardsOnGUI();
                    clearHandOnGUI();
                    List<Object> hand = me.getHand() as List<Object>;
                    for (int i = 0; i < hand.Count; i++)
                    {
                        placeHandCardOnGUI(hand[i], i);
                    }
                    collapseUnused();
                }
                else
                {
                    // template to load for showing Toast Notification
                    var xmlToastTemplate = "<toast launch=\"app-defined-string\">" +
                                             "<visual>" +
                                               "<binding template =\"ToastGeneric\">" +
                                                 "<text>Can't Equip To Monster</text>" +
                                                 "<text>" +
                                                   result +
                                                 "</text>" +
                                               "</binding>" +
                                             "</visual>" +
                                           "</toast>";
                    // load the template as XML document
                    var xmlDocument = new Windows.Data.Xml.Dom.XmlDocument();
                    xmlDocument.LoadXml(xmlToastTemplate);
                    ToastNotification toast = new ToastNotification(xmlDocument);
                    ToastNotificationManager.CreateToastNotifier().Show(toast);
                }
            }
            else
            {
                if (myCurrentlySelectedStackPanel == null || (myCurrentlySelectedStackPanel != (sender as StackPanel)))
                {
                    if (myCurrentlySelectedStackPanel != null && currentlySelectedCardType == CurrentlySelectedCardType.Hand)
                    {
                        myCurrentlySelectedStackPanel.BorderBrush = new SolidColorBrush(Windows.UI.Color.FromArgb(255, 128, 0, 128));
                    }
                    else if (myCurrentlySelectedCard != null && currentlySelectedCardType == CurrentlySelectedCardType.Monster)
                    {
                        myCurrentlySelectedStackPanel.BorderBrush = new SolidColorBrush(Windows.UI.Color.FromArgb(255, 239, 244, 255));
                    }
                    StackPanel s = sender as StackPanel;
                    s.BorderBrush = new SolidColorBrush(Windows.UI.Color.FromArgb(255, 0, 255, 0));
                    myCurrentlySelectedCard = getField()[2];
                    myCurrentlySelectedStackPanel = s;
                    currentlySelectedCardType = CurrentlySelectedCardType.Monster;
                }
                else
                {
                    disEngageCurrentlySelected();
                }
            }
        }

        private void MyMonsterFourZone_Tapped(object sender, TappedRoutedEventArgs e)
        {
            if (myCurrentlySelectedCard is SpellAndTrapCard)
            {
                string result = me.TryEquip(myCurrentlySelectedCard, MyMonsterFourNameBlock.Text);
                if (result == "")
                {
                    clearMyMonsterCardsOnGUI();
                    placeMyMonsterCardsOnGUI();
                    clearHandOnGUI();
                    List<Object> hand = me.getHand() as List<Object>;
                    for (int i = 0; i < hand.Count; i++)
                    {
                        placeHandCardOnGUI(hand[i], i);
                    }
                    collapseUnused();
                }
                else
                {
                    // template to load for showing Toast Notification
                    var xmlToastTemplate = "<toast launch=\"app-defined-string\">" +
                                             "<visual>" +
                                               "<binding template =\"ToastGeneric\">" +
                                                 "<text>Can't Equip To Monster</text>" +
                                                 "<text>" +
                                                   result +
                                                 "</text>" +
                                               "</binding>" +
                                             "</visual>" +
                                           "</toast>";
                    // load the template as XML document
                    var xmlDocument = new Windows.Data.Xml.Dom.XmlDocument();
                    xmlDocument.LoadXml(xmlToastTemplate);
                    ToastNotification toast = new ToastNotification(xmlDocument);
                    ToastNotificationManager.CreateToastNotifier().Show(toast);
                }
            }
            else
            {
                if (myCurrentlySelectedStackPanel == null || (myCurrentlySelectedStackPanel != (sender as StackPanel)))
                {
                    if (myCurrentlySelectedStackPanel != null && currentlySelectedCardType == CurrentlySelectedCardType.Hand)
                    {
                        myCurrentlySelectedStackPanel.BorderBrush = new SolidColorBrush(Windows.UI.Color.FromArgb(255, 128, 0, 128));
                    }
                    else if (myCurrentlySelectedCard != null && currentlySelectedCardType == CurrentlySelectedCardType.Monster)
                    {
                        myCurrentlySelectedStackPanel.BorderBrush = new SolidColorBrush(Windows.UI.Color.FromArgb(255, 239, 244, 255));
                    }
                    StackPanel s = sender as StackPanel;
                    s.BorderBrush = new SolidColorBrush(Windows.UI.Color.FromArgb(255, 0, 255, 0));
                    myCurrentlySelectedCard = getField()[3];
                    myCurrentlySelectedStackPanel = s;
                    currentlySelectedCardType = CurrentlySelectedCardType.Monster;
                }
                else
                {
                    disEngageCurrentlySelected();
                }
            }
        }

        private void MyMonsterFiveZone_Tapped(object sender, TappedRoutedEventArgs e)
        {
            if (myCurrentlySelectedCard is SpellAndTrapCard)
            {
                string result = me.TryEquip(myCurrentlySelectedCard, MyMonsterFiveNameBlock.Text);
                if (result == "")
                {
                    clearMyMonsterCardsOnGUI();
                    placeMyMonsterCardsOnGUI();
                    clearHandOnGUI();
                    List<Object> hand = me.getHand() as List<Object>;
                    for (int i = 0; i < hand.Count; i++)
                    {
                        placeHandCardOnGUI(hand[i], i);
                    }
                    collapseUnused();
                }
                else
                {
                    // template to load for showing Toast Notification
                    var xmlToastTemplate = "<toast launch=\"app-defined-string\">" +
                                             "<visual>" +
                                               "<binding template =\"ToastGeneric\">" +
                                                 "<text>Can't Equip To Monster</text>" +
                                                 "<text>" +
                                                   result +
                                                 "</text>" +
                                               "</binding>" +
                                             "</visual>" +
                                           "</toast>";
                    // load the template as XML document
                    var xmlDocument = new Windows.Data.Xml.Dom.XmlDocument();
                    xmlDocument.LoadXml(xmlToastTemplate);
                    ToastNotification toast = new ToastNotification(xmlDocument);
                    ToastNotificationManager.CreateToastNotifier().Show(toast);
                }
            }
            else
            {
                if (myCurrentlySelectedStackPanel == null || (myCurrentlySelectedStackPanel != (sender as StackPanel)))
                {
                    if (myCurrentlySelectedStackPanel != null && currentlySelectedCardType == CurrentlySelectedCardType.Hand)
                    {
                        myCurrentlySelectedStackPanel.BorderBrush = new SolidColorBrush(Windows.UI.Color.FromArgb(255, 128, 0, 128));
                    }
                    else if (myCurrentlySelectedCard != null && currentlySelectedCardType == CurrentlySelectedCardType.Monster)
                    {
                        myCurrentlySelectedStackPanel.BorderBrush = new SolidColorBrush(Windows.UI.Color.FromArgb(255, 239, 244, 255));
                    }
                    StackPanel s = sender as StackPanel;
                    s.BorderBrush = new SolidColorBrush(Windows.UI.Color.FromArgb(255, 0, 255, 0));
                    myCurrentlySelectedCard = getField()[4];
                    myCurrentlySelectedStackPanel = s;
                    currentlySelectedCardType = CurrentlySelectedCardType.Monster;
                }
                else
                {
                    disEngageCurrentlySelected();
                }
            }
        }

        private void MyMonsterSixZone_Tapped(object sender, TappedRoutedEventArgs e)
        {
            if (myCurrentlySelectedCard is SpellAndTrapCard)
            {
                string result = me.TryEquip(myCurrentlySelectedCard, MyMonsterSixNameBlock.Text);
                if (result == "")
                {
                    clearMyMonsterCardsOnGUI();
                    placeMyMonsterCardsOnGUI();
                    clearHandOnGUI();
                    List<Object> hand = me.getHand() as List<Object>;
                    for (int i = 0; i < hand.Count; i++)
                    {
                        placeHandCardOnGUI(hand[i], i);
                    }
                    collapseUnused();
                }
                else
                {
                    // template to load for showing Toast Notification
                    var xmlToastTemplate = "<toast launch=\"app-defined-string\">" +
                                             "<visual>" +
                                               "<binding template =\"ToastGeneric\">" +
                                                 "<text>Can't Equip To Monster</text>" +
                                                 "<text>" +
                                                   result +
                                                 "</text>" +
                                               "</binding>" +
                                             "</visual>" +
                                           "</toast>";
                    // load the template as XML document
                    var xmlDocument = new Windows.Data.Xml.Dom.XmlDocument();
                    xmlDocument.LoadXml(xmlToastTemplate);
                    ToastNotification toast = new ToastNotification(xmlDocument);
                    ToastNotificationManager.CreateToastNotifier().Show(toast);
                }
            }
            else
            {
                if (myCurrentlySelectedStackPanel == null || (myCurrentlySelectedStackPanel != (sender as StackPanel)))
                {
                    if (myCurrentlySelectedStackPanel != null && currentlySelectedCardType == CurrentlySelectedCardType.Hand)
                    {
                        myCurrentlySelectedStackPanel.BorderBrush = new SolidColorBrush(Windows.UI.Color.FromArgb(255, 128, 0, 128));
                    }
                    else if (myCurrentlySelectedCard != null && currentlySelectedCardType == CurrentlySelectedCardType.Monster)
                    {
                        myCurrentlySelectedStackPanel.BorderBrush = new SolidColorBrush(Windows.UI.Color.FromArgb(255, 239, 244, 255));
                    }
                    StackPanel s = sender as StackPanel;
                    s.BorderBrush = new SolidColorBrush(Windows.UI.Color.FromArgb(255, 0, 255, 0));
                    myCurrentlySelectedCard = getField()[5];
                    myCurrentlySelectedStackPanel = s;
                    currentlySelectedCardType = CurrentlySelectedCardType.Monster;
                }
                else
                {
                    disEngageCurrentlySelected();
                }
            }
        }

        private void OppMonsterZonePanel_Tapped(object sender, TappedRoutedEventArgs e)
        {
            if (myCurrentlySelectedCard is MonsterCard)
            {
                if (OppMonsterOneZone.Visibility == Visibility.Collapsed && OppMonsterTwoZone.Visibility == Visibility.Collapsed && OppMonsterThreeZone.Visibility == Visibility.Collapsed && OppMonsterFourZone.Visibility == Visibility.Collapsed && OppMonsterFiveZone.Visibility == Visibility.Collapsed && OppMonsterSixZone.Visibility == Visibility.Collapsed)
                {
                    string result = me.AttackLifePoints(myCurrentlySelectedCard as MonsterCard);
                    if (result == "")
                    {
                        clearHandOnGUI();
                        clearMyMonsterCardsOnGUI();
                        clearMySpellAndTrapCardsOnGUI();
                        clearOppMonsterCardsOnGUI();
                        placeMyMonsterCardsOnGUI();
                        placeMySpellAndTrapCardsOnGUI();
                        placeOppMonsterCardsOnGUI();
                        updateLifePoints();
                        List<Object> hand = me.getHand() as List<Object>;
                        for (int i = 0; i < hand.Count; i++)
                        {
                            placeHandCardOnGUI(hand[i], i);
                        }
                        collapseUnused();
                    }
                    else
                    {
                        // template to load for showing Toast Notification
                        var xmlToastTemplate = "<toast launch=\"app-defined-string\">" +
                                                 "<visual>" +
                                                   "<binding template =\"ToastGeneric\">" +
                                                     "<text>Can't Attack LifePoints</text>" +
                                                     "<text>" +
                                                       result +
                                                     "</text>" +
                                                   "</binding>" +
                                                 "</visual>" +
                                               "</toast>";
                        // load the template as XML document
                        var xmlDocument = new Windows.Data.Xml.Dom.XmlDocument();
                        xmlDocument.LoadXml(xmlToastTemplate);
                        ToastNotification toast = new ToastNotification(xmlDocument);
                        ToastNotificationManager.CreateToastNotifier().Show(toast);
                        clearHandOnGUI();
                        clearMyMonsterCardsOnGUI();
                        clearMySpellAndTrapCardsOnGUI();
                        clearOppMonsterCardsOnGUI();
                        placeMyMonsterCardsOnGUI();
                        placeMySpellAndTrapCardsOnGUI();
                        placeOppMonsterCardsOnGUI();
                        updateLifePoints();
                        List<Object> hand = me.getHand() as List<Object>;
                        for (int i = 0; i < hand.Count; i++)
                        {
                            placeHandCardOnGUI(hand[i], i);
                        }
                        collapseUnused();
                    }
                }
            }
        }

        private void OppMonsterOneZone_Tapped(object sender, TappedRoutedEventArgs e)
        {
            if (myCurrentlySelectedCard is MonsterCard)
            {
                if (OppMonsterOneNameBlock.Text.Contains("?"))
                {
                    if (OppMonsterOneAttackPoints.Text.Contains("ATKMode"))
                    {
                        string result = me.AttackFaceDownOpponent(myCurrentlySelectedCard as MonsterCard, Mode.Attack);
                        if (result == "")
                        {
                            clearHandOnGUI();
                            clearMyMonsterCardsOnGUI();
                            clearMySpellAndTrapCardsOnGUI();
                            clearOppMonsterCardsOnGUI();
                            placeMyMonsterCardsOnGUI();
                            placeMySpellAndTrapCardsOnGUI();
                            placeOppMonsterCardsOnGUI();
                            updateLifePoints();
                            List<Object> hand = me.getHand() as List<Object>;
                            for (int i = 0; i < hand.Count; i++)
                            {
                                placeHandCardOnGUI(hand[i], i);
                            }
                            collapseUnused();
                        }
                        else
                        {
                            // template to load for showing Toast Notification
                            var xmlToastTemplate = "<toast launch=\"app-defined-string\">" +
                                                     "<visual>" +
                                                       "<binding template =\"ToastGeneric\">" +
                                                         "<text>Can't Attack Monster</text>" +
                                                         "<text>" +
                                                           result +
                                                         "</text>" +
                                                       "</binding>" +
                                                     "</visual>" +
                                                   "</toast>";
                            // load the template as XML document
                            var xmlDocument = new Windows.Data.Xml.Dom.XmlDocument();
                            xmlDocument.LoadXml(xmlToastTemplate);
                            ToastNotification toast = new ToastNotification(xmlDocument);
                            ToastNotificationManager.CreateToastNotifier().Show(toast);
                            clearHandOnGUI();
                            clearMyMonsterCardsOnGUI();
                            clearMySpellAndTrapCardsOnGUI();
                            clearOppMonsterCardsOnGUI();
                            placeMyMonsterCardsOnGUI();
                            placeMySpellAndTrapCardsOnGUI();
                            placeOppMonsterCardsOnGUI();
                            updateLifePoints();
                            List<Object> hand = me.getHand() as List<Object>;
                            for (int i = 0; i < hand.Count; i++)
                            {
                                placeHandCardOnGUI(hand[i], i);
                            }
                            collapseUnused();
                        }
                    }
                    else
                    {
                        string result = me.AttackFaceDownOpponent(myCurrentlySelectedCard as MonsterCard, Mode.Defense);
                        if (result == "")
                        {
                            clearHandOnGUI();
                            clearMyMonsterCardsOnGUI();
                            clearMySpellAndTrapCardsOnGUI();
                            clearOppMonsterCardsOnGUI();
                            placeMyMonsterCardsOnGUI();
                            placeMySpellAndTrapCardsOnGUI();
                            placeOppMonsterCardsOnGUI();
                            updateLifePoints();
                            List<Object> hand = me.getHand() as List<Object>;
                            for (int i = 0; i < hand.Count; i++)
                            {
                                placeHandCardOnGUI(hand[i], i);
                            }
                            collapseUnused();
                        }
                        else
                        {
                            // template to load for showing Toast Notification
                            var xmlToastTemplate = "<toast launch=\"app-defined-string\">" +
                                                     "<visual>" +
                                                       "<binding template =\"ToastGeneric\">" +
                                                         "<text>Can't Attack Monster</text>" +
                                                         "<text>" +
                                                           result +
                                                         "</text>" +
                                                       "</binding>" +
                                                     "</visual>" +
                                                   "</toast>";
                            // load the template as XML document
                            var xmlDocument = new Windows.Data.Xml.Dom.XmlDocument();
                            xmlDocument.LoadXml(xmlToastTemplate);
                            ToastNotification toast = new ToastNotification(xmlDocument);
                            ToastNotificationManager.CreateToastNotifier().Show(toast);
                            clearHandOnGUI();
                            clearMyMonsterCardsOnGUI();
                            clearMySpellAndTrapCardsOnGUI();
                            clearOppMonsterCardsOnGUI();
                            placeMyMonsterCardsOnGUI();
                            placeMySpellAndTrapCardsOnGUI();
                            placeOppMonsterCardsOnGUI();
                            updateLifePoints();
                            List<Object> hand = me.getHand() as List<Object>;
                            for (int i = 0; i < hand.Count; i++)
                            {
                                placeHandCardOnGUI(hand[i], i);
                            }
                            collapseUnused();
                        }
                    }
                }
                else
                {
                    IList<MonsterCard> oppMonsters = me.getOpponent().getFaceUpMonstersInMonsterZone();
                    MonsterCard toAttack = null;
                    for (int i = 0; i < oppMonsters.Count; i++)
                    {
                        if (OppMonsterOneNameBlock.Text.Equals(oppMonsters[i].getName()))
                        {
                            toAttack = oppMonsters[i];
                            break;
                        }
                    }
                    if (toAttack != null)
                    {
                        string result = me.AttackFaceUpOpponent(myCurrentlySelectedCard as MonsterCard, toAttack);
                        if (result == "")
                        {
                            clearHandOnGUI();
                            clearMyMonsterCardsOnGUI();
                            clearMySpellAndTrapCardsOnGUI();
                            clearOppMonsterCardsOnGUI();
                            placeMyMonsterCardsOnGUI();
                            placeMySpellAndTrapCardsOnGUI();
                            placeOppMonsterCardsOnGUI();
                            updateLifePoints();
                            List<Object> hand = me.getHand() as List<Object>;
                            for (int i = 0; i < hand.Count; i++)
                            {
                                placeHandCardOnGUI(hand[i], i);
                            }
                            collapseUnused();
                        }
                        else
                        {
                            // template to load for showing Toast Notification
                            var xmlToastTemplate = "<toast launch=\"app-defined-string\">" +
                                                     "<visual>" +
                                                       "<binding template =\"ToastGeneric\">" +
                                                         "<text>Can't Attack Monster</text>" +
                                                         "<text>" +
                                                           result +
                                                         "</text>" +
                                                       "</binding>" +
                                                     "</visual>" +
                                                   "</toast>";
                            // load the template as XML document
                            var xmlDocument = new Windows.Data.Xml.Dom.XmlDocument();
                            xmlDocument.LoadXml(xmlToastTemplate);
                            ToastNotification toast = new ToastNotification(xmlDocument);
                            ToastNotificationManager.CreateToastNotifier().Show(toast);
                            clearHandOnGUI();
                            clearMyMonsterCardsOnGUI();
                            clearMySpellAndTrapCardsOnGUI();
                            clearOppMonsterCardsOnGUI();
                            placeMyMonsterCardsOnGUI();
                            placeMySpellAndTrapCardsOnGUI();
                            placeOppMonsterCardsOnGUI();
                            updateLifePoints();
                            List<Object> hand = me.getHand() as List<Object>;
                            for (int i = 0; i < hand.Count; i++)
                            {
                                placeHandCardOnGUI(hand[i], i);
                            }
                            collapseUnused();
                        }
                    }
                    else
                    {
                        clearHandOnGUI();
                        clearMyMonsterCardsOnGUI();
                        clearMySpellAndTrapCardsOnGUI();
                        clearOppMonsterCardsOnGUI();
                        placeMyMonsterCardsOnGUI();
                        placeMySpellAndTrapCardsOnGUI();
                        placeOppMonsterCardsOnGUI();
                        updateLifePoints();
                        List<Object> hand = me.getHand() as List<Object>;
                        for (int i = 0; i < hand.Count; i++)
                        {
                            placeHandCardOnGUI(hand[i], i);
                        }
                        collapseUnused();
                    }
                }
            }
        }

        private void OppMonsterTwoZone_Tapped(object sender, TappedRoutedEventArgs e)
        {
            if (myCurrentlySelectedCard is MonsterCard)
            {
                if (OppMonsterTwoNameBlock.Text.Contains("?"))
                {
                    if (OppMonsterTwoAttackPoints.Text.Contains("ATKMode"))
                    {
                        string result = me.AttackFaceDownOpponent(myCurrentlySelectedCard as MonsterCard, Mode.Attack);
                        if (result == "")
                        {
                            clearHandOnGUI();
                            clearMyMonsterCardsOnGUI();
                            clearMySpellAndTrapCardsOnGUI();
                            clearOppMonsterCardsOnGUI();
                            placeMyMonsterCardsOnGUI();
                            placeMySpellAndTrapCardsOnGUI();
                            placeOppMonsterCardsOnGUI();
                            updateLifePoints();
                            List<Object> hand = me.getHand() as List<Object>;
                            for (int i = 0; i < hand.Count; i++)
                            {
                                placeHandCardOnGUI(hand[i], i);
                            }
                            collapseUnused();
                        }
                        else
                        {
                            // template to load for showing Toast Notification
                            var xmlToastTemplate = "<toast launch=\"app-defined-string\">" +
                                                     "<visual>" +
                                                       "<binding template =\"ToastGeneric\">" +
                                                         "<text>Can't Attack Monster</text>" +
                                                         "<text>" +
                                                           result +
                                                         "</text>" +
                                                       "</binding>" +
                                                     "</visual>" +
                                                   "</toast>";
                            // load the template as XML document
                            var xmlDocument = new Windows.Data.Xml.Dom.XmlDocument();
                            xmlDocument.LoadXml(xmlToastTemplate);
                            ToastNotification toast = new ToastNotification(xmlDocument);
                            ToastNotificationManager.CreateToastNotifier().Show(toast);
                            clearHandOnGUI();
                            clearMyMonsterCardsOnGUI();
                            clearMySpellAndTrapCardsOnGUI();
                            clearOppMonsterCardsOnGUI();
                            placeMyMonsterCardsOnGUI();
                            placeMySpellAndTrapCardsOnGUI();
                            placeOppMonsterCardsOnGUI();
                            updateLifePoints();
                            List<Object> hand = me.getHand() as List<Object>;
                            for (int i = 0; i < hand.Count; i++)
                            {
                                placeHandCardOnGUI(hand[i], i);
                            }
                            collapseUnused();
                        }
                    }
                    else
                    {
                        string result = me.AttackFaceDownOpponent(myCurrentlySelectedCard as MonsterCard, Mode.Defense);
                        if (result == "")
                        {
                            clearHandOnGUI();
                            clearMyMonsterCardsOnGUI();
                            clearMySpellAndTrapCardsOnGUI();
                            clearOppMonsterCardsOnGUI();
                            placeMyMonsterCardsOnGUI();
                            placeMySpellAndTrapCardsOnGUI();
                            placeOppMonsterCardsOnGUI();
                            updateLifePoints();
                            List<Object> hand = me.getHand() as List<Object>;
                            for (int i = 0; i < hand.Count; i++)
                            {
                                placeHandCardOnGUI(hand[i], i);
                            }
                            collapseUnused();
                        }
                        else
                        {
                            // template to load for showing Toast Notification
                            var xmlToastTemplate = "<toast launch=\"app-defined-string\">" +
                                                     "<visual>" +
                                                       "<binding template =\"ToastGeneric\">" +
                                                         "<text>Can't Attack Monster</text>" +
                                                         "<text>" +
                                                           result +
                                                         "</text>" +
                                                       "</binding>" +
                                                     "</visual>" +
                                                   "</toast>";
                            // load the template as XML document
                            var xmlDocument = new Windows.Data.Xml.Dom.XmlDocument();
                            xmlDocument.LoadXml(xmlToastTemplate);
                            ToastNotification toast = new ToastNotification(xmlDocument);
                            ToastNotificationManager.CreateToastNotifier().Show(toast);
                            clearHandOnGUI();
                            clearMyMonsterCardsOnGUI();
                            clearMySpellAndTrapCardsOnGUI();
                            clearOppMonsterCardsOnGUI();
                            placeMyMonsterCardsOnGUI();
                            placeMySpellAndTrapCardsOnGUI();
                            placeOppMonsterCardsOnGUI();
                            updateLifePoints();
                            List<Object> hand = me.getHand() as List<Object>;
                            for (int i = 0; i < hand.Count; i++)
                            {
                                placeHandCardOnGUI(hand[i], i);
                            }
                            collapseUnused();
                        }
                    }
                }
                else
                {
                    IList<MonsterCard> oppMonsters = me.getOpponent().getFaceUpMonstersInMonsterZone();
                    MonsterCard toAttack = null;
                    for (int i = 0; i < oppMonsters.Count; i++)
                    {
                        if (OppMonsterTwoNameBlock.Text.Equals(oppMonsters[i].getName()))
                        {
                            toAttack = oppMonsters[i];
                            break;
                        }
                    }
                    if (toAttack != null)
                    {
                        string result = me.AttackFaceUpOpponent(myCurrentlySelectedCard as MonsterCard, toAttack);
                        if (result == "")
                        {
                            clearHandOnGUI();
                            clearMyMonsterCardsOnGUI();
                            clearMySpellAndTrapCardsOnGUI();
                            clearOppMonsterCardsOnGUI();
                            placeMyMonsterCardsOnGUI();
                            placeMySpellAndTrapCardsOnGUI();
                            placeOppMonsterCardsOnGUI();
                            updateLifePoints();
                            List<Object> hand = me.getHand() as List<Object>;
                            for (int i = 0; i < hand.Count; i++)
                            {
                                placeHandCardOnGUI(hand[i], i);
                            }
                            collapseUnused();
                        }
                        else
                        {
                            // template to load for showing Toast Notification
                            var xmlToastTemplate = "<toast launch=\"app-defined-string\">" +
                                                     "<visual>" +
                                                       "<binding template =\"ToastGeneric\">" +
                                                         "<text>Can't Attack Monster</text>" +
                                                         "<text>" +
                                                           result +
                                                         "</text>" +
                                                       "</binding>" +
                                                     "</visual>" +
                                                   "</toast>";
                            // load the template as XML document
                            var xmlDocument = new Windows.Data.Xml.Dom.XmlDocument();
                            xmlDocument.LoadXml(xmlToastTemplate);
                            ToastNotification toast = new ToastNotification(xmlDocument);
                            ToastNotificationManager.CreateToastNotifier().Show(toast);
                            clearHandOnGUI();
                            clearMyMonsterCardsOnGUI();
                            clearMySpellAndTrapCardsOnGUI();
                            clearOppMonsterCardsOnGUI();
                            placeMyMonsterCardsOnGUI();
                            placeMySpellAndTrapCardsOnGUI();
                            placeOppMonsterCardsOnGUI();
                            updateLifePoints();
                            List<Object> hand = me.getHand() as List<Object>;
                            for (int i = 0; i < hand.Count; i++)
                            {
                                placeHandCardOnGUI(hand[i], i);
                            }
                            collapseUnused();
                        }
                    }
                    else
                    {
                        clearHandOnGUI();
                        clearMyMonsterCardsOnGUI();
                        clearMySpellAndTrapCardsOnGUI();
                        clearOppMonsterCardsOnGUI();
                        placeMyMonsterCardsOnGUI();
                        placeMySpellAndTrapCardsOnGUI();
                        placeOppMonsterCardsOnGUI();
                        updateLifePoints();
                        List<Object> hand = me.getHand() as List<Object>;
                        for (int i = 0; i < hand.Count; i++)
                        {
                            placeHandCardOnGUI(hand[i], i);
                        }
                        collapseUnused();
                    }
                }
            }
        }

        private void OppMonsterThreeZone_Tapped(object sender, TappedRoutedEventArgs e)
        {
            if (myCurrentlySelectedCard is MonsterCard)
            {
                if (OppMonsterThreeNameBlock.Text.Contains("?"))
                {
                    if (OppMonsterThreeAttackPoints.Text.Contains("ATKMode"))
                    {
                        string result = me.AttackFaceDownOpponent(myCurrentlySelectedCard as MonsterCard, Mode.Attack);
                        if (result == "")
                        {
                            clearHandOnGUI();
                            clearMyMonsterCardsOnGUI();
                            clearMySpellAndTrapCardsOnGUI();
                            clearOppMonsterCardsOnGUI();
                            placeMyMonsterCardsOnGUI();
                            placeMySpellAndTrapCardsOnGUI();
                            placeOppMonsterCardsOnGUI();
                            updateLifePoints();
                            List<Object> hand = me.getHand() as List<Object>;
                            for (int i = 0; i < hand.Count; i++)
                            {
                                placeHandCardOnGUI(hand[i], i);
                            }
                            collapseUnused();
                        }
                        else
                        {
                            // template to load for showing Toast Notification
                            var xmlToastTemplate = "<toast launch=\"app-defined-string\">" +
                                                     "<visual>" +
                                                       "<binding template =\"ToastGeneric\">" +
                                                         "<text>Can't Attack Monster</text>" +
                                                         "<text>" +
                                                           result +
                                                         "</text>" +
                                                       "</binding>" +
                                                     "</visual>" +
                                                   "</toast>";
                            // load the template as XML document
                            var xmlDocument = new Windows.Data.Xml.Dom.XmlDocument();
                            xmlDocument.LoadXml(xmlToastTemplate);
                            ToastNotification toast = new ToastNotification(xmlDocument);
                            ToastNotificationManager.CreateToastNotifier().Show(toast);
                            clearHandOnGUI();
                            clearMyMonsterCardsOnGUI();
                            clearMySpellAndTrapCardsOnGUI();
                            clearOppMonsterCardsOnGUI();
                            placeMyMonsterCardsOnGUI();
                            placeMySpellAndTrapCardsOnGUI();
                            placeOppMonsterCardsOnGUI();
                            updateLifePoints();
                            List<Object> hand = me.getHand() as List<Object>;
                            for (int i = 0; i < hand.Count; i++)
                            {
                                placeHandCardOnGUI(hand[i], i);
                            }
                            collapseUnused();
                        }
                    }
                    else
                    {
                        string result = me.AttackFaceDownOpponent(myCurrentlySelectedCard as MonsterCard, Mode.Defense);
                        if (result == "")
                        {
                            clearHandOnGUI();
                            clearMyMonsterCardsOnGUI();
                            clearMySpellAndTrapCardsOnGUI();
                            clearOppMonsterCardsOnGUI();
                            placeMyMonsterCardsOnGUI();
                            placeMySpellAndTrapCardsOnGUI();
                            placeOppMonsterCardsOnGUI();
                            updateLifePoints();
                            List<Object> hand = me.getHand() as List<Object>;
                            for (int i = 0; i < hand.Count; i++)
                            {
                                placeHandCardOnGUI(hand[i], i);
                            }
                            collapseUnused();
                        }
                        else
                        {
                            // template to load for showing Toast Notification
                            var xmlToastTemplate = "<toast launch=\"app-defined-string\">" +
                                                     "<visual>" +
                                                       "<binding template =\"ToastGeneric\">" +
                                                         "<text>Can't Attack Monster</text>" +
                                                         "<text>" +
                                                           result +
                                                         "</text>" +
                                                       "</binding>" +
                                                     "</visual>" +
                                                   "</toast>";
                            // load the template as XML document
                            var xmlDocument = new Windows.Data.Xml.Dom.XmlDocument();
                            xmlDocument.LoadXml(xmlToastTemplate);
                            ToastNotification toast = new ToastNotification(xmlDocument);
                            ToastNotificationManager.CreateToastNotifier().Show(toast);
                            clearHandOnGUI();
                            clearMyMonsterCardsOnGUI();
                            clearMySpellAndTrapCardsOnGUI();
                            clearOppMonsterCardsOnGUI();
                            placeMyMonsterCardsOnGUI();
                            placeMySpellAndTrapCardsOnGUI();
                            placeOppMonsterCardsOnGUI();
                            updateLifePoints();
                            List<Object> hand = me.getHand() as List<Object>;
                            for (int i = 0; i < hand.Count; i++)
                            {
                                placeHandCardOnGUI(hand[i], i);
                            }
                            collapseUnused();
                        }
                    }
                }
                else
                {
                    IList<MonsterCard> oppMonsters = me.getOpponent().getFaceUpMonstersInMonsterZone();
                    MonsterCard toAttack = null;
                    for (int i = 0; i < oppMonsters.Count; i++)
                    {
                        if (OppMonsterThreeNameBlock.Text.Equals(oppMonsters[i].getName()))
                        {
                            toAttack = oppMonsters[i];
                            break;
                        }
                    }
                    if (toAttack != null)
                    {
                        string result = me.AttackFaceUpOpponent(myCurrentlySelectedCard as MonsterCard, toAttack);
                        if (result == "")
                        {
                            clearHandOnGUI();
                            clearMyMonsterCardsOnGUI();
                            clearMySpellAndTrapCardsOnGUI();
                            clearOppMonsterCardsOnGUI();
                            placeMyMonsterCardsOnGUI();
                            placeMySpellAndTrapCardsOnGUI();
                            placeOppMonsterCardsOnGUI();
                            updateLifePoints();
                            List<Object> hand = me.getHand() as List<Object>;
                            for (int i = 0; i < hand.Count; i++)
                            {
                                placeHandCardOnGUI(hand[i], i);
                            }
                            collapseUnused();
                        }
                        else
                        {
                            // template to load for showing Toast Notification
                            var xmlToastTemplate = "<toast launch=\"app-defined-string\">" +
                                                     "<visual>" +
                                                       "<binding template =\"ToastGeneric\">" +
                                                         "<text>Can't Attack Monster</text>" +
                                                         "<text>" +
                                                           result +
                                                         "</text>" +
                                                       "</binding>" +
                                                     "</visual>" +
                                                   "</toast>";
                            // load the template as XML document
                            var xmlDocument = new Windows.Data.Xml.Dom.XmlDocument();
                            xmlDocument.LoadXml(xmlToastTemplate);
                            ToastNotification toast = new ToastNotification(xmlDocument);
                            ToastNotificationManager.CreateToastNotifier().Show(toast);
                            clearHandOnGUI();
                            clearMyMonsterCardsOnGUI();
                            clearMySpellAndTrapCardsOnGUI();
                            clearOppMonsterCardsOnGUI();
                            placeMyMonsterCardsOnGUI();
                            placeMySpellAndTrapCardsOnGUI();
                            placeOppMonsterCardsOnGUI();
                            updateLifePoints();
                            List<Object> hand = me.getHand() as List<Object>;
                            for (int i = 0; i < hand.Count; i++)
                            {
                                placeHandCardOnGUI(hand[i], i);
                            }
                            collapseUnused();
                        }
                    }
                    else
                    {
                        clearHandOnGUI();
                        clearMyMonsterCardsOnGUI();
                        clearMySpellAndTrapCardsOnGUI();
                        clearOppMonsterCardsOnGUI();
                        placeMyMonsterCardsOnGUI();
                        placeMySpellAndTrapCardsOnGUI();
                        placeOppMonsterCardsOnGUI();
                        updateLifePoints();
                        List<Object> hand = me.getHand() as List<Object>;
                        for (int i = 0; i < hand.Count; i++)
                        {
                            placeHandCardOnGUI(hand[i], i);
                        }
                        collapseUnused();
                    }
                }
            }
        }

        private void OppMonsterFourZone_Tapped(object sender, TappedRoutedEventArgs e)
        {
            if (myCurrentlySelectedCard is MonsterCard)
            {
                if (OppMonsterFourNameBlock.Text.Contains("?"))
                {
                    if (OppMonsterFourAttackPoints.Text.Contains("ATKMode"))
                    {
                        string result = me.AttackFaceDownOpponent(myCurrentlySelectedCard as MonsterCard, Mode.Attack);
                        if (result == "")
                        {
                            clearHandOnGUI();
                            clearMyMonsterCardsOnGUI();
                            clearMySpellAndTrapCardsOnGUI();
                            clearOppMonsterCardsOnGUI();
                            placeMyMonsterCardsOnGUI();
                            placeMySpellAndTrapCardsOnGUI();
                            placeOppMonsterCardsOnGUI();
                            updateLifePoints();
                            List<Object> hand = me.getHand() as List<Object>;
                            for (int i = 0; i < hand.Count; i++)
                            {
                                placeHandCardOnGUI(hand[i], i);
                            }
                            collapseUnused();
                        }
                        else
                        {
                            // template to load for showing Toast Notification
                            var xmlToastTemplate = "<toast launch=\"app-defined-string\">" +
                                                     "<visual>" +
                                                       "<binding template =\"ToastGeneric\">" +
                                                         "<text>Can't Attack Monster</text>" +
                                                         "<text>" +
                                                           result +
                                                         "</text>" +
                                                       "</binding>" +
                                                     "</visual>" +
                                                   "</toast>";
                            // load the template as XML document
                            var xmlDocument = new Windows.Data.Xml.Dom.XmlDocument();
                            xmlDocument.LoadXml(xmlToastTemplate);
                            ToastNotification toast = new ToastNotification(xmlDocument);
                            ToastNotificationManager.CreateToastNotifier().Show(toast);
                            clearHandOnGUI();
                            clearMyMonsterCardsOnGUI();
                            clearMySpellAndTrapCardsOnGUI();
                            clearOppMonsterCardsOnGUI();
                            placeMyMonsterCardsOnGUI();
                            placeMySpellAndTrapCardsOnGUI();
                            placeOppMonsterCardsOnGUI();
                            updateLifePoints();
                            List<Object> hand = me.getHand() as List<Object>;
                            for (int i = 0; i < hand.Count; i++)
                            {
                                placeHandCardOnGUI(hand[i], i);
                            }
                            collapseUnused();
                        }
                    }
                    else
                    {
                        string result = me.AttackFaceDownOpponent(myCurrentlySelectedCard as MonsterCard, Mode.Defense);
                        if (result == "")
                        {
                            clearHandOnGUI();
                            clearMyMonsterCardsOnGUI();
                            clearMySpellAndTrapCardsOnGUI();
                            clearOppMonsterCardsOnGUI();
                            placeMyMonsterCardsOnGUI();
                            placeMySpellAndTrapCardsOnGUI();
                            placeOppMonsterCardsOnGUI();
                            updateLifePoints();
                            List<Object> hand = me.getHand() as List<Object>;
                            for (int i = 0; i < hand.Count; i++)
                            {
                                placeHandCardOnGUI(hand[i], i);
                            }
                            collapseUnused();
                        }
                        else
                        {
                            // template to load for showing Toast Notification
                            var xmlToastTemplate = "<toast launch=\"app-defined-string\">" +
                                                     "<visual>" +
                                                       "<binding template =\"ToastGeneric\">" +
                                                         "<text>Can't Attack Monster</text>" +
                                                         "<text>" +
                                                           result +
                                                         "</text>" +
                                                       "</binding>" +
                                                     "</visual>" +
                                                   "</toast>";
                            // load the template as XML document
                            var xmlDocument = new Windows.Data.Xml.Dom.XmlDocument();
                            xmlDocument.LoadXml(xmlToastTemplate);
                            ToastNotification toast = new ToastNotification(xmlDocument);
                            ToastNotificationManager.CreateToastNotifier().Show(toast);
                            clearHandOnGUI();
                            clearMyMonsterCardsOnGUI();
                            clearMySpellAndTrapCardsOnGUI();
                            clearOppMonsterCardsOnGUI();
                            placeMyMonsterCardsOnGUI();
                            placeMySpellAndTrapCardsOnGUI();
                            placeOppMonsterCardsOnGUI();
                            updateLifePoints();
                            List<Object> hand = me.getHand() as List<Object>;
                            for (int i = 0; i < hand.Count; i++)
                            {
                                placeHandCardOnGUI(hand[i], i);
                            }
                            collapseUnused();
                        }
                    }
                }
                else
                {
                    IList<MonsterCard> oppMonsters = me.getOpponent().getFaceUpMonstersInMonsterZone();
                    MonsterCard toAttack = null;
                    for (int i = 0; i < oppMonsters.Count; i++)
                    {
                        if (OppMonsterFourNameBlock.Text.Equals(oppMonsters[i].getName()))
                        {
                            toAttack = oppMonsters[i];
                            break;
                        }
                    }
                    if (toAttack != null)
                    {
                        string result = me.AttackFaceUpOpponent(myCurrentlySelectedCard as MonsterCard, toAttack);
                        if (result == "")
                        {
                            clearHandOnGUI();
                            clearMyMonsterCardsOnGUI();
                            clearMySpellAndTrapCardsOnGUI();
                            clearOppMonsterCardsOnGUI();
                            placeMyMonsterCardsOnGUI();
                            placeMySpellAndTrapCardsOnGUI();
                            placeOppMonsterCardsOnGUI();
                            updateLifePoints();
                            List<Object> hand = me.getHand() as List<Object>;
                            for (int i = 0; i < hand.Count; i++)
                            {
                                placeHandCardOnGUI(hand[i], i);
                            }
                            collapseUnused();
                        }
                        else
                        {
                            // template to load for showing Toast Notification
                            var xmlToastTemplate = "<toast launch=\"app-defined-string\">" +
                                                     "<visual>" +
                                                       "<binding template =\"ToastGeneric\">" +
                                                         "<text>Can't Attack Monster</text>" +
                                                         "<text>" +
                                                           result +
                                                         "</text>" +
                                                       "</binding>" +
                                                     "</visual>" +
                                                   "</toast>";
                            // load the template as XML document
                            var xmlDocument = new Windows.Data.Xml.Dom.XmlDocument();
                            xmlDocument.LoadXml(xmlToastTemplate);
                            ToastNotification toast = new ToastNotification(xmlDocument);
                            ToastNotificationManager.CreateToastNotifier().Show(toast);
                            clearHandOnGUI();
                            clearMyMonsterCardsOnGUI();
                            clearMySpellAndTrapCardsOnGUI();
                            clearOppMonsterCardsOnGUI();
                            placeMyMonsterCardsOnGUI();
                            placeMySpellAndTrapCardsOnGUI();
                            placeOppMonsterCardsOnGUI();
                            updateLifePoints();
                            List<Object> hand = me.getHand() as List<Object>;
                            for (int i = 0; i < hand.Count; i++)
                            {
                                placeHandCardOnGUI(hand[i], i);
                            }
                            collapseUnused();
                        }
                    }
                    else
                    {
                        clearHandOnGUI();
                        clearMyMonsterCardsOnGUI();
                        clearMySpellAndTrapCardsOnGUI();
                        clearOppMonsterCardsOnGUI();
                        placeMyMonsterCardsOnGUI();
                        placeMySpellAndTrapCardsOnGUI();
                        placeOppMonsterCardsOnGUI();
                        updateLifePoints();
                        List<Object> hand = me.getHand() as List<Object>;
                        for (int i = 0; i < hand.Count; i++)
                        {
                            placeHandCardOnGUI(hand[i], i);
                        }
                        collapseUnused();
                    }
                }
            }
        }

        private void OppMonsterFiveZone_Tapped(object sender, TappedRoutedEventArgs e)
        {
            if (myCurrentlySelectedCard is MonsterCard)
            {
                if (OppMonsterFiveNameBlock.Text.Contains("?"))
                {
                    if (OppMonsterFiveAttackPoints.Text.Contains("ATKMode"))
                    {
                        string result = me.AttackFaceDownOpponent(myCurrentlySelectedCard as MonsterCard, Mode.Attack);
                        if (result == "")
                        {
                            clearHandOnGUI();
                            clearMyMonsterCardsOnGUI();
                            clearMySpellAndTrapCardsOnGUI();
                            clearOppMonsterCardsOnGUI();
                            placeMyMonsterCardsOnGUI();
                            placeMySpellAndTrapCardsOnGUI();
                            placeOppMonsterCardsOnGUI();
                            updateLifePoints();
                            List<Object> hand = me.getHand() as List<Object>;
                            for (int i = 0; i < hand.Count; i++)
                            {
                                placeHandCardOnGUI(hand[i], i);
                            }
                            collapseUnused();
                        }
                        else
                        {
                            // template to load for showing Toast Notification
                            var xmlToastTemplate = "<toast launch=\"app-defined-string\">" +
                                                     "<visual>" +
                                                       "<binding template =\"ToastGeneric\">" +
                                                         "<text>Can't Attack Monster</text>" +
                                                         "<text>" +
                                                           result +
                                                         "</text>" +
                                                       "</binding>" +
                                                     "</visual>" +
                                                   "</toast>";
                            // load the template as XML document
                            var xmlDocument = new Windows.Data.Xml.Dom.XmlDocument();
                            xmlDocument.LoadXml(xmlToastTemplate);
                            ToastNotification toast = new ToastNotification(xmlDocument);
                            ToastNotificationManager.CreateToastNotifier().Show(toast);
                            clearHandOnGUI();
                            clearMyMonsterCardsOnGUI();
                            clearMySpellAndTrapCardsOnGUI();
                            clearOppMonsterCardsOnGUI();
                            placeMyMonsterCardsOnGUI();
                            placeMySpellAndTrapCardsOnGUI();
                            placeOppMonsterCardsOnGUI();
                            updateLifePoints();
                            List<Object> hand = me.getHand() as List<Object>;
                            for (int i = 0; i < hand.Count; i++)
                            {
                                placeHandCardOnGUI(hand[i], i);
                            }
                            collapseUnused();
                        }
                    }
                    else
                    {
                        string result = me.AttackFaceDownOpponent(myCurrentlySelectedCard as MonsterCard, Mode.Defense);
                        if (result == "")
                        {
                            clearHandOnGUI();
                            clearMyMonsterCardsOnGUI();
                            clearMySpellAndTrapCardsOnGUI();
                            clearOppMonsterCardsOnGUI();
                            placeMyMonsterCardsOnGUI();
                            placeMySpellAndTrapCardsOnGUI();
                            placeOppMonsterCardsOnGUI();
                            updateLifePoints();
                            List<Object> hand = me.getHand() as List<Object>;
                            for (int i = 0; i < hand.Count; i++)
                            {
                                placeHandCardOnGUI(hand[i], i);
                            }
                            collapseUnused();
                        }
                        else
                        {
                            // template to load for showing Toast Notification
                            var xmlToastTemplate = "<toast launch=\"app-defined-string\">" +
                                                     "<visual>" +
                                                       "<binding template =\"ToastGeneric\">" +
                                                         "<text>Can't Attack Monster</text>" +
                                                         "<text>" +
                                                           result +
                                                         "</text>" +
                                                       "</binding>" +
                                                     "</visual>" +
                                                   "</toast>";
                            // load the template as XML document
                            var xmlDocument = new Windows.Data.Xml.Dom.XmlDocument();
                            xmlDocument.LoadXml(xmlToastTemplate);
                            ToastNotification toast = new ToastNotification(xmlDocument);
                            ToastNotificationManager.CreateToastNotifier().Show(toast);
                            clearHandOnGUI();
                            clearMyMonsterCardsOnGUI();
                            clearMySpellAndTrapCardsOnGUI();
                            clearOppMonsterCardsOnGUI();
                            placeMyMonsterCardsOnGUI();
                            placeMySpellAndTrapCardsOnGUI();
                            placeOppMonsterCardsOnGUI();
                            updateLifePoints();
                            List<Object> hand = me.getHand() as List<Object>;
                            for (int i = 0; i < hand.Count; i++)
                            {
                                placeHandCardOnGUI(hand[i], i);
                            }
                            collapseUnused();
                        }
                    }
                }
                else
                {
                    IList<MonsterCard> oppMonsters = me.getOpponent().getFaceUpMonstersInMonsterZone();
                    MonsterCard toAttack = null;
                    for (int i = 0; i < oppMonsters.Count; i++)
                    {
                        if (OppMonsterFiveNameBlock.Text.Equals(oppMonsters[i].getName()))
                        {
                            toAttack = oppMonsters[i];
                            break;
                        }
                    }
                    if (toAttack != null)
                    {
                        string result = me.AttackFaceUpOpponent(myCurrentlySelectedCard as MonsterCard, toAttack);
                        if (result == "")
                        {
                            clearHandOnGUI();
                            clearMyMonsterCardsOnGUI();
                            clearMySpellAndTrapCardsOnGUI();
                            clearOppMonsterCardsOnGUI();
                            placeMyMonsterCardsOnGUI();
                            placeMySpellAndTrapCardsOnGUI();
                            placeOppMonsterCardsOnGUI();
                            updateLifePoints();
                            List<Object> hand = me.getHand() as List<Object>;
                            for (int i = 0; i < hand.Count; i++)
                            {
                                placeHandCardOnGUI(hand[i], i);
                            }
                            collapseUnused();
                        }
                        else
                        {
                            // template to load for showing Toast Notification
                            var xmlToastTemplate = "<toast launch=\"app-defined-string\">" +
                                                     "<visual>" +
                                                       "<binding template =\"ToastGeneric\">" +
                                                         "<text>Can't Attack Monster</text>" +
                                                         "<text>" +
                                                           result +
                                                         "</text>" +
                                                       "</binding>" +
                                                     "</visual>" +
                                                   "</toast>";
                            // load the template as XML document
                            var xmlDocument = new Windows.Data.Xml.Dom.XmlDocument();
                            xmlDocument.LoadXml(xmlToastTemplate);
                            ToastNotification toast = new ToastNotification(xmlDocument);
                            ToastNotificationManager.CreateToastNotifier().Show(toast);
                            clearHandOnGUI();
                            clearMyMonsterCardsOnGUI();
                            clearMySpellAndTrapCardsOnGUI();
                            clearOppMonsterCardsOnGUI();
                            placeMyMonsterCardsOnGUI();
                            placeMySpellAndTrapCardsOnGUI();
                            placeOppMonsterCardsOnGUI();
                            updateLifePoints();
                            List<Object> hand = me.getHand() as List<Object>;
                            for (int i = 0; i < hand.Count; i++)
                            {
                                placeHandCardOnGUI(hand[i], i);
                            }
                            collapseUnused();
                        }
                    }
                    else
                    {
                        clearHandOnGUI();
                        clearMyMonsterCardsOnGUI();
                        clearMySpellAndTrapCardsOnGUI();
                        clearOppMonsterCardsOnGUI();
                        placeMyMonsterCardsOnGUI();
                        placeMySpellAndTrapCardsOnGUI();
                        placeOppMonsterCardsOnGUI();
                        updateLifePoints();
                        List<Object> hand = me.getHand() as List<Object>;
                        for (int i = 0; i < hand.Count; i++)
                        {
                            placeHandCardOnGUI(hand[i], i);
                        }
                        collapseUnused();
                    }
                }
            }
        }

        private void OppMonsterSixZone_Tapped(object sender, TappedRoutedEventArgs e)
        {
            if (myCurrentlySelectedCard is MonsterCard)
            {
                if (OppMonsterSixNameBlock.Text.Contains("?"))
                {
                    if (OppMonsterSixAttackPoints.Text.Contains("ATKMode"))
                    {
                        string result = me.AttackFaceDownOpponent(myCurrentlySelectedCard as MonsterCard, Mode.Attack);
                        if (result == "")
                        {
                            clearHandOnGUI();
                            clearMyMonsterCardsOnGUI();
                            clearMySpellAndTrapCardsOnGUI();
                            clearOppMonsterCardsOnGUI();
                            placeMyMonsterCardsOnGUI();
                            placeMySpellAndTrapCardsOnGUI();
                            placeOppMonsterCardsOnGUI();
                            updateLifePoints();
                            List<Object> hand = me.getHand() as List<Object>;
                            for (int i = 0; i < hand.Count; i++)
                            {
                                placeHandCardOnGUI(hand[i], i);
                            }
                            collapseUnused();
                        }
                        else
                        {
                            // template to load for showing Toast Notification
                            var xmlToastTemplate = "<toast launch=\"app-defined-string\">" +
                                                     "<visual>" +
                                                       "<binding template =\"ToastGeneric\">" +
                                                         "<text>Can't Attack Monster</text>" +
                                                         "<text>" +
                                                           result +
                                                         "</text>" +
                                                       "</binding>" +
                                                     "</visual>" +
                                                   "</toast>";
                            // load the template as XML document
                            var xmlDocument = new Windows.Data.Xml.Dom.XmlDocument();
                            xmlDocument.LoadXml(xmlToastTemplate);
                            ToastNotification toast = new ToastNotification(xmlDocument);
                            ToastNotificationManager.CreateToastNotifier().Show(toast);
                            clearHandOnGUI();
                            clearMyMonsterCardsOnGUI();
                            clearMySpellAndTrapCardsOnGUI();
                            clearOppMonsterCardsOnGUI();
                            placeMyMonsterCardsOnGUI();
                            placeMySpellAndTrapCardsOnGUI();
                            placeOppMonsterCardsOnGUI();
                            updateLifePoints();
                            List<Object> hand = me.getHand() as List<Object>;
                            for (int i = 0; i < hand.Count; i++)
                            {
                                placeHandCardOnGUI(hand[i], i);
                            }
                            collapseUnused();
                        }
                    }
                    else
                    {
                        string result = me.AttackFaceDownOpponent(myCurrentlySelectedCard as MonsterCard, Mode.Defense);
                        if (result == "")
                        {
                            clearHandOnGUI();
                            clearMyMonsterCardsOnGUI();
                            clearMySpellAndTrapCardsOnGUI();
                            clearOppMonsterCardsOnGUI();
                            placeMyMonsterCardsOnGUI();
                            placeMySpellAndTrapCardsOnGUI();
                            placeOppMonsterCardsOnGUI();
                            updateLifePoints();
                            List<Object> hand = me.getHand() as List<Object>;
                            for (int i = 0; i < hand.Count; i++)
                            {
                                placeHandCardOnGUI(hand[i], i);
                            }
                            collapseUnused();
                        }
                        else
                        {
                            // template to load for showing Toast Notification
                            var xmlToastTemplate = "<toast launch=\"app-defined-string\">" +
                                                     "<visual>" +
                                                       "<binding template =\"ToastGeneric\">" +
                                                         "<text>Can't Attack Monster</text>" +
                                                         "<text>" +
                                                           result +
                                                         "</text>" +
                                                       "</binding>" +
                                                     "</visual>" +
                                                   "</toast>";
                            // load the template as XML document
                            var xmlDocument = new Windows.Data.Xml.Dom.XmlDocument();
                            xmlDocument.LoadXml(xmlToastTemplate);
                            ToastNotification toast = new ToastNotification(xmlDocument);
                            ToastNotificationManager.CreateToastNotifier().Show(toast);
                            clearHandOnGUI();
                            clearMyMonsterCardsOnGUI();
                            clearMySpellAndTrapCardsOnGUI();
                            clearOppMonsterCardsOnGUI();
                            placeMyMonsterCardsOnGUI();
                            placeMySpellAndTrapCardsOnGUI();
                            placeOppMonsterCardsOnGUI();
                            updateLifePoints();
                            List<Object> hand = me.getHand() as List<Object>;
                            for (int i = 0; i < hand.Count; i++)
                            {
                                placeHandCardOnGUI(hand[i], i);
                            }
                            collapseUnused();
                        }
                    }
                }
                else
                {
                    IList<MonsterCard> oppMonsters = me.getOpponent().getFaceUpMonstersInMonsterZone();
                    MonsterCard toAttack = null;
                    for (int i = 0; i < oppMonsters.Count; i++)
                    {
                        if (OppMonsterSixNameBlock.Text.Equals(oppMonsters[i].getName()))
                        {
                            toAttack = oppMonsters[i];
                            break;
                        }
                    }
                    if (toAttack != null)
                    {
                        string result = me.AttackFaceUpOpponent(myCurrentlySelectedCard as MonsterCard, toAttack);
                        if (result == "")
                        {
                            clearHandOnGUI();
                            clearMyMonsterCardsOnGUI();
                            clearMySpellAndTrapCardsOnGUI();
                            clearOppMonsterCardsOnGUI();
                            placeMyMonsterCardsOnGUI();
                            placeMySpellAndTrapCardsOnGUI();
                            placeOppMonsterCardsOnGUI();
                            updateLifePoints();
                            List<Object> hand = me.getHand() as List<Object>;
                            for (int i = 0; i < hand.Count; i++)
                            {
                                placeHandCardOnGUI(hand[i], i);
                            }
                            collapseUnused();
                        }
                        else
                        {
                            // template to load for showing Toast Notification
                            var xmlToastTemplate = "<toast launch=\"app-defined-string\">" +
                                                     "<visual>" +
                                                       "<binding template =\"ToastGeneric\">" +
                                                         "<text>Can't Attack Monster</text>" +
                                                         "<text>" +
                                                           result +
                                                         "</text>" +
                                                       "</binding>" +
                                                     "</visual>" +
                                                   "</toast>";
                            // load the template as XML document
                            var xmlDocument = new Windows.Data.Xml.Dom.XmlDocument();
                            xmlDocument.LoadXml(xmlToastTemplate);
                            ToastNotification toast = new ToastNotification(xmlDocument);
                            ToastNotificationManager.CreateToastNotifier().Show(toast);
                            clearHandOnGUI();
                            clearMyMonsterCardsOnGUI();
                            clearMySpellAndTrapCardsOnGUI();
                            clearOppMonsterCardsOnGUI();
                            placeMyMonsterCardsOnGUI();
                            placeMySpellAndTrapCardsOnGUI();
                            placeOppMonsterCardsOnGUI();
                            updateLifePoints();
                            List<Object> hand = me.getHand() as List<Object>;
                            for (int i = 0; i < hand.Count; i++)
                            {
                                placeHandCardOnGUI(hand[i], i);
                            }
                            collapseUnused();
                        }
                    }
                    else
                    {
                        clearHandOnGUI();
                        clearMyMonsterCardsOnGUI();
                        clearMySpellAndTrapCardsOnGUI();
                        clearOppMonsterCardsOnGUI();
                        placeMyMonsterCardsOnGUI();
                        placeMySpellAndTrapCardsOnGUI();
                        placeOppMonsterCardsOnGUI();
                        updateLifePoints();
                        List<Object> hand = me.getHand() as List<Object>;
                        for (int i = 0; i < hand.Count; i++)
                        {
                            placeHandCardOnGUI(hand[i], i);
                        }
                        collapseUnused();
                    }
                }
            }
        }

        private void MyMonsterOneZone_DoubleTapped(object sender, DoubleTappedRoutedEventArgs e)
        {

            if (myCurrentlySelectedStackPanel != null && currentlySelectedCardType == CurrentlySelectedCardType.Hand)
            {
                myCurrentlySelectedStackPanel.BorderBrush = new SolidColorBrush(Windows.UI.Color.FromArgb(255, 128, 0, 128));
            }
            else if (myCurrentlySelectedCard != null && currentlySelectedCardType == CurrentlySelectedCardType.Monster)
            {
                myCurrentlySelectedStackPanel.BorderBrush = new SolidColorBrush(Windows.UI.Color.FromArgb(255, 239, 244, 255));
            }
            StackPanel s = sender as StackPanel;
            s.BorderBrush = new SolidColorBrush(Windows.UI.Color.FromArgb(255, 0, 255, 0));
            myCurrentlySelectedCard = getField()[0];
            myCurrentlySelectedStackPanel = s;
            currentlySelectedCardType = CurrentlySelectedCardType.Monster;
            me.ChangeModeOfCard(myCurrentlySelectedCard as MonsterCard);
            clearMyMonsterCardsOnGUI();
            placeMyMonsterCardsOnGUI();
        }

        private void MyMonsterTwoZone_DoubleTapped(object sender, DoubleTappedRoutedEventArgs e)
        {
            if (myCurrentlySelectedStackPanel == null || (myCurrentlySelectedStackPanel != (sender as StackPanel)))
            {
                if (myCurrentlySelectedStackPanel != null && currentlySelectedCardType == CurrentlySelectedCardType.Hand)
                {
                    myCurrentlySelectedStackPanel.BorderBrush = new SolidColorBrush(Windows.UI.Color.FromArgb(255, 128, 0, 128));
                }
                else if (myCurrentlySelectedCard != null && currentlySelectedCardType == CurrentlySelectedCardType.Monster)
                {
                    myCurrentlySelectedStackPanel.BorderBrush = new SolidColorBrush(Windows.UI.Color.FromArgb(255, 239, 244, 255));
                }
                StackPanel s = sender as StackPanel;
                s.BorderBrush = new SolidColorBrush(Windows.UI.Color.FromArgb(255, 0, 255, 0));
                myCurrentlySelectedCard = getField()[1];
                myCurrentlySelectedStackPanel = s;
                currentlySelectedCardType = CurrentlySelectedCardType.Monster;
                me.ChangeModeOfCard(myCurrentlySelectedCard as MonsterCard);
                clearMyMonsterCardsOnGUI();
                placeMyMonsterCardsOnGUI();
            }
            else
            {
                disEngageCurrentlySelected();
            }
        }

        private void MyMonsterThreeZone_DoubleTapped(object sender, DoubleTappedRoutedEventArgs e)
        {
            if (myCurrentlySelectedStackPanel == null || (myCurrentlySelectedStackPanel != (sender as StackPanel)))
            {
                if (myCurrentlySelectedStackPanel != null && currentlySelectedCardType == CurrentlySelectedCardType.Hand)
                {
                    myCurrentlySelectedStackPanel.BorderBrush = new SolidColorBrush(Windows.UI.Color.FromArgb(255, 128, 0, 128));
                }
                else if (myCurrentlySelectedCard != null && currentlySelectedCardType == CurrentlySelectedCardType.Monster)
                {
                    myCurrentlySelectedStackPanel.BorderBrush = new SolidColorBrush(Windows.UI.Color.FromArgb(255, 239, 244, 255));
                }
                StackPanel s = sender as StackPanel;
                s.BorderBrush = new SolidColorBrush(Windows.UI.Color.FromArgb(255, 0, 255, 0));
                myCurrentlySelectedCard = getField()[2];
                myCurrentlySelectedStackPanel = s;
                currentlySelectedCardType = CurrentlySelectedCardType.Monster;
                me.ChangeModeOfCard(myCurrentlySelectedCard as MonsterCard);
                clearMyMonsterCardsOnGUI();
                placeMyMonsterCardsOnGUI();
            }
            else
            {
                disEngageCurrentlySelected();
            }
        }

        private void MyMonsterFourZone_DoubleTapped(object sender, DoubleTappedRoutedEventArgs e)
        {
            if (myCurrentlySelectedStackPanel == null || (myCurrentlySelectedStackPanel != (sender as StackPanel)))
            {
                if (myCurrentlySelectedStackPanel != null && currentlySelectedCardType == CurrentlySelectedCardType.Hand)
                {
                    myCurrentlySelectedStackPanel.BorderBrush = new SolidColorBrush(Windows.UI.Color.FromArgb(255, 128, 0, 128));
                }
                else if (myCurrentlySelectedCard != null && currentlySelectedCardType == CurrentlySelectedCardType.Monster)
                {
                    myCurrentlySelectedStackPanel.BorderBrush = new SolidColorBrush(Windows.UI.Color.FromArgb(255, 239, 244, 255));
                }
                StackPanel s = sender as StackPanel;
                s.BorderBrush = new SolidColorBrush(Windows.UI.Color.FromArgb(255, 0, 255, 0));
                myCurrentlySelectedCard = getField()[3];
                myCurrentlySelectedStackPanel = s;
                currentlySelectedCardType = CurrentlySelectedCardType.Monster;
                me.ChangeModeOfCard(myCurrentlySelectedCard as MonsterCard);
                clearMyMonsterCardsOnGUI();
                placeMyMonsterCardsOnGUI();
            }
            else
            {
                disEngageCurrentlySelected();
            }
        }

        private void MyMonsterFiveZone_DoubleTapped(object sender, DoubleTappedRoutedEventArgs e)
        {
            if (myCurrentlySelectedStackPanel == null || (myCurrentlySelectedStackPanel != (sender as StackPanel)))
            {
                if (myCurrentlySelectedStackPanel != null && currentlySelectedCardType == CurrentlySelectedCardType.Hand)
                {
                    myCurrentlySelectedStackPanel.BorderBrush = new SolidColorBrush(Windows.UI.Color.FromArgb(255, 128, 0, 128));
                }
                else if (myCurrentlySelectedCard != null && currentlySelectedCardType == CurrentlySelectedCardType.Monster)
                {
                    myCurrentlySelectedStackPanel.BorderBrush = new SolidColorBrush(Windows.UI.Color.FromArgb(255, 239, 244, 255));
                }
                StackPanel s = sender as StackPanel;
                s.BorderBrush = new SolidColorBrush(Windows.UI.Color.FromArgb(255, 0, 255, 0));
                myCurrentlySelectedCard = getField()[4];
                myCurrentlySelectedStackPanel = s;
                currentlySelectedCardType = CurrentlySelectedCardType.Monster;
                me.ChangeModeOfCard(myCurrentlySelectedCard as MonsterCard);
                clearMyMonsterCardsOnGUI();
                placeMyMonsterCardsOnGUI();
            }
            else
            {
                disEngageCurrentlySelected();
            }
        }

        private void MyMonsterSixZone_DoubleTapped(object sender, DoubleTappedRoutedEventArgs e)
        {
            if (myCurrentlySelectedStackPanel == null || (myCurrentlySelectedStackPanel != (sender as StackPanel)))
            {
                if (myCurrentlySelectedStackPanel != null && currentlySelectedCardType == CurrentlySelectedCardType.Hand)
                {
                    myCurrentlySelectedStackPanel.BorderBrush = new SolidColorBrush(Windows.UI.Color.FromArgb(255, 128, 0, 128));
                }
                else if (myCurrentlySelectedCard != null && currentlySelectedCardType == CurrentlySelectedCardType.Monster)
                {
                    myCurrentlySelectedStackPanel.BorderBrush = new SolidColorBrush(Windows.UI.Color.FromArgb(255, 239, 244, 255));
                }
                StackPanel s = sender as StackPanel;
                s.BorderBrush = new SolidColorBrush(Windows.UI.Color.FromArgb(255, 0, 255, 0));
                myCurrentlySelectedCard = getField()[5];
                myCurrentlySelectedStackPanel = s;
                currentlySelectedCardType = CurrentlySelectedCardType.Monster;
                me.ChangeModeOfCard(myCurrentlySelectedCard as MonsterCard);
                clearMyMonsterCardsOnGUI();
                placeMyMonsterCardsOnGUI();
            }
            else
            {
                disEngageCurrentlySelected();
            }
        }

        private void SacrificeBtn_Tapped(object sender, TappedRoutedEventArgs e)
        {
            if(currentlySelectedCardType==CurrentlySelectedCardType.Monster)
            {
                me.Sacrifice(myCurrentlySelectedCard as MonsterCard);
                clearMyMonsterCardsOnGUI();
                placeMyMonsterCardsOnGUI();
            }
        }
        /*
        private void PhaseBtn_Tapped(object sender, TappedRoutedEventArgs e)
        {
            me.ChangePhase();
        }
        */
    }
}
