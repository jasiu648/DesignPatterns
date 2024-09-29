using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns.Bridge
{
    public interface IFootballSkills
    {
        public int GetBallControl();
        public int GetPass();
        public int GetShoot();
        public int GetPace();
    }

    public class JuniorFootballSkills : IFootballSkills
    {
        public int GetBallControl()
        {
            return 30;
        }

        public int GetPace()
        {
            return 50;
        }

        public int GetPass()
        {
            return 40;
        }

        public int GetShoot()
        {
            return 20;
        }
    }
    public class SeniorFootballSkills : IFootballSkills
    {
        public int GetBallControl()
        {
            return 60;
        }

        public int GetPace()
        {
            return 80;
        }

        public int GetPass()
        {
            return 60;
        }

        public int GetShoot()
        {
            return 80;
        }
    }
    public class OldboyFootballSkills : IFootballSkills
    {
        public int GetBallControl()
        {
            return 60;
        }

        public int GetPace()
        {
            return 20;
        }

        public int GetPass()
        {
            return 80;
        }

        public int GetShoot()
        {
            return 70;
        }
    }
}
