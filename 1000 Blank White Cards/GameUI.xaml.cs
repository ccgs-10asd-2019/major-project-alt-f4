﻿using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media.Imaging;
using System.Collections.Generic;
using System.Windows.Input;

namespace _1000_Blank_White_Cards
{
    /// <summary>
    /// Interaction logic for GameUI.xaml
    /// </summary>
    public partial class GameUI : Page
    {
        public EventHandler ladder;
        List<Button> buttons = new List<Button>();
        int globalCounter = 1;


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
            image.Source = new BitmapImage(new Uri($"cards/nyan the cat print.jpg", UriKind.Relative));
            buttons[buttons.Count - 1].Content = image;
            GameUIGrid.Children.Add(buttons[buttons.Count - 1]);
            buttons[buttons.Count - 1].Click += playCard;
            buttons[buttons.Count - 1].Height = 77;
            buttons[buttons.Count - 1].Width = 59;
            buttons[buttons.Count - 1].VerticalAlignment = VerticalAlignment.Bottom;
            buttons[buttons.Count - 1].HorizontalAlignment = HorizontalAlignment.Left;
            buttons[buttons.Count - 1].Name = "Button" + Convert.ToString(globalCounter);
            globalCounter += 1;
            buttons[buttons.Count - 1].MouseEnter += bigg;
            buttons[buttons.Count - 1].MouseLeave += smol;
            reorganiseCards();
        }

        private void bigg(object sender, RoutedEventArgs e)
        {
            Button card = (Button)sender;
            reorganiseCards();
            //card.Margin = new Thickness(card.Margin.Left - 10, card.Margin.Top - 15, 0, 0);
            card.Height += 30;
            card.Width += 20;
            GameUIGrid.Children.RemoveAt((int)GameUIGrid.Children.IndexOf(card));
            GameUIGrid.Children.Add(card);
        }

        private void smol(object sender, RoutedEventArgs e)
        {
            Button card = (Button)sender;
            //card.Margin = new Thickness(card.Margin.Left + 10, card.Margin.Top + 15, 0, 0);
            card.Height -= 30;
            card.Width -= 20;
            reorganiseCards();
        }

        private void reorganiseCards()
        {
            if (buttons.Count > 9)
            {
                for (var x = 0; x < buttons.Count; x++)
                {
                    buttons[x].Margin = new Thickness(x * buttons[0].Width * 9/buttons.Count + TextScroller.Width + 60 - buttons[x].Width, 270, 0, 0);
                    GameUIGrid.Children.RemoveAt((int)GameUIGrid.Children.IndexOf(buttons[x]));
                    GameUIGrid.Children.Add(buttons[x]);
                }
            }
            else
            {
                for (var x = 0; x < buttons.Count; x++)
                {
                    buttons[x].Margin = new Thickness((x-1) * buttons[0].Width + TextScroller.Width + 60, 270, 0, 0);
                    GameUIGrid.Children.RemoveAt((int)GameUIGrid.Children.IndexOf(buttons[x]));
                    GameUIGrid.Children.Add(buttons[x]);
                }
            }
        }

        public void ClimbLadder(object sender, RoutedEventArgs e)
        {
            ladder(this, EventArgs.Empty);
        }

        private void DrawCard_MouseEnter(object sender, System.Windows.Input.MouseEventArgs e)
        {
            DrawCard.Margin = new Thickness(0, 50, 32, 0);
            DrawCard.Height += 10;
            DrawCard.Width += 8;
        }

        private void DrawCard_MouseLeave(object sender, System.Windows.Input.MouseEventArgs e)
        {
            DrawCard.Margin = new Thickness(0, 55, 36, 0);
            DrawCard.Height -= 10;
            DrawCard.Width -= 8;
        }


        private void GimmeText(object sender, RoutedEventArgs e)
        {
            if (TypeText.Text != "")
            {
                TextBlock blockOfText = new TextBlock();
                blockOfText.Text = TypeText.Text;
                blockOfText.TextWrapping = TextWrapping.Wrap;
                blockOfText.FontSize = 6;

                stackTwoElectricBoogaloo.Children.Add(blockOfText);

                TextScroller.ScrollToBottom();

                TypeText.Text = "";
            }
        }

        private void textPush(object sender, System.Windows.Input.KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                if (TypeText.Text != "")
                {
                    TextBlock blockOfText = new TextBlock();
                    blockOfText.Text = TypeText.Text;
                    blockOfText.TextWrapping = TextWrapping.Wrap;
                    blockOfText.FontSize = 6;

                    stackTwoElectricBoogaloo.Children.Add(blockOfText);

                    TextScroller.ScrollToBottom();

                    TypeText.Text = "";
                }
            }
        }
    }
}