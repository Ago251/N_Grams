# N_Grams

![image](https://github.com/user-attachments/assets/a4606fcf-1272-4bc9-b9a8-2dfa1cf6c89f)

## Introduction

This project implements an AI to play the game of Rock, Paper, Scissors using N-Gram analysis. The goal of this AI is to predict the player's next move based on the history of previous moves, using patterns of sequences (N-Grams) from the past to make more informed choices.

By analyzing the opponent's move sequences, the AI can attempt to anticipate the next choice and adjust its strategy accordingly. This project showcases how N-Grams, often used in natural language processing, can be applied to game strategy prediction.

## How It Works

The AI builds a model from the player's previous moves to predict the next one. The process involves:
1. **Tracking Move History**: The AI records the sequence of moves made by the player.
2. **N-Gram Generation**: The AI uses N-Grams (combinations of `N` previous moves) to analyze the patterns.
3. **Predicting the Next Move**: Based on the frequency and occurrence of certain move sequences in the history, the AI predicts the most likely next move.
4. **Choosing a Counter-Move**: The AI selects the optimal move that would beat the predicted move.

For example, if the player often follows a pattern of "Rock → Paper → Rock", the AI will recognize this sequence and predict "Rock" might follow "Paper" again, and will counter with "Paper".
