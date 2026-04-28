---
kind: property
id: P:Autodesk.Revit.DB.PrintManager.Collate
source: html/f4fb7312-710b-73d6-dea0-9667230ef74f.htm
---
# Autodesk.Revit.DB.PrintManager.Collate Property

Indicates whether to collate of the current print.

## Syntax (C#)
```csharp
public bool Collate { get; set; }
```

## Remarks
The value of this property represents the global print setting property used for print operations on any document.
In order to make a change to this property, after setting it call the Apply() method, or one of the SubmitPrint() methods, which
save the local changes as modifications to the global print settings.

## Exceptions
- **Autodesk.Revit.Exceptions.InvalidOperationException** - Thrown when there is only one view or only one copy in the current settings.

