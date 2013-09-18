using System;

public class CSharpExam : Exam
{
    private const int MinExamScore = 0;
    private const int MaxExamScore = 100;

    public int Score { get; private set; }

    public CSharpExam(int score)
    {
        if (score < 0)
        {
            throw new ArgumentException("Scores cannot be negative!");
        }

        this.Score = score;
    }

    public override ExamResult Check()
    {
        if (Score < MinExamScore || Score > MaxExamScore)
        {
            throw new ArgumentOutOfRangeException(String.Format("Scores must be in interval [{0}, {1}]", MinExamScore, MaxExamScore));
        }
        else
        {
            return new ExamResult(this.Score, 0, 100, "Exam results calculated by score.");
        }
    }
}
