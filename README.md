# PokerGame
## Description
Application to play poker with a computer opponent. 
## Goal of the project
Create a poker game that is easily extendable and flexible in regard of adding new kinds of rules.
By means of design batterns the extensions in game process can be added without excess modification of allready existing code.
### The pattersn used here are:
- Singleton (to make sure than only one instance of a player exists)
- Chain of Responsibility (to check the card combination. Especially useful uf you want to add a new poker rule that has a different set of Winning Combinations)
- Strategy (to ensure the ability of choosing game rules on the run)
- Template Methods (to allow editing the algorythm of performing different stages of the game)
- Facade (to make usage of the whole game easier)
## Features
- Choose two kinds of poker rules available: Irish Poker and Texas Holdem.
- Input your start budget and do the blind.
- Perform 3 kinds of Pokes moves: Fold, Call, Raise.
- Play multiple rounds against computer to and see if you can take all of his money.
- Make computer's money 0 to win. 
## Technologies
- C#, .Net Framework
- Linq
