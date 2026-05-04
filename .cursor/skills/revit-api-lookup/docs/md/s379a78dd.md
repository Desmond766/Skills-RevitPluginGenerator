---
kind: method
id: M:Autodesk.Revit.DB.SolidUtils.IsValidForTessellation(Autodesk.Revit.DB.Solid)
source: html/a99a8a88-2e90-8d90-60bd-6ee37ab47515.htm
---
# Autodesk.Revit.DB.SolidUtils.IsValidForTessellation Method

Tests if the input solid or shell is valid for tessellation.

## Syntax (C#)
```csharp
public static bool IsValidForTessellation(
	Solid solidOrShell
)
```

## Parameters
- **solidOrShell** (`Autodesk.Revit.DB.Solid`) - The solid or shell.

## Returns
True if the solid or shell is valid for tessellation, false otherwise.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null

