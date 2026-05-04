---
kind: method
id: M:Autodesk.Revit.DB.Architecture.MultistoryStairs.IsPinned(Autodesk.Revit.DB.Architecture.Stairs)
source: html/c9dea1f0-00e3-e5ab-d66d-84e6250accab.htm
---
# Autodesk.Revit.DB.Architecture.MultistoryStairs.IsPinned Method

Checks if a stair is pinned.

## Syntax (C#)
```csharp
public bool IsPinned(
	Stairs stairs
)
```

## Parameters
- **stairs** (`Autodesk.Revit.DB.Architecture.Stairs`) - A stairs element in this multistory stairs element.

## Returns
Returns true if the stairs is pinned; otherwise returns false.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentException** - The input stairs is not a member of this multistory stairs.
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null

