---
kind: property
id: P:Autodesk.Revit.DB.Macros.DocumentEntryPoint.AddinFolder
source: html/47ffdf8b-ca4e-9b70-f7b3-f29ef39be302.htm
---
# Autodesk.Revit.DB.Macros.DocumentEntryPoint.AddinFolder Property

The full path to the Revit Macros module.

## Syntax (C#)
```csharp
public string AddinFolder { get; }
```

## Remarks
This path should be used instead of the .NET GetExecutingAssembly() result, because
the Macros module is loaded in such a way to make that result unreliable.

