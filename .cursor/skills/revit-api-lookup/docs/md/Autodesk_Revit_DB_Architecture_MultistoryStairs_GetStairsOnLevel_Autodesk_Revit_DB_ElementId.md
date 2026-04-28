---
kind: method
id: M:Autodesk.Revit.DB.Architecture.MultistoryStairs.GetStairsOnLevel(Autodesk.Revit.DB.ElementId)
source: html/7a591c9d-6dd9-398e-9eb5-280eca78d396.htm
---
# Autodesk.Revit.DB.Architecture.MultistoryStairs.GetStairsOnLevel Method

Gets the individual stairs or stairs group on the given base level.

## Syntax (C#)
```csharp
public Stairs GetStairsOnLevel(
	ElementId levelId
)
```

## Parameters
- **levelId** (`Autodesk.Revit.DB.ElementId`) - The base level id.

## Returns
The id of stairs element on the given level.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null

