---
kind: method
id: M:Autodesk.Revit.DB.IFC.IFCGeometryInfo.CreateFaceGeometryInfo(System.Double,System.Boolean)
source: html/4dba723d-b758-0962-7812-113f6bab9cf2.htm
---
# Autodesk.Revit.DB.IFC.IFCGeometryInfo.CreateFaceGeometryInfo Method

Creates a new container object which holds IfcFace handles processed from a Revit geometry object.

## Syntax (C#)
```csharp
public static IFCGeometryInfo CreateFaceGeometryInfo(
	double epsilon,
	bool isCoarse
)
```

## Parameters
- **epsilon** (`System.Double`) - The epsilon value used to process surfaces.
- **isCoarse** (`System.Boolean`) - Indicates whether we should use a coarse representation.

## Returns
The new geometry info container.

