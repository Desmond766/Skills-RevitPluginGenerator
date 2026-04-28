---
kind: method
id: M:Autodesk.Revit.DB.FamilyInstance.GetOriginalGeometry(Autodesk.Revit.DB.Options)
zh: 族实例
source: html/d28a0880-bff8-1acc-ddf1-ce3205f2e8b3.htm
---
# Autodesk.Revit.DB.FamilyInstance.GetOriginalGeometry Method

**中文**: 族实例

Returns the original geometry of the instance, before the instance is modified by 
joins, cuts, coping, extensions, or other post-processing.

## Syntax (C#)
```csharp
public GeometryElement GetOriginalGeometry(
	Options options
)
```

## Parameters
- **options** (`Autodesk.Revit.DB.Options`) - The options used to obtain the geometry. Note that ComputeReferences may not
be set to true.

## Remarks
This method returns the original geometry of the instance. The instance's geometry
will reflect the values of all instance level parameters (e.g. reference levels for columns) and
of the placement conditions (so a beam placed along a 20' long line will be 20' long). It excludes
all modifications made to the geometry due to operations like joining, cutting, openings, coping, 
or extensions. The geometry will not include the GeometryInstance typically returned when you access the geometry
of a FamilyInstance via Element.Geometry. But GeometryInstances may be encountered if there
are nested family instances within the family. The geometry is returned in the coordinates of the FamilySymbol, not the coordinates of the 
instance. If needed, you can transform the returned GeometryElement using the GetTransformed() 
method, passing the results from GetTransform(), or some other user-defined transformation.
 The geometry returned is from Revit's internal computations and does not represent actual
Revit geometry. Thus, you cannot use it as a reference for other geometry.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentException** - Thrown when the options are not 
valid for this operation (ComputeReferences == true)

