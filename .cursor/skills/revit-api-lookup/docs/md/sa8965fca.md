---
kind: method
id: M:Autodesk.Revit.DB.Architecture.MultistoryStairs.GetStairsPlacementLevels(Autodesk.Revit.DB.Architecture.Stairs)
source: html/1d81b0f3-4065-8ec7-e7f8-0fbb1d120617.htm
---
# Autodesk.Revit.DB.Architecture.MultistoryStairs.GetStairsPlacementLevels Method

Gets all the levels the given stairs group placed on.

## Syntax (C#)
```csharp
public ISet<ElementId> GetStairsPlacementLevels(
	Stairs stairs
)
```

## Parameters
- **stairs** (`Autodesk.Revit.DB.Architecture.Stairs`) - A stairs element in this multistory stairs element.

## Returns
The ids of base levels of the given stairs in this multistory stairs.

## Remarks
If a stairs element is a stairs group, it gets all the base levels of each member of the group;
 If a stairs element is an individual stairs, it just gets the base level of the stairs element.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentException** - The input stairs is not a member of this multistory stairs.
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null

