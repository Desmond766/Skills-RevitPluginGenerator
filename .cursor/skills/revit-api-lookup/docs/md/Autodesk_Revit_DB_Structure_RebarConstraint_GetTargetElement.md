---
kind: method
id: M:Autodesk.Revit.DB.Structure.RebarConstraint.GetTargetElement
source: html/75975a79-d608-9210-dbd7-0099a046fa3d.htm
---
# Autodesk.Revit.DB.Structure.RebarConstraint.GetTargetElement Method

Gets the Element object (either Host or Rebar) which provides the constraint.
 Will throw exception if it's a multi target constraint.

## Syntax (C#)
```csharp
public Element GetTargetElement()
```

## Returns
Returns the Element object (either Host or Rebar) which provides the constraint.

## Exceptions
- **Autodesk.Revit.Exceptions.InvalidOperationException** - RebarConstraint is no longer valid.
 -or-
 Multi target constraint. Consider using the indexed version of the method.

