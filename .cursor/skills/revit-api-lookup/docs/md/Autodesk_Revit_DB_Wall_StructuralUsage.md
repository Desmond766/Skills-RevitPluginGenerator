---
kind: property
id: P:Autodesk.Revit.DB.Wall.StructuralUsage
zh: 墙、墙体
source: html/3957dfb0-fa41-0f9f-d3c8-ecfbd210e91d.htm
---
# Autodesk.Revit.DB.Wall.StructuralUsage Property

**中文**: 墙、墙体

Retrieves or changes the wall's designated structural usage.

## Syntax (C#)
```csharp
public StructuralWallUsage StructuralUsage { get; set; }
```

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentOutOfRangeException** - When setting this property: The enum value is not invalid for StructuralWallUsage.
 -or-
 When setting this property: A value passed for an enumeration argument is not a member of that enumeration

