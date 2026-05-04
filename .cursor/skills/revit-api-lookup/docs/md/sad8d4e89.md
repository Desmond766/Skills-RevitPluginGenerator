---
kind: method
id: M:Autodesk.Revit.DB.Architecture.MultistoryStairs.CanConnectLevel(Autodesk.Revit.DB.ElementId)
source: html/01069be7-0661-3d91-48d3-9a6dea6c9711.htm
---
# Autodesk.Revit.DB.Architecture.MultistoryStairs.CanConnectLevel Method

Checks if the given level can be connected into multistory stairs.
 You cannot connect levels between standard stairs top and bottom or already connected.

## Syntax (C#)
```csharp
public bool CanConnectLevel(
	ElementId levelId
)
```

## Parameters
- **levelId** (`Autodesk.Revit.DB.ElementId`) - The id of the level.

## Returns
True if the level can be connected to this multistory stairs, false otherwise.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null

