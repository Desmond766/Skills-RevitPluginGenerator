---
kind: method
id: M:Autodesk.Revit.DB.Structure.RebarConstraintsManager.GetAllConstrainedHandles
source: html/d87a1741-7965-413d-3c44-666516fd31aa.htm
---
# Autodesk.Revit.DB.Structure.RebarConstraintsManager.GetAllConstrainedHandles Method

Retrieves all handles on the Rebar that are constrained to external references.

## Syntax (C#)
```csharp
public IList<RebarConstrainedHandle> GetAllConstrainedHandles()
```

## Returns
A collection of RebarConstrainedHandles

## Exceptions
- **Autodesk.Revit.Exceptions.InvalidOperationException** - The RebarConstraintsManager does not manage a valid Rebar element.

