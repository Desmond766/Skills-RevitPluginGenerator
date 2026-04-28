---
kind: method
id: M:Autodesk.Revit.DB.Architecture.MultistoryStairs.Unpin(Autodesk.Revit.DB.ElementId)
source: html/f1eb4c84-2b7e-1b6a-dc8b-dfc6c0c994c9.htm
---
# Autodesk.Revit.DB.Architecture.MultistoryStairs.Unpin Method

Removes a particular story of the stairs (identified by its base level id) from a stairs group.

## Syntax (C#)
```csharp
public Stairs Unpin(
	ElementId levelId
)
```

## Parameters
- **levelId** (`Autodesk.Revit.DB.ElementId`) - The base level id.
 If the level id belongs to the base level of a unpinned stairs element, it returns the stairs id directly.

## Returns
The unpinned stairs element.

## Remarks
If the story at the given level is in a group, it will separate an individual stairs element from the group with "unpinned" status. Changes you make to the returned stairs element will not affect any other stairs.
 If the story of stairs is already an individual stairs element, the status will be changed to "unpinned".

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentException** - There is no stairs instance at the given base levelId.
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null

