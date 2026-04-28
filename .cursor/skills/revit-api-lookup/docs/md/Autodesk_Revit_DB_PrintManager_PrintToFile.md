---
kind: property
id: P:Autodesk.Revit.DB.PrintManager.PrintToFile
source: html/e287a6db-f36c-435a-e3d7-78598d62bc4e.htm
---
# Autodesk.Revit.DB.PrintManager.PrintToFile Property

Indicates whether to print to file.

## Syntax (C#)
```csharp
public bool PrintToFile { get; set; }
```

## Remarks
The value of this property represents the global print setting property used for print operations on any document.
In order to make a change to this property, after setting it call the Apply() method, or one of the SubmitPrint() methods, which
save the local changes as modifications to the global print settings.

