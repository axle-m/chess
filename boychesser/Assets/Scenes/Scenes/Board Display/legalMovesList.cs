using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class LegalMovesList : MonoBehaviour
{


    bool putsInCheck(int destinationIndex, Tile[] tiles)
    {
        return false;
    }

    public string[] getLegalMoves(Tile[] tiles)
    {
        string[] moves = new string[218];

        for (int i = 0; i < 64; i++)
        {
            bool isLeftEdge = i % 8 == 0;
            bool isRightEdge = i % 8 == 7;
            bool isTopEdge = i > 55;
            bool isBottomEdge = i < 8;

            //char movingPiece = curFen.ActiveColor == "w" ? 'w' : 'b';

            int[] knightMoves = { 15, 17, 10, 6, -15, -17, -10, -6 };
            int[] kingMoves = { 1, -1, 8, -8, 9, 7, -9, -7 };

            if (tiles[i] != null && tiles[i].hasPiece() /*&& tiles[i].getPieceType() == movingPiece*/)
            {
                switch (tiles[i].getPieceType())
                {
                    case 'k':
                        foreach (int move in kingMoves)
                        {
                            int destinationIndex = i + move;

                            //bounds check
                            if (destinationIndex >= 0 && destinationIndex < 64)
                            {
                                //wraparound check
                                int targetFile = destinationIndex % 8;
                                int curFile = i % 8;

                                if (curFile - targetFile == 1)
                                {
                                    if (tiles[destinationIndex].getPieceType() == '0' && !putsInCheck(destinationIndex, tiles))
                                    {
                                        string s = "K" + tiles[destinationIndex].getName();
                                        moves[MoveHasher.ChessMoveToHash(s)] = s;
                                        
                                    }
                                    else if (tiles[destinationIndex].getPieceColor() != tiles[i].getPieceColor() && !putsInCheck(destinationIndex, tiles))
                                    {
                                        string s = "Kx" + tiles[destinationIndex].getName();
                                        moves[MoveHasher.ChessMoveToHash(s)] = s;
                                    }
                                }
                            }
                        }

                        break;




                    case 'q':

                        //vertical moves

                        //move up
                        int tempIndex = i;
                        while (tempIndex + 8 < 63)
                        {
                            if (tiles[tempIndex + 8].getPieceType() == '0')
                            {
                                legalMovesList[1].Add("Q" + tiles[tempIndex + 8].getName());
                                tiles[i].setLegalMove(true);
                            }
                            else if (tiles[tempIndex + 8].getPieceColor() != tiles[i].getPieceColor())
                            {
                                legalMovesList[1].Add("Qx" + tiles[tempIndex + 8].getName());
                                tiles[i].setLegalMove(true);
                                break;
                            }
                            else
                            {
                                break;
                            }
                            tempIndex += 8;
                        }

                        //move down
                        tempIndex = i;
                        while (tempIndex - 8 > 0)
                        {
                            if (tiles[tempIndex - 8].getPieceType() == '0')
                            {
                                legalMovesList[1].Add("Q" + tiles[tempIndex - 8].getName());
                                tiles[i].setLegalMove(true);
                            }
                            else if (tiles[tempIndex - 8].getPieceColor() != tiles[i].getPieceColor())
                            {
                                legalMovesList[1].Add("Qx" + tiles[tempIndex - 8].getName());
                                tiles[i].setLegalMove(true);
                                break;
                            }
                            else
                            {
                                break;
                            }
                            tempIndex -= 8;
                        }

                        //horizontal moves

                        //move right
                        tempIndex = i;
                        while (tempIndex % 8 != 7)
                        {
                            if (tiles[tempIndex + 1].getPieceType() == '0')
                            {
                                legalMovesList[1].Add("Q" + tiles[tempIndex + 1].getName());
                                tiles[i].setLegalMove(true);
                            }
                            else if (tiles[tempIndex + 1].getPieceColor() != tiles[i].getPieceColor())
                            {
                                legalMovesList[1].Add("Qx" + tiles[tempIndex + 1].getName());
                                tiles[i].setLegalMove(true);
                                break;
                            }
                            else
                            {
                                break;
                            }
                            tempIndex += 1;
                        }

                        //move left
                        tempIndex = i;
                        while (tempIndex % 8 != 0)
                        {
                            if (tiles[tempIndex - 1].getPieceType() == '0')
                            {
                                legalMovesList[1].Add("Q" + tiles[tempIndex - 1].getName());
                                tiles[i].setLegalMove(true);
                            }
                            else if (tiles[tempIndex - 1].getPieceColor() != tiles[i].getPieceColor())
                            {
                                legalMovesList[1].Add("Qx" + tiles[tempIndex - 1].getName());
                                tiles[i].setLegalMove(true);
                                break;
                            }
                            else
                            {
                                break;
                            }
                            tempIndex -= 1;
                        }

                        // diagonal moves

                        // move up right
                        tempIndex = i;
                        while ((tempIndex % 8 != 7) && (tempIndex + 9 <= 63))
                        {
                            if (tiles[tempIndex + 9].getPieceType() == '0')
                            {
                                legalMovesList[1].Add("Q" + tiles[tempIndex + 9].getName());
                                tiles[i].setLegalMove(true);
                            }
                            else if (tiles[tempIndex + 9].getPieceColor() != tiles[i].getPieceColor())
                            {
                                legalMovesList[1].Add("Qx" + tiles[tempIndex + 9].getName());
                                tiles[i].setLegalMove(true);
                                break;
                            }
                            else
                            {
                                break;
                            }
                            tempIndex += 9;
                        }

                        // move up left
                        tempIndex = i;
                        while ((tempIndex % 8 != 0) && (tempIndex + 7 <= 63))
                        {
                            if (tiles[tempIndex + 7].getPieceType() == '0')
                            {
                                legalMovesList[1].Add("Q" + tiles[tempIndex + 7].getName());
                                tiles[i].setLegalMove(true);
                            }
                            else if (tiles[tempIndex + 7].getPieceColor() != tiles[i].getPieceColor())
                            {
                                legalMovesList[1].Add("Qx" + tiles[tempIndex + 7].getName());
                                tiles[i].setLegalMove(true);
                                break;
                            }
                            else
                            {
                                break;
                            }
                            tempIndex += 7;
                        }

                        // move down right
                        tempIndex = i;
                        while ((tempIndex % 8 != 7) && (tempIndex - 7 >= 0))
                        {
                            if (tiles[tempIndex - 7].getPieceType() == '0')
                            {
                                legalMovesList[1].Add("Q" + tiles[tempIndex - 7].getName());
                                tiles[i].setLegalMove(true);
                            }
                            else if (tiles[tempIndex - 7].getPieceColor() != tiles[i].getPieceColor())
                            {
                                legalMovesList[1].Add("Qx" + tiles[tempIndex - 7].getName());
                                tiles[i].setLegalMove(true);
                                break;
                            }
                            else
                            {
                                break;
                            }
                            tempIndex -= 7;
                        }

                        // move down left
                        tempIndex = i;
                        while ((tempIndex % 8 != 0) && (tempIndex - 9 >= 0))
                        {
                            if (tiles[tempIndex - 9].getPieceType() == '0')
                            {
                                legalMovesList[1].Add("Q" + tiles[tempIndex - 9].getName());
                                tiles[i].setLegalMove(true);
                            }
                            else if (tiles[tempIndex - 9].getPieceColor() != tiles[i].getPieceColor())
                            {
                                legalMovesList[1].Add("Qx" + tiles[tempIndex - 9].getName());
                                tiles[i].setLegalMove(true);
                                break;
                            }
                            else
                            {
                                break;
                            }
                            tempIndex -= 9;
                        }

                        break;



                    case 'r':

                        //vertical moves

                        //move up
                        tempIndex = i;
                        while (tempIndex + 8 < 63)
                        {
                            if (tiles[tempIndex + 8].getPieceType() == '0')
                            {
                                legalMovesList[2].Add("R" + tiles[tempIndex + 8].getName());
                                tiles[i].setLegalMove(true);
                            }
                            else if (tiles[tempIndex + 8].getPieceColor() != tiles[i].getPieceColor())
                            {
                                legalMovesList[2].Add("Rx" + tiles[tempIndex + 8].getName());
                                tiles[i].setLegalMove(true);
                                break;
                            }
                            else
                            {
                                break;
                            }
                            tempIndex += 8;
                        }

                        //move down
                        tempIndex = i;
                        while (tempIndex - 8 > 0)
                        {
                            if (tiles[tempIndex - 8].getPieceType() == '0')
                            {
                                legalMovesList[2].Add("R" + tiles[tempIndex - 8].getName());
                                tiles[i].setLegalMove(true);
                            }
                            else if (tiles[tempIndex - 8].getPieceColor() != tiles[i].getPieceColor())
                            {
                                legalMovesList[2].Add("Rx" + tiles[tempIndex - 8].getName());
                                tiles[i].setLegalMove(true);
                                break;
                            }
                            else
                            {
                                break;
                            }
                            tempIndex -= 8;
                        }

                        //horizontal moves

                        //move right
                        tempIndex = i;
                        while (tempIndex % 8 != 7)
                        {
                            if (tiles[tempIndex + 1].getPieceType() == '0')
                            {
                                legalMovesList[2].Add("R" + tiles[tempIndex + 1].getName());
                                tiles[i].setLegalMove(true);
                            }
                            else if (tiles[tempIndex + 1].getPieceColor() != tiles[i].getPieceColor())
                            {
                                legalMovesList[2].Add("Rx" + tiles[tempIndex + 1].getName());
                                tiles[i].setLegalMove(true);
                                break;
                            }
                            else
                            {
                                break;
                            }
                            tempIndex += 1;
                        }

                        //move left
                        while (tempIndex % 8 != 0)
                        {
                            if (tiles[tempIndex - 1].getPieceType() == '0')
                            {
                                legalMovesList[2].Add("R" + tiles[tempIndex - 1].getName());
                                tiles[i].setLegalMove(true);
                            }
                            else if (tiles[tempIndex - 1].getPieceColor() != tiles[i].getPieceColor())
                            {
                                legalMovesList[2].Add("Rx" + tiles[tempIndex - 1].getName());
                                tiles[i].setLegalMove(true);
                                break;
                            }
                            else
                            {
                                break;
                            }
                            tempIndex -= 1;
                        }

                        break;




                    case 'b':

                        //move up right
                        tempIndex = i;
                        while ((tempIndex % 8 != 7) && (tempIndex + 9 <= 63))
                        {
                            if (tiles[tempIndex + 9].getPieceType() == '0')
                            {
                                legalMovesList[3].Add("B" + tiles[tempIndex + 9].getName());
                                tiles[i].setLegalMove(true);
                            }
                            else if (tiles[tempIndex + 9].getPieceColor() != tiles[i].getPieceColor())
                            {
                                legalMovesList[3].Add("Bx" + tiles[tempIndex + 9].getName());
                                tiles[i].setLegalMove(true);
                                break;
                            }
                            else
                            {
                                break;
                            }
                            tempIndex += 9;
                        }

                        // move up left
                        tempIndex = i;
                        while ((tempIndex % 8 != 0) && (tempIndex + 7 <= 63))
                        {
                            if (tiles[tempIndex + 7].getPieceType() == '0')
                            {
                                legalMovesList[3].Add("B" + tiles[tempIndex + 7].getName());
                                tiles[i].setLegalMove(true);
                            }
                            else if (tiles[tempIndex + 7].getPieceColor() != tiles[i].getPieceColor())
                            {
                                legalMovesList[3].Add("Bx" + tiles[tempIndex + 7].getName());
                                tiles[i].setLegalMove(true);
                                break;
                            }
                            else
                            {
                                break;
                            }
                            tempIndex += 7;
                        }

                        // move down right
                        tempIndex = i;
                        while ((tempIndex % 8 != 7) && (tempIndex - 7 >= 0))
                        {
                            if (tiles[tempIndex - 7].getPieceType() == '0')
                            {
                                legalMovesList[3].Add("B" + tiles[tempIndex - 7].getName());
                                tiles[i].setLegalMove(true);
                            }
                            else if (tiles[tempIndex - 7].getPieceColor() != tiles[i].getPieceColor())
                            {
                                legalMovesList[3].Add("Bx" + tiles[tempIndex - 7].getName());
                                tiles[i].setLegalMove(true);
                                break;
                            }
                            else
                            {
                                break;
                            }
                            tempIndex -= 7;
                        }

                        // move down left
                        tempIndex = i;
                        while ((tempIndex % 8 != 0) && (tempIndex - 9 >= 0))
                        {
                            if (tiles[tempIndex - 9].getPieceType() == '0')
                            {
                                legalMovesList[3].Add("B" + tiles[tempIndex - 9].getName());
                                tiles[i].setLegalMove(true);
                            }
                            else if (tiles[tempIndex - 9].getPieceColor() != tiles[i].getPieceColor())
                            {
                                legalMovesList[3].Add("Bx" + tiles[tempIndex - 9].getName());
                                tiles[i].setLegalMove(true);
                                break;
                            }
                            else
                            {
                                break;
                            }
                            tempIndex -= 9;
                        }

                        break;

                    case 'n':

                        foreach (int move in knightMoves)
                        {
                            int destinationIndex = i + move;

                            //bounds check
                            if (destinationIndex >= 0 && destinationIndex < 64)
                            {
                                //wraparound check
                                int targetFile = destinationIndex % 8;
                                int curFile = i % 8;

                                if (Math.Abs(targetFile - curFile) == 2 || Math.Abs(targetFile - curFile) == 1)
                                {
                                    if (tiles[destinationIndex].getPieceType() == '0')
                                    {
                                        legalMovesList[4].Add("N" + tiles[destinationIndex].getName());
                                    }
                                    else if (tiles[destinationIndex].getPieceColor() != tiles[i].getPieceColor())
                                    {
                                        legalMovesList[4].Add("Nx" + tiles[destinationIndex].getName());
                                    }
                                }
                            }
                        }

                        break;
                    case 'p':

                        switch (tiles[i].getPieceColor())
                        {
                            case 'w':
                                if (i + 8 < 64 && tiles[i + 8].getPieceType() == '0')
                                {
                                    legalMovesList[5].Add(tiles[i + 8].getName());
                                }

                                if (i + 16 < 64 && i < 16 && tiles[i + 16].getPieceType() == '0')
                                {
                                    legalMovesList[5].Add(tiles[i + 16].getName());
                                }

                                if (i + 7 < 64 && !isRightEdge && tiles[i + 7].getPieceColor() == 'b')
                                {
                                    legalMovesList[5].Add(tiles[i].getName().Substring(0, 1) + tiles[i + 7].getName());
                                }

                                if (i + 9 < 64 && !isLeftEdge && tiles[i + 9].getPieceColor() == 'b')
                                {
                                    legalMovesList[5].Add(tiles[i].getName().Substring(0, 1) + tiles[i + 9].getName());
                                }

                                break;
                            case 'b':
                                if (i - 8 >= 0 && tiles[i - 8].getPieceType() == '0')
                                {
                                    legalMovesList[5].Add(tiles[i - 8].getName());
                                }

                                if (i - 16 >= 0 && i > 47 && tiles[i - 16].getPieceType() == '0')
                                {
                                    legalMovesList[5].Add(tiles[i - 16].getName());
                                }

                                if (i - 7 >= 0 && !isLeftEdge && tiles[i - 7].getPieceColor() == 'w')
                                {
                                    legalMovesList[5].Add(tiles[i].getName().Substring(0, 1) + "x" + tiles[i - 7].getName());
                                }

                                if (i - 9 >= 0 && !isRightEdge && tiles[i - 9].getPieceColor() == 'w')
                                {
                                    legalMovesList[5].Add(tiles[i].getName().Substring(0, 1) + tiles[i - 9].getName());
                                }

                                break;
                        }

                        break;
                }
            }
        }

        for (int i = 0; i < 6; i++)
        {
            foreach (string move in legalMovesList[i])
            {
                Debug.Log(move);
            }
        }

        return legalMovesList;

    }



}
