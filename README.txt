CONTENTS OF THIS FILE
---------------------

 * Introduction
 * Requirements
 * Compile
 * Run Program
 * FAQ
 * Maintainers


INTRODUCTION
------------

This project includes 3 files an implementation file(.fs), a signature file(.fsi) and a script file(.fsx).
The purpose of this project is to create a functional board game in the console/terminal.


REQUIREMENTS
------------

Requirements to compile and run the program:

 *F#: (https://fsharp.org/)
 *Mono: (https://www.mono-project.com/)


COMPILE
-------

How to compile the program:

 *Linux:
    1.$ fsharpc --nologo -a <Filename>.fsi <Filename>.fs
    2.$ fsharpc --nologo -r <Filename>.dll <Filename>.fsx

 *Windows 10:
    1.> fsharpc --nologo -a <Filename>.fsi <Filename>.fs
    2.> fsharpc --nologo -r <Filename>.dll <Filename>.fsx

RUN PROGRAM
-----------

Starting the program:
 *Linux: $ mono <Filename>.exe
 *Win 10: > mono <Filename>.exe

When the program is running the following userinteractions are available:
On keyboard: 1 to 6 (selects pit in which to start on the current players side)

Stopping the program:
Ctrl-C


FAQ
---

Q: What is Awari?

A: Oware is an abstract 2-player strategy game among the Mancala family of board games
   (pit and pebble ... A common name in English is Awari but one of the earliest Western scholars to study the game,
   Robert Sutherland Rattray, used the name Wari. The game is about winning,
   you win by getting more beans in your home pit than your opponent gets in is.

Q: Is this the best Awari game ever made?

A: Yes it is.

Q: What is the best strategy for winning every game in Awari?

A: Don't suck. It ain't that difficult


MAINTAINERS
-----------

Current maintainers:
 * Frederik Berthelsen - https://absalon.ku.dk/courses/28623/users/279406
 * Kasper Schmidt-Christensen - https://absalon.ku.dk/courses/28623/users/280516
 * Christian Franck - https://absalon.ku.dk/courses/28623/users/280667

This project has been sponsored by:
 * No one at the moment- If interested in being sponsor for our project, or potential future projects; contact Frederik Berthelsen

########################################################
########################################################
###      ######         ###         ###             ####
#####    ######         ###         ###            #####
#####    ##########     #######     #########     ######
#####    ######         ###         ########     #######
#####    ######         ###         #######     ########
#####    ##########     #######     ######     #########
#####    ##########     #######     #####     ##########
###         ###         ###         ####     ###########
########################################################
########################################################
