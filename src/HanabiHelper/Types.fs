module HanabiHelper.Types

type Color = Red | White | Blue | Green | Yellow

type Number = One | Two | Three | Four | Five

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