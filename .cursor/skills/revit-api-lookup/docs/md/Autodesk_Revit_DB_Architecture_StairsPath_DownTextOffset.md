---
kind: property
id: P:Autodesk.Revit.DB.Architecture.StairsPath.DownTextOffset
source: html/aae9f40d-d966-1acb-1126-b2f7d43afe95.htm
---
# Autodesk.Revit.DB.Architecture.StairsPath.DownTextOffset Property

The offset of stairs down text.

## Syntax (C#)
```csharp
public XYZ DownTextOffset { get; set; }
```

## Remarks
The z direction makes no sense in API.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentNullException** - When setting this property: A non-optional argument was null
- **Autodesk.Revit.Exceptions.InvalidOperationException** - When setting this property: The type of this stairs path is not automatic up/down direction.
 -or-
 When setting this property: The stairs path doesn't show down text so the data being set is inapplicable.

