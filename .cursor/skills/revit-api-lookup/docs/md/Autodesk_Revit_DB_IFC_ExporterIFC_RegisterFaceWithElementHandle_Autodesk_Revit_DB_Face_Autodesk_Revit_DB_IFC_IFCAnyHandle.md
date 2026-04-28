---
kind: method
id: M:Autodesk.Revit.DB.IFC.ExporterIFC.RegisterFaceWithElementHandle(Autodesk.Revit.DB.Face,Autodesk.Revit.DB.IFC.IFCAnyHandle)
source: html/f002582a-79a1-23b6-4278-2fabcb133444.htm
---
# Autodesk.Revit.DB.IFC.ExporterIFC.RegisterFaceWithElementHandle Method

Register face with element handle to make sure the openings created are related to the right element.

## Syntax (C#)
```csharp
public void RegisterFaceWithElementHandle(
	Face face,
	IFCAnyHandle elemHandle
)
```

## Parameters
- **face** (`Autodesk.Revit.DB.Face`) - The face.
- **elemHandle** (`Autodesk.Revit.DB.IFC.IFCAnyHandle`) - The element handle.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null

