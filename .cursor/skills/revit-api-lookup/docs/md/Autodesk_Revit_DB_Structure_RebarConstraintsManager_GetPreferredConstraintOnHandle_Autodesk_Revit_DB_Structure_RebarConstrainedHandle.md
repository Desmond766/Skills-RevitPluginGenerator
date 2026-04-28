---
kind: method
id: M:Autodesk.Revit.DB.Structure.RebarConstraintsManager.GetPreferredConstraintOnHandle(Autodesk.Revit.DB.Structure.RebarConstrainedHandle)
source: html/4f92a917-683e-52f7-ad29-de2025af0220.htm
---
# Autodesk.Revit.DB.Structure.RebarConstraintsManager.GetPreferredConstraintOnHandle Method

For ShapeDriven: Returns the RebarConstraint that has been set as preferred for the specified RebarConstrainedHandle. For FreeForm: Returns the RebarConstraint that acts on the specified RebarConstraintHandle.

## Syntax (C#)
```csharp
public RebarConstraint GetPreferredConstraintOnHandle(
	RebarConstrainedHandle handle
)
```

## Parameters
- **handle** (`Autodesk.Revit.DB.Structure.RebarConstrainedHandle`) - The RebarConstrainedHandle for which the RebarConstraint is to be returned.

## Returns
The user preferred RebarConstraint applied to the RebarConstrainedHandle.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentException** - handle is no longer valid.
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null
- **Autodesk.Revit.Exceptions.InvalidOperationException** - The RebarConstraintsManager does not manage a valid Rebar element.

