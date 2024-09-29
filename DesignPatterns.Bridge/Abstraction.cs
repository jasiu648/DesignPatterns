using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns.Bridge
{
    public abstract class Footballer
    {
        
        protected IFootballSkills footballSkills;
        public Footballer(IFootballSkills footballSkills) 
        {
            this.footballSkills = footballSkills;
        }

        public abstract float GetOffensiveSkills();
        public abstract float GetDribbling();

        
    }

    public class Defender : Footballer
    {
        private const float skillRate = 0.3f; 
        public Defender(IFootballSkills footballSkills) : base(footballSkills)
        {
        }

        public override float GetOffensiveSkills()
        {
            return skillRate * (footballSkills.GetShoot() + footballSkills.GetPass()) / 2;
        }
        public override float GetDribbling()
        {
            return skillRate * (footballSkills.GetPace() + footballSkills.GetBallControl()) / 2;
        }
    }
    public class Midfielder : Footballer
    {
        private const float skillRate = 0.6f;
        public Midfielder(IFootballSkills footballSkills) : base(footballSkills)
        {
        }

        public override float GetOffensiveSkills()
        {
            return skillRate * (footballSkills.GetShoot() + footballSkills.GetPass()) / 2;
        }
        public override float GetDribbling()
        {
            return skillRate * (footballSkills.GetPace() + footballSkills.GetBallControl()) / 2;
        }
    }

    public class Forward : Footballer
    {
        private const float skillRate = 0.8f;
        public Forward(IFootballSkills footballSkills) : base(footballSkills)
        {
        }

        public override float GetOffensiveSkills()
        {
            return skillRate * (footballSkills.GetShoot() + footballSkills.GetPass()) / 2;
        }
        public override float GetDribbling()
        {
            return skillRate * (footballSkills.GetPace() + footballSkills.GetBallControl()) / 2;
        }
    }
}
