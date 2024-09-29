
using DesignPatterns.Bridge;

var juniorSkill = new JuniorFootballSkills();
var seniorSkill = new SeniorFootballSkills();
var oldboySkill = new OldboyFootballSkills();

var juniorForward = new Forward(juniorSkill);

Console.WriteLine(juniorForward.GetOffensiveSkills().ToString());
Console.WriteLine(juniorForward.GetDribbling().ToString());