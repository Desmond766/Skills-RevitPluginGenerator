---
kind: property
id: P:Autodesk.Revit.DB.PrintManager.CopyNumber
source: html/7c609f41-5602-6776-6de1-821101da9c60.htm
---
# Autodesk.Revit.DB.PrintManager.CopyNumber Property

The copy number.

## Syntax (C#)
```csharp
public int CopyNumber { get; set; }
```

## Remarks
Returns 0 if current printer does not support CopyNumber property.
The value of this property represents the global print setting property used for print operations on any document.
In order to make a change to this property, after setting it call the Apply() method, or one of the SubmitPrint() methods, which
save the local changes as modifications to the global print settings.

