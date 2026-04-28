---
kind: property
id: P:Autodesk.Revit.DB.SpotDimension.LeaderHasShoulder
source: html/7285e050-0673-cd70-64c4-de7df60f05c2.htm
---
# Autodesk.Revit.DB.SpotDimension.LeaderHasShoulder Property

True is dimension has leader with shoulder, false otherwise.

## Syntax (C#)
```csharp
public bool LeaderHasShoulder { get; set; }
```

## Exceptions
- **Autodesk.Revit.Exceptions.InvalidOperationException** - Dimension must have leader.
 -or-
 Thrown when:
 SpotDimension style type is SpotSlope. Using equality formula. Dimension style is ordinate. 
 -or-
 The dimension is a SpotSlope or has no leader.

