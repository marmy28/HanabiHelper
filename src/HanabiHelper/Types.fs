module HanabiHelper.Types

type Color = Red = 0 | White = 5 | Blue = 23 | Green =  45 | Yellow = 46

type Number = One = 1 | Two = 2 | Three = 3 | Four = 4 | Five = 5

type Clue =
    | Color of Color
    | Number of Number
    | NotColor of Color
    | NotNumber of Number

type Card = {Color: Color; Number: Number}

type PlayerCard = {Card: Card; ClueCollection: Clue list}

type Hand = (Card * Clue list) list

type Discard = Card list

type Deck = Card list

type Firework = {Color: Color; Cards: Card list}

type FireworkDisplay = Firework list