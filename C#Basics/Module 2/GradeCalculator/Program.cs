using System;

string calculateGradeLetter(decimal gradeDecimal) {
    string[] gradeScoreInLetters = {"F", "D-", "D", "D+", "C-", "C", "C+", "B-", "B", "B+", "A-", "A", "A+",};
    int grade = (int) gradeDecimal;
    Console.WriteLine(grade);

    if(grade <= 59){
        return gradeScoreInLetters[0];
    } else {
        int gradeScoreInLettersIndex = 1;
        for(int i = 60; i<100; ){
            if(grade >= i && grade <= i+2){
                return gradeScoreInLetters[gradeScoreInLettersIndex];
            } else{
                i=i+3;
                gradeScoreInLettersIndex++;
            }

            if(grade >= i && grade <= i+3){
                return gradeScoreInLetters[gradeScoreInLettersIndex];
            } else{
                i=i+4;
                gradeScoreInLettersIndex++;
            }
            
            if(grade >= i && grade <= i+2){
                return gradeScoreInLetters[gradeScoreInLettersIndex];
            } else{
                i=i+3;
                gradeScoreInLettersIndex++;
            }
        }
    }

    return ":(";
}

/*
Table of the relationship of numbers grades to letter grades:
97 - 100   A+
93 - 96    A
90 - 92    A-
87 - 89    B+
83 - 86    B
80 - 82    B-
77 - 79    C+
73 - 76    C
70 - 72    C-
67 - 69    D+
63 - 66    D
60 - 62    D-
0  - 59    F
*/

// initialize variables - graded assignments

string[] studentNames = {"sophia", "andrew", "emma", "logan"};

int currentAssignments = 5;

int[] sophiaScores = { 90, 86, 87, 98, 100 };
int[] andrewScores = { 92, 89, 81, 96, 90 };
int[] emmaScores = { 90, 85, 87, 98, 68 };
int[] loganScores = { 90, 95, 87, 88, 96 };

int sophiaSum = 0;
int andrewSum = 0;
int emmaSum = 0;
int loganSum = 0;

foreach (int score in sophiaScores)
{
    sophiaSum += score;
}
foreach (int score in andrewScores)
{
    andrewSum += score;
}
foreach (int score in emmaScores)
{
    emmaSum += score;
}
foreach (int score in loganScores)
{
    loganSum += score;
}

decimal sophiaScore = (decimal)sophiaSum / currentAssignments;
decimal andrewScore = (decimal)andrewSum / currentAssignments;
decimal emmaScore = (decimal)emmaSum / currentAssignments;
decimal loganScore = (decimal)loganSum / currentAssignments;

Console.WriteLine("Student\t\tGrade\n");
Console.WriteLine($"Sophia:\t\t {sophiaScore} \t{calculateGradeLetter(sophiaScore)}");
Console.WriteLine($"Andrew:\t\t {andrewScore} \t{calculateGradeLetter(andrewScore)}");
Console.WriteLine($"Emma:\t\t {emmaScore} \t{calculateGradeLetter(emmaScore)}");
Console.WriteLine($"Logan:\t\t {loganScore} \t{calculateGradeLetter(loganScore)}");
