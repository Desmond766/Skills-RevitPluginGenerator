---
kind: method
id: M:Autodesk.Revit.DB.WallUtils.AllowWallJoinAtEnd(Autodesk.Revit.DB.Wall,System.Int32)
source: html/e77a6d4e-bfbc-a146-0e29-54276bbb8056.htm
---
# Autodesk.Revit.DB.WallUtils.AllowWallJoinAtEnd Method

Allows the wall's end to join to other walls. If that end is near other walls it will become joined as a result.

## Syntax (C#)
```csharp
public static void AllowWallJoinAtEnd(
	Wall wall,
	int end
)
```

## Parameters
- **wall** (`Autodesk.Revit.DB.Wall`) - The wall in question
- **end** (`System.Int32`) - 0 or 1 for the beginning or end of the wall's curve

## Remarks
By default all walls are allowed to join at ends, so this function is only needed if this wall end is already disallowed to join.
 If this wall is a stacked wall, all subwalls at this end will be allowed to join.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null

