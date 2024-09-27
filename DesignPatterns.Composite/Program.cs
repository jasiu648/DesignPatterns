using DesignPatters.Composite;
using System.ComponentModel;

namespace DesignPatters.Composite
{
    public interface IComponent
    {
        public void Execute();
    }
    public class CompositeNode : IComponent
    {
        public CompositeNode() { }
        private List<IComponent> components = new List<IComponent>();
        public void Add(IComponent component)
        {
            components.Add(component);
        }
        public void Remove(IComponent component)
        {
            components.Remove(component);
        }
        public void Execute()
        {
            foreach (IComponent component in components)
            {
                component.Execute();
            }
        }

    }

    public class CompositeLeaf : IComponent
    {
        public CompositeLeaf(string message)
        {
            this.message = message;
        }
        private string message;
        public void Execute()
        {
            Console.WriteLine(message);
        }
    }

}

public static class Program
{
    public static void Main()
    {
        var MainElement = new CompositeNode();
        var SubElement1 = new CompositeNode();
        MainElement.Add(SubElement1);

        var Leaf1 = new CompositeLeaf("Messege 1 from sub elem");
        var Leaf2 = new CompositeLeaf("Messege 2 from sub elem");
        var Leaf3 = new CompositeLeaf("Messege 3 from main");

        SubElement1.Add(Leaf1);
        SubElement1.Add(Leaf2);
        MainElement.Add(Leaf3);

        MainElement.Execute();
        SubElement1.Execute();
    }
}

