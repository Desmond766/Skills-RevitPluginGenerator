---
kind: method
id: M:Autodesk.Revit.DB.DisplacementElement.CanCategoryBeDisplaced(Autodesk.Revit.DB.ElementId)
source: html/cdab956b-de93-bf5a-1698-5d5746447934.htm
---
# Autodesk.Revit.DB.DisplacementElement.CanCategoryBeDisplaced Method

Indicates whether elements of the specified category are eligible as displaced elements.

## Syntax (C#)
```csharp
public static bool CanCategoryBeDisplaced(
	ElementId categoryId
)
```

## Parameters
- **categoryId** (`Autodesk.Revit.DB.ElementId`) - Category id of element to be replaced.

## Returns
Returns true if elements of this category can be displaced, and false otherwise.

## Remarks
Elements may be disallowed as displaced elements for reasons other than their category.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null

