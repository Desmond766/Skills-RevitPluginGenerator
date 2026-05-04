---
kind: method
id: M:Autodesk.Revit.DB.Structure.RebarConstraint.IsEqual(Autodesk.Revit.DB.Structure.RebarConstraint)
source: html/f2d5fb51-542c-6f74-d931-590c9d429e6b.htm
---
# Autodesk.Revit.DB.Structure.RebarConstraint.IsEqual Method

Returns true if the specified RebarConstraint is the same as 'this.' The method
 can be used to determine which of the RebarConstraint candidates offered by the
 RebarConstraintsManager is currently active.

## Syntax (C#)
```csharp
public bool IsEqual(
	RebarConstraint other
)
```

## Parameters
- **other** (`Autodesk.Revit.DB.Structure.RebarConstraint`)

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentException** - other is no longer valid.
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null
- **Autodesk.Revit.Exceptions.InvalidOperationException** - RebarConstraint is no longer valid.

