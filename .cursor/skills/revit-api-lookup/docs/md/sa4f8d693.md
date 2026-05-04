---
kind: property
id: P:Autodesk.Revit.DB.Part.OriginalCategoryId
source: html/a06ea771-6aea-6a39-9036-4d3f1389b7ed.htm
---
# Autodesk.Revit.DB.Part.OriginalCategoryId Property

The category Id of the original element corresponding to this Part.

## Syntax (C#)
```csharp
public ElementId OriginalCategoryId { get; set; }
```

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentException** - When setting this property: dPartOriginalCategoryId is not an available member of the original category ids of the elements which formed this Part.
- **Autodesk.Revit.Exceptions.ArgumentNullException** - When setting this property: A non-optional argument was null

