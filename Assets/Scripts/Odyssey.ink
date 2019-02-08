// Unusually for an Ink story, this story doesn't really have a "start" point.
// Instead our GameController script always use an explicit knot to start from,
// via story.ChoosePathString(). Each island is assigned a knot name to be that
// island's starting point in the story.

VAR crew = 10
VAR gold = 0

// Randomly pick one from some of the simpler story fragments
=== random_encounter ===
{shuffle:
          - -> island_of_dogs
          - -> island_of_frogs
          - -> abandoned_island
}

=== island_of_dogs ===
This island is full of dogs! Amazing.

1 member of your crew decides to stay behind and live with the dogs.

~ crew = crew - 1

-> DONE

=== island_of_frogs ===
This island is covered by frogs! Fascinating.

Also you find a few coins in the sand.

~ gold = gold + 3 

-> DONE

=== abandoned_island ===
There's nobody here ... wait, no -- someone has been stranded here! She's barely alive. You nurse her back to health, and she joins your crew.

~ crew = crew + 1
 
-> DONE

=== cyclops ===
A terrible cyclops has made this island his home.

* Offer him some wine.
  He loves it, and drinks several barrels. You slip away as he sleeps it off.
  You'll have to buy more wine at the next port. It should cost about 5 coins.
  ~ gold = gold - 5
  -> DONE
* Offer to let him eat your crew.
  He happily devours 3 members of your crew. They are so delicious that he gives you 20 gold coins before sending you on your way.
  ~ gold = gold + 20
  ~ crew = crew - 3
  -> DONE

=== home ===
~ gold = 20
~ crew = 20

{
  - crew < 1:
    You have arrived home, but can't dock the ship without any crew to help you.
  - gold < 5:
    You have arrived home, but can't afford the docking fee of 5 gold coins. 
  - else:
    You have arrived home. Argos and Penelope are delighted. You win!
}

# ENDING
- -> DONE
