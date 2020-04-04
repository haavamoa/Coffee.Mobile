using System;
using System.Collections.Generic;
using System.Text;
using Coffee.Mobile.Models;

namespace Coffee.Mobile.ViewModels
{
    public class MethodViewModel
    {
        private readonly Method m_method;

        public MethodViewModel(Method method)
        {
            m_method = method;
        }
    }
}
