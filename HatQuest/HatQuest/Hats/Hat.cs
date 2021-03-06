﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using HatQuest.Init;

namespace HatQuest.Hats
{
    enum HatRarity { Common, Uncommon, Epic, Developer };

    /// <summary>
    /// Elijah
    /// </summary>
    class Hat
    {
        //Fields
        protected int maxHealth;
        protected int def;
        protected int atk;
        protected int maxMana;
        protected string name;
        protected string description;
        protected HatRarity rarity;
        protected Texture2D texture;
        protected Ability ability;
        protected Color color;
        protected Random r;

        //Properties
        public String Name
        {
            get
            {
                return name;
            }
        }

        public HatRarity Rarity
        {
            get
            {
                return rarity;
            }
        }

        /// <summary>
        /// Checks if this has gives the wearer a new ability
        /// </summary>
        public bool HasAbility
        {
            get
            {
                if(ability != null)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }

        public Ability Ability
        {
            get
            {
                return ability;
            }
        }
        
        /// <summary>
        /// Hats modify the stats of the Entity it's equipped to, but you must call the Equip method to actually apply
        /// the modifications
        /// </summary>
        /// <param name="texture">The Hat's texture</param>
        /// <param name="maxHealth">Any modification to the equipped Entity's maximum health</param>
        /// <param name="def">Any modification to the equipped Entity's defense</param>
        /// <param name="atk">Any modification to the equipped Entity's attack</param>
        /// <param name="maxMana">If the Entity's a player, this modifies their maximum mana</param>
        public Hat(string name, string description, Texture2D texture, Color color, HatRarity rarity, Ability ability = null, int maxHealth = 0, int def = 0, int atk = 0, int maxMana = 0)
        {
            this.texture = texture;
            this.maxHealth = maxHealth;
            this.def = def;
            this.atk = atk;
            this.maxMana = maxMana;
            this.name = name;
            this.description = description;
            this.rarity = rarity;
            this.ability = ability;
            this.color = color;
            r = new Random(5);
        }

        /// <summary>
        /// Equips the Hat to an Entity and modifies their stats accordingly
        /// </summary>
        /// <param name="entity">The Entity that the Hat will be equipped to</param>
        public virtual void Equip(Entity entity)
        {
            if (entity is Player)
            {
                ((Player)entity).MaxMP += maxMana;
                ((Player)entity).CurrentMP += maxMana;
            }
            else
            {
                if(ability != null)
                {
                    entity.Abilities.Add(ability.Clone(entity));
                }
            }
            entity.MaxHealth += maxHealth;
            entity.Health += maxHealth;
            entity.Def += def;
            entity.Atk += atk;
            entity.Hats.Add(this);
        }

        /// <summary>
        /// Used to equip hats to the player that give abilities
        /// </summary>
        /// <param name="player">Player</param>
        /// <param name="index">Index in the player's list of abilities too put the new ability in</param>
        public virtual void Equip(Player player, int index)
        {
            if(ability != null)
            {
                player.Abilities[index] = ability.Clone(player);
            }
            Equip(player);
        }

        /// <summary>
        /// Draws the hat
        /// </summary>
        /// <param name="sb">The SpriteBatch that draws the hat</param>
        public void Draw(SpriteBatch sb, Entity wearer, int hatNumber)
        {
            bool goingDown = false;
            bool offScreen = false;

            if (wearer != null)
            {
                if ((wearer.Position.Location.Y - SpritesDirectory.height / 8) - (SpritesDirectory.height / 8 * hatNumber) < 0 || (wearer.Position.Location.Y - SpritesDirectory.height / 8) - (SpritesDirectory.height / 8 * hatNumber) >= SpritesDirectory.height)
                {
                    offScreen = true;
                    goingDown = !goingDown;
                }

                if (!offScreen)
                {
                    sb.Draw(texture,
                        new Rectangle(new Point(wearer.Position.Location.X + SpritesDirectory.width / 80, 
                                              (wearer.Position.Location.Y - SpritesDirectory.height / 8) - (SpritesDirectory.height / 8 * hatNumber) + wearer.HatPosition),
                                      new Point((int)(SpritesDirectory.height / 6.4), (int)(SpritesDirectory.height / 6.4))),
                        color);
                }
                else if (goingDown)
                {
                    sb.Draw(texture,
                        new Rectangle(new Point(wearer.Position.Location.X + SpritesDirectory.width / 80 + ((int)(SpritesDirectory.height / 6.4) * 2) * ((hatNumber + 4) / 6), 
                                                               SpritesDirectory.height / 8 * ((hatNumber - 1) % 6)),
                        new Point(-(int)(SpritesDirectory.height / 6.4), -(int)(SpritesDirectory.height / 6.4))),
                        color);
                }
                else
                {
                    sb.Draw(texture,
                         new Rectangle(new Point(wearer.Position.Location.X + SpritesDirectory.width / 80 + (int)(SpritesDirectory.height / 6.4) * ((hatNumber + 4) / 6), 
                                                                SpritesDirectory.height - (SpritesDirectory.height / 8 * (hatNumber % 6))),
                                       new Point((int)(SpritesDirectory.height / 6.4), (int)(SpritesDirectory.height / 6.4))),
                         color);
                }
            }
            else
            {
                sb.Draw(texture, new Rectangle(new Point((int)(SpritesDirectory.height * 1.3), (int)(SpritesDirectory.width * .3)), new Point((int)(SpritesDirectory.height / 6.4), (int)(SpritesDirectory.height / 6.4))), color);
            }
            
        }
    }
}
