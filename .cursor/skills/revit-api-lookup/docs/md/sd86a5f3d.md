---
kind: type
id: T:Autodesk.Revit.DB.ElevationMarker
source: html/ca59d2f7-4cd0-d13d-22a0-c153ac8310d4.htm
---
# Autodesk.Revit.DB.ElevationMarker

ElevationMarkers either host elevation ViewSection views or view references.

## Syntax (C#)
```csharp
public class ElevationMarker : Element
```

## Remarks
ElevationMarkers store the ViewFamilyType which will be used by all elevations
 hosted on the ElevationMarker.
 The orientation of an ElevationMarker is determined by the orientation of the views
 it hosts. You can check the orientation of any view by getting View.ViewDirection.
 To reorient the ElevationMarker and all of the views it hosts, call
 ElementTransformUtils.RotateElement with the ElevationMarker as an argument.

