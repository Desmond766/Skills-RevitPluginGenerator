---
kind: method
id: M:Autodesk.Revit.DB.GlobalParameter.UnlabelDimension(Autodesk.Revit.DB.ElementId)
source: html/b862ea70-8b3a-2800-f434-7163a878deeb.htm
---
# Autodesk.Revit.DB.GlobalParameter.UnlabelDimension Method

Unlabels a dimension that is currently labeled by this global parameter.

## Syntax (C#)
```csharp
public void UnlabelDimension(
	ElementId dimensionId
)
```

## Parameters
- **dimensionId** (`Autodesk.Revit.DB.ElementId`) - Id of a dimension element.

## Remarks
It is assumed that the given dimension element is presently labeled
 by this parameter. If it is not, this method throws an exception.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentException** - Given element Id is not of a valid dimension element.
 -or-
 The given dimension (dimensionId) is not labeled by this global parameter.
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null

