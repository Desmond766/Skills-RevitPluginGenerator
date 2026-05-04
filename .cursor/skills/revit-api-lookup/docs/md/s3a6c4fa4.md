---
kind: method
id: M:Autodesk.Revit.DB.ExportUtils.GetNurbsSurfaceDataForSurface(Autodesk.Revit.DB.Surface)
source: html/659dfb29-ce3b-4527-01ed-ac3c01fa36e4.htm
---
# Autodesk.Revit.DB.ExportUtils.GetNurbsSurfaceDataForSurface Method

Returns the necessary information to define a NURBS surface
 for a given [!:Autodesk::Revit::DB::HermiteSuface] or [!:Autodesk::Revit::DB::RuledSuface] .

## Syntax (C#)
```csharp
public static NurbsSurfaceData GetNurbsSurfaceDataForSurface(
	Surface surface
)
```

## Parameters
- **surface** (`Autodesk.Revit.DB.Surface`) - The HermiteSurface or RuledSurface to be converted.

## Returns
A class containing the necessary data to define a NURBS surface.

## Remarks
This function is intended for export purposes.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentException** - This surface type is not supported for this function.
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null
- **Autodesk.Revit.Exceptions.InvalidOperationException** - Couldn't get NURBS data from surface.

