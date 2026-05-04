---
kind: method
id: M:Autodesk.Revit.DB.Structure.RebarConstraintsManager.GetCurrentConstraintOnHandle(Autodesk.Revit.DB.Structure.RebarConstrainedHandle)
source: html/6020571a-fa8f-5f21-3874-f808456a8854.htm
---
# Autodesk.Revit.DB.Structure.RebarConstraintsManager.GetCurrentConstraintOnHandle Method

Retrieves the RebarConstraint that acts on the specified RebarConstraintHandle.

## Syntax (C#)
```csharp
public RebarConstraint GetCurrentConstraintOnHandle(
	RebarConstrainedHandle handle
)
```

## Parameters
- **handle** (`Autodesk.Revit.DB.Structure.RebarConstrainedHandle`)

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentException** - handle is no longer valid.
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null
- **Autodesk.Revit.Exceptions.InvalidOperationException** - The RebarConstraintsManager does not manage a valid Rebar element.

