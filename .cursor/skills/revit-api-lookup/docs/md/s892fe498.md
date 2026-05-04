---
kind: method
id: M:Autodesk.Revit.DB.AreaVolumeSettings.SetSpatialElementBoundaryLocation(Autodesk.Revit.DB.SpatialElementBoundaryLocation,Autodesk.Revit.DB.SpatialElementType)
source: html/d1d395b6-7cb4-358a-3838-68c619c22385.htm
---
# Autodesk.Revit.DB.AreaVolumeSettings.SetSpatialElementBoundaryLocation Method

Sets the spatial element boundary location of a spatial element type.

## Syntax (C#)
```csharp
public void SetSpatialElementBoundaryLocation(
	SpatialElementBoundaryLocation spatialElementBoundaryLocation,
	SpatialElementType spType
)
```

## Parameters
- **spatialElementBoundaryLocation** (`Autodesk.Revit.DB.SpatialElementBoundaryLocation`) - The boundary location.
- **spType** (`Autodesk.Revit.DB.SpatialElementType`) - The spatial element type.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentException** - Currently only SpatialElementType.Room is permitted when setting the boundary location.
- **Autodesk.Revit.Exceptions.ArgumentOutOfRangeException** - A value passed for an enumeration argument is not a member of that enumeration

