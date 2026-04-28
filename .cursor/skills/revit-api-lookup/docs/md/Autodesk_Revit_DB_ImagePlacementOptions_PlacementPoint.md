---
kind: property
id: P:Autodesk.Revit.DB.ImagePlacementOptions.PlacementPoint
source: html/abc60f96-41eb-64af-6e6e-0dd45cd90442.htm
---
# Autodesk.Revit.DB.ImagePlacementOptions.PlacementPoint Property

Identifies which point of the ImageInstance will be aligned to the Location

## Syntax (C#)
```csharp
public BoxPlacement PlacementPoint { get; set; }
```

## Remarks
The location of the corners of the image in the model depends on the size and orientation of the ImageInstance 
 and the orientation of the view it is placed in.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentOutOfRangeException** - When setting this property: A value passed for an enumeration argument is not a member of that enumeration

