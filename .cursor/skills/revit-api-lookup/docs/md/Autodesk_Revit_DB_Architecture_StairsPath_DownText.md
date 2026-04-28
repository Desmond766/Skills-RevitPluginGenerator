---
kind: property
id: P:Autodesk.Revit.DB.Architecture.StairsPath.DownText
source: html/a9947a82-b103-29f2-f629-010b5c4f5f0b.htm
---
# Autodesk.Revit.DB.Architecture.StairsPath.DownText Property

The stairs down text.

## Syntax (C#)
```csharp
public string DownText { get; set; }
```

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentNullException** - When setting this property: A non-optional argument was null
- **Autodesk.Revit.Exceptions.InvalidOperationException** - When setting this property: The type of this stairs path is not automatic up/down direction.
 -or-
 When setting this property: The stairs path doesn't show down text so the data being set is inapplicable.

