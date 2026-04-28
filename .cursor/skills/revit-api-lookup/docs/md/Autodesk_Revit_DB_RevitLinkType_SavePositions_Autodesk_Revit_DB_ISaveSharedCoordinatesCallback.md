---
kind: method
id: M:Autodesk.Revit.DB.RevitLinkType.SavePositions(Autodesk.Revit.DB.ISaveSharedCoordinatesCallback)
source: html/2bfb9cc1-5a29-a195-0892-92bef673ab66.htm
---
# Autodesk.Revit.DB.RevitLinkType.SavePositions Method

Saves shared coordinates changes back to the linked document.

## Syntax (C#)
```csharp
public bool SavePositions(
	ISaveSharedCoordinatesCallback callback
)
```

## Parameters
- **callback** (`Autodesk.Revit.DB.ISaveSharedCoordinatesCallback`) - A callback object to resolve situations when Revit encounters
 modified links.

## Returns
True if we saved the link or if there were no changes to save.
 False if the operation failed.

## Remarks
While this operation does not clear the document's undo history,
 you will not be able to undo this specific action, since it saves
 the link's shared coordinates changes to disk.

## Exceptions
- **Autodesk.Revit.Exceptions.InvalidOperationException** - Revit could not save shared coordinates changes to the link
 or one of its nested links.

