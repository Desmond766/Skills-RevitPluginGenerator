---
kind: method
id: M:Autodesk.Revit.DB.AdaptiveComponentInstanceUtils.SetInstanceFlipped(Autodesk.Revit.DB.FamilyInstance,System.Boolean)
source: html/e5da2516-4b63-daf8-ec1a-1d70ad73d2d7.htm
---
# Autodesk.Revit.DB.AdaptiveComponentInstanceUtils.SetInstanceFlipped Method

Sets the value of the flip parameter on the adaptive instance.

## Syntax (C#)
```csharp
public static void SetInstanceFlipped(
	FamilyInstance famInst,
	bool flip
)
```

## Parameters
- **famInst** (`Autodesk.Revit.DB.FamilyInstance`) - The FamilyInstance
- **flip** (`System.Boolean`) - The flip flag

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentException** - The FamilyInstance famInst is not an Adaptive Family Instance.
 -or-
 The FamilyInstance famInst does not have an Adaptive Family Symbol.
 -or-
 The FamilyInstance famInst cannot be flipped or unflipped.
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null
- **Autodesk.Revit.Exceptions.InvalidOperationException** - This operation failed.

