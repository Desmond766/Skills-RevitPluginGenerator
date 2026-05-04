---
kind: property
id: P:Autodesk.Revit.UI.ThinLinesOptions.AreThinLinesEnabled
source: html/cc12cf65-dbb1-8e89-5136-c8e7f087bd5e.htm
---
# Autodesk.Revit.UI.ThinLinesOptions.AreThinLinesEnabled Property

A static property defining if the 'Thin Lines' setting is on or off in current Revit Application Session.

## Syntax (C#)
```csharp
public static bool AreThinLinesEnabled { get; set; }
```

## Remarks
If user started multiple Revit sessions, and the 'Thin Lines' setting might be different in each session.
 Revit.ini file stores the lastest setting no matter what the Revit session is. The setting will be writen to Revit.ini if user set the value.

