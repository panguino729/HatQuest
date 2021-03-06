﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace HatQuest
{
    /// <summary>
    /// Elijah, Jack
    /// </summary>
    class EnemyType
    {
        //Fields
        //All vales are the baseline maximums
        //Changes in stats such as current health should be heald in the Enemy object
        public string Name { get; }
        public Texture2D Sprite { get; }
        public int Health { get; }
        public int Attack { get; }
        public int Defense { get; }
        public List<Ability> Abilities { get; }
        public bool IsBoss { get; }
        public bool IsRandom { get; }
        public int HatPosition { get; }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="name">Name of the enemy</param>
        /// <param name="health">Base max health</param>
        /// <param name="attack">Base attack</param>
        /// <param name="defense">Base defense</param>
        /// <param name="abilities">Base abilities</param>
        public EnemyType(string name, Texture2D sprite, int health, int attack, int defense, Ability[] abilities, bool isBoss, int hatPosition)
        {
            Name = name;
            Sprite = sprite;
            Health = health;
            Attack = attack;
            Defense = defense;
            Abilities = abilities.ToList<Ability>();
            IsBoss = isBoss;
            IsRandom = false;
            HatPosition = hatPosition;
        }

        /// <summary>
        /// Create a random EnemyType. This object stores no data and the IsRandom property should be
        /// checked when directly handling this object.
        /// </summary>
        public EnemyType()
        {
            IsRandom = true;
        }
    }
}
