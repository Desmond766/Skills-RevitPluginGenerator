---
kind: method
id: M:Autodesk.Revit.DB.Structure.RebarFreeFormAccessor.CanBeHookNormal(System.Int32,System.Int32,Autodesk.Revit.DB.XYZ)
source: html/3848f3d8-f2f3-fca8-66af-9122d00b3869.htm
---
# Autodesk.Revit.DB.Structure.RebarFreeFormAccessor.CanBeHookNormal Method

A vector can be hook normal if for a bar specified by index, the bar direction is not parallel with the vector.

## Syntax (C#)
```csharp
public bool CanBeHookNormal(
	int barIndex,
	int end,
	XYZ normal
)
```

## Parameters
- **barIndex** (`System.Int32`) - The index of bar for which it will try to see if hook normal is applicable.
- **end** (`System.Int32`) - The end of bar. Should be 0 for start, 1 for end.
- **normal** (`Autodesk.Revit.DB.XYZ`) - The hook plane normal that will be tested.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null

