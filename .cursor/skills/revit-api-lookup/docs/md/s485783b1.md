---
kind: method
id: M:Autodesk.Revit.DB.Structure.RebarConstraint.GetTargetElement(System.Int32)
source: html/f20b6107-6c40-860d-2445-4c2fcbde3f29.htm
---
# Autodesk.Revit.DB.Structure.RebarConstraint.GetTargetElement Method

Gets the Element object (either Host or Rebar) which provides the constraint. Will return the Element which contains the face at targetIndex.

## Syntax (C#)
```csharp
public Element GetTargetElement(
	int targetIndex
)
```

## Parameters
- **targetIndex** (`System.Int32`) - The index of the target. Should be between 0 and NumberOfTargets().

## Returns
Returns the Element object (either Host or Rebar) which provides the constraint. Will return the Element which contains the face at targetIndex.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentException** - targetIndex is out of range.
- **Autodesk.Revit.Exceptions.InvalidOperationException** - RebarConstraint is no longer valid.

