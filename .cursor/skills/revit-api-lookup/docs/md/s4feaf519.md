---
kind: property
id: P:Autodesk.Revit.DB.Structure.LoadBase.OrientTo
source: html/c1252918-899f-23f0-c3e8-c0e5817ef812.htm
---
# Autodesk.Revit.DB.Structure.LoadBase.OrientTo Property

The load orientation option.

## Syntax (C#)
```csharp
public LoadOrientTo OrientTo { get; set; }
```

## Remarks
For hosted load only LoadOrientTo.Project and LoadOrientTo.HostLocalCoordinateSystem are permitted.
 For non-hosted load only LoadOrientTo.Project and LoadOrientTo.WorkPlane are permitted.
 To determine if load is hosted use IsHosted property.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentException** - When setting this property: orientTo is not permitted for this type of load.
- **Autodesk.Revit.Exceptions.ArgumentOutOfRangeException** - When setting this property: A value passed for an enumeration argument is not a member of that enumeration

