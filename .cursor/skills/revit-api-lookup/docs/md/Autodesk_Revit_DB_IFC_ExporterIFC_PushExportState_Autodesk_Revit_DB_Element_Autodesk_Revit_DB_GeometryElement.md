---
kind: method
id: M:Autodesk.Revit.DB.IFC.ExporterIFC.PushExportState(Autodesk.Revit.DB.Element,Autodesk.Revit.DB.GeometryElement)
source: html/84dee1b6-d008-e039-6f06-6e984920228c.htm
---
# Autodesk.Revit.DB.IFC.ExporterIFC.PushExportState Method

Sets the internal state of the exporter to process the geometry and properties of the input element.

## Syntax (C#)
```csharp
public void PushExportState(
	Element Elem,
	GeometryElement GRep
)
```

## Parameters
- **Elem** (`Autodesk.Revit.DB.Element`) - The element.
- **GRep** (`Autodesk.Revit.DB.GeometryElement`) - The geometry of the element. Optional, can be Nothing nullptr a null reference ( Nothing in Visual Basic) .

## Remarks
The element will be assigned until PopExportState() is called.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null

