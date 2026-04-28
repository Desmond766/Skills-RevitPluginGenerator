---
kind: property
id: P:Autodesk.Revit.DB.PointCloudInstance.FilterAction
source: html/34b01a28-e1f7-b8b3-06fb-83f28e4b64c3.htm
---
# Autodesk.Revit.DB.PointCloudInstance.FilterAction Property

The action taken based on the results of the selection filter applied to this point cloud.

## Syntax (C#)
```csharp
public SelectionFilterAction FilterAction { get; set; }
```

## Remarks
If no selection filter is applied, changing this value will have no visible effect.
 The filter is provided in the coordinates of the Revit model. If the point cloud is
 altered (e.g. by moving, rotating, scaling or other modifications) the point cloud
 filter is not modified and the set of highlighted or isolated points will change.
 The filter action is not preserved when the Revit document is saved.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentOutOfRangeException** - When setting this property: A value passed for an enumeration argument is not a member of that enumeration

