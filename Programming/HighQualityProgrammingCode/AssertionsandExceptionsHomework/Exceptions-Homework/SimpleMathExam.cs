using System;

public class SimpleMathExam : Exam
{
    private const int MinProblemsCount = 0;
    private const int MaxProblemsCount = 10;

    public int ProblemsSolved { get; private set; }

    public SimpleMathExam(int problemsSolved)
    {
        if (MinProblemsCount <= problemsSolved && problemsSolved <= MaxProblemsCount)
        {
            this.ProblemsSolved = problemsSolved;   
        }
        else
        {
            throw new ArgumentException(string.Format("Solved problems must be within interval [{0}, {1}]",
                MinProblemsCount, MaxProblemsCount));
        }
    }

    public override ExamResult Check()
    {
        ExamResult currentExamResult = new ExamResult();

        if (ProblemsSolved == 0)
        {
            currentExamResult = new ExamResult(2, 2, 6, "Bad result: nothing done.");
        }
        else if (ProblemsSolved == 1)
        {
            currentExamResult = new ExamResult(4, 2, 6, "Average result: nothing done.");
        }
        else if (ProblemsSolved == 2)
        {
            currentExamResult = new ExamResult(6, 2, 6, "Average result: nothing done.");
        }

        return currentExamResult;
    }
}
