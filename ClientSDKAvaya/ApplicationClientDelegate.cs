using Avaya.ClientServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClientSDKAvaya
{
    public class ApplicationClientDelegate
    {
       public void client_UserCreated(object sender, UserEventArgs e)
        {
            Console.WriteLine("Usuario Creado");

        }

        public void client_UserRemoved(object sender, UserEventArgs e)
        {
            Console.WriteLine("Se ha eliminado Usuario");

        }

        public void client_ShutdownCompleted(object sender, EventArgs e)
        {
            Console.WriteLine("Shutdown");

        }
    }
}
