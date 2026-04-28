---
kind: method
id: M:Autodesk.Revit.DB.Structure.LoadBase.IsOrientToPermitted(Autodesk.Revit.DB.Structure.LoadOrientTo)
source: html/8681b54f-c427-9024-9ede-98ec917d0f8d.htm
---
# Autodesk.Revit.DB.Structure.LoadBase.IsOrientToPermitted Method

Indicates if the provided orientation is permitted for this load.

## Syntax (C#)
```csharp
public bool IsOrientToPermitted(
	LoadOrientTo orientTo
)
```

## Parameters
- **orientTo** (`Autodesk.Revit.DB.Structure.LoadOrientTo`) - Load orientation to check.

## Returns
True if provided orientation type is permitted for this load, false if not.

## Remarks
For hosted load only LoadOrientTo.Project and LoadOrientTo.HostLocalCoordinateSystem are permitted.
 For non-hosted load only LoadOrientTo.Project and LoadOrientTo.WorkPlane are permitted.
 To determine if load is hosted use IsHosted property.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentOutOfRangeException** - A value passed for an enumeration argument is not a member of that enumeration

