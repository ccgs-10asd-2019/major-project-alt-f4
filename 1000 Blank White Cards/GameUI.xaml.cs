﻿using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media.Imaging;
using System.Collections.Generic;

namespace _1000_Blank_White_Cards
{
    /// <summary>
    /// Interaction logic for GameUI.xaml
    /// </summary>
    public partial class GameUI : Page
    {
        public EventHandler ladder;
        List<Button> buttons = new List<Button>();

        public GameUI()
        {
            InitializeComponent();
            for (var x = 0; x < 5; x++)
            {
                summonDeckCard(null, null);
            }
        }

        private void playCard(object sender, RoutedEventArgs e)
        {
            Button button = (Button)sender;
            buttons.Remove(button);
            GameUIGrid.Children.Remove(button);
            reorganiseCards();
            Image image = (Image)button.Content;
            discardPile.Source = image.Source;
        }

        public void summonDeckCard(object sender, RoutedEventArgs e)
        {
            buttons.Add(new Button());
            Image image = new Image();
            image.Source = new BitmapImage( new Uri($"cards/3 headed guard dog2 print.jpg", UriKind.Relative));
            buttons[buttons.Count-1].Content = image;
            GameUIGrid.Children.Add(buttons[buttons.Count-1]);
            buttons[buttons.Count - 1].Click += playCard;
            //Margin = "0,0"
            buttons[buttons.Count - 1].Height = 77;
            buttons[buttons.Count - 1].Width = 59;
            

            
            reorganiseCards();
        }
        
        private void reorganiseCards()
        {
            if (buttons.Count > 9)
            {
                for (var x = 0; x < buttons.Count; x++)
                {
                    buttons[x].Margin = new Thickness((x+1) * 120 * 9 / buttons.Count - 590, 270,0 , 0);
                }
            }
            else
            {
                for (var x = 0; x < buttons.Count; x++)
                {
                    buttons[x].Margin = new Thickness((x+1) * 120 - 590, 270, 0, 0);
                }
            }
        }

        public void ClimbLadder(object sender, RoutedEventArgs e)
        {
            ladder(this, EventArgs.Empty);
        }

        private void DrawCard_MouseEnter(object sender, System.Windows.Input.MouseEventArgs e)
        {
            /*
            Button DrawCard = (Button)sender;
            int width = 96;
            int height = 130;
            int larger = 100;
            DrawCard.RenderSize = new Size(width + larger, height + larger);
            */
            /*
            Button DrawCard = (Button)sender;
            int width = DrawCard.RenderSize.Width;
            int height = DrawCard.RednerSize.Height;
            int larger = 10;
            DrawCard.Size = new Size(width + larger, height + larger);
            */
        }
    }
}
