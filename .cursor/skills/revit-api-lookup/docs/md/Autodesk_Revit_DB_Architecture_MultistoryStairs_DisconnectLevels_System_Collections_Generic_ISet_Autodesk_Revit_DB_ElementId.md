---
kind: method
id: M:Autodesk.Revit.DB.Architecture.MultistoryStairs.DisconnectLevels(System.Collections.Generic.ISet{Autodesk.Revit.DB.ElementId})
source: html/482be079-8bd4-e275-8231-7d3ae487e73c.htm
---
# Autodesk.Revit.DB.Architecture.MultistoryStairs.DisconnectLevels Method

Shrinks the multistory stairs by disconnecting input levels.

## Syntax (C#)
```csharp
public void DisconnectLevels(
	ISet<ElementId> levelIds
)
```

## Parameters
- **levelIds** (`System.Collections.Generic.ISet < ElementId >`) - The level ids.

## Remarks
If you remove a stairs that is connected at the top and bottom to another level stairs, the remaining stairs will automatically adjust to maintain the multistory stairs.
 The stairs above the one that is removed extends to attach to the stairs on the level below the one that is removed.
 You cannot disconnect the levels of standard stair (the stair associated with the Reference Level for the multistory stairs) or already disconnected.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentException** - This multistory stairs cannot disconnect from one or more members of levelIds.
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null

