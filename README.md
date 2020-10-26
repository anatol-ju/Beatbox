# Beatbox
The ultimate damage-dealer

## Important Information

This application started recently as a base project to learn C#, .NET and more important WPF.
I hope it indicates how well I am progressing with this (for me) new technology stack.

## What to expect

The idea is to make an "idle" application, that simulates simple combat logic.
The user/player makes attacks and deals damage with each hit.
Also, there are some stats available to change the behaviour (see below).
When reaching an amount of damage dealt, he reaches next level.
Each level-up grants one "skill-point" that can be spent into one of these stats:
- Attack Power: increases damage with each hit
- Critical Strike Rating: improves chance to get double damage with a strike
- Haste Rating: reduces time between attacks
For each level-up there is a higher value of damage dealt required, therefore the player must decide how to improve his stats more efficient.
For later releases, it is planned to have a possible interaction of the player with the application to increase the damage putput (like a real idle game).

## Update (22.10.)

First working version released!
Yes! Thats right. After a few days of working with C# and WPF my small application is really doing great.
I managed to get some nice functionality going:
- UI design (using different panels and controls using WPF)
- control binding (using XAML and C# for events)
- a text area to keep track of numbers
- animation, yes thats right (making images move on the UI)
- background worker included (calculating stuff while UI stays responsive)
But that's only the beginning, more to come. But this is how it looks like now (from VS).

![Beatbox_01](https://user-images.githubusercontent.com/55158774/96895948-45dd3000-148d-11eb-91af-6b77ffb3cbe5.png)

## How to use

For now, before the first release, download the code (or clone it) and execute it in Visual Studio.
