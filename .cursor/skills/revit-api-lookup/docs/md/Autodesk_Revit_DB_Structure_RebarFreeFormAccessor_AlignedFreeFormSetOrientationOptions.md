---
kind: property
id: P:Autodesk.Revit.DB.Structure.RebarFreeFormAccessor.AlignedFreeFormSetOrientationOptions
source: html/052bb659-79b5-60ca-c683-c2e45c3882cd.htm
---
# Autodesk.Revit.DB.Structure.RebarFreeFormAccessor.AlignedFreeFormSetOrientationOptions Property

Orientation options for an Aligned Free Form Rebar set.

## Syntax (C#)
```csharp
public AlignedFreeFormSetOrientationOptions AlignedFreeFormSetOrientationOptions { get; set; }
```

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentOutOfRangeException** - When setting this property: A value passed for an enumeration argument is not a member of that enumeration
- **Autodesk.Revit.Exceptions.InvalidOperationException** - This RebarFreeFormAccessor doesn't contain a valid rebar reference.
 -or-
 This RebarFreeFormAccessor Rebar is not created with the Aligned Free Form rebar server.

