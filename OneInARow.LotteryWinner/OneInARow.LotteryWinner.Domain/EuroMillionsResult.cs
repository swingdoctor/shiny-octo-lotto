using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OneInARow.LotteryWinner.Domain
{
    public struct EuroMillionsResult
    {
        public EuroMillionsResult(DateTime drawDate, int drawNumber, List<int> balls, List<int> bonusBalls)
            : this(drawDate, drawNumber, balls[0], balls[1], balls[2], balls[3], balls[4], bonusBalls[0], bonusBalls[1])
        {
        }

        public EuroMillionsResult(DateTime drawDate, int drawNumber, int ball1, int ball2, int ball3, int ball4, int ball5, int bonusBall1, int bonusBall2)
            : this()
        {
            this.DrawDate = drawDate;
            this.DrawNumber = drawNumber;
            this.Balls = new List<int>() { ball1, ball2, ball3, ball4, ball5 };
            this.BonusBalls = new List<int>() { bonusBall1, bonusBall2 };
        }

        public DateTime DrawDate { get; private set; }

        public int DrawNumber { get; private set; }

        public List<int> Balls { get; private set; }

        public List<int> BonusBalls { get; set; }
    }
}
