---
kind: method
id: M:Autodesk.Revit.DB.FamilyManager.SortParameters(Autodesk.Revit.DB.ParametersOrder)
source: html/329ceb60-b9b5-d603-a23c-e9fcfc9d2f62.htm
---
# Autodesk.Revit.DB.FamilyManager.SortParameters Method

Sorts the family parameters according to the desired sort order.

## Syntax (C#)
```csharp
public void SortParameters(
	ParametersOrder order
)
```

## Parameters
- **order** (`Autodesk.Revit.DB.ParametersOrder`) - The desired sort order.

## Remarks
The sort only affects visible parameters within the same parameter group. Parameters that belong to different groups will remain separated, and the groups' order will not be affected. The sort is a one-time operation and when new parameters are added they will not be automatically sorted.

## Exceptions
- **Autodesk.Revit.Exceptions.InvalidOperationException** - Thrown when this family is a Rebar Shape family which doesn't support parameters reorder.

