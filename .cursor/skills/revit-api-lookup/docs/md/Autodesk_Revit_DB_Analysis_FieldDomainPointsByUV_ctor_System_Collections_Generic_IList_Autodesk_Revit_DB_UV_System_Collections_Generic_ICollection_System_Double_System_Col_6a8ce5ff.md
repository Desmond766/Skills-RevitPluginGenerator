---
kind: method
id: M:Autodesk.Revit.DB.Analysis.FieldDomainPointsByUV.#ctor(System.Collections.Generic.IList{Autodesk.Revit.DB.UV},System.Collections.Generic.ICollection{System.Double},System.Collections.Generic.ICollection{System.Double})
source: html/829c3a3b-b370-a1eb-f27a-5a5a3939c782.htm
---
# Autodesk.Revit.DB.Analysis.FieldDomainPointsByUV.#ctor Method

Creates object from an array of two-dimensional point coordinates

## Syntax (C#)
```csharp
public FieldDomainPointsByUV(
	IList<UV> points,
	ICollection<double> uCoordinates,
	ICollection<double> vCoordinates
)
```

## Parameters
- **points** (`System.Collections.Generic.IList < UV >`) - Array of two-dimensional point coordinates representing domain points (usually on surface)
- **uCoordinates** (`System.Collections.Generic.ICollection < Double >`) - Set of u coordinates at which to draw grid lines on the surface
- **vCoordinates** (`System.Collections.Generic.ICollection < Double >`) - Set of v coordinates at which to draw grid lines on the surface

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null

