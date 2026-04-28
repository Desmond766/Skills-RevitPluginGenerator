---
kind: method
id: M:Autodesk.Revit.DB.HostObjectUtils.GetSideFaces(Autodesk.Revit.DB.HostObject,Autodesk.Revit.DB.ShellLayerType)
source: html/589b9363-c2cc-52d9-6ba1-fc8e8f912b27.htm
---
# Autodesk.Revit.DB.HostObjectUtils.GetSideFaces Method

Returns the major side faces for this host object.

## Syntax (C#)
```csharp
public static IList<Reference> GetSideFaces(
	HostObject hostObject,
	ShellLayerType side
)
```

## Parameters
- **hostObject** (`Autodesk.Revit.DB.HostObject`) - The host object.
- **side** (`Autodesk.Revit.DB.ShellLayerType`) - The side of the host object.

## Returns
An array of references to the faces which are on the given side of this element.

## Remarks
This utility supports host objects whose CompoundStructure is nominally oriented vertically. It
 outputs faces which are at the boundary of the CompoundStructure (such as Walls and FaceWalls).

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentException** - This host object does not support access to side faces.
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null
- **Autodesk.Revit.Exceptions.ArgumentOutOfRangeException** - A value passed for an enumeration argument is not a member of that enumeration

