---
kind: property
id: P:Autodesk.Revit.DB.BoundingBoxUV.IsSet
source: html/b03677fc-ffa8-4c23-d957-6c9fc1afd995.htm
---
# Autodesk.Revit.DB.BoundingBoxUV.IsSet Property

Indicates whether the BoundingBoxUV is set or not.

## Syntax (C#)
```csharp
public bool IsSet { get; }
```

## Remarks
An unset BoundingBoxUV has its lower-left corner to the right of (and above)
its upper-right corner (this is an arbitrary internal representation). It means that it is empty
and has never been initialized. 
If someone using the API creates a Plane via one of the Plane.Create() methods, for example, 
the Plane will not have its envelope set, so Surface.GetBoundingBoxUV() would return an empty BoundingBoxUV.

