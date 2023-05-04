using System;
using Xamarin.Forms;

namespace AppTTT
{
    public class GeneralClass
    {
        public bool hasGoneInn = false;
        public GeneralClass()
        {
            var item= Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            var data = new Data() { Adderss="Address",Name="JC"};
            MessagingCenter.Send<Data>(data, "Hi");

        }

        public string[] CheckIfThereIs3RowsOf_X(string[] Board, out int IfHaveInputted)
        {
            IfHaveInputted = 0;


            if (Board[4] == "X")
                for (int Index = 0; Index < 9; Index++)
                {
                    int Index_Back = 8 - Index;
                    if (Board[Index] == "X" && (Board[Index_Back] != "O" && Board[Index_Back] != "X"))
                    { Board[Index_Back] = "O"; IfHaveInputted = 1; break; }
                }

            int EvenNumber = 0;
            if (IfHaveInputted != 1)
                for (int i = 0; i < 2; i++)
                {
                    if ((Board[EvenNumber] == "X" && Board[2] == "X") && (Board[(EvenNumber + 2) / 2] != "O" && Board[(EvenNumber + 2) / 2] != "X"))
                    { Board[(EvenNumber + 2) / 2] = "O"; IfHaveInputted = 1; }
                    if ((Board[EvenNumber] == "X" && Board[6] == "X") && (Board[(EvenNumber + 6) / 2] != "O" && Board[(EvenNumber + 6) / 2] != "X"))
                    { Board[(EvenNumber + 6) / 2] = "O"; IfHaveInputted = 1; }
                    EvenNumber = EvenNumber + 8;
                }
            int OddNumber = 1;
            if (IfHaveInputted != 1)
                for (int i = 0; i < 4; i++)
                {
                    if (OddNumber == 1 || OddNumber == 7)
                    {
                        if (Board[OddNumber] == "X" && Board[OddNumber + 1] == "X" && (Board[OddNumber - 1] != "O" && Board[OddNumber - 1] != "X"))
                        { Board[OddNumber - 1] = "O"; IfHaveInputted = 1; }
                        if (Board[OddNumber] == "X" && Board[OddNumber - 1] == "X" && (Board[OddNumber + 1] != "O" && Board[OddNumber + 1] != "X"))
                        { Board[OddNumber + 1] = "O"; IfHaveInputted = 1; }
                    }
                    if (OddNumber == 3 || OddNumber == 5)
                    {
                        if (Board[OddNumber] == "X" && Board[OddNumber + 3] == "X" && (Board[OddNumber - 3] != "O" && Board[OddNumber - 3] != "X"))
                        { Board[OddNumber - 3] = "O"; IfHaveInputted = 1; }
                        if (Board[OddNumber] == "X" && Board[OddNumber - 3] == "X" && (Board[OddNumber + 3] != "O" && Board[OddNumber + 3] != "X"))
                        { Board[OddNumber + 3] = "O"; IfHaveInputted = 1; }
                    }
                    OddNumber = OddNumber + 2;
                }
            return Board;

        }
        public string[] CheckIfThereIs3RowsOf_O(string[] Board, out int IfHaveInputted)
        {
            IfHaveInputted = 0;
            if (Board[4] == "O")
                for (int i = 0; i < 9; i++)
                {
                    int IndexFromBack = 8 - i;
                    if (Board[i] == "O" && (Board[IndexFromBack] != "O" && Board[IndexFromBack] != "X"))
                    { Board[IndexFromBack] = "O"; IfHaveInputted = 1; break; }
                }
            int EvenNumberInBoard = 0;
            for (int i = 0; i < 2; i++)
            {
                if ((Board[EvenNumberInBoard] == "O" && Board[2] == "O") && (Board[(EvenNumberInBoard + 2) / 2] != "O" && Board[(EvenNumberInBoard + 2) / 2] != "X"))
                { Board[(EvenNumberInBoard + 2) / 2] = "O"; IfHaveInputted = 1; }
                if ((Board[EvenNumberInBoard] == "O" && Board[6] == "O") && (Board[(EvenNumberInBoard + 6) / 2] != "O" && Board[(EvenNumberInBoard + 6) / 2] != "X"))
                { Board[(EvenNumberInBoard + 6) / 2] = "O"; IfHaveInputted = 1; }
                EvenNumberInBoard = EvenNumberInBoard + 8;
            }
            int oddNumberFromBoard = 1;
            for (int i = 0; i < 4; i++)
            {
                if (oddNumberFromBoard == 1 || oddNumberFromBoard == 7)
                {
                    if (Board[oddNumberFromBoard] == "O" && Board[oddNumberFromBoard + 1] == "O" && (Board[oddNumberFromBoard - 1] != "O" && Board[oddNumberFromBoard - 1] != "X"))
                    { Board[oddNumberFromBoard - 1] = "O"; IfHaveInputted = 1; }
                    if (Board[oddNumberFromBoard] == "O" && Board[oddNumberFromBoard - 1] == "O" && (Board[oddNumberFromBoard + 1] != "O" && Board[oddNumberFromBoard + 1] != "X"))
                    { Board[oddNumberFromBoard + 1] = "O"; IfHaveInputted = 1; }
                }
                if (oddNumberFromBoard == 3 || oddNumberFromBoard == 5)
                {
                    if (Board[oddNumberFromBoard] == "O" && Board[oddNumberFromBoard + 3] == "O" && (Board[oddNumberFromBoard - 3] != "O" && Board[oddNumberFromBoard - 3] != "X"))
                    { Board[oddNumberFromBoard - 3] = "O"; IfHaveInputted = 1; }
                    if (Board[oddNumberFromBoard] == "O" && Board[oddNumberFromBoard - 3] == "O" && (Board[oddNumberFromBoard + 3] != "O" && Board[oddNumberFromBoard + 3] != "X"))
                    { Board[oddNumberFromBoard + 3] = "O"; IfHaveInputted = 1; }
                }
                oddNumberFromBoard = oddNumberFromBoard + 2;
            }
            return Board;

        }


        #region CheckingIfAnyoneWon
        public int CheckIfAnyoneWon(string[] Board,out int Flagfor_X,out int FlagFor_O)
        {
            int K_index = 0;
            Flagfor_X = 0;
            FlagFor_O = 0;
            for (int Index = 0; Index < 3; Index++)
            {
                K_index = 4 - Index;
                if (Board[Index] == "X" && Board[4] == "X" && Board[4 + K_index] == "X")
                    Flagfor_X = 1;
                if (Board[Index] == "O" && Board[4] == "O" && Board[4 + K_index] == "O")
                    FlagFor_O = 1;
            }
            if ((Board[0] == "X" && Board[1] == "X" && Board[2] == "X") || (Board[3] == "X" && Board[4] == "X" && Board[5] == "X") || (Board[1] == "X" && Board[4] == "X" && Board[7] == "X") || (Board[0] == "X" && Board[3] == "X" && Board[6] == "X") || (Board[2] == "X" && Board[5] == "X" && Board[8] == "X") || (Board[6] == "X" && Board[7] == "X" && Board[8] == "X"))
                Flagfor_X = 1;
            if ((Board[0] == "O" && Board[1] == "O" && Board[2] == "O") || (Board[3] == "O" && Board[4] == "O" && Board[5] == "O") || (Board[1] == "O" && Board[4] == "O" && Board[7] == "O") || (Board[0] == "O" && Board[3] == "O" && Board[6] == "O") || (Board[2] == "O" && Board[5] == "O" && Board[8] == "O") || (Board[6] == "O" && Board[7] == "O" && Board[8] == "O"))
                FlagFor_O = 1;
       
            if (Flagfor_X == 1|| FlagFor_O == 1)
            {
                K_index = 0;
            }
            return K_index;
        }
        #endregion

        #region RandomNumberInputing
        public string[] RandomInputFromTheSystem(string[] Board)
        {
            int randon_Index = 0;
            bool Loopforchecking = true;
            Random RandomObject = new Random();
            while (Loopforchecking)
            {
                randon_Index = RandomObject.Next(0, 8);

                if (Board[randon_Index] == "X" || Board[randon_Index] == "O")
                    continue;
                else
                    break;
            }
            Board[randon_Index] = "O";
            return Board;
        }
        #endregion

        public String[] BasicGameFunction(string[] Board,out string winner)
        {
            winner = string.Empty;
            GeneralClass Clever = new GeneralClass();

            int  SampleFlag = 1, Clever_X = 0, Clever_O = 0;
            SampleFlag = Clever.CheckIfAnyoneWon(Board,out int player,out int computer);
            if (SampleFlag == 0)
            {
                winner = player == 1 && computer == 0 ? "Player" : winner;
                winner = player == 0 && computer == 1 ? "Computer" : winner;
                return new string[9];
            }
            string[] box1 = new string[8];
                    Board = Clever.CheckIfThereIs3RowsOf_O(Board, out Clever_X);
                    if (Clever_X != 1)
                        Board = Clever.CheckIfThereIs3RowsOf_X(Board, out Clever_X);

                    if (Clever_X == 0 && Clever_O == 0)
                        Board = Clever.RandomInputFromTheSystem(Board);

                    SampleFlag = Clever.CheckIfAnyoneWon(Board, out  player, out  computer);
                    if (SampleFlag == 0)
                    {
                        winner = player == 1 && computer == 0 ? "Player" : string.Empty;
                        winner = player == 0 && computer == 1 ? "Computer" : string.Empty;
                        return new string[9];
                    }
            return Board;
               
            
        }
    }
}

