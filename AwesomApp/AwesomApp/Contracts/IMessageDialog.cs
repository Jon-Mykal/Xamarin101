using System;
using System.Collections.Generic;
using System.Text;

namespace AwesomApp.Contracts
{
    public interface IMessageDialog
    {
        void ShowMessage(string title, string message, string buttonText);
    }
}
