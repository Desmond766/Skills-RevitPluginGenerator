---
kind: method
id: M:Autodesk.Revit.DB.AreaVolumeSettings.GetSpatialElementBoundaryLocation(Autodesk.Revit.DB.SpatialElementType)
source: html/96d8e23d-2c29-a2c2-de51-7f692abd79ca.htm
---
# Autodesk.Revit.DB.AreaVolumeSettings.GetSpatialElementBoundaryLocation Method

Gets the spatial element boundary location based on spatial element type.

## Syntax (C#)
```csharp
public SpatialElementBoundaryLocation GetSpatialElementBoundaryLocation(
	SpatialElementType spType
)
```

## Parameters
- **spType** (`Autodesk.Revit.DB.SpatialElementType`) - The spatial element type.

## Returns
The boundary location.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentOutOfRangeException** - A value passed for an enumeration argument is not a member of that enumeration

