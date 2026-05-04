---
kind: method
id: M:Autodesk.Revit.DB.DirectContext3D.DirectContext3DHandleOverrides.SetDirectContext3DHandleSettings(Autodesk.Revit.DB.Document,Autodesk.Revit.DB.ElementId,Autodesk.Revit.DB.DirectContext3D.DirectContext3DHandleSettings)
source: html/5c4e3445-11c4-c260-930c-8bf8451c21ad.htm
---
# Autodesk.Revit.DB.DirectContext3D.DirectContext3DHandleOverrides.SetDirectContext3DHandleSettings Method

Assigns override settings associated with a DirectContext3D handle instance or type.

## Syntax (C#)
```csharp
public void SetDirectContext3DHandleSettings(
	Document aDoc,
	ElementId elementId,
	DirectContext3DHandleSettings newSettings
)
```

## Parameters
- **aDoc** (`Autodesk.Revit.DB.Document`) - Document where elementId resides.
- **elementId** (`Autodesk.Revit.DB.ElementId`) - Id of the element to be overridden.
- **newSettings** (`Autodesk.Revit.DB.DirectContext3D.DirectContext3DHandleSettings`) - The override settings to be assigned to the handle element.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentException** - The ElementId elementId is not a valid DirectContext3D handle instance or type.
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null

