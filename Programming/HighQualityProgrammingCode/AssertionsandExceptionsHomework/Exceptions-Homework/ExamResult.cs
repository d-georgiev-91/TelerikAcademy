using System;

public class ExamResult
{
    public int Grade { get; private set; }

    public int MinGrade { get; private set; }

    public int MaxGrade { get; private set; }

    public string Comments { get; private set; }

    public ExamResult() 
    {
    }

    public ExamResult(int grade, int minGrade, int maxGrade, string comments)
    {
        if (grade < 0)
        {
            throw new ArgumentException("Grade cannot be negative number!");
        }
        if (minGrade < 0)
        {
            throw new ArgumentException("Min grade cannot be negative number!");
        }
        if (maxGrade <= minGrade)
        {
            throw new ArgumentException("Max grade should be greater than or equal to min grade!");
        }
        if (string.IsNullOrWhiteSpace(comments))
        {
            throw new ArgumentException("Comment should be non nullable or non empty string!");
        }

        this.Grade = grade;
        this.MinGrade = minGrade;
        this.MaxGrade = maxGrade;
        this.Comments = comments;
    }
}