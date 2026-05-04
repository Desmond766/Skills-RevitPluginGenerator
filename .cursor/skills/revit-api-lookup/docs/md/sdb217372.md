---
kind: property
id: P:Autodesk.Revit.DB.PrintManager.CombinedFile
source: html/8eab5a96-8461-82f9-f7bc-ff141ad80572.htm
---
# Autodesk.Revit.DB.PrintManager.CombinedFile Property

Indicates whether to combine multiple selected views/sheets into a single file.

## Syntax (C#)
```csharp
public bool CombinedFile { get; set; }
```

## Remarks
The value of this property represents the global print setting property used for print operations on any document.
In order to make a change to this property, after setting it call the Apply() method, or one of the SubmitPrint() methods, which
save the local changes as modifications to the global print settings.

## Exceptions
- **Autodesk.Revit.Exceptions.InvalidOperationException** - Thrown when the current printer is not a virtual printer.

