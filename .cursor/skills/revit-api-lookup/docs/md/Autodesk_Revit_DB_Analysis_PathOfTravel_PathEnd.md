---
kind: property
id: P:Autodesk.Revit.DB.Analysis.PathOfTravel.PathEnd
source: html/a763a360-481d-14e3-bcde-e3b7aea2bc82.htm
---
# Autodesk.Revit.DB.Analysis.PathOfTravel.PathEnd Property

The end point of the path. The Z coordinate will equal the view's level elevation.
 To update path calculations, call update.

## Syntax (C#)
```csharp
public XYZ PathEnd { get; set; }
```

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentNullException** - When setting this property: A non-optional argument was null
- **Autodesk.Revit.Exceptions.InvalidOperationException** - When setting this property: This functionality is not available in Revit LT.
 -or-
 When setting this property: Cannot perform this operation for a path of travel in a group.

