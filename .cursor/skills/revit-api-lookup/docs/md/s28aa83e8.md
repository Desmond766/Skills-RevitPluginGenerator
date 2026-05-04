---
kind: property
id: P:Autodesk.Revit.DB.PrintManager.PrintToFileName
source: html/e21748e0-ed8c-1825-40a4-f48790582fbb.htm
---
# Autodesk.Revit.DB.PrintManager.PrintToFileName Property

The file name when printing to file.

## Syntax (C#)
```csharp
public string PrintToFileName { get; set; }
```

## Remarks
A default file name will be used when the PrintToFile is true and PrintToFileName is not be set. 
The value of this property represents the global print setting property used for print operations on any document.
In order to make a change to this property, after setting it call the Apply() method, or one of the SubmitPrint() methods, which
save the local changes as modifications to the global print settings.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentNullException** - Thrown when the input file name is Nothing nullptr a null reference ( Nothing in Visual Basic) .
- **Autodesk.Revit.Exceptions.ArgumentException** - Thrown when the input file name is an invalid string.

