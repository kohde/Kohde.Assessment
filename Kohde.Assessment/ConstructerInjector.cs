using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Kohde.Assessment
{
    /*
     * Injector class to enable dependency injection
     */
    public class ConstructerInjector: ICreature
    {

        //Creature variable
        private ICreature _creature;

        //Constructer to create Creature
        public ConstructerInjector(ICreature creature)
        {
            _creature = creature;
        }

        // Exposing a GetDetails method for a Creature
        public string GetDetails()
        {
            return _creature.GetDetails();
        }
    }
}
