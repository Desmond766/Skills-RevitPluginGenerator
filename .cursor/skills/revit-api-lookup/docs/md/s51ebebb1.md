---
kind: property
id: P:Autodesk.Revit.UI.Macros.DocumentEntryPoint.AddinFolder
source: html/59d0a1b3-b52f-a295-6b47-105a980a4baf.htm
---
# Autodesk.Revit.UI.Macros.DocumentEntryPoint.AddinFolder Property

The full path to the Revit Macros module.

## Syntax (C#)
```csharp
public string AddinFolder { get; }
```

## Remarks
This path should be used instead of the .NET GetExecutingAssembly() result, because
the Macros module is loaded in such a way to make that result unreliable.

