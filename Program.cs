/*
This C# console application is designed to:
- Use arrays to store student names and assignment scores.
- Use a `foreach` statement to iterate through the student names as an outer program loop.
- Use an `if` statement within the outer loop to identify the current student name and access that student's assignment scores.
- Use a `foreach` statement within the outer loop to iterate though the assignment scores array and sum the values.
- Use an algorithm within the outer loop to calculate the average exam score for each student.
- Use an `if-elseif-else` construct within the outer loop to evaluate the average exam score and assign a letter grade automatically.
- Integrate extra credit scores when calculating the student's final score and letter grade as follows:
    - detects extra credit assignments based on the number of elements in the student's scores array.
    - divides the values of extra credit assignments by 10 before adding extra credit scores to the sum of exam scores.
- Calculates the average of all exams that are included in examAssignments (the first 5) and displays it in the Exam Score column
- Calculates the average of all extra credit scores and displays it in the Extra Credit column
    -The total points is calculated by dividing the 10% of the sum of extra credit scores by the total exam assignments not including the extra credit exams. Basically, (extraCreditScores / 10) / examAssignments.
-New variables
    -extraCredit contains the 10% of every extra credit exam
    -extraCreditCount is the total number of extra credit exams
    -examScore is the sum of all normal exams
    -extraCreditScores is the sum of all extra credit scores
    -extraCreditAverage = extraCreditScore / extraCreditCount
    -extraCreditPoints is the total points added to the exam score making up the overall grade. Ex: extraCreditPoints = 3.68; 92.2 + 3.68 = 95.88
- use the following report format to report student grades:

  Student         Exam Score      Overall Grade   Extra Credit
  Sophia          92.2            95.88   A       92 (3.68 points)
  Andrew          89.6            91.38   A-      89 (1.78 points)
  Emma            85.6            90.94   A-      89 (5.34 points)
  Logan           91.2            93.12   A       96 (1.92 points)
*/
int examAssignments = 5;

string[] studentNames = new string[] { "Sophia", "Andrew", "Emma", "Logan" };

int[] sophiaScores = new int[] { 90, 86, 87, 98, 100, 94, 90 };
int[] andrewScores = new int[] { 92, 89, 81, 96, 90, 89 };
int[] emmaScores = new int[] { 90, 85, 87, 98, 68, 89, 89, 89 };
int[] loganScores = new int[] { 90, 95, 87, 88, 96, 96 };

int[] studentScores = new int[10];

string currentStudentLetterGrade = "";

// display the header row for scores/grades
Console.Clear();
Console.WriteLine("Student\t\tExam Score\tOverall Grade\tExtra Credit"); //Updated this to include Exam Score and the Extra Credit column

/*
The outer foreach loop is used to:
- iterate through student names
- assign a student's grades to the studentScores array
- sum assignment scores (inner foreach loop)
- calculate numeric and letter grade
- write the score report information
*/
foreach (string name in studentNames)
{
    string currentStudent = name;

    if (currentStudent == "Sophia")
        studentScores = sophiaScores;
    else if (currentStudent == "Andrew")
        studentScores = andrewScores;
    else if (currentStudent == "Emma")
        studentScores = emmaScores;
    else if (currentStudent == "Logan")
        studentScores = loganScores;

    decimal sumAssignmentScores = 0;

    decimal currentStudentGrade = 0;

    int gradedAssignments = 0;

    decimal extraCredit = 0; 
    int extraCreditCount = studentScores.Length - examAssignments; 
    decimal examScore = 0; 
    decimal extraCreditScores = 0; 
    int extraCreditAverage = 0;  
    decimal extraCreditPoints = 0;

    /*
    the inner foreach loop sums assignment scores
    extra credit assignments are worth 10% of an exam score
    */
    foreach (int score in studentScores)
    {
        gradedAssignments += 1;

        if (gradedAssignments <= examAssignments)
            examScore += score;
        else
        {
            extraCredit += (decimal) score / 10;
            extraCreditScores += (decimal) score;
        }
           
    }

    sumAssignmentScores = examScore + extraCredit;
    examScore /= examAssignments; //The average of the normal exam score
    extraCreditAverage = (int) extraCreditScores / extraCreditCount;

    currentStudentGrade = (decimal)(sumAssignmentScores) / (decimal)examAssignments; //Calculation of the final grade

    extraCreditPoints = (decimal)(extraCreditScores / 10) / examAssignments;

    if (currentStudentGrade >= 97)
        currentStudentLetterGrade = "A+";
    else if (currentStudentGrade >= 93)
        currentStudentLetterGrade = "A";
    else if (currentStudentGrade >= 90)
        currentStudentLetterGrade = "A-";
    else if (currentStudentGrade >= 87)
        currentStudentLetterGrade = "B+";
    else if (currentStudentGrade >= 83)
        currentStudentLetterGrade = "B";
    else if (currentStudentGrade >= 80)
        currentStudentLetterGrade = "B-";
    else if (currentStudentGrade >= 77)
        currentStudentLetterGrade = "C+";
    else if (currentStudentGrade >= 73)
        currentStudentLetterGrade = "C";
    else if (currentStudentGrade >= 70)
        currentStudentLetterGrade = "C-";
    else if (currentStudentGrade >= 67)
        currentStudentLetterGrade = "D+";
    else if (currentStudentGrade >= 63)
        currentStudentLetterGrade = "D";
    else if (currentStudentGrade >= 60)
        currentStudentLetterGrade = "D-";
    else
        currentStudentLetterGrade = "F";

    // Student         Grade
    // Sophia:         92.2    A-

    Console.WriteLine(
        $"{currentStudent}\t\t{examScore}\t\t{currentStudentGrade}\t{currentStudentLetterGrade}\t{extraCreditAverage} ({extraCreditPoints} points)"
    );
}

// required for running in VS Code (keeps the Output windows open to view results)
Console.WriteLine("\n\rPress the Enter key to continue");
Console.ReadLine();
