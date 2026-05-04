---
kind: property
id: P:Autodesk.Revit.DB.ImagePlacementOptions.Location
source: html/9e5ffb2b-a732-b118-e551-3966dad02d20.htm
---
# Autodesk.Revit.DB.ImagePlacementOptions.Location Property

The location in the model where a point of the ImageInstance , determined by the PlacementPoint property, is going to be inserted.

## Syntax (C#)
```csharp
public XYZ Location { get; set; }
```

## Remarks
The location represents a point in the model where the ImageInstance will be placed.
 The location of the image in the view is determined by the projection of this
 point onto the plane of the view.
 This means that in a plan view, for example, the z-coordinate has no effect.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentNullException** - When setting this property: A non-optional argument was null

