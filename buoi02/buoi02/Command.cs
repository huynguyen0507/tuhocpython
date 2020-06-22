#region Namespaces
using System;
using System.Collections.Generic;
using System.Diagnostics;
using Autodesk.Revit.ApplicationServices;
using Autodesk.Revit.Attributes;
using Autodesk.Revit.DB;
using Autodesk.Revit.UI;
using Autodesk.Revit.UI.Selection;
#endregion

namespace buoi02
{
    [Transaction(TransactionMode.Manual)]
    public class Command : IExternalCommand
    {
        public Result Execute(
          ExternalCommandData commandData,
          ref string message,
          ElementSet elements)
        {
            UIApplication uiapp = commandData.Application;
            UIDocument uidoc = uiapp.ActiveUIDocument;
            Application app = uiapp.Application;
            Document doc = uidoc.Document;

            // Access current selection
            LanguageType kq = app.Language;
            string name = "";
            IList<Reference>  refe  = uidoc.Selection.PickObjects(ObjectType.Element,"aaaaaaaaaaaaaaaa");
            foreach (var item in refe)
            {
                Element ele = doc.GetElement(item);
                 name = name+"-"+ ele.Name;
            }
       
            TaskDialog.Show("Thong bao", name);

            return Result.Succeeded;
        }
    }
}
