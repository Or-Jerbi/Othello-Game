# Othello Game

This repository contains an implementation of the Othello game (also known as Reversi). The game follows the classic rules, where two players take turns placing pieces on an 8x8 or 6X6 board. The goal is to have the majority of your pieces on the board by the end of the game.

## Features

- **Classic Othello Gameplay:** Play against another human or AI.
- **Game Board:** 8x8 or 6x6 grid with standard Othello rules.
- **Piece Flipping Mechanism:** As per Othello's rules, pieces are flipped when enclosed by an opponent's pieces.
- **AI Opponent:** Option to play against a simple AI (if implemented).
- **Human vs Human Mode:** For a classic 2-player experience.

## Installation

1. Clone the repository:
    ```bash
    git clone https://github.com/Or-Jerbi/Othello-Game.git
    ```

2. Navigate to the directory:
    ```bash
    cd Othello-Game
    ```

3. Install dependencies:
    ```bash
    # Example if there are any dependencies like Python packages (not shown in this repository directly)
    pip install -r requirements.txt
    ```

   **Note:** This step may not be needed depending on your specific setup and the language used.

## Usage

To play the game, simply run the main file or script, which starts the game in a terminal (or GUI if available).

1. Run the game:
    ```bash
    python main.py
    ```

2. Follow the instructions in the terminal for either a human vs. human game or a human vs. AI game.

## Game Rules

- The board is 8x8 or 6x6.
- Players take turns placing their pieces on the board.
- A piece must be placed so that it "flanks" one or more of the opponent’s pieces.
- Once a player places a piece, all opponent pieces flanked by that piece are flipped to the player’s color.
- The game ends when neither player can make a move or the board is full.

