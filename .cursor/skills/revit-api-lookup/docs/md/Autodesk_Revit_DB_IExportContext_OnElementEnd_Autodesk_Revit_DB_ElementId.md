---
kind: method
id: M:Autodesk.Revit.DB.IExportContext.OnElementEnd(Autodesk.Revit.DB.ElementId)
source: html/14aeeee7-9389-d7fc-5a40-2b7541ce95d1.htm
---
# Autodesk.Revit.DB.IExportContext.OnElementEnd Method

This method marks the end of an element being exported.

## Syntax (C#)
```csharp
void OnElementEnd(
	ElementId elementId
)
```

## Parameters
- **elementId** (`Autodesk.Revit.DB.ElementId`) - The Id of the element that has just been processed.

## Remarks
This method is never called for 2D export (see cref="Autodesk::Revit::DB::IExportContext2D").

