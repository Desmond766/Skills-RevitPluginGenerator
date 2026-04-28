---
kind: property
id: P:Autodesk.Revit.DB.BuiltInFailures.FaceSplitterFailures.InvalidClosedLoopsForFaceSplit
source: html/ff21648e-5c98-1266-a2fa-94344fcc75b6.htm
---
# Autodesk.Revit.DB.BuiltInFailures.FaceSplitterFailures.InvalidClosedLoopsForFaceSplit Property

The closed loop used to split the face must lie completely within the face and cannot intersect or overlap any of the face's edges.
 To split a face at its border, use an open loop that ends on the boundary of the face.

## Syntax (C#)
```csharp
public static FailureDefinitionId InvalidClosedLoopsForFaceSplit { get; }
```

