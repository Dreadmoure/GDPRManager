﻿using System;
using Microsoft.Xna.Framework;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GDPRManager.ComponentPattern;

namespace GDPRManager.CommandPattern
{
    /// <summary>
    /// class for the movecommand
    /// </summary>
    public class MoveCommand : ICommand
    {
        private Vector2 velocity;

        /// <summary>
        /// sets the velocity based on the input
        /// </summary>
        /// <param name="velocity">which direction we want</param>
        public MoveCommand(Vector2 velocity)
        {
            this.velocity = velocity;
        }

        /// <summary>
        /// calls the move command on the player
        /// </summary>
        /// <param name="player">the player we need to execute the method on</param>
        public void Execute(Player player)
        {
            player.Move(velocity);
        }
    }
}
