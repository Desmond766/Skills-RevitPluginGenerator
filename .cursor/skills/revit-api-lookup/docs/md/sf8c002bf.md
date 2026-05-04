---
kind: method
id: M:Autodesk.Revit.DB.Mechanical.IDuctPressureDropServer.GetHtmlDescription
source: html/11e11723-5b66-5d1b-e6e4-c3c4dc285982.htm
---
# Autodesk.Revit.DB.Mechanical.IDuctPressureDropServer.GetHtmlDescription Method

The method that Revit will invoke to get an HTML formatted description of the server.

## Syntax (C#)
```csharp
string GetHtmlDescription()
```

## Returns
The HTML format description of the server.

## Remarks
The HTML description is used by Revit unless it is empty or the server is not available, in which case, Revit will use the plain text description from IExternalServer.GetDescription().

