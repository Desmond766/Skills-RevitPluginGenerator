---
kind: property
id: P:Autodesk.Revit.DB.Architecture.BalusterInfo.DistanceFromPreviousOrSpace
source: html/3c7045d7-7493-4f10-cb94-715a0c922b39.htm
---
# Autodesk.Revit.DB.Architecture.BalusterInfo.DistanceFromPreviousOrSpace Property

The length, in case of balusters, it is a distance from a previous one.
 For a post, it is a space from the original position of the post.

## Syntax (C#)
```csharp
public double DistanceFromPreviousOrSpace { get; set; }
```

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentException** - When setting this property: The given value for distanceFromPreviousOrSpace is not finite
- **Autodesk.Revit.Exceptions.ArgumentOutOfRangeException** - When setting this property: The given value for distanceFromPreviousOrSpace must be greater than 0 and no more than 30000 feet.

