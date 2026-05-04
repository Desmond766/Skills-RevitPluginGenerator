---
kind: property
id: P:Autodesk.Revit.DB.Macros.ApplicationEntryPoint.AddinFolder
source: html/4e33486f-13c2-076d-71aa-503825fa983b.htm
---
# Autodesk.Revit.DB.Macros.ApplicationEntryPoint.AddinFolder Property

The full path to the Revit Macros module.

## Syntax (C#)
```csharp
public string AddinFolder { get; }
```

## Remarks
This path should be used instead of the .NET GetExecutingAssembly() result, because
the Macros module is loaded in such a way to make that result unreliable.

