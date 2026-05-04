---
kind: method
id: M:Autodesk.Revit.DB.DirectContext3D.DirectContext3DHandleOverrides.GetDirectContext3DHandleSettings(Autodesk.Revit.DB.Document,Autodesk.Revit.DB.ElementId)
source: html/081f2683-cad8-cd20-8d11-0e188767a479.htm
---
# Autodesk.Revit.DB.DirectContext3D.DirectContext3DHandleOverrides.GetDirectContext3DHandleSettings Method

Gets override settings associated with a DirectContext3D handle instance or type.

## Syntax (C#)
```csharp
public DirectContext3DHandleSettings GetDirectContext3DHandleSettings(
	Document aDoc,
	ElementId elementId
)
```

## Parameters
- **aDoc** (`Autodesk.Revit.DB.Document`) - Document where elementId resides.
- **elementId** (`Autodesk.Revit.DB.ElementId`) - Id of the overridden element.

## Returns
The override settings assigned to the handle element, if present, or a default override settings if nothing was found.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentException** - The ElementId elementId is not a valid DirectContext3D handle instance or type.
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null

