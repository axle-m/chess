using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class ChessBot
{
    
    /* a couple of things:
     * methods in this class should be static
     * the bot takes in a board and an array of legal moves
     * there should be a method bestMove(String[] moves, String board) that returns the best move
     * 
     * Also you're currently passing in a LegalMovesList object, and then using it to create an array of legal moves. You should be using a string array. Refer to randomMove for how it should be implemented
     * although i did modify the other method signatures to take in a string array instead of a LegalMovesList object and a fen string to describe a board
     */

    void Start()
    {

    }

    void Update()
    {
    }

    // Selects a random legal move and logs it
    public static string randomMove(String[] moves){
        System.Random rnd = new System.Random();
        string move = moves[rnd.Next(0, moves.Length)];
        Debug.Log(move + " bot move");//maybe instead of move add something more specific like "Evaluating move (currentLegalMoves[i] with score {score}");
        return move;
    }

   
    string bestPositionMove(String[] currentLegalMoves, String fenString){
        //Make a 2d array
        //Inside each array, first index is the move, the second index is the value
        //Store them as strings, String.GetNumbericalValue to get the second value

        List<string[]> movesAndValueList = new List<string[]>();
        //int val = int.Parse(ints[index][1]);
        double highestValue = 0;
        int index = 0;
        if(currentLegalMoves.Length == 0){
            Debug.LogWarning("No legal moves available");
            return null;
        }
        for(int i = 0; i < currentLegalMoves.Length; i++){
            Fen move = new Fen(Fen.move(fenString, currentLegalMoves[i]));
            double moveValue = getPositionScoring(move);
            if(moveValue > highestValue){
                highestValue = moveValue;
                index = i;
            }
            string[] movesAndValueArray = {currentLegalMoves[i], moveValue.ToString()};
            movesAndValueList.Add(movesAndValueArray);
        }
        return currentLegalMoves[index];

        //Goes through all legal moves, Applies scorer, stores move, returns move with highest value


        //This returns the best possible move based on position however more can be done
        //We can use the 2d array (movesAndValueList) choose between the best 1-3 or 1-5 
        //It should still favor the best move  the probability could be something like ⌄⌄⌄
        //(1st - 70%, 2nd - 15%, 3rd - 5%, 4th - 5%, 5th - 5%)?
        //We could keep track of those indicies or sort the arrays to figure this out

        //Question: Should this return a string (move played) or fen (curFen + move played)?
    }
    // HEY GUYS READ THIS: how about we compress the best position move and the best piece move into one class?
    /*this is a possible implementation of this: 
    string GetBestMove(LegalMovesList legalMovesList, Func<Fen, double> scoringFunction){
    double highestValue = double.MinValue;
    int index = -1;
    string[] currentLegalMoves = (string[])legalMovesList.getLegalMoves(board.curFen);
    string fenString = board.curFen;


    for (int i = 0; i < currentLegalMoves.Length; i++)
    {
        Fen move = new Fen(Fen.move(fenString, currentLegalMoves[i]));
        double score = scoringFunction(move);


        if (score > highestValue)
        {
            highestValue = score;
            index = i;
        }
    }


    return index >= 0 ? currentLegalMoves[index] : null; // Handle no valid moves
}*/
// ALSO we should also be able to call this new class with something like string bestPosition(or)PieceMove = GetBestMove(legalMovesList, getPositionScoring);





    string bestPieceMove(String[] currentLegalMoves, String fenString)
    {
        double highestValue = 0;
        int index = 0;
        List<string[]> movesAndValueList = new List<string[]>();
        if(currentLegalMoves.Length == 0){
            Debug.LogWarning("No legal moves available");  //ADDED THIS just in case of checkmate bugs - Max
                                                           //good forsight but i dont have checks implemented and i think we'll stick to a pseudo legal moves list where a position without a king is checkmate and the bot scoring algorithm should prevent it from giving up the king
            return null;
        }
        for(int i = 0; i < currentLegalMoves.Length; i++){
            Fen move = new Fen(Fen.move(fenString, currentLegalMoves[i]));
            double moveValue = getPieceScoring(move);
            if(moveValue > highestValue){
                highestValue = moveValue;
                index = i;
            }
            string[] movesAndValueArray = {currentLegalMoves[i], moveValue.ToString()};
            movesAndValueList.Add(movesAndValueArray);
        }
        return currentLegalMoves[index];
        //This is a copy-paste of the position mover just different scorer used
    }


    public double getPositionScoring(Fen fen){
        return Scorer.getPositionScore(fen); 
    }

    public double getPieceScoring(Fen fen){
        return Scorer.getPieceScore(fen); 
    }
}