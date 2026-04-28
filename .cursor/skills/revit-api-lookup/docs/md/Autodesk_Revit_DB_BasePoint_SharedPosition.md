---
kind: property
id: P:Autodesk.Revit.DB.BasePoint.SharedPosition
source: html/ad4095ac-ab51-3589-fcbd-c28b93bb3158.htm
---
# Autodesk.Revit.DB.BasePoint.SharedPosition Property

Shared position of the BasePoint based on the active ProjectLocation of its belonging Document.
 To get the shared position under other ProjectLocations, please use ProjectLocation.GetProjectPosition(BasePoint.Position).

## Syntax (C#)
```csharp
public XYZ SharedPosition { get; internal set; }
```

