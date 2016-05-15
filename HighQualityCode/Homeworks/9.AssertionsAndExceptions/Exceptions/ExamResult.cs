using System;

public class ExamResult
{
    public ExamResult(int grade, int minGrade, int maxGrade, string comments)
    {
        if (grade < 0)
        {
            throw new ArgumentException("grade", "Grade can not be negative!");
        }

        if (minGrade < 0)
        {
            throw new ArgumentException("minGrade", "MinGrade can not be negative!");
        }

        if (maxGrade <= minGrade)
        {
            throw new ArgumentException("maxGrade", "MaxGrade should be greater than Min Grade!");
        }

        if (string.IsNullOrEmpty(comments))
        {
            throw new ArgumentNullException("comments", "Comments can no be null or empty!");
        }

        this.Grade = grade;
        this.MinGrade = minGrade;
        this.MaxGrade = maxGrade;
        this.Comments = comments;
    }

    public int Grade { get; private set; }

    public int MinGrade { get; private set; }

    public int MaxGrade { get; private set; }

    public string Comments { get; private set; }
}
