using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns.Prototype
{
    public interface IPrototype
    {
        public IPrototype Clone();
        public int Data {  get; set; }
    }

    public class AppComponent : IPrototype
    {
        public int Data {  get; set; }
        public AppComponent() { }
        protected AppComponent(AppComponent prototypeComponent) 
        {
            this.Data = prototypeComponent.Data;
        }
        public virtual IPrototype Clone()
        {
            return new AppComponent(this);
        }
    }

    public class SubAppComponent : AppComponent 
    {
        public int AdditionalData { get; set; }
        public SubAppComponent() { }
        protected SubAppComponent(SubAppComponent subAppComponent) : base(subAppComponent)
        {
            this.AdditionalData = subAppComponent.AdditionalData;
        }
        public override IPrototype Clone()
        {
            return new SubAppComponent(this);
        }
    }
}
