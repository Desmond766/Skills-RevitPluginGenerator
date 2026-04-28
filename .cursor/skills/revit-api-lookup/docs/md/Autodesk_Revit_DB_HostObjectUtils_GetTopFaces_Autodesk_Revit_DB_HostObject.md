---
kind: method
id: M:Autodesk.Revit.DB.HostObjectUtils.GetTopFaces(Autodesk.Revit.DB.HostObject)
source: html/de3ad895-337e-06f7-b1bb-edfb4fe2f35d.htm
---
# Autodesk.Revit.DB.HostObjectUtils.GetTopFaces Method

Returns the top faces for this host object.

## Syntax (C#)
```csharp
public static IList<Reference> GetTopFaces(
	HostObject hostObject
)
```

## Parameters
- **hostObject** (`Autodesk.Revit.DB.HostObject`) - The host object.

## Returns
An array of references to the faces which are at the top of this element.

## Remarks
This utility supports host objects whose top faces represent one of the boundaries
 of CompoundStructure (such as roofs, floors or ceilings).

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentException** - This host object does not support access to top or bottom faces.
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null

