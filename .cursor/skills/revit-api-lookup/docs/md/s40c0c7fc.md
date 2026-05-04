---
kind: property
id: P:Autodesk.Revit.DB.Wall.CrossSection
zh: 墙、墙体
source: html/78d7a145-5b3c-c82f-6bec-85bb14b00cf5.htm
---
# Autodesk.Revit.DB.Wall.CrossSection Property

**中文**: 墙、墙体

Obtain the Wall Cross-section for this wall.

## Syntax (C#)
```csharp
public WallCrossSection CrossSection { get; set; }
```

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentException** - When setting this property: The current wall does not support the cross section wallCrossSection.
- **Autodesk.Revit.Exceptions.ArgumentOutOfRangeException** - When setting this property: A value passed for an enumeration argument is not a member of that enumeration

