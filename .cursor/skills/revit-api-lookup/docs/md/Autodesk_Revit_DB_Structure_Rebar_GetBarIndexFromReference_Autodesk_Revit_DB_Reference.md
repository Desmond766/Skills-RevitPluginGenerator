---
kind: method
id: M:Autodesk.Revit.DB.Structure.Rebar.GetBarIndexFromReference(Autodesk.Revit.DB.Reference)
zh: 钢筋、配筋
source: html/6d2769f6-ba8d-5173-0947-9d82aeabefa8.htm
---
# Autodesk.Revit.DB.Structure.Rebar.GetBarIndexFromReference Method

**中文**: 钢筋、配筋

Given a reference that represents a part of a bar, this method will return the bar index.

## Syntax (C#)
```csharp
public int GetBarIndexFromReference(
	Reference barReference
)
```

## Parameters
- **barReference** (`Autodesk.Revit.DB.Reference`) - The Reference of the Rebar element.

## Returns
The bar index the reference refers to.

## Remarks
The method returns an index between 0 and NumberOfBarPositions - 1 if it the given reference represents a part of a bar.
 Otherwise will return -1.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null

