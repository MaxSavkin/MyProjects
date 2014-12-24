using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Starostin_PD
{
    class Manager_command
    {
        private Manager_command(){}
        private List<ICommand> l= new List<ICommand>();

        private static readonly Manager_command instance = new Manager_command();
 
        public static Manager_command Instance
        {
            get { return instance; }
        }

        public void registerCommand(ICommand command)
        {
            command.execute();
            l.Add(command);
        }

        public void cancelLastCommand()
        {
            if (l.Count() > 1)
            {
                l.RemoveAt(l.Count() - 1);

                foreach (ICommand com in l)
                    com.execute();
            }
        }

    }
}
