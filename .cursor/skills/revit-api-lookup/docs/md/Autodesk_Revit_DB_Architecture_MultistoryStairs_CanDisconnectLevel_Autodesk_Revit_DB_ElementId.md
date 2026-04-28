---
kind: method
id: M:Autodesk.Revit.DB.Architecture.MultistoryStairs.CanDisconnectLevel(Autodesk.Revit.DB.ElementId)
source: html/471db1d0-7f14-6a45-a31e-b31a85f1f124.htm
---
# Autodesk.Revit.DB.Architecture.MultistoryStairs.CanDisconnectLevel Method

Checks if the given level can be disconnected from multistory stairs.
 You cannot disconnect the levels of standard stair (the stair associated with the Reference Level for the multistory stairs) or already disconnected.

## Syntax (C#)
```csharp
public bool CanDisconnectLevel(
	ElementId levelId
)
```

## Parameters
- **levelId** (`Autodesk.Revit.DB.ElementId`) - The id of the level.

## Returns
True if the level id can be used to remove stairs.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null

