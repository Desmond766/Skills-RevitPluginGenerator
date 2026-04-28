---
kind: method
id: M:Autodesk.Revit.DB.HostObjectUtils.GetBottomFaces(Autodesk.Revit.DB.HostObject)
source: html/34737312-04d0-3550-6a42-5020c4ea2284.htm
---
# Autodesk.Revit.DB.HostObjectUtils.GetBottomFaces Method

Returns the bottom faces for this host object.

## Syntax (C#)
```csharp
public static IList<Reference> GetBottomFaces(
	HostObject hostObject
)
```

## Parameters
- **hostObject** (`Autodesk.Revit.DB.HostObject`) - The host object.

## Returns
An array of references to the faces which are at the bottom of this element.

## Remarks
This utility supports host objects whose bottom faces represent one of the boundaries
 of CompoundStructure (such as roofs, floors or ceilings).

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentException** - This host object does not support access to top or bottom faces.
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null

