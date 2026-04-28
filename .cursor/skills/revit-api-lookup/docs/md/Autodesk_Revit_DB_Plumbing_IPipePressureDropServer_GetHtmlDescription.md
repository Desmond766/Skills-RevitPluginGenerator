---
kind: method
id: M:Autodesk.Revit.DB.Plumbing.IPipePressureDropServer.GetHtmlDescription
source: html/10c0425e-04e8-a43c-30ea-b367deb71862.htm
---
# Autodesk.Revit.DB.Plumbing.IPipePressureDropServer.GetHtmlDescription Method

The method that Revit will invoke to get an HTML formatted description of the server.

## Syntax (C#)
```csharp
string GetHtmlDescription()
```

## Returns
The HTML format description of the server.

## Remarks
The HTML description is used by Revit unless it is empty or the server is not available, in which case, Revit will use the plain text description from IExternalServer.GetDescription().

