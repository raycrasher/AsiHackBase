using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AsiHack.Base
{
    [AttributeUsage(AttributeTargets.Class)]
    public sealed class ModelAttribute: Attribute { }

    [AttributeUsage(AttributeTargets.Class)]
    public sealed class ApiModuleAttribute : Attribute { }

    [AttributeUsage(AttributeTargets.Method)]
    public sealed class ApiFunctionAttribute : Attribute { }

}