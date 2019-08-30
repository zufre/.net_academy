using System;
using System.Collections.Generic;

public class Program
{
    public static void Main()
    {
		var qone = new TextQuestion();
			qone.Label = "How old are you?";
		
			var qtwo = new TextQuestion();
			qtwo.Label = "Whats your name?";
		
			Survey one = new Survey("title1");
			one.AddQuestion(qone);
	 		one.AddQuestion(qtwo);
			
	 		
	 		int score = one.GetScore();
		    Console.WriteLine("Your score: {0} ",score);
			
    }
}

public abstract class Answer
{
    public int Score { get; set; }
}

public abstract class Question
{
    public string Label { get; set; }

    protected abstract Answer CreateAnswer(string input);

    protected virtual void PrintQuestion()
    {
        Console.WriteLine(Label);
    }

    public Answer Ask()
    {
        PrintQuestion();

        string input = Console.ReadLine();

        return CreateAnswer(input);
    }
}

public class TextAnswer : Answer
{
    public string Text { get; set; }
}

public class TextQuestion : Question
{
    protected override Answer CreateAnswer(string input)
    {
        return new TextAnswer { Text = input, Score = input.Length };
    }
}

public class Survey
{
    public Survey(string title)
    {
        Title = title;
        Questions = new List<Question>();
    }

    public string Title { get; set; }

    public List<Question> Questions { get; private set; }

    public void AddQuestion(Question question)
    {
        Questions.Add(question);
    }

    public int GetScore()
    {
        int total = 0;
        foreach (Question question in Questions)
        {
            Answer answer = question.Ask();
            total = total + answer.Score;
        }

        return total;
    }
}
