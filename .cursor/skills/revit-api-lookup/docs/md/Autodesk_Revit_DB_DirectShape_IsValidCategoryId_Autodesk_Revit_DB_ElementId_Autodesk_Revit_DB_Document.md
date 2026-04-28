---
kind: method
id: M:Autodesk.Revit.DB.DirectShape.IsValidCategoryId(Autodesk.Revit.DB.ElementId,Autodesk.Revit.DB.Document)
source: html/c8881d31-d410-842a-1375-5ba688191cf8.htm
---
# Autodesk.Revit.DB.DirectShape.IsValidCategoryId Method

Test the category id to make sure the category is allowed for a DirectShape or DirectShapeType.

## Syntax (C#)
```csharp
public static bool IsValidCategoryId(
	ElementId categoryId,
	Document doc
)
```

## Parameters
- **categoryId** (`Autodesk.Revit.DB.ElementId`) - Category id to be tested.
- **doc** (`Autodesk.Revit.DB.Document`) - Document to look up the category by id.

## Returns
True if the category is allowed for a DirectShape or DirectShapeType, false if not.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null

