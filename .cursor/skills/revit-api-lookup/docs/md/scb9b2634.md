---
kind: method
id: M:Autodesk.Revit.DB.IFC.ExporterIFCUtils.GetDoor2DArcsFromFamily(Autodesk.Revit.DB.Family)
source: html/dde73d45-46a1-4789-7c63-5523ef16a6de.htm
---
# Autodesk.Revit.DB.IFC.ExporterIFCUtils.GetDoor2DArcsFromFamily Method

Gets the arcs associated with the plan view of a door.

## Syntax (C#)
```csharp
public static IList<Arc> GetDoor2DArcsFromFamily(
	Family pFam
)
```

## Parameters
- **pFam** (`Autodesk.Revit.DB.Family`) - The family.

## Returns
The arcs.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null

