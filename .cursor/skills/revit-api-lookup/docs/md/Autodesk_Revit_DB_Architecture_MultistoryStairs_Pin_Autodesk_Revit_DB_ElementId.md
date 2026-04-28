---
kind: method
id: M:Autodesk.Revit.DB.Architecture.MultistoryStairs.Pin(Autodesk.Revit.DB.ElementId)
source: html/41a11436-7ef4-f8c8-f247-04d529f8c466.htm
---
# Autodesk.Revit.DB.Architecture.MultistoryStairs.Pin Method

Restores an unpinned stairs element back into the group of stairs governed by level height.

## Syntax (C#)
```csharp
public Stairs Pin(
	ElementId levelId
)
```

## Parameters
- **levelId** (`Autodesk.Revit.DB.ElementId`) - The base level id.
 If the level id belongs to the base level of an individual pinned stairs, it returns the stairs id directly.

## Returns
The stairs element which the pinned story belongs to.

## Remarks
If the level height of current story can be found among other stories, the stair will be added back into the group;
 Otherwise only the status will be changed to "pinned".

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentException** - There is no stairs instance at the given base levelId.
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null

