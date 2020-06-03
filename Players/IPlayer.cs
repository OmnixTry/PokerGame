using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MainGameProject.Cards;

namespace MainGameProject.Player
{
    /// <summary>
    /// Interface for all the poker player classes
    /// </summary>
    interface IPlayer
    {
        /// <summary>
        /// Takes the list of cards and puts it into players hand
        /// </summary>
        /// <param name="hand">A list of cards to hand the player</param>
        void HandOutCards(List<Card> hand);

        /// <summary>
        /// Taker a particular sum of money from player's cash and puts it as a bet
        /// </summary>
        /// <param name="bet">A sum of money to bet</param>
        /// <returns>A sum to bet</returns>
        uint MakeBet(uint bet);

        /// <summary>
        /// Standart action that player can perform during preflop, flop, rutn, river.
        /// </summary>
        /// <returns>Decision that player has taken: Fold, Call, or Raise</returns>
        Game.decision PerformAction();

        /// <summary>
        /// Performs action specific to a particular preflop
        /// </summary>
        void PreflopAction();

        /// <summary>
        /// Performs action specific to a particular flop
        /// </summary>
        void FlopAction();

        /// <summary>
        /// Performs action specific to a particular turn
        /// </summary>
        void TurnAction();

        /// <summary>
        /// Performs action specific to a particular river
        /// </summary>
        void RiverAction();

        /// <summary>
        /// Adds the sum of money in the bank to Player's cash when player wins
        /// </summary>
        /// <param name="bank"></param>
        void WinBank(uint bank);

        /// <summary>
        /// Discards card from the hand
        /// </summary>
        /// <param name="toDiscard">List of cards for player to discard</param>
        void Discard(List<Card> toDiscard);
    }
}
