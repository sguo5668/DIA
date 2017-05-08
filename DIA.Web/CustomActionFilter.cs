using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

 
  using System.Collections.ObjectModel;
  using System.Diagnostics.CodeAnalysis;
 
 using System.Reflection;
 
using Microsoft.AspNetCore.Mvc;
 using System.Diagnostics;
using Microsoft.AspNetCore.Mvc.ActionConstraints;

namespace DIA.Web
{
    public class CustomActionFilter
    {




        [AttributeUsage(AttributeTargets.Parameter, AllowMultiple = false)]
        public sealed class RouteValueAttribute : Attribute
        {
            public RouteValueAttribute() { }
        }


        [AttributeUsage(AttributeTargets.Parameter, AllowMultiple = false)]
        public sealed class FormValueAttribute : Attribute
        {
            public FormValueAttribute() { }
        }



        [AttributeUsage(AttributeTargets.Method, AllowMultiple = false, Inherited = true)]
        public sealed class ParametersMatchAttribute : ActionMethodSelectorAttribute
        {
            public ParametersMatchAttribute() { }

            public override bool IsValidForRequest(ControllerContext controllerContext, MethodInfo methodInfo)
            {

                List<string> requestRouteValuesKeys = controllerContext.RouteData.Values.Where(v => !(v.Key == "controller" || v.Key == "action" || v.Key == "area")).Select(rv => rv.Key).ToList();


                var form = controllerContext.HttpContext.Request.Form;
                List<string> requestFormValuesKeys = form.AllKeys.ToList();


                var parameters = methodInfo.GetParameters();

                var parametersNotMatched = parameters.ToList();


                foreach (var param in parameters)
                {
                    string name = param.Name;

                    bool isRouteParam = param.GetCustomAttributes(true).Any(a => a is RouteValueAttribute);
                    bool isFormParam = param.GetCustomAttributes(true).Any(a => a is FormValueAttribute);

                    if (isRouteParam && requestRouteValuesKeys.Contains(name))
                    {

                        requestRouteValuesKeys.Remove(name);
                        parametersNotMatched.Remove(param);
                    }
                    else if (isFormParam && requestFormValuesKeys.Contains(name))

                    {

                        requestFormValuesKeys.Remove(name);
                        parametersNotMatched.Remove(param);
                    }
                    else
                    {
                 
                     Debug.WriteLine(methodInfo + " failed to match " + param + " against either a RouteValue or a FormValue");
                        return false;
                    }
                }

                if (parametersNotMatched.Count > 0)
                {
                    Debug.WriteLine(methodInfo + " - FAIL: has parameters left over not matched by route or form values");
                    return false;
                }

                if (requestRouteValuesKeys.Count > 0)
                {
               
                 return false;
                }

                if (requestFormValuesKeys.Count > 1)
                {
                    Debug.WriteLine(methodInfo + " - FAIL : unmatched form values " + string.Join(", ", requestFormValuesKeys.ToArray()));
                    return false;
                }

                Debug.WriteLine(methodInfo + " - PASS - unmatched form values " + string.Join(", ", requestFormValuesKeys.ToArray()));
                return true;
            }
        }
    }


}
}
