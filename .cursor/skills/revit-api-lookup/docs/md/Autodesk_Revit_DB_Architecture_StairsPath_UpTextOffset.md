---
kind: property
id: P:Autodesk.Revit.DB.Architecture.StairsPath.UpTextOffset
source: html/92fd8a26-e755-7a50-08eb-13fed2ab08dc.htm
---
# Autodesk.Revit.DB.Architecture.StairsPath.UpTextOffset Property

The offset of stairs up text.

## Syntax (C#)
```csharp
public XYZ UpTextOffset { get; set; }
```

## Remarks
The z direction makes no sense in API.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentNullException** - When setting this property: A non-optional argument was null
- **Autodesk.Revit.Exceptions.InvalidOperationException** - When setting this property: The stairs path doesn't not show up text so the data being set is inapplicable.

