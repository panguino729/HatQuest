﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

/* Iain Davis
 * The Abstract Ability class which every ability will inherit from
 * There are no known issues */

namespace HatQuest
{
    abstract class Ability
    {
        protected int manaCost;

        /// <summary>
        /// The MP cost of the ability
        /// </summary>
        public int ManaCost
        {
            get
            {
                return manaCost;
            }
        }

        /// <summary>
        /// The logic behind activating an ability
        /// </summary>
        /// <param name="attacker">The attacking Entity</param>
        /// <param name="defender">The defending Entity</param>
        public abstract void Activate(Entity attacker, Entity defender);
    }
}