---
kind: method
id: M:Autodesk.Revit.DB.ElevationMarker.CreateReferenceElevationMarker(Autodesk.Revit.DB.Document,Autodesk.Revit.DB.ElementId,Autodesk.Revit.DB.XYZ,Autodesk.Revit.DB.ElementId)
source: html/21c6e391-32f7-5ee8-03d9-269c4ecb3892.htm
---
# Autodesk.Revit.DB.ElevationMarker.CreateReferenceElevationMarker Method

Creates a new ElevationMarker.

## Syntax (C#)
```csharp
public static ElevationMarker CreateReferenceElevationMarker(
	Document document,
	ElementId viewFamilyTypeId,
	XYZ origin,
	ElementId viewPlanId
)
```

## Parameters
- **document** (`Autodesk.Revit.DB.Document`) - The document to which the new ElevationMarker will be added.
- **viewFamilyTypeId** (`Autodesk.Revit.DB.ElementId`) - This ViewFamilyType will be used by all elevations hosted on the new ElevationMarker.
- **origin** (`Autodesk.Revit.DB.XYZ`) - The desired origin for the ElevationMarker.
- **viewPlanId** (`Autodesk.Revit.DB.ElementId`) - The ViewPlan in which the reference ElevationMarker will appear. Reference ElevationMarkers only appear in one view.

## Returns
The new ElevationMarker.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentException** - The ElementId viewPlanId does not correspond to a ViewPlan.
 -or-
 This view family type is not appropriate for ElevationMarkers.
 -or-
 Elevation view creation is not allowed in this family.
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null

