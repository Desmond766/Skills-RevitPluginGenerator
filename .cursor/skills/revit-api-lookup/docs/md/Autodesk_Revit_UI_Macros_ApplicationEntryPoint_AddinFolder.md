---
kind: property
id: P:Autodesk.Revit.UI.Macros.ApplicationEntryPoint.AddinFolder
source: html/b53d72ab-a4e6-5d4d-cd05-4a2d1f73070a.htm
---
# Autodesk.Revit.UI.Macros.ApplicationEntryPoint.AddinFolder Property

The full path to the Revit Macros module.

## Syntax (C#)
```csharp
public string AddinFolder { get; }
```

## Remarks
This path should be used instead of the .NET GetExecutingAssembly() result, because
the Macros module is loaded in such a way to make that result unreliable.

