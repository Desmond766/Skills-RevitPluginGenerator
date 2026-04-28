---
kind: method
id: M:Autodesk.Revit.DB.DirectShape.CreateElement(Autodesk.Revit.DB.Document,Autodesk.Revit.DB.ElementId)
source: html/bee8a24f-704e-44d9-e187-9e031548a6d2.htm
---
# Autodesk.Revit.DB.DirectShape.CreateElement Method

Creates a DirectShape object and adds it to document.

## Syntax (C#)
```csharp
public static DirectShape CreateElement(
	Document document,
	ElementId categoryId
)
```

## Parameters
- **document** (`Autodesk.Revit.DB.Document`) - Document to which the created element will be added.
- **categoryId** (`Autodesk.Revit.DB.ElementId`) - Id of the category assigned to this DirectShape. Must be a valid category id.

## Returns
The created DirectShape object.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentException** - Document document may not contain DirectShape or DirectShapeType objects.
 -or-
 Element id categoryId may not be used as a DirectShape category.
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null

