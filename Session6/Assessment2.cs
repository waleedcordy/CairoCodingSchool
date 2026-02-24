using Microsoft.VisualBasic;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using System.Threading.Channels;
using System.Threading.Tasks;
using static ConsoleApp1.Session6.Assessment1;
using static System.Net.Mime.MediaTypeNames;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace ConsoleApp1.Session6
{
    //Design a class called Post.This class models a StackOverflow post.
    //It should have properties for title, description and the date/time it was created.We should be able to up-vote or down-vote a post.
    //We should also be able to see the current vote value.
    //In the main method, create a post, up-vote and down-vote it a few times and then display the the current vote value.
    //In this exercise, you will learn that a StackOverflowpost should provide methods for up-voting and down-voting.
    //You should not give the ability to set the Vote property from the outside, because otherwise, accidentally change the votes of a class to 0 or to a random number.
    //And this is how we create bugs in our programs.
    //The class should always protect its state and hide its implementation detail.
    //Educational tip: The aim of this exercise is to help you understand that classes should encapsulate data AND behaviour around that data.
    //Many developers (even those with years of experience) tend to create classes that are purely data containers,
    //and other classes that are purely behaviour(methods) providers.
    //This is not object-oriented programming.This is procedural programming. Such programs are very fragile.
    //Making a change breaks many parts of the code.
    public class Assessment2
    {
        public Assessment2()
        {
            Post post = new Post("How asp.net works?", "dear stackoverflowers, I need to understand the ........................");

            for (int i=0;i<10;i++)
            {
                post.UpVote();
            }
            for (int i=0;i<12;i++)
            {
                post.DownVote();
            }

            Console.WriteLine($"Title: {post.Title} - Votes: {post.Votes}");
        }
    }

    public class Post
    {
        public string Title { get; private set; }
        public string Description { get; private set; }
        public DateTime CreatedOn { get; private set; }

        public int Votes { get; private set; }

        public Post(string title, string description)
        {
            Title = title;
            Description = description;
            CreatedOn = DateTime.Now;
        }

        public void UpVote()
        {
            Votes++;
        }

        public void DownVote()
        {
            Votes--;
        }
    }
}