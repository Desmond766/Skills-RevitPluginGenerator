---
kind: method
id: M:Autodesk.Revit.DB.WallUtils.IsWallJoinAllowedAtEnd(Autodesk.Revit.DB.Wall,System.Int32)
source: html/d5028e5c-92d2-0b84-b258-26d1b758b378.htm
---
# Autodesk.Revit.DB.WallUtils.IsWallJoinAllowedAtEnd Method

Identifies if the indicated end of the wall allows joins or not.

## Syntax (C#)
```csharp
public static bool IsWallJoinAllowedAtEnd(
	Wall wall,
	int end
)
```

## Parameters
- **wall** (`Autodesk.Revit.DB.Wall`) - The wall in question
- **end** (`System.Int32`) - 0 or 1 for the beginning or end of the wall's curve

## Returns
true if it is allowed to join. false if it is disallowed.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null

