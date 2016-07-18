﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace AgarIO
{
    public class LoginManager
    {
        LoginForm loginForm;

        public LoginManager(LoginForm loginForm)
        {
            this.loginForm = loginForm;
        }

        /// <summary>
        /// Method that will try to start the game.
        /// Should be called from the UI thread.
        /// </summary>
        /// <returns></returns>
        public async Task StartGameAsync()
        {
            ServerConnection connection;
            try
            {
                connection = await ServerConnection.ConnectAsync(IPAddress.Loopback, loginForm.LoginTextBox.Text);
            } catch (Exception ex)
            {
                loginForm.InfoLabel.Text = ex.Message;
                return;
            }

            Game game = new Game();
            GameForm gameForm = new GameForm();
            GraphicsEngine graphicsEngine = new GraphicsEngine(gameForm);
            InputManager inputManager = new InputManager(gameForm, game);

            game.Init(this, graphicsEngine, inputManager, connection);
            game.Start();
            loginForm.Visible = false;
        }

        public void Show(string closingMsg)
        {
            loginForm.BeginInvoke(new Action(() =>
            {
                loginForm.InfoLabel.Text = closingMsg;
                loginForm.Visible = true;
            }));
        }
    }
}