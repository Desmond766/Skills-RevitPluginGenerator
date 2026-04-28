---
kind: type
id: T:Autodesk.Revit.DB.ElementClassFilter
source: html/4b7fb6d7-cb9c-d556-56fc-003a0b8a51b7.htm
---
# Autodesk.Revit.DB.ElementClassFilter

A filter used to match elements by their class.

## Syntax (C#)
```csharp
public class ElementClassFilter : ElementQuickFilter
```

## Remarks
This filter is a quick filter.
 Quick filters operate only on the ElementRecord, a low-memory class which has
 a limited interface to read element properties. Elements which are rejected
 by a quick filter will not be expanded in memory.
 This filter will match elements whose class is an exact match to the input class,
 or elements whose class is derived from the input class. There is a small subset of Element subclasses in the API which are not supported
 by this filter. These types exist in the API, but not in Revit's native object model,
 which means that this filter doesn't support them. In order to use a class filter to
 find elements of these types, it is necessary to use a higher level class and then
 process the results further to find elements matching only the subtype. The following
 types are affected by this restriction:
 Subclasses of Autodesk.Revit.DB.Material Subclasses of Autodesk.Revit.DB.CurveElement Subclasses of Autodesk.Revit.DB.ConnectorElement Subclasses of Autodesk.Revit.DB.HostedSweep Autodesk.Revit.DB.Architecture.Room Autodesk.Revit.DB.Mechanical.Space Autodesk.Revit.DB.Area Autodesk.Revit.DB.Architecture.RoomTag Autodesk.Revit.DB.Mechanical.SpaceTag Autodesk.Revit.DB.AreaTag Autodesk.Revit.DB.CombinableElement Autodesk.Revit.DB.Mullion Autodesk.Revit.DB.Panel Autodesk.Revit.DB.AnnotationSymbol Autodesk.Revit.DB.Structure.AreaReinforcementType Autodesk.Revit.DB.Structure.PathReinforcementType Autodesk.Revit.DB.AnnotationSymbolType Autodesk.Revit.DB.Architecture.RoomTagType Autodesk.Revit.DB.Mechanical.SpaceTagType Autodesk.Revit.DB.AreaTagType Autodesk.Revit.DB.Structure.TrussType

