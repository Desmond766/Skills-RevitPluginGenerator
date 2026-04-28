---
kind: property
id: P:Autodesk.Revit.DB.Analysis.PathOfTravel.PathStart
source: html/967e4fe9-ad0b-d275-05e9-e0bdf37c650a.htm
---
# Autodesk.Revit.DB.Analysis.PathOfTravel.PathStart Property

The start point of the path. The Z coordinate will equal the view's level elevation.
 To update path calculations, call update.

## Syntax (C#)
```csharp
public XYZ PathStart { get; set; }
```

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentNullException** - When setting this property: A non-optional argument was null
- **Autodesk.Revit.Exceptions.InvalidOperationException** - When setting this property: This functionality is not available in Revit LT.
 -or-
 When setting this property: Cannot perform this operation for a path of travel in a group.

