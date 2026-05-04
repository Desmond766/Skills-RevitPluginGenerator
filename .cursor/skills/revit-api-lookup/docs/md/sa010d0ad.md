---
kind: method
id: M:Autodesk.Revit.DB.WallUtils.DisallowWallJoinAtEnd(Autodesk.Revit.DB.Wall,System.Int32)
source: html/e8669ee5-322c-de8e-8f53-a7884cb3bb39.htm
---
# Autodesk.Revit.DB.WallUtils.DisallowWallJoinAtEnd Method

Sets the wall's end not to join to other walls.

## Syntax (C#)
```csharp
public static void DisallowWallJoinAtEnd(
	Wall wall,
	int end
)
```

## Parameters
- **wall** (`Autodesk.Revit.DB.Wall`) - The wall in question
- **end** (`System.Int32`) - 0 or 1 for the beginning or end of the wall's curve

## Remarks
If this wall is already joined at this end, it will become disconnected.
 If this wall is a stacked wall, all subwalls at this end will be disallowed to join.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null

