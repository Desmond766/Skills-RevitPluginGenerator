---
kind: property
id: P:Autodesk.Revit.DB.Mechanical.Zone.Boundary
source: html/c1608fa1-1360-a8b0-1e4f-08c71467cefd.htm
---
# Autodesk.Revit.DB.Mechanical.Zone.Boundary Property

Returns the boundary of the Zone.

## Syntax (C#)
```csharp
public CurveArray Boundary { get; }
```

## Remarks
This property is used to retrieve the segments that constitute the boundary of the Zone.
Each Zone may have several regions, each of which have several segments hence the data is returned
in the form of an array of boundary segment arrays. See the Zone.BoundarySegment object for more
details about the segments that make up the Zone topology.

