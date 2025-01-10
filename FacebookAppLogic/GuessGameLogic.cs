using System;
using System.Collections.Generic;
using FacebookWrapper.ObjectModel;


namespace FacebookAppLogic
{
    public class GuessGameLogic
    {
        private readonly List<Page> r_Pages;
        private int m_CurrentIndex;
        public int Score { get; private set; }


        public GuessGameLogic(List<Page> i_Pages)
        {
            r_Pages = i_Pages;
            m_CurrentIndex = 0;
            Score = 0;
        }

        public bool IsThereMorePages()
        {
            return m_CurrentIndex < r_Pages.Count;
        }

        public Page GetCurrentPage()
        {
            return r_Pages[m_CurrentIndex];
        }

        public eAnswerStatus CheckPlayerGuess(int i_UserGuess)

        {
            long actualLikes = r_Pages[m_CurrentIndex].LikesCount ?? 0;

            int difference = Math.Abs(i_UserGuess - (int)actualLikes);

            eAnswerStatus answerStatus;

            if (difference == 0)
            {
                Score += 10;
                answerStatus = eAnswerStatus.CORRECT;
            }
            else if(difference <= 100)
            {
                Score += 5;
                answerStatus = eAnswerStatus.ALMOST;
            }
            else
            {
                Score -= 1;
                answerStatus = eAnswerStatus.WRONG;
            }

            m_CurrentIndex++;
            return answerStatus;
        }

        public enum eAnswerStatus
        {
            CORRECT,ALMOST,WRONG
        }

    }
}

