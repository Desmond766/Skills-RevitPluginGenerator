---
kind: property
id: P:Autodesk.Revit.DB.PrintManager.PrintRange
source: html/d1e00760-b2fe-799d-472c-64d0b8284a4d.htm
---
# Autodesk.Revit.DB.PrintManager.PrintRange Property

The print range.

## Syntax (C#)
```csharp
public PrintRange PrintRange { get; set; }
```

## Remarks
The value of this property represents the global print setting property used for print operations on any document.
In order to make a change to this property, after setting it call the Apply() method, or one of the SubmitPrint() methods, which
save the local changes as modifications to the global print settings.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentOutOfRangeException** - Thrown when the argument is out of range.

