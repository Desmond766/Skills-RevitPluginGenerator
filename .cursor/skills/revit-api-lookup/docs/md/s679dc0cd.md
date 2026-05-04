---
kind: method
id: M:Autodesk.Revit.DB.Structure.RebarInSystem.GetBarIndexFromReference(Autodesk.Revit.DB.Reference)
source: html/96d5460c-a1e5-bf9b-54de-8c3fd9a78e3c.htm
---
# Autodesk.Revit.DB.Structure.RebarInSystem.GetBarIndexFromReference Method

Given a reference that represents a part of a bar, this method will return the bar index.

## Syntax (C#)
```csharp
public int GetBarIndexFromReference(
	Reference barReference
)
```

## Parameters
- **barReference** (`Autodesk.Revit.DB.Reference`) - The Reference of the RebarInSystem element.

## Returns
The bar index the reference refers to.

## Remarks
The method returns an index between 0 and NumberOfBarPositions - 1 if it the given reference represents a part of a bar.
 Otherwise will return -1.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null

