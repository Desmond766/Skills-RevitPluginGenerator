---
kind: method
id: M:Autodesk.Revit.DB.Analysis.FieldDomainPointsByXYZ.#ctor(System.Collections.Generic.IList{Autodesk.Revit.DB.XYZ})
source: html/1e66fd61-43c4-8ef0-887a-75a18d68b181.htm
---
# Autodesk.Revit.DB.Analysis.FieldDomainPointsByXYZ.#ctor Method

Creates object from an array of three-dimensional point coordinates

## Syntax (C#)
```csharp
public FieldDomainPointsByXYZ(
	IList<XYZ> points
)
```

## Parameters
- **points** (`System.Collections.Generic.IList < XYZ >`) - Array of three-dimensional point coordinates representing domain points

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentException** - Thrown when supplied array points contain too many members (over 1000)
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null

