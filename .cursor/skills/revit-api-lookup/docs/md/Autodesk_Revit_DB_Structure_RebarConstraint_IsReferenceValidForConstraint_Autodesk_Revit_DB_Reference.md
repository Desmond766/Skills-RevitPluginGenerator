---
kind: method
id: M:Autodesk.Revit.DB.Structure.RebarConstraint.IsReferenceValidForConstraint(Autodesk.Revit.DB.Reference)
source: html/728e9832-f292-212e-1579-a34d30954b32.htm
---
# Autodesk.Revit.DB.Structure.RebarConstraint.IsReferenceValidForConstraint Method

Checks if the reference provided can be used in creating Rebar constraints

## Syntax (C#)
```csharp
public bool IsReferenceValidForConstraint(
	Reference targetReference
)
```

## Parameters
- **targetReference** (`Autodesk.Revit.DB.Reference`) - The reference to be checked

## Returns
returns true if reference can be used in a constraint, false otherwise

## Remarks
Reference is valid if it points to an uncut face of a structural that can host rebar.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null

