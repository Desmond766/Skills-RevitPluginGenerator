---
kind: property
id: P:Autodesk.Revit.DB.Element.Geometry(Autodesk.Revit.DB.Options)
zh: 构件、图元、元素
source: html/d8a55a5b-2a69-d5ab-3e1f-6cf1ee43c8ec.htm
---
# Autodesk.Revit.DB.Element.Geometry Property

**中文**: 构件、图元、元素

Retrieves the geometric representation of the element.

## Syntax (C#)
```csharp
public GeometryElement this[
	Options options
] { get; }
```

## Parameters
- **options** (`Autodesk.Revit.DB.Options`) - User preferences for parsing of geometry.

## Remarks
This call will retrieve 3d representation of the element. Nothing nullptr a null reference ( Nothing in Visual Basic) will be returned
for symbols, annotations or details. This involves extensive parsing or Revit's data
structures, so try to minimize calls if performance is critical. Geometry objects provided from this method are obtained directly from the element. When
the element is changed for any reason, the geometry will be recalculated by Revit and geometry
objects obtained before the change are likely to no longer be valid. If you need to preserve
geometry information obtained an element even after changes to that element, you should copy
the geometry objects or save the properties independently. Although the geometry obtained from this method comes directly from the element, any attempt to modify 
any of the geometry objects will operate only on a disconnected copy of the original geometry object from the element. 
The modification will not affect the geometry of the original element from which it was obtained - 
to change the geometry of the element you must use methods that directly affect the geometry calculated or 
stored by Revit for this element. If you require that the geometry items obtained contain valid 
 Reference objects , be sure to set the ComputeReferences
property of the Options.

