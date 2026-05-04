---
kind: property
id: P:Autodesk.Revit.DB.Structure.RebarContainerItem.RebarShapeId
source: html/4e755081-80ba-11c1-f428-ed1f0a1f580b.htm
---
# Autodesk.Revit.DB.Structure.RebarContainerItem.RebarShapeId Property

The RebarShape element that defines the shape of the rebar.

## Syntax (C#)
```csharp
public ElementId RebarShapeId { get; set; }
```

## Remarks
Changing the value of this property causes the Rebar instance to choose values for its
 shape parameters to preserve its previous shape as closely as possible

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentException** - When setting this property: shapeId is not the id of a RebarShape in the document.
 -or-
 When setting this property: The RebarShape has End Treatments
- **Autodesk.Revit.Exceptions.ArgumentNullException** - When setting this property: A non-optional argument was null

